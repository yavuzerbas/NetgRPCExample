using Grpc.Net.Client;
using grpcMessageClient;

var channel = GrpcChannel.ForAddress("http://localhost:5187");
//var greetClient = new Greeter.GreeterClient(channel);
var messageClient = new Message.MessageClient(channel);

var response = messageClient.SendMessage(new MessageRequest
{
    Message = "",
    Name = "Test user",
});

var cancellationTokenSource = new CancellationTokenSource();
while (await response.ResponseStream.MoveNext(cancellationTokenSource.Token))
{
    System.Console.WriteLine(response.ResponseStream.Current.Message);

}

