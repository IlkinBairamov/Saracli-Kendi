using SaracliKend.Domain.Common.Contracts;

namespace SaracliKend.Domain.Entities
{
    public class News : IEntity
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public string Image { get; set; }
    }
}
