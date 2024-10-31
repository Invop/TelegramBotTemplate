namespace TelegramBotTemplate.Data.Templates.ResponseMessages;

public static class StartCommandResponseTemplate
{
    public static string Message => """
                                      <b><u>Bot menu</u></b>:
                                      /inline_buttons - send inline buttons
                                      /keyboard       - send keyboard buttons
                                      /remove         - remove keyboard buttons
                                      /poll           - send a poll
                                      /throw          - what happens if handler fails
                                  """;
}