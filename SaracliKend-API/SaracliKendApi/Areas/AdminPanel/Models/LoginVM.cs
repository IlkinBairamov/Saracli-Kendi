using System.ComponentModel.DataAnnotations;

namespace SaracliKendApi.Areas.AdminPanel.Models
{
    public class LoginVM
    {
        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
