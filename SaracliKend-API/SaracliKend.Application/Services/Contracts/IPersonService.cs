using SaracliKend.Application.Models;
using SaracliKend.Domain.Enums;

namespace SaracliKend.Application.Services.Contracts;

public interface IPersonService : ICrudService<PersonModel>
{
    Task<List<PersonModel>> GetByType(PersonType type);
}
