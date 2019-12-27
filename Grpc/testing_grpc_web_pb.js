/**
 * @fileoverview gRPC-Web generated client stub for Test
 * @enhanceable
 * @public
 */

// GENERATED CODE -- DO NOT EDIT!



const grpc = {};
grpc.web = require('grpc-web');

const proto = {};
proto.Test = require('./testing_pb.js');

/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?Object} options
 * @constructor
 * @struct
 * @final
 */
proto.Test.TesterClient =
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
proto.Test.TesterPromiseClient =
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
 *   !proto.Test.StringRequest,
 *   !proto.Test.StringReplay>}
 */
const methodDescriptor_Tester_StringTest = new grpc.web.MethodDescriptor(
  '/Test.Tester/StringTest',
  grpc.web.MethodType.UNARY,
  proto.Test.StringRequest,
  proto.Test.StringReplay,
  /**
   * @param {!proto.Test.StringRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.Test.StringReplay.deserializeBinary
);


/**
 * @const
 * @type {!grpc.web.AbstractClientBase.MethodInfo<
 *   !proto.Test.StringRequest,
 *   !proto.Test.StringReplay>}
 */
const methodInfo_Tester_StringTest = new grpc.web.AbstractClientBase.MethodInfo(
  proto.Test.StringReplay,
  /**
   * @param {!proto.Test.StringRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.Test.StringReplay.deserializeBinary
);


/**
 * @param {!proto.Test.StringRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.Error, ?proto.Test.StringReplay)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.Test.StringReplay>|undefined}
 *     The XHR Node Readable Stream
 */
proto.Test.TesterClient.prototype.stringTest =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/Test.Tester/StringTest',
      request,
      metadata || {},
      methodDescriptor_Tester_StringTest,
      callback);
};


/**
 * @param {!proto.Test.StringRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.Test.StringReplay>}
 *     A native promise that resolves to the response
 */
proto.Test.TesterPromiseClient.prototype.stringTest =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/Test.Tester/StringTest',
      request,
      metadata || {},
      methodDescriptor_Tester_StringTest);
};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.Test.IntRequest,
 *   !proto.Test.IntReplay>}
 */
const methodDescriptor_Tester_IntTest = new grpc.web.MethodDescriptor(
  '/Test.Tester/IntTest',
  grpc.web.MethodType.UNARY,
  proto.Test.IntRequest,
  proto.Test.IntReplay,
  /**
   * @param {!proto.Test.IntRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.Test.IntReplay.deserializeBinary
);


/**
 * @const
 * @type {!grpc.web.AbstractClientBase.MethodInfo<
 *   !proto.Test.IntRequest,
 *   !proto.Test.IntReplay>}
 */
const methodInfo_Tester_IntTest = new grpc.web.AbstractClientBase.MethodInfo(
  proto.Test.IntReplay,
  /**
   * @param {!proto.Test.IntRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.Test.IntReplay.deserializeBinary
);


/**
 * @param {!proto.Test.IntRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.Error, ?proto.Test.IntReplay)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.Test.IntReplay>|undefined}
 *     The XHR Node Readable Stream
 */
proto.Test.TesterClient.prototype.intTest =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/Test.Tester/IntTest',
      request,
      metadata || {},
      methodDescriptor_Tester_IntTest,
      callback);
};


/**
 * @param {!proto.Test.IntRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.Test.IntReplay>}
 *     A native promise that resolves to the response
 */
proto.Test.TesterPromiseClient.prototype.intTest =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/Test.Tester/IntTest',
      request,
      metadata || {},
      methodDescriptor_Tester_IntTest);
};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.Test.ByteRequest,
 *   !proto.Test.ByteReplay>}
 */
const methodDescriptor_Tester_ByteTest = new grpc.web.MethodDescriptor(
  '/Test.Tester/ByteTest',
  grpc.web.MethodType.UNARY,
  proto.Test.ByteRequest,
  proto.Test.ByteReplay,
  /**
   * @param {!proto.Test.ByteRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.Test.ByteReplay.deserializeBinary
);


/**
 * @const
 * @type {!grpc.web.AbstractClientBase.MethodInfo<
 *   !proto.Test.ByteRequest,
 *   !proto.Test.ByteReplay>}
 */
const methodInfo_Tester_ByteTest = new grpc.web.AbstractClientBase.MethodInfo(
  proto.Test.ByteReplay,
  /**
   * @param {!proto.Test.ByteRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.Test.ByteReplay.deserializeBinary
);


/**
 * @param {!proto.Test.ByteRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.Error, ?proto.Test.ByteReplay)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.Test.ByteReplay>|undefined}
 *     The XHR Node Readable Stream
 */
proto.Test.TesterClient.prototype.byteTest =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/Test.Tester/ByteTest',
      request,
      metadata || {},
      methodDescriptor_Tester_ByteTest,
      callback);
};


/**
 * @param {!proto.Test.ByteRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.Test.ByteReplay>}
 *     A native promise that resolves to the response
 */
proto.Test.TesterPromiseClient.prototype.byteTest =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/Test.Tester/ByteTest',
      request,
      metadata || {},
      methodDescriptor_Tester_ByteTest);
};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.Test.ByteRequest,
 *   !proto.Test.ByteReplay>}
 */
const methodDescriptor_Tester_BigByteTest = new grpc.web.MethodDescriptor(
  '/Test.Tester/BigByteTest',
  grpc.web.MethodType.UNARY,
  proto.Test.ByteRequest,
  proto.Test.ByteReplay,
  /**
   * @param {!proto.Test.ByteRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.Test.ByteReplay.deserializeBinary
);


/**
 * @const
 * @type {!grpc.web.AbstractClientBase.MethodInfo<
 *   !proto.Test.ByteRequest,
 *   !proto.Test.ByteReplay>}
 */
const methodInfo_Tester_BigByteTest = new grpc.web.AbstractClientBase.MethodInfo(
  proto.Test.ByteReplay,
  /**
   * @param {!proto.Test.ByteRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.Test.ByteReplay.deserializeBinary
);


/**
 * @param {!proto.Test.ByteRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.Error, ?proto.Test.ByteReplay)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.Test.ByteReplay>|undefined}
 *     The XHR Node Readable Stream
 */
proto.Test.TesterClient.prototype.bigByteTest =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/Test.Tester/BigByteTest',
      request,
      metadata || {},
      methodDescriptor_Tester_BigByteTest,
      callback);
};


/**
 * @param {!proto.Test.ByteRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.Test.ByteReplay>}
 *     A native promise that resolves to the response
 */
proto.Test.TesterPromiseClient.prototype.bigByteTest =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/Test.Tester/BigByteTest',
      request,
      metadata || {},
      methodDescriptor_Tester_BigByteTest);
};


module.exports = proto.Test;

