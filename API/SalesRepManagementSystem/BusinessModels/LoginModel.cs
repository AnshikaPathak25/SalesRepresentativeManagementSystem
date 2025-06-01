using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class LoginModel
    {
        [DisplayName("Email Id")]
        [Required(ErrorMessage = "Email Id is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Id")]
        public string EmailId { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
