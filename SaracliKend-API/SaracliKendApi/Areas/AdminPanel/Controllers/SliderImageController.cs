using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Infrastructure.Resources;
using SaracliKendApi.Areas.AdminPanel.Data;
using SaracliKendApi.Areas.AdminPanel.Models;

namespace SaracliKendApi.Areas.AdminPanel.Controllers
{
    public class SliderImageController : BaseController
    {
        private readonly ISliderImageService _sliderImageService;

        public SliderImageController(ISliderImageService sliderImageService)
        {
            _sliderImageService = sliderImageService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            if (page < 1)
                return BadRequest();
            var files = await _sliderImageService.GetAllAsync();

            var totalPageCount = Math.Ceiling((decimal)files.Count / 10);
            if (files.Count != 0 && ((page - 1) * 10) >= files.Count)
                page--;
            if (files.Count != 0 && page > totalPageCount)
                return NotFound();
            ViewBag.totalPageCount = totalPageCount;
            ViewBag.currentPage = page;
            files = files.Skip((page - 1) * 10).Take(10).ToList();

            return View(files);
        }

        public async Task<IActionResult> Details(int id)
        {
            var file = await _sliderImageService.GetAsync(id);
            if (file == null)
                return NotFound();

            return View(file);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderImageCreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.File != null)
            {
                model.SliderImage.Path = await model.File.GenerateFile(Path.Combine(Constants.ImageFolderPath, "slider"));
            }
            else
            {
                ModelState.AddModelError("File", "Please select File");
                return View(model);
            }

            await _sliderImageService.CreateAsync(model.SliderImage);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var file = await _sliderImageService.GetAsync(id);
            if (file == null)
                return Json(new { status = 404 });

            FileExtension.DeleteFile(file.Path, Path.Combine(Constants.ImageFolderPath, "slider"));

            await _sliderImageService.DeleteAsync(id);
            return Json(new { status = 200 });
        }
    }
}
