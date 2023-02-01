using System.ComponentModel.DataAnnotations;

namespace SaracliKend.Application.Models
{
    public class FooterVM
    {
        public int Id { get; set; }

        public string About { get; set; } = string.Empty;

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumebr { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        public string FacebookUrl { get; set; } = string.Empty;

        public string InstagramUrl { get; set; } = string.Empty;
    }
}
