using Grpc.Net.Client;
using grpcClient;
/*using grpcClient;

var channel = GrpcChannel.ForAddress("http://localhost:5187");
var greetClient = new Greeter.GreeterClient(channel);    

HelloReply helloReply = await greetClient.SayHelloAsync(new HelloRequest{
    Name = "Test greeting"
});

System.Console.WriteLine(helloReply.Message);
*/

var channel = GrpcChannel.ForAddress("http://localhost:5187");
var greetClient = new Greeter.GreeterClient(channel);

HelloReply result = await greetClient.SayHelloAsync(new HelloRequest{
    Name = "Test user"
});

System.Console.WriteLine(result.Message);