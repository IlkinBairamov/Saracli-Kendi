using SaracliKend.Database.Repositories.EntityFrameworkCore;
using SaracliKend.Core.Repositories;
using SaracliKend.Database.Context;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Database.Repositoires.EntityFrameworkCore;

public class EFSchoolRepository : EFRepository<School, SaracliDbContext>, ISchoolRepository
{
	public EFSchoolRepository(SaracliDbContext dbContext) : base(dbContext)
	{
	}
}
