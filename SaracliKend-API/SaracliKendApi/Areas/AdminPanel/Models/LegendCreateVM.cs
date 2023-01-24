using SaracliKend.Application.Models;

namespace SaracliKendApi.Areas.AdminPanel.Models
{
    public class LegendCreateVM
    {
        public LegendVM Legend { get; set; }

        public IFormFile? Image { get; set; }
    }
}
