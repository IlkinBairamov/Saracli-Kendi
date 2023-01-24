using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Domain.Enums;
using SaracliKend.Infrastructure.Utils;

namespace SaracliKendApi.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<IActionResult> Index(PersonType personType)
        {
            var people = await _personService.GetByType(personType);
            ViewBag.Title = EnumHelper.GetDescription(personType);
            return View(people);
        }

        public async Task<IActionResult> GetPerson(int id)
        {
            var person = await _personService.GetAsync(id);
            return PartialView("_PersonDetailsPartial", person);
        }
    }
}
