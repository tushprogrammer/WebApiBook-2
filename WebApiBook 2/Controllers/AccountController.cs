﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiBook_2.AuthPersonApp;
using WebApIBook_2;

namespace WebApiBook_2.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    //Контроллер для доступа к данным о пользователях
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost]//api/Account/Login
        public async Task<bool> Login([FromBody] UserModel user)
        {
            var listuser = _userManager.Users.ToList();
            try
            {
                var loginResult = _signInManager.PasswordSignInAsync(user.LoginProp,
                    user.Password,
                    false,
                    lockoutOnFailure: false).Result;
                if (loginResult.Succeeded)
                {
                    return true;
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            return false;
         
        }   


        [HttpGet("{username}")] //api/Account/username
        //Метод проверки у пользователя роли администратора
        public async Task<bool> GetIsAdmin(string username)
        {
            var usernow = await _userManager.FindByNameAsync(username); //
            var r = await _userManager.IsInRoleAsync(usernow, "Admin");
            return r;
        }
    }
}
