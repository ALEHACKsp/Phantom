using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Phantom.Settings;

namespace Phantom.DiscordBot
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;

        public CommandHandler(DiscordSocketClient Client)
        {
            _client = Client;
            _commands = new CommandService();
            _client.MessageReceived += MessageReceivedAsync;
        }

        public async Task Install() =>
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);

        public async Task MessageReceivedAsync(SocketMessage rawMessage)
        {
            var msg = rawMessage as SocketUserMessage;
            if (msg == null) return;
            if (msg.Author.Id == _client.CurrentUser.Id || !Configuration.GetConfig().DiscordModerators.Contains(msg.Author.Id)) return;

            var context = new SocketCommandContext(_client, msg);

            int argPos = 0;
            if (msg.HasStringPrefix(Configuration.GetConfig().Prefix, ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, null);

                if (!result.IsSuccess)
                    await context.Channel.SendMessageAsync($"Something went wrong while executing that command. Details: `{result.ErrorReason}`");
            }
        }
    }
}