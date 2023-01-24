using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Infrastructure.Resources;
using SaracliKendApi.Areas.AdminPanel.Data;
using SaracliKendApi.Areas.AdminPanel.Models;

namespace SaracliKendApi.Areas.AdminPanel.Controllers
{
    public class SchoolController : BaseController
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            if (page < 1)
                return BadRequest();
            var entities = await _schoolService.GetAllAsync();

            var totalPageCount = Math.Ceiling((decimal)entities.Count / 10);
            if (entities.Count != 0 && ((page - 1) * 10) >= entities.Count)
                page--;
            if (entities.Count != 0 && page > totalPageCount)
                return NotFound();
            ViewBag.totalPageCount = totalPageCount;
            ViewBag.currentPage = page;
            entities = entities.Skip((page - 1) * 10).Take(10).ToList();
            return View(entities);
        }

        public async Task<IActionResult> Details(int id)
        {
            var entity = await _schoolService.GetAsync(id);
            if (entity == null)
                return NotFound();

            return View(entity);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SchoolCreateVM schoolVM)
        {
            if (!ModelState.IsValid)
                return View(schoolVM);

            if (schoolVM.Image != null)
            {
                if (!schoolVM.Image.IsImage())
                {
                    ModelState.AddModelError("Photo", "File must to be a Photo!");
                    return View(schoolVM);
                }

                schoolVM.School.Image = await schoolVM.Image.GenerateFile(Path.Combine(Constants.ImageFolderPath, "school"));
            }
            else
            {
                ModelState.AddModelError("Photo", "Please select Photo");
                return View(schoolVM);
            }

            await _schoolService.CreateAsync(schoolVM.School);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var entity = await _schoolService.GetAsync(id);
            if (entity == null)
                return NotFound();
            return View(new SchoolCreateVM
            {
                School = entity
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SchoolCreateVM schoolVM)
        {
            if (!ModelState.IsValid)
                return View(schoolVM);

            var existStory = await _schoolService.GetAsync(id);
            if (existStory == null)
                return NotFound();

            if (schoolVM.Image != null)
            {
                if (!schoolVM.Image.IsImage())
                {
                    ModelState.AddModelError("Photo", "File must to be a Photo!");
                    return View(schoolVM);
                }

                FileExtension.DeleteFile(existStory.Image, Path.Combine(Constants.ImageFolderPath, "school"));

                schoolVM.School.Image = await schoolVM.Image.GenerateFile(Path.Combine(Constants.ImageFolderPath, "school"));
            }

            schoolVM.School.Id = id;
            await _schoolService.UpdateAsync(schoolVM.School);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _schoolService.GetAsync(id);
            if (entity == null)
                return Json(new { status = 404 });

            await _schoolService.DeleteAsync(id);
            return Json(new { status = 200 });
        }
    }
}
