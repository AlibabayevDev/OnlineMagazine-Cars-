using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineMagazine.Data.Models;
using OnlineMagazine.Data.Models.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagazinWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginRequestModel loginModel)
        {
            var user = userManager.FindByNameAsync(loginModel.Email).Result;
            if (user == null)
            {
                return BadRequest("UserName or password is incorrect");
            }

            var signInResult = signInManager.PasswordSignInAsync(user, loginModel.Password, true, false).Result;

            if (signInResult.Succeeded == false)
            {
                return BadRequest("Username or password is incorrect");
            }

            string token = GenerateJwtToken(user);

            return Ok(new LoginResponseModel
            {
                Email = user.Email,
                Token = token,
            });

        }

        #region private logic

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes("xecretKeywqejane");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                }),
                Expires = DateTime.Now.AddDays(15), //Token expires after 15 days
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        #endregion

    }
}
