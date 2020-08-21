﻿using DrewKestellSite.Data;
using DrewKestellSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DrewKestellSite.Controllers
{
    public class ArticleController : Controller
    {
        readonly ApplicationContext context;

        public ArticleController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet("/Article")]
        public async Task<IActionResult> Index() => 
            View((await context.Articles.AsQueryable().ToListAsync()).Select(a => new ArticleViewModel(a)));
    }
}
