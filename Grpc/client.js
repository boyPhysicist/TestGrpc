import { ByteReplay, IntReply, StringReplay, ByteRequest, IntRequest, StringRequest } from './testing_pb.js';
import { TesterClient } from './testing_grpc_web_pb.js';

var client = new TesterClient('http://localhost:1234');

var intRequest = new IntRequest();
var byteRequest = new ByteRequest();
var stringRequest = new StringRequest();


perf(byteBench, 'byteBench');


async function perf(func, name) {

  let result = 0;

  for (let index = 0; index < 10; index++) {
    var start = window.performance.now();

    await func();
    var end = window.performance.now();
    var time = end - start;
    console.log(time + name);
    result += time;
  }

  console.log(result + ' result ' + result / 10000 + ' one request' + name);
  return result;

}

async function intBench() {
  for (let index = 0; index < 1000; index++) {
    var promise = new Promise(function (resolve) {
      client.intTest(intRequest, {}, (err, response) => { resolve('') });
    })
  }
  await promise;
}

async function byteBench() {
  for (let index = 0; index < 10; index++) {
    var promise = new Promise(function (resolve) {
      client.byteTest(byteRequest, {}, (err, response) => { resolve('') });
    })
  }

  await promise;
}

async function stringBench() {
  for (let index = 0; index < 1000; index++) {
    var promise = new Promise(function (resolve) {
      client.stringTest(stringRequest, {}, (err, response) => { resolve('') });
    })
  }

  await promise;
}