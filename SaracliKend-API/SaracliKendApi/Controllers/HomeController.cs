using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;

namespace SaracliKendApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISliderImageService _sliderImageService;
        private readonly IPersonService _personService;
        private readonly INewsService _newsService;

        public HomeController(ILogger<HomeController> logger, ISliderImageService sliderImageService, IPersonService personService, INewsService newsService)
        {
            _logger = logger;
            _sliderImageService = sliderImageService;
            _personService = personService;
            _newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            var people = await _personService.GetAllAsync();
            var martyrs = people.FindAll(x => x.Type == SaracliKend.Domain.Enums.PersonType.Martyr);
            var ghazis = people.FindAll(x => x.Type == SaracliKend.Domain.Enums.PersonType.Ghazi);
            var news = await _newsService.GetAllAsync();

            var homeVM = new HomeViewModel
            {
                SliderImages = await _sliderImageService.GetAllAsync(),
                Martyrs = martyrs.Count > 0 ? martyrs.GetRange(0, martyrs.Count < 3 ? martyrs.Count : 3) : martyrs,
                Ghazis = ghazis.Count > 0 ? ghazis.GetRange(0, ghazis.Count < 3 ? ghazis.Count : 3) : ghazis,
                News = news
            };
            return View(homeVM);
        }
    }
}