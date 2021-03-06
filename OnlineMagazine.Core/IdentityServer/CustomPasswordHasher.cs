using BankApp.Core.Utils;
using OnlineMagazine.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace OnlineMagazine.IdentityServer
{
    public class CustomPasswordHasher : IPasswordHasher<User>
    {
        public string HashPassword(User user, string password)
        {
            password = SecurityUtil.ComputeSha256Hash(user.PasswordHash);

            return password;
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            var providedPasswordHash = SecurityUtil.ComputeSha256Hash(providedPassword);

            if(hashedPassword == providedPasswordHash)
            {
                return PasswordVerificationResult.Success;
            }
            return PasswordVerificationResult.Failed;
        }
    }
}
