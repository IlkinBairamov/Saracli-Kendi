using SaracliKend.Core.Repositories;
using SaracliKend.Database.Context;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Database.Repositories.EntityFrameworkCore;

public class EFPersonRepository : EFRepository<Person, SaracliDbContext>, IPersonRepository
{
    public EFPersonRepository(SaracliDbContext context) : base(context)
    {
    }
}
