using SaracliKend.Application.Models;
using SaracliKend.Domain.Enums;

namespace SaracliKend.Application.Services.Contracts
{
    public interface IInformationService : ICrudService<InformationVM>
    {
        Task<InformationVM> GetInformation(InformationType informationType);

        Task UpdateInformation(InformationVM model);
    }
}
