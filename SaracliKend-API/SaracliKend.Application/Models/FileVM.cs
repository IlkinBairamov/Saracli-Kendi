using SaracliKend.Domain.Enums;

namespace SaracliKend.Application.Models
{
    public class FileViewModel
    {
        public int Id { get; set; }

        public string Path { get; set; } = string.Empty;

        public string? Name { get; set; }

        public FileType FileType { get; set; }
    }
}
