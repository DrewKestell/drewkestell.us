using DrewKestellSite.Concerns;
using DrewKestellSite.Data;
using DrewKestellSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DrewKestellSite.Controllers
{
    [Authorize]
    public class DiscordController : Controller
    {
        readonly ApplicationContext context;
        readonly IDiscordApiWrapper discordApi;

        public DiscordController(ApplicationContext context, IDiscordApiWrapper discordApi)
        {
            this.context = context;
            this.discordApi = discordApi;
        }

        [HttpGet("/Discord")]
        public async Task<IActionResult> Index()
        {
            var pins = context.Pins.ToList();

            var messages = await Task.WhenAll(pins.Select(async p => {
                return await discordApi.GetMessage(p.Url);
            }));

            return View(messages.Select(t => new DiscordPinViewModel(t)));
        }
    }
}
