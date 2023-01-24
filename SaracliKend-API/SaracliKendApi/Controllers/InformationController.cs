using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Domain.Enums;

namespace SaracliKendApi.Controllers
{
    public class InformationController : Controller
    {
        private readonly IInformationService _informationService;

        public InformationController(IInformationService generalInformationService)
        {
            _informationService = generalInformationService;
        }

        public async Task<IActionResult> GeneralInformation()
        {
            var generalInformation = await _informationService.GetInformation(InformationType.General);
            return View(generalInformation);
        }

        public async Task<IActionResult> Location()
        {
            var locationInfo = await _informationService.GetInformation(InformationType.Location);
            return View(locationInfo);
        }
    }
}
