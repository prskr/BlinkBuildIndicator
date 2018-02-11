using System.Threading;
using System.Threading.Tasks;
using BBI.Common.Protobuf.Plugin;
using Grpc.Core;

namespace BBI.GitLabCI
{
    public class PluginServer
    {
        private readonly Server _grpcServer;

        public PluginServer(PluginCliOptions options)
        {
            ExitHandle = new AutoResetEvent(false);
            _grpcServer = new Server
            {
                Services = { CIPlugin.BindService(new GitLabCIPlugin(() => ExitHandle.Set()))},
                Ports = { new ServerPort(options.LaunchIp, options.LaunchPort, ServerCredentials.Insecure)}
            };
        }
        
        public EventWaitHandle ExitHandle { get; }

        public void Start()
        {
            _grpcServer.Start();
        }

        public async Task ShutdownAsync()
        {
            await _grpcServer.ShutdownAsync();
        }
    }
}