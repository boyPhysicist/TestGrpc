// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: service.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Test {
  public static partial class TestService
  {
    static readonly string __ServiceName = "test.TestService";

    static readonly grpc::Marshaller<global::Test.Request> __Marshaller_test_Request = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Test.Request.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Test.Reply> __Marshaller_test_Reply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Test.Reply.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Test.HugeRequest> __Marshaller_test_HugeRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Test.HugeRequest.Parser.ParseFrom);

    static readonly grpc::Method<global::Test.Request, global::Test.Reply> __Method_Calculate = new grpc::Method<global::Test.Request, global::Test.Reply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Calculate",
        __Marshaller_test_Request,
        __Marshaller_test_Reply);

    static readonly grpc::Method<global::Test.HugeRequest, global::Test.Reply> __Method_CalculateHuge = new grpc::Method<global::Test.HugeRequest, global::Test.Reply>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "CalculateHuge",
        __Marshaller_test_HugeRequest,
        __Marshaller_test_Reply);

    static readonly grpc::Method<global::Test.Request, global::Test.Reply> __Method_CalculateApi = new grpc::Method<global::Test.Request, global::Test.Reply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CalculateApi",
        __Marshaller_test_Request,
        __Marshaller_test_Reply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Test.ServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of TestService</summary>
    [grpc::BindServiceMethod(typeof(TestService), "BindService")]
    public abstract partial class TestServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Test.Reply> Calculate(global::Test.Request request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task CalculateHuge(global::Test.HugeRequest request, grpc::IServerStreamWriter<global::Test.Reply> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Test.Reply> CalculateApi(global::Test.Request request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for TestService</summary>
    public partial class TestServiceClient : grpc::ClientBase<TestServiceClient>
    {
      /// <summary>Creates a new client for TestService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public TestServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for TestService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public TestServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected TestServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected TestServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Test.Reply Calculate(global::Test.Request request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Calculate(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Test.Reply Calculate(global::Test.Request request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Calculate, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Test.Reply> CalculateAsync(global::Test.Request request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CalculateAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Test.Reply> CalculateAsync(global::Test.Request request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Calculate, null, options, request);
      }
      public virtual grpc::AsyncServerStreamingCall<global::Test.Reply> CalculateHuge(global::Test.HugeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CalculateHuge(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::Test.Reply> CalculateHuge(global::Test.HugeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_CalculateHuge, null, options, request);
      }
      public virtual global::Test.Reply CalculateApi(global::Test.Request request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CalculateApi(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Test.Reply CalculateApi(global::Test.Request request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CalculateApi, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Test.Reply> CalculateApiAsync(global::Test.Request request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CalculateApiAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Test.Reply> CalculateApiAsync(global::Test.Request request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CalculateApi, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override TestServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new TestServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(TestServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Calculate, serviceImpl.Calculate)
          .AddMethod(__Method_CalculateHuge, serviceImpl.CalculateHuge)
          .AddMethod(__Method_CalculateApi, serviceImpl.CalculateApi).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, TestServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Calculate, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Test.Request, global::Test.Reply>(serviceImpl.Calculate));
      serviceBinder.AddMethod(__Method_CalculateHuge, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::Test.HugeRequest, global::Test.Reply>(serviceImpl.CalculateHuge));
      serviceBinder.AddMethod(__Method_CalculateApi, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Test.Request, global::Test.Reply>(serviceImpl.CalculateApi));
    }

  }
}
#endregion
