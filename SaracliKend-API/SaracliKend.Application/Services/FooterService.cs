using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Core.Repositories;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Application.Services
{
    public class FooterService : CrudService<FooterVM, Footer, IFooterRepository>, IFooterService
    {
        public FooterService(IFooterRepository tEntityDal, IMapper mapper) : base(tEntityDal, mapper)
        {
        }

        public async Task<FooterVM> GetFooterAsync()
        {
            var entity = await EntityDal.GetAll().FirstOrDefaultAsync();
            var dto = Mapper.Map<FooterVM>(entity);
            return dto;
        }
    }
}
