using Telegram.Bot.Types;
using TelegramBotTemplate.Configuration;

namespace TelegramBotTemplate.Services.Messaging;

public class MessageProcessor
{
    private readonly IMessageHandler _messageHandler;

    public MessageProcessor(IMessageHandler messageHandler)
    {
        _messageHandler = messageHandler;
    }

    public async Task<Message> ProcessMessageAsync(string messageText, Message msg)
    {
        var command = messageText.Split(' ')[0];
        return await (command switch
        {
            Commands.InlineButtons => _messageHandler.SendInlineKeyboard(msg),
            Commands.Keyboard => _messageHandler.SendReplyKeyboard(msg),
            Commands.Remove => _messageHandler.RemoveKeyboard(msg),
            Commands.Poll => _messageHandler.SendPoll(msg),
            Commands.Throw => _messageHandler.FailingHandler(msg),
            Commands.Start => _messageHandler.Start(msg),
            _ => Task.FromResult(msg)
        });
    }
}