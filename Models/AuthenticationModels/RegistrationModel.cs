using System.ComponentModel.DataAnnotations;

namespace Models.AuthenticationModels
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "No Email was specified")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "No Username was specified")]
        public string Username { get; set; }

        [Required(ErrorMessage = "No Username was specified")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "No Password was specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}