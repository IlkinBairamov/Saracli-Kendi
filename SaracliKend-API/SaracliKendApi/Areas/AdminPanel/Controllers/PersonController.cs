using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Domain.Enums;
using SaracliKend.Infrastructure.Resources;
using SaracliKendApi.Areas.AdminPanel.Data;
using SaracliKendApi.Areas.AdminPanel.Models;

namespace SaracliKendApi.Areas.AdminPanel.Controllers
{
    public class PersonController : BaseController
    {
        public readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<IActionResult> Index(PersonType personType, int page = 1)
        {
            if (page < 1)
                return BadRequest();
            var people = await _personService.GetByType(personType);

            var totalPageCount = Math.Ceiling((decimal)people.Count / 10);
            if (people.Count != 0 && ((page - 1) * 10) >= people.Count)
                page--;
            if (people.Count != 0 && page > totalPageCount)
                return NotFound();
            ViewBag.totalPageCount = totalPageCount;
            ViewBag.currentPage = page;
            people = people.Skip((page - 1) * 10).Take(10).ToList();

            return View(new PersonListModel
            {
                People = people,
                Type = personType
            });
        }

        public async Task<IActionResult> Details(int id)
        {
            var person = await _personService.GetAsync(id);
            if (person == null)
                return NotFound();

            return View(person);
        }

        public async Task<IActionResult> Create(PersonType personType)
        {
            return View(new PersonCreateViewModel
            {
                Person = new PersonModel { Type = personType }
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonCreateViewModel personVM)
        {
            if (!ModelState.IsValid)
                return View(personVM);

            if (personVM.Image != null)
            {
                if (!personVM.Image.IsImage())
                {
                    ModelState.AddModelError("Photo", "File must to be a Photo!");
                    return View(personVM);
                }

                if (!personVM.Image.IsAllowedSize(2))
                {
                    ModelState.AddModelError("Photo", "The size of the photo cannot be more than one MegaByte!");
                    return View(personVM);
                }
                personVM.Person.Image = await personVM.Image.GenerateFile(Path.Combine(Constants.ImageFolderPath, "person"));
            }
            else
            {
                ModelState.AddModelError("Photo", "Please select Photo");
                return View(personVM);
            }

            await _personService.CreateAsync(personVM.Person);
            return RedirectToAction(nameof(Index), new { personType = personVM.Person.Type });
        }

        public async Task<IActionResult> Update(int id)
        {
            var person = await _personService.GetAsync(id);
            if (person == null)
                return NotFound();
            return View(new PersonCreateViewModel
            {
                Person = person
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, PersonCreateViewModel personVM)
        {
            if (!ModelState.IsValid)
                return View(personVM);
            var existblog = await _personService.GetAsync(id);
            if (existblog == null)
                return NotFound();

            if (personVM.Image != null)
            {
                if (!personVM.Image.IsImage())
                {
                    ModelState.AddModelError("Photo", "File must to be a Photo!");
                    return View(personVM);
                }

                if (!personVM.Image.IsAllowedSize(2))
                {
                    ModelState.AddModelError("Photo", "The size of the photo cannot be more than one MegaByte!");
                    return View(personVM);
                }
                var existPath = Path.Combine(Constants.ImageFolderPath, existblog.Image!);
                if (System.IO.File.Exists(existPath))
                {
                    System.IO.File.Delete(existPath);
                }

                personVM.Person.Image = await personVM.Image.GenerateFile(Path.Combine(Constants.ImageFolderPath, "person"));
            }
            personVM.Person.Id = id;
            await _personService.UpdateAsync(personVM.Person);
            return RedirectToAction(nameof(Index), new { personType = personVM.Person.Type });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var person = await _personService.GetAsync(id);
            if (person == null)
                return Json(new { status = 404 });

            await _personService.DeleteAsync(id);
            return Json(new { status = 200 });
        }
    }
}
