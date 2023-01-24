using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Domain.Enums;
using SaracliKendApi.Areas.AdminPanel.Models;

namespace SaracliKendApi.Areas.AdminPanel.Controllers
{
    public class PoetryController : BaseController
    {
        private readonly IPoetryService _poetryService;
        private readonly IPersonService _personService;

        public PoetryController(IPoetryService poetryService, IPersonService personService)
        {
            _poetryService = poetryService;
            _personService = personService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            if (page < 1)
                return BadRequest();
            var stories = await _poetryService.GetAllAsync("Writer");

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
            var story = await _poetryService.GetAsync(id, "Writer");
            if (story == null)
                return NotFound();

            return View(story);
        }

        public async Task<IActionResult> Create()
        {
            return View(new PoetryCreateVM
            {
                Writers = await _personService.GetByType(PersonType.Writer)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PoetryCreateVM storyVM)
        {
            storyVM.Writers = await _personService.GetByType(PersonType.Writer);
            if (!ModelState.IsValid)
                return View(storyVM);

            await _poetryService.CreateAsync(storyVM.Story);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var story = await _poetryService.GetAsync(id, "Writer");
            if (story == null)
                return NotFound();
            return View(new PoetryCreateVM
            {
                Story = story,
                Writers = await _personService.GetByType(PersonType.Writer)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, PoetryCreateVM storyVM)
        {
            storyVM.Writers = await _personService.GetByType(PersonType.Writer);
            if (!ModelState.IsValid)
                return View(storyVM);

            var existStory = await _poetryService.GetAsync(id, "Writer");
            if (existStory == null)
                return NotFound();

            storyVM.Story.Id = id;
            await _poetryService.UpdateAsync(storyVM.Story);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var story = await _poetryService.GetAsync(id);
            if (story == null)
                return Json(new { status = 404 });

            await _poetryService.DeleteAsync(id);
            return Json(new { status = 200 });
        }
    }
}
