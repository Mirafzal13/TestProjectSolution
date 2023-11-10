using System.ComponentModel.DataAnnotations;

namespace TestProject.UI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле Логин обязательное")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Поле Пароль обязательное")]
        public string Password { get; set; }
    }
}
