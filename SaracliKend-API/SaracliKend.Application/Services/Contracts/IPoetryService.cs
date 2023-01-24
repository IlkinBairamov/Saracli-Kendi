using SaracliKend.Application.Models;

namespace SaracliKend.Application.Services.Contracts;

public interface IPoetryService : ICrudService<PoetryVM>
{
    Task<List<PoetryVM>> GetByPoetriesByWriter(int writerId);
}
