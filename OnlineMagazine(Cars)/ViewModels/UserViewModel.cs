using OnlineMagazine.Data.Models.Entities;
using OnlineMagazine.Data.Models;

namespace OnlineMagazine.ViewModels
{
    public class UserViewModel
    {
        public User user { get; set; }
        public LoginModel loginModel { get; set; }
        public string ConfirmPassword { get; set; }
        public string ErrorMessage { get; set; }
    }
}
