using Microsoft.AspNetCore.Identity;
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

        [HttpGet]//api/Account/Login
        public async Task<bool> Login([FromBody] User user)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(user.UserName,
                    user.Password,
                    false,
                    lockoutOnFailure: false);
            if (loginResult.Succeeded) return true;
            else return false;
        }


        [HttpGet] //api/Account/IsAdmin
        //Метод проверки у пользователя роли администратора
        public async Task<bool> IsAdmin([FromBody] string username)
        {
            var usernow = await _userManager.FindByNameAsync(username); //
            var r = await _userManager.IsInRoleAsync(usernow, "Admin");
            return r;
        }
    }
}
