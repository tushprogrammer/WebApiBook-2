using System.ComponentModel.DataAnnotations;

namespace WebApiBook_2.AuthPersonApp
{
    public class UserModel
    {
        [Required, MaxLength(20)]
        public string LoginProp { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } //пароль
    }
}
