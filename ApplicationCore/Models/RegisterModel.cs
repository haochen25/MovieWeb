using ApplicationCore.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="can not be empty")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "can not be empty")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "can not be empty")]
        [EmailAddress(ErrorMessage = "please enter an valid email address")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required(ErrorMessage = "can not be empty")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "can not be empty")]
        [DataType(DataType.Date)]
        [YearValidation(1900,2000)]
        public DateTime DateOfBirth { get; set; }
    }
}
