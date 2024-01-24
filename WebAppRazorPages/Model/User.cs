using System.ComponentModel.DataAnnotations;

namespace WebAppRazorPages.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        public string Email { get; set; }

        public User() 
        { 
            Name ??= string.Empty;
            Email ??= string.Empty;
        }
    }
}
