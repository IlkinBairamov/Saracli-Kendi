using SaracliKend.Domain.Enums;

namespace SaracliKend.Application.Models
{
    public class FileListVM
    {
        public List<FileViewModel> Files { get; set; }

        public FileType FileType { get; set; }
    }
}
