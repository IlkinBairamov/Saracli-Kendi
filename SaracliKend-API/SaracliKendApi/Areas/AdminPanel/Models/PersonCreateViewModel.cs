using SaracliKend.Application.Models;

namespace SaracliKendApi.Areas.AdminPanel.Models
{
    public class PersonCreateViewModel
    {
        public PersonModel Person { get; set; } = null!;

        public IFormFile? Image { get; set; }
    }
}
