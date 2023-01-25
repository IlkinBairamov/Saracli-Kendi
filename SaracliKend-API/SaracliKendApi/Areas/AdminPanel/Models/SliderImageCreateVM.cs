using SaracliKend.Application.Models;

namespace SaracliKendApi.Areas.AdminPanel.Models
{
    public class SliderImageCreateVM
    {
        public SliderViewModel SliderImage { get; set; } = new SliderViewModel();

        public IFormFile File { get; set; }
    }
}
