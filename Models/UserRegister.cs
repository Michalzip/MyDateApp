using System;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
namespace App.Models
{
    public class UserRegisterModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        [Display(Name = "Email")]
        public string? Email { get; set; }


        [Required]
        [StringLength(15,MinimumLength= 3)]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Required]
        [StringLength(27, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password
        {
            get; set;



        }
    }
}

