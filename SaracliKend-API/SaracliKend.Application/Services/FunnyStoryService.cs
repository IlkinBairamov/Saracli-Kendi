using AutoMapper;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Core.Repositories;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Application.Services
{
    internal class FunnyStoryService : CrudService<FunnyStoryVM, FunnyStory, IFunnyStoryRepository>, IFunnyStoryService
    {
        public FunnyStoryService(IFunnyStoryRepository funnyStoryRepository, IMapper mapper) : base(funnyStoryRepository, mapper)
        {
        }
    }
}
