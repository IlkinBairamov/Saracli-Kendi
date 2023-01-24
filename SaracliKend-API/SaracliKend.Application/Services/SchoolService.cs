using AutoMapper;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Core.Repositories;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Application.Services;

internal class SchoolService : CrudService<SchoolModel, School, ISchoolRepository>, ISchoolService
{
    public SchoolService(ISchoolRepository schoolRepository, IMapper mapper) : base(schoolRepository, mapper)
    {
    }
}
