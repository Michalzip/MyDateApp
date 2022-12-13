using System;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using App.Interfaces;
namespace App.Models
{




    public class UserDTO 
    {

        public UserSignUp? userBasicData;

        [Display(Name = "AvatarImage")]
        public string? AvatarImage { get; set; }

        public UserHiddenProperty? userHiddenProperty;
    }



    public class UserSignUp 
    {


        [Required]
        [Display(Name = "firstName")]
        public string? firstName { get; set; }

        [Required]
        [Display(Name = "lastName")]
        public string? lastName { get; set; }


        [Required]
        [Display(Name = "userName")]
        public string? userName { get; set; }


        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }


        [Required]
        [Display(Name = "Password")]
        public string? Password { get; set; }


        public UserSignUpHiddenProperty? userHiddenData;



    }


    public class UserSignIn{
     
     [Required]
     [Display(Name = "Email")]
     public string? Email { get; set; }
     

     [Required]
     [Display(Name = "Password")]
     public string? Password { get; set; }
     
    }



    public class UserSignUpHiddenProperty : IUserSignUp
    {
        //public string? PasswordSolc { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class UserHiddenProperty: IUpdateTime
    {
        public DateTime? UpdatedAt { get; set; }
    }


}

