using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using BBI.Common;
using BBI.Common.Exceptions;
using BBI.Common.Protobuf;
using BBI.Common.Protobuf.Plugin;
using BBI.Common.Protobuf.PluginHost;
using Grpc.Core;

namespace BBI.CIPluginTests.Common
{
    public class CIPluginTestHost : CIPluginHost.CIPluginHostBase
    {
        private static readonly PluginRegistrationReply ConflictingPort = new PluginRegistrationReply{RegistrationCode = PluginRegistrationReply.Types.PluginRegistrationCode.ConflictingPort};
        private static readonly PluginRegistrationReply ConflictingName = new PluginRegistrationReply{RegistrationCode = PluginRegistrationReply.Types.PluginRegistrationCode.ConflictingName};
        private static readonly PluginRegistrationReply UnknownError = new PluginRegistrationReply{RegistrationCode = PluginRegistrationReply.Types.PluginRegistrationCode.UnknownError};
        private static readonly PluginRegistrationReply Success = new PluginRegistrationReply{RegistrationCode = PluginRegistrationReply.Types.PluginRegistrationCode.Success};
        
        private readonly ConcurrentDictionary<string, int> _plugins;

        public CIPluginTestHost()
        {
            _plugins = new ConcurrentDictionary<string, int>();
        }

        public override Task<PluginRegistrationReply> Register(PluginRegistration request, ServerCallContext context)
        {
            try
            {
                if (_plugins.ContainsKey(request.PluginName)) return Task.FromResult(ConflictingName);
                if (_plugins.Values.Any(p => p == request.PluginPort)) return Task.FromResult(ConflictingPort);
                if (!_plugins.TryAdd(request.PluginName, request.PluginPort)) return Task.FromResult(UnknownError);
                return Task.FromResult(Success);
            }
            catch (Exception)
            {
                return Task.FromResult(UnknownError);
            }
        }

        public async Task<CIResponse> ContactPlugin(string pluginName)
        {
            if (!_plugins.ContainsKey(pluginName))
            {
                throw new PluginNotRegisteredException($"Plugin {pluginName} is not registered");
            }
            var channel = new Channel(BBIConstants.PLUGIN_HOST_IP, _plugins[pluginName], ChannelCredentials.Insecure);
            var pluginClient = new CIPlugin.CIPluginClient(channel);

            var ciResponse = await pluginClient.GetCurrentStateAsync(new CIRequest());

            await channel.ShutdownAsync();

            return ciResponse;
        }
    }
}