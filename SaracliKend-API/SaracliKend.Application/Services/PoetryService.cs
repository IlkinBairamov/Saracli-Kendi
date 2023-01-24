using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Core.Repositories;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Application.Services;

internal class PoetryService : CrudService<PoetryVM, Poetry, IPoetryRepository>, IPoetryService
{
    public PoetryService(IMapper mapper, IPoetryRepository poetryRepository) : base(poetryRepository, mapper)
    {
    }

    public async Task<List<PoetryVM>> GetByPoetriesByWriter(int writerId)
    {
        var poetries = Mapper.Map<List<PoetryVM>>(await EntityDal.GetAllPoetriesByWriter(writerId).ToListAsync());
        return poetries;
    }
}
