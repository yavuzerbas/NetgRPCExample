using Grpc.Core;
using grpcMessageServer;

namespace grpcServer.Services;

public class MessageService : Message.MessageBase
{
    public override async Task<MessageReply> SendMessage(MessageRequest request, ServerCallContext context)
    {
        System.Console.WriteLine($"name: {request.Name}, message: {request.Message}");
        /*return Task.FromResult(new MessageReply
        {
            Message = $"Welcome {request.Name}. I recevied your message: {request.Message}"
        });*/
        return new MessageReply
        {
            Message = $"Welcome {request.Name}. I recevied your message: {request.Message}"
        };
    }
}