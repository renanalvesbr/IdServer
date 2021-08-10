using System.ComponentModel.DataAnnotations;

namespace Senff.IdServer.Admin.Api.Dtos.Users
{
    public class UserChangePasswordApiDto<TKey>
    {
        public TKey UserId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}







