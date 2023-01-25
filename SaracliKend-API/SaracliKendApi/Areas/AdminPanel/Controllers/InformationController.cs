using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Domain.Enums;
using SaracliKend.Infrastructure.Resources;
using SaracliKendApi.Areas.AdminPanel.Data;
using SaracliKendApi.Areas.AdminPanel.Models;

namespace SaracliKendApi.Areas.AdminPanel.Controllers
{
    public class InformationController : BaseController
    {
        private readonly IInformationService _informationService;

        public InformationController(IInformationService informationService)
        {
            _informationService = informationService;
        }

        public async Task<IActionResult> Index(InformationType type)
        {
            var entity = await _informationService.GetInformation(type);
            ViewBag.Type = type;
            return View(entity);
        }

        public async Task<IActionResult> Update(InformationType type)
        {
            var story = await _informationService.GetInformation(type);
            if (story == null)
                return NotFound();
            return View(new InformationCreateVM
            {
                Information = story,
                Type = type
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, InformationCreateVM infoVM)
        {
            if (!ModelState.IsValid)
                return View(infoVM);

            var existInfo = await _informationService.GetInformation(infoVM.Type);
            if (existInfo == null)
                return NotFound();
            infoVM.Information.Images = new List<string>();
            if (infoVM.Type == InformationType.Location)
            {
                if (infoVM.Image != null)
                {
                    if (!infoVM.Image.IsImage())
                    {
                        ModelState.AddModelError("Photo", "File must to be a Photo!");
                        return View(infoVM);
                    }

                    if (existInfo.Images?.Count > 0)
                    {
                        FileExtension.DeleteFile(existInfo.Images[0], Path.Combine(Constants.ImageFolderPath, "information"));
                    }

                    infoVM.Information.Images.Add(await infoVM.Image.GenerateFile(Path.Combine(Constants.ImageFolderPath, "information")));
                }
            }
            else if (infoVM.Type == InformationType.General)
            {
                if (infoVM.Images != null)
                {
                    foreach (var item in infoVM.Images)
                    {
                        if (!item.IsImage())
                        {
                            ModelState.AddModelError("Photo", "File must to be a Photo!");
                            return View(infoVM);
                        }
                        var path = Path.Combine(Constants.ImageFolderPath, "information");
                        var test = await item.GenerateFile(path);
                        infoVM.Information.Images.Add(test);
                    }
                    foreach (var item in existInfo.Images)
                    {
                        FileExtension.DeleteFile(item, Path.Combine(Constants.ImageFolderPath, "information"));
                    }
                }
            }

            infoVM.Information.Id = id;
            infoVM.Information.InformationType = infoVM.Type;
            await _informationService.UpdateInformation(infoVM.Information);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create(InformationType type)
        {
            ViewBag.Type = type;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InformationCreateVM infoVM)
        {
            if (!ModelState.IsValid)
                return View(infoVM);

            infoVM.Information.Images = new List<string>();
            if (infoVM.Type == InformationType.Location)
            {
                if (infoVM.Image != null)
                {
                    if (!infoVM.Image.IsImage())
                    {
                        ModelState.AddModelError("Photo", "File must to be a Photo!");
                        return View(infoVM);
                    }
                    infoVM.Information.Images.Add(await infoVM.Image.GenerateFile(Path.Combine(Constants.ImageFolderPath, "information")));
                }
            }
            else if (infoVM.Type == InformationType.General)
            {
                if (infoVM.Images != null)
                {
                    foreach (var item in infoVM.Images)
                    {
                        if (!item.IsImage())
                        {
                            ModelState.AddModelError("Photo", "File must to be a Photo!");
                            return View(infoVM);
                        }
                        var path = Path.Combine(Constants.ImageFolderPath, "information");
                        var test = await item.GenerateFile(path);
                        infoVM.Information.Images.Add(test);
                    }
                }
            }

            infoVM.Information.InformationType = infoVM.Type;
            await _informationService.CreateInformation(infoVM.Information);
            return RedirectToAction(nameof(Index));
        }
    }
}
