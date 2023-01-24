using System.ComponentModel.DataAnnotations;

namespace SaracliKend.Application.Models.Auth
{
    public class ChangePasswordVM
    {
        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password), Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }
    }
}
