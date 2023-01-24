namespace SaracliKend.Application.Services.Contracts
{
    public interface ICrudService<TDto>
    {
        Task<List<TDto>> GetAllAsync(params string[] includes);

        Task<TDto> GetAsync(int id, params string[] includes);

        Task CreateAsync(TDto dto);

        Task UpdateAsync(TDto dto);

        Task DeleteAsync(TDto dto);

        Task DeleteAsync(int id);
    }
}
