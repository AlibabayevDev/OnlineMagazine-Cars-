using BankApp.Core.Utils;
using OnlineMagazine.Data.Models.Entities;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using OnlineMagazine.Data.Models;
using OnlineMagazine.Data.Models;
using OnlineMagazine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMagazine.Controllers
{
    public class AccountController : Controller
    {
        private static string ConfirmPass { get; set; }
        public static UserViewModel selectedModel;

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var user = userManager.FindByNameAsync(model.Email).Result;
            if (user == null)
            {
                return Content("UserName or password is incorrect");
            }
            
            var signInResult = signInManager.PasswordSignInAsync(user, model.Password, true, false).Result;

            if(signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return Content("Username or password is incorrect");
        }

        [HttpGet]
        public IActionResult Regist( )
        {
            return View();
        }


        [HttpPost]
        public IActionResult Regist(UserViewModel model)
        {
            try
            {
                Random rnd = new Random();
                ConfirmPass = rnd.Next(100000, 999999).ToString();
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Adminstrator", "alibabaev375@mail.ru"));
                message.To.Add(new MailboxAddress("naren", model.user.Email));
                message.Subject = "Confirm Password";
                message.Body = new TextPart("plain")
                {
                    Text = ConfirmPass
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.mail.ru", 25, false);
                    client.Authenticate("alibabaev375@mail.ru", "UnhvOfx824cPnFhevo3g");
                    client.Send(message);
                    client.Disconnect(true);
                }
                selectedModel = model;
                return View("Complete", model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Такой email не существует";
                return View(model);
            }

        }



        public IActionResult Complete(UserViewModel model)
        {
            if(model.ConfirmPassword == ConfirmPass)
            {
                string password = selectedModel.user.PasswordHash;
                if (selectedModel.user.PasswordHash != null)
                {
                    var user = userManager.CreateAsync(selectedModel.user, selectedModel.user.PasswordHash).Result;
                    if (user.Succeeded)
                    {
                        var signInResult = signInManager.PasswordSignInAsync(selectedModel.user, password, true, false).Result;
                        
                        if (signInResult.Succeeded)
                        {
                            return RedirectToActionPermanent("Index", "Home");
                        }
                    }
                    else
                    {
                        foreach (var i in user.Errors)
                        {
                            selectedModel.ErrorMessage += i.Description;
                            ViewBag.Error = selectedModel.ErrorMessage;
                        }
                        return View(selectedModel);
                    }
                }
            }
            return View();
        }


        [Authorize]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); 
        }

        public IActionResult AccessDenied()
        {
            return Content("You have no any access for this page");
        } 
    }
        
}
