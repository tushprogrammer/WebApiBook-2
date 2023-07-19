using Microsoft.AspNetCore.Identity;

namespace WebApiBook_2.AuthPersonApp
{
    public class User : IdentityUser
    {
        public string Password { get; set; }
    }
}
