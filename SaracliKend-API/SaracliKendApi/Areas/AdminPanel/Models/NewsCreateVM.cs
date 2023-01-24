using SaracliKend.Application.Models;

namespace SaracliKendApi.Areas.AdminPanel.Models
{
    public class NewsCreateVM
    {
        public NewsViewModel News { get; set; }

        public IFormFile? Image { get; set; }
    }
}
