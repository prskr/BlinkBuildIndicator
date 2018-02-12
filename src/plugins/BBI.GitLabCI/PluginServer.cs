using System.Threading;
using System.Threading.Tasks;
using BBI.Common.Protobuf.Plugin;
using Grpc.Core;

namespace BBI.GitLabCI
{
    /// <summary>
    ///     Wrapper to handle start and shutdown of the plugin
    ///     Contains EventWaitHandle to block main thread without busy waiting until the plugin gets a shutdown request from the supervisor
    /// </summary>
    public class PluginServer
    {
        private readonly Server _grpcServer;

        /// <summary>
        ///     Default constructor
        /// </summary>
        /// <param name="options">
        ///     Options parsed from CLI args to determine IP/host and port to bind
        /// </param>
        public PluginServer(PluginCliOptions options)
        {
            ExitHandle = new AutoResetEvent(false);
            _grpcServer = new Server
            {
                Services = {CIPlugin.BindService(new GitLabCIPlugin(() => ExitHandle.Set()))},
                Ports = {new ServerPort(options.LaunchIp, options.LaunchPort, ServerCredentials.Insecure)}
            };
        }

        /// <summary>
        ///     Handle to block main thread
        ///     Event will be set when the supervisor sends the shutdown signal
        /// </summary>
        public EventWaitHandle ExitHandle { get; }

        /// <summary>
        ///     Start the gRPC server
        /// </summary>
        public void Start()
        {
            _grpcServer.Start();
        }

        /// <summary>
        ///     Shutdown the gRPC server
        /// </summary>
        /// <returns></returns>
        public async Task ShutdownAsync()
        {
            await _grpcServer.ShutdownAsync();
        }
    }
}