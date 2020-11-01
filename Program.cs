using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Phantom.Client;
using Phantom.DiscordBot;
using Phantom.Settings;
using Phantom.Utils;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phantom
{
    class Program
    {
        static DiscordSocketClient Client { get; set; }
        static CommandHandler Handler { get; set; }

        static void Main(string[] args)
        {
            Configuration.SetupConfig();
            ConsoleUtils.SetTitle($"Phantom Bot = {Configuration.GetConfig().Authentication.Count} Bot(s) = {ClientUtils.GetCurrentReleaseServer() + "_2.5"} = Discord Bot: Offline");

            if (Configuration.GetConfig().Authentication.Count() == 0)
            {
                ConsoleUtils.Log("No accounts were found in the config. Please add some before continuing.");
                Console.ReadLine();
            }
            else
                ConsoleUtils.SetTitle($"{Console.Title.Replace("Offline", "Starting")}");
                new Program().StartBot().GetAwaiter().GetResult();
        }

        private async Task StartBot()
        {
            var services = new ServiceCollection();
            Client = new DiscordSocketClient();
            Handler = new CommandHandler(Client);
            await Handler.Install();
            Client.Ready += Client_Ready;
            await Client.LoginAsync(Discord.TokenType.Bot, Configuration.GetConfig().Token, true);
            await Client.StartAsync();
            await Task.Delay(-1);
        }

        #region Discord Bot Events
        private Task Client_Ready()
        {
            ConsoleUtils.SetTitle($"{Console.Title.Replace("Starting", "Online")}");
            ConsoleUtils.Log($"{Client.CurrentUser.Username} is online. Current Prefix: {Configuration.GetConfig().Prefix}");
            foreach(var auth in Configuration.GetConfig().Authentication)
                GeneralUtils.Clients.Add(new PhantomClient(auth.Value, auth.Key, "avtr_23c53796-fb1c-4003-8b7a-90c2349bf043"));

            return null;
        }
        #endregion
    }
}
