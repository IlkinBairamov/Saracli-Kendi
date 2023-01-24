using SaracliKend.Application.Models;

namespace SaracliKendApi.Areas.AdminPanel.Models
{
    public class PersonCreateViewModel
    {
        public PersonModel Person { get; set; }

        public IFormFile? Image { get; set; }
    }
}
