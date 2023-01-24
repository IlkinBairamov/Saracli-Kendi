using SaracliKend.Application.Models;

namespace SaracliKendApi.Areas.AdminPanel.Models
{
    public class FileCreateVM
    {
        public FileViewModel FileModel { get; set; }

        public IFormFile File { get; set; }
    }
}
