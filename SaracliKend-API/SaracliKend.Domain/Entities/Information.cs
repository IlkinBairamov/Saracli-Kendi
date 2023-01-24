using SaracliKend.Domain.Common.Contracts;
using SaracliKend.Domain.Enums;

namespace SaracliKend.Domain.Entities
{
    public class Information : IEntity
    {
        public int Id { get; set; }

        public string DescriptionFirstPart { get; set; } = string.Empty;

        public string DescriptionSecondPart { get; set; } = string.Empty;

        public ICollection<InformationImage> Images { get; set; }

        public InformationType InformationType { get; set; }
    }
}
