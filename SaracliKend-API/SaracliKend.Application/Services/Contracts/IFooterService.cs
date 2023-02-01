using SaracliKend.Application.Models;

namespace SaracliKend.Application.Services.Contracts
{
    public interface IFooterService : ICrudService<FooterVM>
    {
        Task<FooterVM> GetFooterAsync();
    }
}
