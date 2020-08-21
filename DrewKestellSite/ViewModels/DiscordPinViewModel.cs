using Discord;

namespace DrewKestellSite.ViewModels
{
    public class DiscordPinViewModel
    {
        public DiscordPinViewModel(IMessage message)
        {
            Content = message.Content;
        }

        public string Content { get; }
    }
}
