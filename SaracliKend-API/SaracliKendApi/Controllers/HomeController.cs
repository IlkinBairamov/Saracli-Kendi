using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Domain.Enums;

namespace SaracliKendApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISliderImageService _sliderImageService;
        private readonly IPersonService _personService;
        private readonly INewsService _newsService;
        private readonly IFileService _fileService;
        private readonly IInformationService _informationService;

        public HomeController(ILogger<HomeController> logger, ISliderImageService sliderImageService, IPersonService personService, INewsService newsService, IFileService fileService, IInformationService informationService)
        {
            _logger = logger;
            _sliderImageService = sliderImageService;
            _personService = personService;
            _newsService = newsService;
            _fileService = fileService;
            _informationService = informationService;
        }

        public async Task<IActionResult> Index()
        {
            var people = await _personService.GetAllAsync();
            var martyrs = people.FindAll(x => x.Type == PersonType.Martyr);
            var ghazis = people.FindAll(x => x.Type == PersonType.Ghazi);
            var news = await _newsService.GetAllAsync();
            var photos = await _fileService.GetFilesByType(FileType.Image);
            var videos = await _fileService.GetFilesByType(FileType.Video);
            var info = await _informationService.GetInformation(InformationType.General);

            var homeVM = new HomeViewModel
            {
                SliderImages = await _sliderImageService.GetAllAsync(),
                Martyrs = martyrs.Count > 0 ? martyrs.GetRange(0, martyrs.Count < 3 ? martyrs.Count : 3) : martyrs,
                Ghazis = ghazis.Count > 0 ? ghazis.GetRange(0, ghazis.Count < 3 ? ghazis.Count : 3) : ghazis,
                News = news,
                Photos = photos.Count > 0 ? photos.GetRange(0, photos.Count < 3 ? photos.Count : 3) : photos,
                Videos = videos.Count > 0 ? videos.GetRange(0, videos.Count < 3 ? videos.Count : 3) : videos,
                Information = info
            };
            return View(homeVM);
        }
    }
}