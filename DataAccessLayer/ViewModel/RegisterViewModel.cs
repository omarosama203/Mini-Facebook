using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModel
{
    public class RegisterViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        //[Remote("IsUserNameAvailable", "Account", ErrorMessage = "Username is already taken")]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateOnly Birthdate { get; set; }
        [Required]

        public string Gender { get; set; }
        [Required]
        public string Country { get; set; }
        public string? Img { get; set; }

    }
}
