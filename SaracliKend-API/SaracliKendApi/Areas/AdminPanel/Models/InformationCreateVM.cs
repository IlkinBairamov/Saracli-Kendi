using SaracliKend.Application.Models;
using SaracliKend.Domain.Enums;

namespace SaracliKendApi.Areas.AdminPanel.Models
{
    public class InformationCreateVM
    {
        public InformationVM Information { get; set; }

        public InformationType Type { get; set; }

        public List<IFormFile>? Images { get; set; }

        public IFormFile? Image { get; set; }
    }
}
