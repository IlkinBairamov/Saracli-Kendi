using SaracliKend.Application.Models;

namespace SaracliKendApi.Areas.AdminPanel.Models
{
    public class SchoolCreateVM
    {
        public SchoolModel School { get; set; }

        public IFormFile? Image { get; set; }
    }
}
