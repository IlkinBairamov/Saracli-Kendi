using SaracliKend.Application.Models;

namespace SaracliKendApi.Areas.AdminPanel.Models
{
    public class FunnyStoryCreateVM
    {
        public FunnyStoryVM Story { get; set; }

        public List<PersonModel>? Writers { get; set; }
    }
}
