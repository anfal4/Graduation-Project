using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class AddUserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [RegularExpression(@"^[^@]+@.*\.edu(\.iq)?$", ErrorMessage = "Registration is allowed only with university email.")]
        public string Email { get; set; }

        public string organization { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


    }
}
