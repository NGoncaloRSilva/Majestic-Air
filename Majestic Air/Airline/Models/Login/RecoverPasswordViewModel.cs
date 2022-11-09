using System.ComponentModel.DataAnnotations;

namespace Airline.Models.Login
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
