using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Core.Repositories;
using SaracliKend.Domain.Entities;
using SaracliKend.Domain.Enums;

namespace SaracliKend.Application.Services;

internal class PersonService : CrudService<PersonModel, Person, IPersonRepository>, IPersonService
{
    public PersonService(IPersonRepository personRepository, IMapper mapper) : base(personRepository, mapper)
    {
    }

    public async Task<List<PersonModel>> GetByType(PersonType type)
    {
        var models = Mapper.Map<List<PersonModel>>(await EntityDal.GetAll().Where(x => x.Type == type).ToListAsync());
        return models;
    }
}
