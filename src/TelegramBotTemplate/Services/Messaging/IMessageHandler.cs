using Telegram.Bot.Types;

namespace TelegramBotTemplate.Services.Messaging;

public interface IMessageHandler
{
    Task<Message> SendInlineKeyboard(Message msg);
    Task<Message> SendReplyKeyboard(Message msg);
    Task<Message> RemoveKeyboard(Message msg);
    Task<Message> SendPoll(Message msg);
    Task<Message> FailingHandler(Message msg);
    Task<Message> Start(Message msg);
}