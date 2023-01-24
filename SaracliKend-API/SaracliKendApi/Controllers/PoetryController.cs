using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Services.Contracts;

namespace SaracliKendApi.Controllers
{
    public class PoetryController : Controller
    {
        private readonly IPoetryService _poetryService;

        public PoetryController(IPoetryService poetryService)
        {
            _poetryService = poetryService;
        }

        public async Task<IActionResult> Index()
        {
            var poetries = await _poetryService.GetAllAsync("Writer");
            return View(poetries);
        }

        public async Task<IActionResult> AllPoetriesByWriter(int writerId)
        {
            var poetries = await _poetryService.GetByPoetriesByWriter(writerId);
            return View(poetries);
        }
    }
}
