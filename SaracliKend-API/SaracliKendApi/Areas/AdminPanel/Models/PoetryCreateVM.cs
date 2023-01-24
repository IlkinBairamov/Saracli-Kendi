using SaracliKend.Application.Models;

namespace SaracliKendApi.Areas.AdminPanel.Models
{
    public class PoetryCreateVM
    {
        public PoetryVM Story { get; set; }

        public List<PersonModel>? Writers { get; set; }
    }
}
