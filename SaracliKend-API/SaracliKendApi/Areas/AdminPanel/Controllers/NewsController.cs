using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Infrastructure.Resources;
using SaracliKendApi.Areas.AdminPanel.Data;
using SaracliKendApi.Areas.AdminPanel.Models;

namespace SaracliKendApi.Areas.AdminPanel.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            if (page < 1)
                return BadRequest();
            var entities = await _newsService.GetAllAsync();

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
            var entity = await _newsService.GetAsync(id);
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
        public async Task<IActionResult> Create(NewsCreateVM newsVM)
        {
            if (!ModelState.IsValid)
                return View(newsVM);

            if (newsVM.Image != null)
            {
                if (!newsVM.Image.IsImage())
                {
                    ModelState.AddModelError("Photo", "File must to be a Photo!");
                    return View(newsVM);
                }

                newsVM.News.Image = await newsVM.Image.GenerateFile(Path.Combine(Constants.ImageFolderPath, "news"));
            }
            else
            {
                ModelState.AddModelError("Photo", "Please select Photo");
                return View(newsVM);
            }

            await _newsService.CreateAsync(newsVM.News);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var entity = await _newsService.GetAsync(id);
            if (entity == null)
                return NotFound();
            return View(new NewsCreateVM
            {
                News = entity
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, NewsCreateVM newsVM)
        {
            if (!ModelState.IsValid)
                return View(newsVM);

            var existStory = await _newsService.GetAsync(id);
            if (existStory == null)
                return NotFound();

            if (newsVM.Image != null)
            {
                if (!newsVM.Image.IsImage())
                {
                    ModelState.AddModelError("Photo", "File must to be a Photo!");
                    return View(newsVM);
                }

                FileExtension.DeleteFile(existStory.Image, Path.Combine(Constants.ImageFolderPath, "news"));

                newsVM.News.Image = await newsVM.Image.GenerateFile(Path.Combine(Constants.ImageFolderPath, "news"));
            }

            newsVM.News.Id = id;
            await _newsService.UpdateAsync(newsVM.News);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _newsService.GetAsync(id);
            if (entity == null)
                return Json(new { status = 404 });

            await _newsService.DeleteAsync(id);
            return Json(new { status = 200 });
        }
    }
}
