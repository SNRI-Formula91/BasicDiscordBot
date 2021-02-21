/* Basic Discord Bot template
 * 
 * This is a template made using the instructional guide from https://docs.stillu.cc/guides/getting_started/first-bot.html
 * This is the minimal amount of code to run a functional bot that is simply able to authenticate access into a discord server and log some fatal errors.
 * 
 * Prerequisites:
 * 1. Application must be made on the Discord Development Portal
 * 2. Use OAuth Token to gain access to a server
 * 3. Need a access token
 * 
 * Things to do when adopting this template
 * 1. Change the namespace
 */

using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace BasicDiscordBot
{
    public class Program
    {
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;

            //  You can assign your bot token to a string, and pass that in to connect.
            //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
            var token = "PLACE_TOKEN_HERE";

            // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
            // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
            // var token = File.ReadAllText("token.txt");
            // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
