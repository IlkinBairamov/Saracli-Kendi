using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Services.Contracts;

namespace SaracliKendApi.Controllers
{
    public class FunnyStoryController : Controller
    {
        private readonly IFunnyStoryService _funnyStoryService;

        public FunnyStoryController(IFunnyStoryService funnyStoryService)
        {
            _funnyStoryService = funnyStoryService;
        }

        public async Task<IActionResult> Index()
        {
            var funnyStories = await _funnyStoryService.GetAllAsync();
            return View(funnyStories);
        }

        public async Task<IActionResult> Details(int id)
        {
            var funnyStory = await _funnyStoryService.GetAsync(id);
            return View(funnyStory);
        }
    }
}
