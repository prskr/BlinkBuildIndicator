// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: CIPlugin.proto
// </auto-generated>
#pragma warning disable 1591
#region Designer generated code

using System;
using System.Threading;
using System.Threading.Tasks;
using grpc = global::Grpc.Core;

namespace BBI.Common.Protobuf.Plugin {
  public static partial class CIPlugin
  {
    static readonly string __ServiceName = "BBI.Protobuf.Hosts.CIPlugin";

    static readonly grpc::Marshaller<global::BBI.Common.Protobuf.CIRequest> __Marshaller_CIRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::BBI.Common.Protobuf.CIRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::BBI.Common.Protobuf.CIResponse> __Marshaller_CIResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::BBI.Common.Protobuf.CIResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::BBI.Common.Protobuf.Empty> __Marshaller_Empty = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::BBI.Common.Protobuf.Empty.Parser.ParseFrom);

    static readonly grpc::Method<global::BBI.Common.Protobuf.CIRequest, global::BBI.Common.Protobuf.CIResponse> __Method_GetCurrentState = new grpc::Method<global::BBI.Common.Protobuf.CIRequest, global::BBI.Common.Protobuf.CIResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetCurrentState",
        __Marshaller_CIRequest,
        __Marshaller_CIResponse);

    static readonly grpc::Method<global::BBI.Common.Protobuf.Empty, global::BBI.Common.Protobuf.Empty> __Method_Shutdown = new grpc::Method<global::BBI.Common.Protobuf.Empty, global::BBI.Common.Protobuf.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Shutdown",
        __Marshaller_Empty,
        __Marshaller_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::BBI.Common.Protobuf.Plugin.CIPluginReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of CIPlugin</summary>
    public abstract partial class CIPluginBase
    {
      public virtual global::System.Threading.Tasks.Task<global::BBI.Common.Protobuf.CIResponse> GetCurrentState(global::BBI.Common.Protobuf.CIRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::BBI.Common.Protobuf.Empty> Shutdown(global::BBI.Common.Protobuf.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for CIPlugin</summary>
    public partial class CIPluginClient : grpc::ClientBase<CIPluginClient>
    {
      /// <summary>Creates a new client for CIPlugin</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public CIPluginClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for CIPlugin that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public CIPluginClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected CIPluginClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected CIPluginClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::BBI.Common.Protobuf.CIResponse GetCurrentState(global::BBI.Common.Protobuf.CIRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return GetCurrentState(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::BBI.Common.Protobuf.CIResponse GetCurrentState(global::BBI.Common.Protobuf.CIRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetCurrentState, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::BBI.Common.Protobuf.CIResponse> GetCurrentStateAsync(global::BBI.Common.Protobuf.CIRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return GetCurrentStateAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::BBI.Common.Protobuf.CIResponse> GetCurrentStateAsync(global::BBI.Common.Protobuf.CIRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetCurrentState, null, options, request);
      }
      public virtual global::BBI.Common.Protobuf.Empty Shutdown(global::BBI.Common.Protobuf.Empty request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return Shutdown(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::BBI.Common.Protobuf.Empty Shutdown(global::BBI.Common.Protobuf.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Shutdown, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::BBI.Common.Protobuf.Empty> ShutdownAsync(global::BBI.Common.Protobuf.Empty request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return ShutdownAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::BBI.Common.Protobuf.Empty> ShutdownAsync(global::BBI.Common.Protobuf.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Shutdown, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override CIPluginClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new CIPluginClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(CIPluginBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetCurrentState, serviceImpl.GetCurrentState)
          .AddMethod(__Method_Shutdown, serviceImpl.Shutdown).Build();
    }

  }
}
#endregion