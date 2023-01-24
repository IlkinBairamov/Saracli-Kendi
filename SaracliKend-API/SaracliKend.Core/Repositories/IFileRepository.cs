using SaracliKend.Domain.Enums;
using File = SaracliKend.Domain.Entities.File;

namespace SaracliKend.Core.Repositories
{
    public interface IFileRepository : IRepository<File>
    {
        IQueryable<File> GetFilesByType(FileType fileType);
    }
}
