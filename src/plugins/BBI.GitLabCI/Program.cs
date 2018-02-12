using System;
using System.Threading.Tasks;
using BBI.Common.Protobuf;
using BBI.Common.Protobuf.PluginHost;
using CommandLine;
using Grpc.Core;
using static BBI.Common.BBIConstants;

namespace BBI.GitLabCI
{
    /// <summary>
    ///     Entrypoint of the plugin
    /// </summary>
    public static class Program
    {
        
        /// <summary>
        /// Entrypoint method of the plugin
        /// </summary>
        /// <param name="args">
        ///     CLI args
        /// </param>
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<PluginCliOptions>(args)
                .WithParsed(opts => StartServer(opts).Wait())
                .WithNotParsed(errs =>
                {
                    Console.Out.WriteLine("The following errors occured while parsing arguments:");
                    foreach (var error in errs)
                    {
                        Console.Out.WriteLine($"Stops execution: {error.StopsProcessing} - {error.Tag}");
                    }
                    Environment.Exit(1);
                });
        }

        private static async Task StartServer(PluginCliOptions options)
        {
            var pluginServer = new PluginServer(options);
            pluginServer.Start();
            var channel = new Channel(PLUGIN_HOST_IP, PLUGIN_HOST_PORT, ChannelCredentials.Insecure);
            var pluginHostClient = new CIPluginHost.CIPluginHostClient(channel);
            var registrationReply = await pluginHostClient.RegisterAsync(new PluginRegistration
            {
                PluginName = options.PluginName,
                PluginPort = options.LaunchPort
            });
            if (registrationReply.RegistrationCode != PluginRegistrationReply.Types.PluginRegistrationCode.Success)
            {
                await pluginServer.ShutdownAsync();
            }
            pluginServer.ExitHandle.WaitOne();
            await pluginServer.ShutdownAsync();
        }
    }
}