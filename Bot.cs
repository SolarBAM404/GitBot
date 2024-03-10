using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Hosting;

namespace GitBot;

public class Bot : IHostedService
{

    private static DiscordSocketClient _client;


    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _client = new DiscordSocketClient();

        _client.Log += LogAsync;

        // Get Token from secrets
        var token = Environment.GetEnvironmentVariable("");

        // Start the bot
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        // Block the program until it is closed
        await Task.Delay(-1, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private static Task LogAsync(LogMessage arg)
    {
        Console.WriteLine(arg);
        return Task.CompletedTask;
    }
}