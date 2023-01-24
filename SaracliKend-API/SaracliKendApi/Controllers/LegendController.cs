using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Services.Contracts;

namespace SaracliKendApi.Controllers
{
    public class LegendController : Controller
    {
        private readonly ILegendService _legendService;

        public LegendController(ILegendService legendService)
        {
            _legendService = legendService;
        }

        public async Task<IActionResult> Index()
        {
            var legends = await _legendService.GetAllAsync();
            return View(legends);
        }
    }
}
