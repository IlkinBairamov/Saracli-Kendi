using AutoMapper;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Core.Repositories;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Application.Services
{
    public class NewsService : CrudService<NewsViewModel, News, INewsRepository>, INewsService
    {
        public NewsService(INewsRepository newsRepository, IMapper mapper) : base(newsRepository, mapper)
        {
        }
    }
}
