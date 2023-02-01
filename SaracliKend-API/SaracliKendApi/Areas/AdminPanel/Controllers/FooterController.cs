using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;

namespace SaracliKendApi.Areas.AdminPanel.Controllers
{
    public class FooterController : BaseController
    {
        private readonly IFooterService _footerService;

        public FooterController(IFooterService footerService)
        {
            _footerService = footerService;
        }

        public async Task<IActionResult> Index()
        {
            var footer = await _footerService.GetFooterAsync();
            return View(footer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FooterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _footerService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update()
        {
            var existFooter = await _footerService.GetFooterAsync();
            return View(existFooter);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, FooterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existEntity = await _footerService.GetFooterAsync();
            if (existEntity == null)
                return NotFound();

            model.Id = id;

            await _footerService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
