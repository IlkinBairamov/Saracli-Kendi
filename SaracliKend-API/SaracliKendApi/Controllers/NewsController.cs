using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Services.Contracts;

namespace SaracliKendApi.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _newsService.GetAllAsync();
            return View(news);
        }

        public async Task<IActionResult> Details(int id)
        {
            var news = await _newsService.GetAsync(id);
            return View(news);
        }
    }
}
