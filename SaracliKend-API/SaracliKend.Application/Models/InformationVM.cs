using SaracliKend.Domain.Enums;

namespace SaracliKend.Application.Models
{
    public class InformationVM
    {
        public int Id { get; set; }

        public string DescriptionFirstPart { get; set; } = string.Empty;

        public string DescriptionSecondPart { get; set; } = string.Empty;

        public List<string>? Images { get; set; }

        public InformationType InformationType { get; set; }
    }
}
