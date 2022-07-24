using OnlineMagazine.Data.Models.Entities;
using OnlineMagazine.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineMagazine.ViewModels
{
    public class UserViewModel
    {
        public User user { get; set; }
        public LoginRequestModel loginModel { get; set; }
        public string ConfirmPassword { get; set; }
        public string ErrorMessage { get; set; }
    }
}
