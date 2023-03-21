using SaracliKend.Domain.Common.Contracts;
using SaracliKend.Domain.Enums;

namespace SaracliKend.Domain.Entities
{
    public class File : IEntity
    {
        public int Id { get; set; }

        public string Path { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public FileType FileType { get; set; }
    }
}
