using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string? UserName { get; set;}

        [Required]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set;}

        [Required]  
        [StringLength(10, ErrorMessage = "{0} have to be at least {2} character lenght.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required]  
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Password does not match.")]
        [Display(Name = "Replay Password")]
        public string? ConfirmPassword { get; set; }
    }
}