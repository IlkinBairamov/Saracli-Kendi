using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Core.Repositories;
using SaracliKend.Domain.Common.Contracts;

namespace SaracliKend.Application.Services
{
    public abstract class CrudService<TDto, TEntity, TEntityDal> : ICrudService<TDto>
         where TEntity : class, IEntity
         where TEntityDal : class, IRepository<TEntity>
    {
        protected readonly TEntityDal EntityDal;
        protected readonly IMapper Mapper;

        public CrudService(TEntityDal tEntityDal, IMapper mapper)
        {
            EntityDal = tEntityDal;
            Mapper = mapper;
        }

        public virtual async Task CreateAsync(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);
            await EntityDal.CreateAsync(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            var data = await GetAsync(id);
            await DeleteAsync(data);
        }

        public virtual async Task DeleteAsync(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);
            await EntityDal.DeleteAsync(entity);
        }

        public virtual async Task<List<TDto>> GetAllAsync(params string[] includes)
        {
            var entites = await EntityDal.GetAll(includes).ToListAsync();
            return Mapper.Map<List<TDto>>(entites);
        }

        public virtual async Task<TDto> GetAsync(int id, params string[] includes)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            return Mapper.Map<TDto>(await EntityDal.GetAsync(id, includes));
        }

        public virtual async Task UpdateAsync(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);
            await EntityDal.UpdateAsync(entity);
        }
    }
}
