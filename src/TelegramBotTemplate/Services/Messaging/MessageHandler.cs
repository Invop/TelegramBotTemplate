using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotTemplate.Configuration;
using TelegramBotTemplate.Data.Templates;
using TelegramBotTemplate.Data.Templates.Keyboard;
using TelegramBotTemplate.Data.Templates.ResponseMessages;

namespace TelegramBotTemplate.Services.Messaging;

public class MessageHandler(ITelegramBotClient bot, ILogger<UpdateHandler> logger) : IMessageHandler
{
    private static readonly InputPollOption[] PollOptions = ["Hello", "World!"];

    public async Task<Message> SendInlineKeyboard(Message msg)
    {
        var markupGenerator = new KeyboardMarkupGenerator();
        InlineKeyboardMarkup inlineKeyboard = markupGenerator.GenerateInlineKeyboard();
        return await bot.SendTextMessageAsync(msg.Chat, "Inline buttons:", replyMarkup: inlineKeyboard);
    }

    public async Task<Message> SendReplyKeyboard(Message msg)
    {
        var markupGenerator = new KeyboardMarkupGenerator();
        ReplyKeyboardMarkup replyKeyboard = markupGenerator.GenerateReplyKeyboard();
        return await bot.SendTextMessageAsync(msg.Chat, "Keyboard buttons:", replyMarkup: replyKeyboard);
    }

    public async Task<Message> RemoveKeyboard(Message msg)
    {
        return await bot.SendTextMessageAsync(msg.Chat, "Removing keyboard", replyMarkup: new ReplyKeyboardRemove());
    }

    public async Task<Message> SendPoll(Message msg)
    {
        return await bot.SendPollAsync(msg.Chat, "Question", PollOptions, isAnonymous: false);
    }
    
    public async Task<Message> FailingHandler(Message msg)
    {
        throw new NotImplementedException("FailingHandler");
    }
    public async Task<Message> Start(Message msg)
    {
        return await bot
            .SendTextMessageAsync(
                msg.Chat, StartCommandResponseTemplate.Message, 
                parseMode: ParseMode.Html, 
                replyMarkup: new ReplyKeyboardRemove());
    }
}