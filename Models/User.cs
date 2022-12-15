using System;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using App.Interfaces;
namespace App.Models
{


    public class UserDto
    {

        [Required]
        [Display(Name = "firstName")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "lastName")]
        public string? LastName { get; set; }

        [Required]
        [Display(Name = "userName")]
        public string? UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }


    }



    public class UserDetailDto
    {


        [Required]
        [Display(Name = "firstName")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "lastName")]
        public string? LastName { get; set; }


        [Required]
        [Display(Name = "userName")]
        public string? UserName { get; set; }


        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }


        [Required]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        public UserProfileAvatar? UserAvatar;

        public UserDataTime? UserDataTime;

    }


    public class UserAuthModel
    {

        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string? Password { get; set; }

    }


    public class UserDataTime : IUserDataTime
    {
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

    public class UserProfileAvatar : IUserAvatar
    {

        public string? UserAvatar { get; set; }

    }




}

