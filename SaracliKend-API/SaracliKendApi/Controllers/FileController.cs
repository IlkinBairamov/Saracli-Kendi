using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Domain.Enums;

namespace SaracliKendApi.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<IActionResult> Index(FileType fileType)
        {
            var files = await _fileService.GetFilesByType(fileType);
            return View(new FileListVM
            {
                Files = files,
                FileType = fileType
            });
        }
    }
}
