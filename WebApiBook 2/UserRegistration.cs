using System.ComponentModel.DataAnnotations;

namespace WebApiBook_2
{
    public class UserRegistration
    {
        public string LoginProp { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
