using System;
using System.Threading.Tasks;
using BBI.Common.Protobuf;
using BBI.Common.Protobuf.Plugin;
using Grpc.Core;

namespace BBI.GitLabCI
{
    /// <summary>
    ///     Implementation of the CIPluginBase
    ///     Overrides empty base methods to add required logic to the API
    /// </summary>
    public class GitLabCIPlugin : CIPlugin.CIPluginBase
    {

        private readonly Action _shutdownHandle;

        /// <summary>
        ///     Default constructor
        /// </summary>
        /// <param name="shutdownHandle">
        ///     Handle which gets executed when the shutdown signal gets received
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     If shutdownHandle is null
        /// </exception>
        public GitLabCIPlugin(Action shutdownHandle)
        {
            _shutdownHandle = shutdownHandle ?? throw new ArgumentNullException();
        }

        /// <summary>
        ///     Get current state of a GitLab CI pipeline
        /// </summary>
        /// <param name="request">Request sent by the supervisor</param>
        /// <param name="context">Request context</param>
        /// <returns></returns>
        public override async Task<CIResponse> GetCurrentState(CIRequest request, ServerCallContext context)
        {
            return new CIResponse();
        }

        /// <summary>
        ///     Shutdown handler
        /// </summary>
        /// <param name="request">Request sent by the supervisor</param>
        /// <param name="context">Request context</param>
        /// <returns></returns>
        public override Task<Empty> Shutdown(Empty request, ServerCallContext context)
        {
            _shutdownHandle();
            return Task.FromResult(new Empty());
        }
    }
}