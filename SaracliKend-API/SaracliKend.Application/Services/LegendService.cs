using AutoMapper;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Core.Repositories;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Application.Services;

internal class LegendService : CrudService<LegendVM, Legend, ILegendRepository>, ILegendService
{

    public LegendService(IMapper mapper, ILegendRepository legendRepository) : base(legendRepository, mapper)
    {
    }
}
