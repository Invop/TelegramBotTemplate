using Microsoft.Extensions.Options;
using Telegram.Bot;
using TelegramBotTemplate;
using TelegramBotTemplate.Abstract;
using TelegramBotTemplate.Configuration;
using TelegramBotTemplate.Services;
using TelegramBotTemplate.Services.Messaging;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSystemd();
var configuration = builder.Configuration;

builder.Services.Configure<BotConfiguration>(configuration.GetSection("BotConfiguration"));

builder.Services.AddHttpClient("telegram_bot_client").AddTypedClient<ITelegramBotClient>(
    (httpClient, serviceProvider) =>
    {
        BotConfiguration? botConfiguration = serviceProvider.GetService<IOptions<BotConfiguration>>()?.Value;
        ArgumentNullException.ThrowIfNull(botConfiguration);
        TelegramBotClientOptions options = new(botConfiguration.BotToken);
        return new TelegramBotClient(options, httpClient);
    });
builder.Services.AddScoped<IMessageHandler, MessageHandler>();
builder.Services.AddScoped<MessageProcessor>();

builder.Services.AddScoped<UpdateHandler>();
builder.Services.AddScoped<ReceiverService>();
builder.Services.AddHostedService<PollingService>();
var host = builder.Build();
host.Run();