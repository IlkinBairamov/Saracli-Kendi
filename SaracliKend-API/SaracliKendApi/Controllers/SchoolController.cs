using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Services.Contracts;

namespace SaracliKendApi.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        public async Task<IActionResult> Index()
        {
            var schools = await _schoolService.GetAllAsync();
            return View(schools);
        }
    }
}
