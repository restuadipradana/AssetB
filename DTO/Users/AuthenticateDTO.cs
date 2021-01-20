using System.ComponentModel.DataAnnotations;

namespace AssetB.DTO.Users
{
    public class AuthenticateDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}