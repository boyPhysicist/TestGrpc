/**
 * @fileoverview gRPC-Web generated client stub for test
 * @enhanceable
 * @public
 */

// GENERATED CODE -- DO NOT EDIT!



const grpc = {};
grpc.web = require('grpc-web');

const proto = {};
proto.test = require('./service_pb.js');

/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?Object} options
 * @constructor
 * @struct
 * @final
 */
proto.test.TestServiceClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options['format'] = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname;

};


/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?Object} options
 * @constructor
 * @struct
 * @final
 */
proto.test.TestServicePromiseClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options['format'] = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname;

};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.test.Request,
 *   !proto.test.Reply>}
 */
const methodDescriptor_TestService_Calculate = new grpc.web.MethodDescriptor(
  '/test.TestService/Calculate',
  grpc.web.MethodType.UNARY,
  proto.test.Request,
  proto.test.Reply,
  /**
   * @param {!proto.test.Request} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.test.Reply.deserializeBinary
);


/**
 * @const
 * @type {!grpc.web.AbstractClientBase.MethodInfo<
 *   !proto.test.Request,
 *   !proto.test.Reply>}
 */
const methodInfo_TestService_Calculate = new grpc.web.AbstractClientBase.MethodInfo(
  proto.test.Reply,
  /**
   * @param {!proto.test.Request} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.test.Reply.deserializeBinary
);


/**
 * @param {!proto.test.Request} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.Error, ?proto.test.Reply)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.test.Reply>|undefined}
 *     The XHR Node Readable Stream
 */
proto.test.TestServiceClient.prototype.calculate =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/test.TestService/Calculate',
      request,
      metadata || {},
      methodDescriptor_TestService_Calculate,
      callback);
};


/**
 * @param {!proto.test.Request} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.test.Reply>}
 *     A native promise that resolves to the response
 */
proto.test.TestServicePromiseClient.prototype.calculate =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/test.TestService/Calculate',
      request,
      metadata || {},
      methodDescriptor_TestService_Calculate);
};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.test.HugeRequest,
 *   !proto.test.Reply>}
 */
const methodDescriptor_TestService_CalculateHuge = new grpc.web.MethodDescriptor(
  '/test.TestService/CalculateHuge',
  grpc.web.MethodType.SERVER_STREAMING,
  proto.test.HugeRequest,
  proto.test.Reply,
  /**
   * @param {!proto.test.HugeRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.test.Reply.deserializeBinary
);


/**
 * @const
 * @type {!grpc.web.AbstractClientBase.MethodInfo<
 *   !proto.test.HugeRequest,
 *   !proto.test.Reply>}
 */
const methodInfo_TestService_CalculateHuge = new grpc.web.AbstractClientBase.MethodInfo(
  proto.test.Reply,
  /**
   * @param {!proto.test.HugeRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.test.Reply.deserializeBinary
);


/**
 * @param {!proto.test.HugeRequest} request The request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @return {!grpc.web.ClientReadableStream<!proto.test.Reply>}
 *     The XHR Node Readable Stream
 */
proto.test.TestServiceClient.prototype.calculateHuge =
    function(request, metadata) {
  return this.client_.serverStreaming(this.hostname_ +
      '/test.TestService/CalculateHuge',
      request,
      metadata || {},
      methodDescriptor_TestService_CalculateHuge);
};


/**
 * @param {!proto.test.HugeRequest} request The request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @return {!grpc.web.ClientReadableStream<!proto.test.Reply>}
 *     The XHR Node Readable Stream
 */
proto.test.TestServicePromiseClient.prototype.calculateHuge =
    function(request, metadata) {
  return this.client_.serverStreaming(this.hostname_ +
      '/test.TestService/CalculateHuge',
      request,
      metadata || {},
      methodDescriptor_TestService_CalculateHuge);
};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.test.Request,
 *   !proto.test.Reply>}
 */
const methodDescriptor_TestService_CalculateApi = new grpc.web.MethodDescriptor(
  '/test.TestService/CalculateApi',
  grpc.web.MethodType.UNARY,
  proto.test.Request,
  proto.test.Reply,
  /**
   * @param {!proto.test.Request} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.test.Reply.deserializeBinary
);


/**
 * @const
 * @type {!grpc.web.AbstractClientBase.MethodInfo<
 *   !proto.test.Request,
 *   !proto.test.Reply>}
 */
const methodInfo_TestService_CalculateApi = new grpc.web.AbstractClientBase.MethodInfo(
  proto.test.Reply,
  /**
   * @param {!proto.test.Request} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.test.Reply.deserializeBinary
);


/**
 * @param {!proto.test.Request} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.Error, ?proto.test.Reply)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.test.Reply>|undefined}
 *     The XHR Node Readable Stream
 */
proto.test.TestServiceClient.prototype.calculateApi =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/test.TestService/CalculateApi',
      request,
      metadata || {},
      methodDescriptor_TestService_CalculateApi,
      callback);
};


/**
 * @param {!proto.test.Request} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.test.Reply>}
 *     A native promise that resolves to the response
 */
proto.test.TestServicePromiseClient.prototype.calculateApi =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/test.TestService/CalculateApi',
      request,
      metadata || {},
      methodDescriptor_TestService_CalculateApi);
};


module.exports = proto.test;

