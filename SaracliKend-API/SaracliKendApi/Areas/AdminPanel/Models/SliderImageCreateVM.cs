using SaracliKend.Application.Models;

namespace SaracliKendApi.Areas.AdminPanel.Models
{
    public class SliderImageCreateVM
    {
        public SliderViewModel SliderImage { get; set; }

        public IFormFile Image { get; set; }
    }
}
