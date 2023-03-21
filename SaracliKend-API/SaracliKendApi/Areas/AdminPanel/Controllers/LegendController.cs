using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Infrastructure.Resources;
using SaracliKendApi.Areas.AdminPanel.Data;
using SaracliKendApi.Areas.AdminPanel.Models;

namespace SaracliKendApi.Areas.AdminPanel.Controllers
{
    public class LegendController : BaseController
    {
        private readonly ILegendService _legendService;

        public LegendController(ILegendService legendService)
        {
            _legendService = legendService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            if (page < 1)
                return BadRequest();
            var legends = await _legendService.GetAllAsync();

            var totalPageCount = Math.Ceiling((decimal)legends.Count / 10);
            if (legends.Count != 0 && ((page - 1) * 10) >= legends.Count)
                page--;
            if (legends.Count != 0 && page > totalPageCount)
                return NotFound();
            ViewBag.totalPageCount = totalPageCount;
            ViewBag.currentPage = page;
            legends = legends.Skip((page - 1) * 10).Take(10).ToList();
            return View(legends);
        }

        public async Task<IActionResult> Details(int id)
        {
            var story = await _legendService.GetAsync(id);
            if (story == null)
                return NotFound();

            return View(story);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LegendCreateVM storyVM)
        {
            if (!ModelState.IsValid)
                return View(storyVM);

            await _legendService.CreateAsync(storyVM.Legend);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var story = await _legendService.GetAsync(id);
            if (story == null)
                return NotFound();
            return View(new LegendCreateVM
            {
                Legend = story
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, LegendCreateVM storyVM)
        {
            if (!ModelState.IsValid)
                return View(storyVM);

            var existStory = await _legendService.GetAsync(id);
            if (existStory == null)
                return NotFound();

            storyVM.Legend.Id = id;
            await _legendService.UpdateAsync(storyVM.Legend);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var story = await _legendService.GetAsync(id);
            if (story == null)
                return Json(new { status = 404 });

            await _legendService.DeleteAsync(id);
            return Json(new { status = 200 });
        }
    }
}
