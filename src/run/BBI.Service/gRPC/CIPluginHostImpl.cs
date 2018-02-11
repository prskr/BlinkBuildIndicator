using System.Threading.Tasks;
using BBI.Common.Protobuf;
using BBI.Common.Protobuf.PluginHost;
using Grpc.Core;

namespace BBI.Service.gRPC
{
    public class CIPluginHostImpl : CIPluginHost.CIPluginHostBase
    {
        public override async Task<PluginRegistrationReply> Register(PluginRegistration request, ServerCallContext context)
        {
            return new PluginRegistrationReply();
        }
    }
}