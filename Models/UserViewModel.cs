using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using exam.Models;


namespace exam.Models
{
    public class UserViewModel 
    {
        
        
        [Required]
        [MinLength(2,ErrorMessage = "A real First Name is required")]
        
        
        public string FirstName{ get; set;}
        [Required]
        [MinLength(2,ErrorMessage = "A real Last Name is required")]
        public string LastName{ get; set;}

        [Required]
        [EmailAddress]
        public string Email{ get; set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        // [RegularExpression(@"(?=.\d)(?=.[A-Z])(?=.[a-z]).$", ErrorMessage = "Password must contain at least one uppercase, one lowercase, and one number.")]
        public string Password{ get; set;}

        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        public string PasswordConfirm{ get; set;}

    }
}