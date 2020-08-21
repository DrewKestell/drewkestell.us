using Discord;
using System.Threading.Tasks;

namespace DrewKestellSite.Concerns
{
    public interface IDiscordApiWrapper
    {
        Task<IMessage> GetMessage(string url);
    }
}
