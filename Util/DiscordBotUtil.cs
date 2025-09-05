using Discord;
using Discord.Rest;
using Discord.WebSocket;
using Newtonsoft.Json.Linq;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


#nullable enable
namespace InvestSupTool.Util
{
    internal class DiscordBotUtil
    {
        private static readonly Lazy<DiscordBotUtil> _instance = new Lazy<DiscordBotUtil>((Func<DiscordBotUtil>)(() => new DiscordBotUtil()));

        private DiscordBotUtil()
        {
            this.Client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
            });
            LogUtil.Info("DiscordBot 인스턴스가 생성되었습니다.");
        }

        public static DiscordBotUtil Instance => DiscordBotUtil._instance.Value;

        public DiscordSocketClient Client { get; private set; }

        public async Task StartAsync(string token)
        {
            DiscordSocketConfig config = new DiscordSocketConfig()
            {
                GatewayIntents = GatewayIntents.Guilds | GatewayIntents.GuildMessages | GatewayIntents.MessageContent
            };
            this.Client = new DiscordSocketClient(config);
            this.Client.Log += new Func<LogMessage, Task>(this.OnLogReceived);
            this.Client.MessageReceived += new Func<SocketMessage, Task>(this.OnMessageReceived);
            await this.Client.LoginAsync(TokenType.Bot, token);
            await this.Client.StartAsync();
            config = (DiscordSocketConfig)null;
        }

        public async Task StopAsync()
        {
            if (this.Client == null)
                return;
            await this.Client.StopAsync();
            await this.Client.LogoutAsync();
        }

        private Task OnLogReceived(LogMessage message)
        {
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
            interpolatedStringHandler.AppendLiteral("[Log] ");
            interpolatedStringHandler.AppendFormatted<LogMessage>(message);
            LogUtil.Info(interpolatedStringHandler.ToStringAndClear());
            return Task.CompletedTask;
        }

        private async Task OnMessageReceived(SocketMessage message)
        {
            if (message.Author.IsBot || !(message.Content.ToLower() == "!안녕"))
                return;
            RestUserMessage restUserMessage = await message.Channel.SendMessageAsync("안녕하세요.", false, (Embed)null, (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, MessageFlags.None, (PollProperties)null);
        }
    }
}
