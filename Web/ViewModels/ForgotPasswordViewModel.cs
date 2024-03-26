using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@"^[^@]+@.*\.edu(\.iq)?$", ErrorMessage = "Password reset is allowed only with university email.")]
        public string Email { get; set; }
    }
}
