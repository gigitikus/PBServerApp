using System.ComponentModel.DataAnnotations;

namespace PBShared.Models
{
    [Serializable]
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
