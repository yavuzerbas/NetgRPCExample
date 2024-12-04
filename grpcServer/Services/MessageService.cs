using Grpc.Core;
using grpcMessageServer;

namespace grpcServer.Services;

public class MessageService : Message.MessageBase
{
    /*public override async Task<MessageReply> SendMessage(MessageRequest request, ServerCallContext context)
    {
        System.Console.WriteLine($"name: {request.Name}, message: {request.Message}");
        return new MessageReply
        {
            Message = $"Welcome {request.Name}. I recevied your message: {request.Message}"
        };
    }*/

    public override async Task SendMessage(MessageRequest request, IServerStreamWriter<MessageReply> responseStream, ServerCallContext context)
    {
        System.Console.WriteLine($"Message: {request.Message} | Name: {request.Name}");

        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(500);
            await responseStream.WriteAsync(new MessageReply
            {
                Message = $"({i}.)Hello {request.Name}, your message {request.Message}"
            });
        }
    }

}