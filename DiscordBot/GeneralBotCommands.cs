using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Phantom.Settings;
using Phantom.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phantom.DiscordBot
{
    public class GeneralBotCommands : ModuleBase
    {
        [Command("statistics")]
        public async Task Stats()
        {
            EmbedBuilder builder = new EmbedBuilder();
            builder.WithTitle("Phantom Bot Controller");
            builder.WithAuthor($"{Context.User.Username}#{Context.User.DiscriminatorValue}", Context.User.GetAvatarUrl(), "https://exploiting-discord-for.fun");
            builder.WithColor(Color.Blue);
            builder.WithTimestamp(DateTime.UtcNow);
            builder.WithDescription($"Hello, {Context.User.Username}!\nYou have requested for phantom's statistics.\nYour action has been recorded for quality assurance and testing.");
            builder.WithThumbnailUrl("https://i.imgur.com/u5cY4xZ.jpg");
            builder.WithImageUrl("https://i.imgur.com/igRkLFI.png");
            builder.AddField("👍 Photon Master Server Ping: ", $"{GeneralUtils.Clients[0].LoadBalancingPeer.RoundTripTime}ms");
            builder.AddField("😋 Discord Bot Ping: ", $"{(Context.Client as DiscordSocketClient).Latency}ms");
            builder.AddField("👀 Bot(s): ", GeneralUtils.Clients.Count());
            builder.AddField("👻 Status: ", GeneralUtils.BotStatus);
            builder.AddField("😎 Connected To Region: ", "USW");
            builder.AddField("🎉 Current Release Server: ", ClientUtils.GetCurrentReleaseServer());
            builder.AddField("😐 Current Room Name: ", GeneralUtils.CurrentRoomName);
            builder.AddField("🤟 Current Room ID: ", GeneralUtils.CurrentRoomName);
            builder.WithFooter("Phantom, a very good private photon bot controller. Developed by the Phantom Team (Luni, Yaekith).", "https://i.imgur.com/u5cY4xZ.jpg");
            await Context.Channel.SendMessageAsync(null, false, builder.Build());
        }
        [Command("room")]
        public async Task RoomInfo()
        {
            EmbedBuilder builder = new EmbedBuilder();
            if (GeneralUtils.CurrentRoom == "None")
            {
                builder.WithTitle("Phantom Bot Controller");
                builder.WithAuthor($"{Context.User.Username}#{Context.User.DiscriminatorValue}", Context.User.GetAvatarUrl(), "https://exploiting-discord-for.fun");
                builder.WithColor(Color.Blue);
                builder.WithTimestamp(DateTime.UtcNow);
                builder.WithDescription($"The bots haven't joined a room yet! Command them to do so before trying this command again.");
                builder.WithThumbnailUrl("https://i.imgur.com/u5cY4xZ.jpg");
                builder.WithImageUrl("https://i.imgur.com/igRkLFI.png");
            }
            else
            {
                builder.WithTitle("Phantom Bot Controller");
                builder.WithAuthor($"{Context.User.Username}#{Context.User.DiscriminatorValue}", Context.User.GetAvatarUrl(), "https://exploiting-discord-for.fun");
                builder.WithColor(Color.Blue);
                builder.WithTimestamp(DateTime.UtcNow);
                builder.WithDescription($"Hello, {Context.User.Username}!\nYou have requested for phantom's current room info.\nYour action has been recorded for quality assurance and testing.");
                builder.WithThumbnailUrl("https://i.imgur.com/u5cY4xZ.jpg");
                builder.WithImageUrl("https://i.imgur.com/igRkLFI.png");
                builder.AddField("🤖 Room Name: ", $"`{GeneralUtils.CurrentRoomName}`");
                builder.AddField("😋 Player Count: ", GeneralUtils.Clients[0].CurrentRoom.PlayerCount);
                builder.AddField("👀 Master: ", GeneralUtils.Clients[0].GetPlayer(GeneralUtils.Clients[0].CurrentRoom.MasterClientId).AsVRChatPlayer().DisplayName);
                builder.AddField("😐 Room ID: ", $"`{GeneralUtils.CurrentRoom}`");
                builder.WithFooter("Phantom, a very good private photon bot controller. Developed by the Phantom Team (Luni, Yaekith).", "https://i.imgur.com/u5cY4xZ.jpg");
            }
            
            await Context.Channel.SendMessageAsync(null, false, builder.Build());
        }
        [Command("join")]
        public async Task Join(string roomID)
        {
            EmbedBuilder builder = new EmbedBuilder();
            builder.WithTitle("Phantom Bot Controller");
            builder.WithAuthor($"{Context.User.Username}#{Context.User.DiscriminatorValue}", Context.User.GetAvatarUrl(), "https://exploiting-discord-for.fun");
            builder.WithColor(Color.Blue);
            builder.WithTimestamp(DateTime.UtcNow);
            builder.WithDescription($"Hello, {Context.User.Username}!\nYou have requested for all bots to join Room: `{roomID}`\nYour action has been recorded for quality assurance and testing.");
            builder.WithThumbnailUrl("https://i.imgur.com/u5cY4xZ.jpg");
            builder.WithImageUrl("https://i.imgur.com/igRkLFI.png");
            builder.AddField("👀 Command Execution Status: ", "Joining Room.");
            var msg = await Context.Channel.SendMessageAsync(null, false, builder.Build());
            GeneralUtils.JoinRoom(roomID);
            await Task.Delay(2000);
            builder.Fields.First().Value = "👍 Joined Room.";
            builder.AddField("👀 Command Execution Status: ", "👍 Joined Room.");
            await msg.ModifyAsync(x => x.Embed = builder.Build());
        }
        [Command("joincurrentroom")]
        public async Task JoinCurrentRoom()
        {
            EmbedBuilder builder = new EmbedBuilder();
            builder.WithTitle("Phantom Bot Controller");
            builder.WithAuthor($"{Context.User.Username}#{Context.User.DiscriminatorValue}", Context.User.GetAvatarUrl(), "https://exploiting-discord-for.fun");
            builder.WithColor(Color.Blue);
            builder.WithTimestamp(DateTime.UtcNow);
            builder.WithDescription($"Hello, {Context.User.Username}!\nYou have requested for all bots to join the hoster's current room.\nYour action has been recorded for quality assurance and testing.");
            builder.WithThumbnailUrl("https://i.imgur.com/u5cY4xZ.jpg");
            builder.WithImageUrl("https://i.imgur.com/igRkLFI.png");
            builder.AddField("👀 Command Execution Status: ", "Joining Room.");
            var msg = await Context.Channel.SendMessageAsync(null, false, builder.Build());
            GeneralUtils.JoinRoom(ClientUtils.GetCurrentRoom());
            await Task.Delay(2000);
            builder.Fields.First().Value = "👍 Joined Room.";
            await msg.ModifyAsync(x => x.Embed = builder.Build());
        }
        [Command("instantiate")]
        public async Task Instantiate()
        {
            EmbedBuilder builder = new EmbedBuilder();
            builder.WithTitle("Phantom Bot Controller");
            builder.WithAuthor($"{Context.User.Username}#{Context.User.DiscriminatorValue}", Context.User.GetAvatarUrl(), "https://exploiting-discord-for.fun");
            builder.WithColor(Color.Blue);
            builder.WithTimestamp(DateTime.UtcNow);
            builder.WithDescription($"Hello, {Context.User.Username}!\nYou have requested for all bots to instantiate in the current room.\nYour action has been recorded for quality assurance and testing.");
            builder.WithThumbnailUrl("https://i.imgur.com/u5cY4xZ.jpg");
            builder.WithImageUrl("https://i.imgur.com/igRkLFI.png");
            builder.AddField("👀 Command Execution Status: ", "Instantiating...");
            var msg = await Context.Channel.SendMessageAsync(null, false, builder.Build());
            GeneralUtils.InstantiateAll();
            await Task.Delay(2000);
            builder.Fields.First().Value = "👍 Instantiated.";
            await msg.ModifyAsync(x => x.Embed = builder.Build());
        }
        [Command("leave")]
        public async Task LeaveCurrentRoom()
        {
            EmbedBuilder builder = new EmbedBuilder();
            builder.WithTitle("Phantom Bot Controller");
            builder.WithAuthor($"{Context.User.Username}#{Context.User.DiscriminatorValue}", Context.User.GetAvatarUrl(), "https://exploiting-discord-for.fun");
            builder.WithColor(Color.Blue);
            builder.WithTimestamp(DateTime.UtcNow);
            builder.WithDescription($"Hello, {Context.User.Username}!\nYou have requested for all bots to leave their current room.\nYour action has been recorded for quality assurance and testing.");
            builder.WithThumbnailUrl("https://i.imgur.com/u5cY4xZ.jpg");
            builder.WithImageUrl("https://i.imgur.com/igRkLFI.png");
            builder.AddField("👀 Command Execution Status: ", "Leaving Room.");
            var msg = await Context.Channel.SendMessageAsync(null, false, builder.Build());
            GeneralUtils.LeaveRoom();
            await Task.Delay(3000);
            builder.Fields.First().Value = "👍 Left Room.";
            await msg.ModifyAsync(x => x.Embed = builder.Build());
        }
        [Command("help")]
        [Alias("cmds")]
        public async Task Help()
        {
            string discordmoderators = string.Empty;
            string ingamemoderators = string.Empty;
            foreach(var mod in Configuration.GetConfig().DiscordModerators)
            {
                var user = await Context.Client.GetUserAsync(mod);
                discordmoderators += $"{user.Username}#{user.Discriminator} ({user.Id})\n";
            }

            foreach (var gamemod in Configuration.GetConfig().InGameModerators)
                ingamemoderators += gamemod + "\n";

            EmbedBuilder builder = new EmbedBuilder();
            builder.WithTitle("Phantom Bot Controller");
            builder.WithAuthor($"{Context.User.Username}#{Context.User.DiscriminatorValue}", Context.User.GetAvatarUrl(), "https://exploiting-discord-for.fun");
            builder.WithColor(Color.Blue);
            builder.WithTimestamp(DateTime.UtcNow);
            builder.WithDescription($"Hello, {Context.User.Username}!\nYou have requested for phantom's list of commands.\nYour action has been recorded for quality assurance and testing.");
            builder.WithThumbnailUrl("https://i.imgur.com/u5cY4xZ.jpg");
            builder.WithImageUrl("https://i.imgur.com/igRkLFI.png");
            builder.AddField($"🚁 {Configuration.GetConfig().Prefix}help", "Returns a list of commands to use with phantom.");
            builder.AddField($"🤖 {Configuration.GetConfig().Prefix}join [RoomID]", "Commands all the photon bots to join a room by It's ID.");
            builder.AddField($"🤖 {Configuration.GetConfig().Prefix}joincurrentroom", "Commands all the photon bots to join the hoster's current room.");
            builder.AddField($"🤖 {Configuration.GetConfig().Prefix}leave", "Leaves the current room with all bots.");
            builder.AddField($"🤖 {Configuration.GetConfig().Prefix}room", "Gathers information about the current room.");
            builder.AddField($"===== DISCORD MODERATORS =====", discordmoderators);
            builder.AddField($"===== IN GAME MODERATORS =====", ingamemoderators);
            builder.WithFooter("Phantom, a very good private photon bot controller. Developed by the Phantom Team (Luni, Yaekith).", "https://i.imgur.com/u5cY4xZ.jpg");
            await Context.Channel.SendMessageAsync(null, false, builder.Build());
        }
    }
}
