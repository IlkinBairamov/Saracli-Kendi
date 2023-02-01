using SaracliKend.Domain.Common.Contracts;

namespace SaracliKend.Domain.Entities
{
    public class Footer : IEntity
    {
        public int Id { get; set; }

        public string About { get; set; } = string.Empty;

        public string PhoneNumebr { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string FacebookUrl { get; set; } = string.Empty;

        public string InstagramUrl { get; set; } = string.Empty;
    }
}
