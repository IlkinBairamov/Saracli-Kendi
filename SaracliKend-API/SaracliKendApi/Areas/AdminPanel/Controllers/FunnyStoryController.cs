using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Domain.Enums;
using SaracliKendApi.Areas.AdminPanel.Models;

namespace SaracliKendApi.Areas.AdminPanel.Controllers
{
    public class FunnyStoryController : BaseController
    {
        private readonly IFunnyStoryService _funnyStoryService;
        private readonly IPersonService _personService;

        public FunnyStoryController(IFunnyStoryService funnyStoryService, IPersonService personService)
        {
            _funnyStoryService = funnyStoryService;
            _personService = personService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            if (page < 1)
                return BadRequest();
            var stories = await _funnyStoryService.GetAllAsync();

            var totalPageCount = Math.Ceiling((decimal)stories.Count / 10);
            if (stories.Count != 0 && ((page - 1) * 10) >= stories.Count)
                page--;
            if (stories.Count != 0 && page > totalPageCount)
                return NotFound();
            ViewBag.totalPageCount = totalPageCount;
            ViewBag.currentPage = page;
            stories = stories.Skip((page - 1) * 10).Take(10).ToList();

            return View(stories);
        }

        public async Task<IActionResult> Details(int id)
        {
            var story = await _funnyStoryService.GetAsync(id);
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
        public async Task<IActionResult> Create(FunnyStoryCreateVM storyVM)
        {
            if (!ModelState.IsValid)
                return View(storyVM);

            await _funnyStoryService.CreateAsync(storyVM.Story);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var story = await _funnyStoryService.GetAsync(id);
            if (story == null)
                return NotFound();

            return View(new FunnyStoryCreateVM
            {
                Story = story,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, FunnyStoryCreateVM storyVM)
        {
            if (!ModelState.IsValid)
                return View(storyVM);

            var existStory = await _funnyStoryService.GetAsync(id);
            if (existStory == null)
                return NotFound();

            storyVM.Story.Id = id;
            await _funnyStoryService.UpdateAsync(storyVM.Story);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var story = await _funnyStoryService.GetAsync(id);
            if (story == null)
                return Json(new { status = 404 });

            await _funnyStoryService.DeleteAsync(id);
            return Json(new { status = 200 });
        }
    }
}
