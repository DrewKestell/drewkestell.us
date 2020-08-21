namespace DrewKestellSite
{
    using Discord;
    using Discord.Rest;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class DiscordClientWrapper
    {
        const ulong GeneralChannelId = 303695206333546496;

        DiscordRestClient client;
        RestTextChannel channel;

        internal DiscordClientWrapper(string token)
        {
            Task.Run(async () => await InitializeDiscord(token));
        }

        async Task InitializeDiscord(string token)
        {
            client = new DiscordRestClient();

            await client.LoginAsync(TokenType.Bot, "NDU5NzM3ODk4NjUzMzE5MTY4.XrA89w.H6nM6U4zhpde3gJOu471KEErMJQ");
            channel = await client.GetChannelAsync(GeneralChannelId) as RestTextChannel;
        }

        internal async Task<IMessage> GetMessage(string url)
        {
            var messageId = url.Split("/").Last();
            return await channel.GetMessageAsync(Convert.ToUInt64(messageId));
        }
    }
}
