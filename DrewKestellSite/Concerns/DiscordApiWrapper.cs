namespace DrewKestellSite.Concerns
{
    using Discord;
    using Discord.Rest;
    using DrewKestellSite.Configuration;
    using Microsoft.Extensions.Options;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class DiscordApiWrapper : IDiscordApiWrapper
    {
        const ulong GeneralChannelId = 303695206333546496;

        readonly string token;

        DiscordRestClient client;
        RestTextChannel channel;

        public DiscordApiWrapper(IOptions<ApiConfiguration> config)
        {
            token = config.Value.DiscordToken;
        }

        async Task InitializeDiscord()
        {
            client = new DiscordRestClient();
            await client.LoginAsync(TokenType.Bot, token);
            channel = await client.GetChannelAsync(GeneralChannelId) as RestTextChannel;
        }

        public async Task<IMessage> GetMessage(string url)
        {
            if (channel == null)
                await InitializeDiscord();

            var messageId = url.Split("/").Last();
            var message = await channel.GetMessageAsync(Convert.ToUInt64(messageId));
            return message;
        }
    }
}
