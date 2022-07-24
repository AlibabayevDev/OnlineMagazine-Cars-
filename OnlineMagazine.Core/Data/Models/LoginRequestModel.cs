using System.ComponentModel.DataAnnotations;

namespace OnlineMagazine.Data.Models
{
    public class LoginRequestModel
    {
        public int Id { get; set; }

        [Display(Name = "Email"), MinLength(8), MaxLength(30), Required(ErrorMessage = "Длина не менее 6 символов")]
        public string Email { get; set; }

        [Display(Name = "Password"), MinLength(7), MaxLength(30), Required(ErrorMessage = "Длина не менее 6 символов")]
        public string Password { get; set; }

    }
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
