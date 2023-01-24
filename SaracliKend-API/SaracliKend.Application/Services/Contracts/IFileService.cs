using SaracliKend.Application.Models;
using SaracliKend.Domain.Enums;

namespace SaracliKend.Application.Services.Contracts
{
    public interface IFileService : ICrudService<FileViewModel>
    {
        Task<List<FileViewModel>> GetFilesByType(FileType fileType);
    }
}
