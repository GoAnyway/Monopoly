using System.ComponentModel.DataAnnotations;

namespace Models.AuthenticationModels
{
    public class AuthenticationModel
    {
        [Required(ErrorMessage = "No Username was specified")]
        public string Username { get; set; }

        [Required(ErrorMessage = "No Password was specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}