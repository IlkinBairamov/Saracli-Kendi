using SaracliKend.Core.Repositories;
using SaracliKend.Database.Context;
using SaracliKend.Database.Repositories.EntityFrameworkCore;
using SaracliKend.Domain.Enums;
using File = SaracliKend.Domain.Entities.File;

namespace SaracliKend.Database.Repositoires.EntityFrameworkCore
{
    internal class EFFileRepository : EFRepository<File, SaracliDbContext>, IFileRepository
    {
        public EFFileRepository(SaracliDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<File> GetFilesByType(FileType fileType)
        {
            return GetAll().Where(f => f.FileType == fileType);
        }
    }
}
