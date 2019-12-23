const {Request, Reply, HugeRequest} = require('./service_pb.js');
const {TestServiceClient} = require('./service_grpc_web_pb.js');

var client = new TestServiceClient('http://localhost:1234');

var request = new Request();
request.setMessage(1);

client.calculate(request, {}, (err, response) => {
  console.log(response.getMessage());
});