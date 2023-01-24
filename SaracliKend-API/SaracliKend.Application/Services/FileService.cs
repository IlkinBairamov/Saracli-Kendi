using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Core.Repositories;
using SaracliKend.Domain.Enums;
using File = SaracliKend.Domain.Entities.File;

namespace SaracliKend.Application.Services
{
    internal class FileService : CrudService<FileViewModel, File, IFileRepository>, IFileService
    {

        public FileService(IFileRepository fileRepository, IMapper mapper) : base(fileRepository, mapper)
        {
        }

        public async Task<List<FileViewModel>> GetFilesByType(FileType fileType)
        {
            var files = Mapper.Map<List<FileViewModel>>(await EntityDal.GetFilesByType(fileType).ToListAsync());
            return files;
        }
    }
}
