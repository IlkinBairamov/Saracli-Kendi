using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Domain.Enums;
using SaracliKend.Infrastructure.Resources;
using SaracliKendApi.Areas.AdminPanel.Data;
using SaracliKendApi.Areas.AdminPanel.Models;

namespace SaracliKendApi.Areas.AdminPanel.Controllers
{
    public class FileController : BaseController
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<IActionResult> Index(FileType fileType, int page = 1)
        {
            if (page < 1)
                return BadRequest();
            var files = await _fileService.GetFilesByType(fileType);

            var totalPageCount = Math.Ceiling((decimal)files.Count / 10);
            if (files.Count != 0 && ((page - 1) * 10) >= files.Count)
                page--;
            if (files.Count != 0 && page > totalPageCount)
                return NotFound();
            ViewBag.totalPageCount = totalPageCount;
            ViewBag.currentPage = page;
            files = files.Skip((page - 1) * 10).Take(10).ToList();

            return View(new FileListVM
            {
                Files = files,
                FileType = fileType
            });
        }

        public async Task<IActionResult> Details(int id)
        {
            var file = await _fileService.GetAsync(id);
            if (file == null)
                return NotFound();

            return View(file);
        }

        public async Task<IActionResult> Create(FileType fileType)
        {
            return View(new FileCreateVM
            {
                FileModel = new FileViewModel { FileType = fileType }
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FileCreateVM fileVM)
        {
            if (!ModelState.IsValid)
                return View(fileVM);

            if (fileVM.File != null)
            {
                fileVM.FileModel.Path = await fileVM.File.GenerateFile(GetFileFolderPath(fileVM.FileModel.FileType));
            }
            else
            {
                ModelState.AddModelError("File", "Please select File");
                return View(fileVM);
            }

            await _fileService.CreateAsync(fileVM.FileModel);
            return RedirectToAction(nameof(Index), new { fileType = fileVM.FileModel.FileType });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var file = await _fileService.GetAsync(id);
            if (file == null)
                return Json(new { status = 404 });

            FileExtension.DeleteFile(file.Path, GetFileFolderPath(file.FileType));

            await _fileService.DeleteAsync(id);
            return Json(new { status = 200 });
        }

        public string GetFileFolderPath(FileType fileType)
        {
            return fileType switch
            {
                FileType.Image => Constants.ImageFolderPath,
                FileType.Video => Constants.VideoFolderPath,
                _ => "",
            };
        }
    }
}
