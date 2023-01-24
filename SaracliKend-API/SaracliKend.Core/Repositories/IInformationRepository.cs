using SaracliKend.Domain.Entities;

namespace SaracliKend.Core.Repositories
{
    public interface IInformationRepository : IRepository<Information>
    {
        Task RemoveImages(Information entity);
    }
}
