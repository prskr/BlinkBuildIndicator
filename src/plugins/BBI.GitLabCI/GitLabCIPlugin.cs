using System;
using System.Threading.Tasks;
using BBI.Common.Protobuf;
using BBI.Common.Protobuf.Plugin;
using Grpc.Core;

namespace BBI.GitLabCI
{
    public class GitLabCIPlugin : CIPlugin.CIPluginBase
    {

        private readonly Action _shutdownHandle;

        public GitLabCIPlugin(Action shutdownHandle)
        {
            if(_shutdownHandle == null) throw new ArgumentNullException();
            _shutdownHandle = shutdownHandle;
        }

        public override async Task<CIResponse> GetCurrentState(CIRequest request, ServerCallContext context)
        {
            return new CIResponse();
        }

        public override Task<Empty> Shutdown(Empty request, ServerCallContext context)
        {
            _shutdownHandle();
            return Task.FromResult(new Empty());
        }
    }
}