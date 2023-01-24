using SaracliKend.Domain.Common.Contracts;

namespace SaracliKend.Domain.Entities
{
    public class InformationImage : IEntity
    {
        public int Id { get; set; }

        public string Path { get; set; } = string.Empty;

        public Information Information { get; set; }

        public int InformationId { get; set; }
    }
}
