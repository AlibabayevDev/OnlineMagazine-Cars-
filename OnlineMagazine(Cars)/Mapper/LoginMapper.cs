using OnlineMagazine.Data.Models;
using OnlineMagazine.Data.Models.Entities;

namespace OnlineMagazine_Cars_.Mapper
{
    public class LoginMapper
    {
        public LoginRequestModel Map(User entity)
        {
            return new LoginRequestModel
            {
                Email = entity.Email,
                Password = entity.PasswordHash,
            }; 
        }

        public User Map(LoginRequestModel model)
        {
            return new User
            {
                Email = model.Email,
                PasswordHash = model.Password
            };
        }

    }
}
