using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Rol seçiniz.")]
        public string Role { get; set; } = "Student"; // Student | Advisor

        [Required(ErrorMessage = "Kullanıcı adı zorunlu.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parola zorunlu.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; } = true;
    }
}
