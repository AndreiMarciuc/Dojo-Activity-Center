using System;
using System.ComponentModel.DataAnnotations;
namespace exam.Models
{
    public class CheckEighteen: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext){
            DateTime Today = DateTime.Now;
            DateTime EighteenYears = new DateTime(Today.Year - 18, Today.Month,Today.Day);
            if((DateTime)value> EighteenYears)
            {
                return new ValidationResult("Must be 18 Years or Older to Join");
            }
            return ValidationResult.Success;
        }
    }


    public class CheckFuture: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext){
            DateTime Today = DateTime.Now;
            
            if((DateTime)value<Today )
            {
                return new ValidationResult("Date must be in the Future");
            }
            return ValidationResult.Success;
        }
    }
    public class CheckPast: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext){
            DateTime Today = DateTime.Now;
            
            if((DateTime)value>Today )
            {
                return new ValidationResult("Date must be in the Future");
            }
            return ValidationResult.Success;
        }
    }
    public class MinQuantity: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext){
            DateTime Today = DateTime.Now;
            
            if((int)value <1)
            {
                return new ValidationResult("quantity must be at leat 1");
            }
            return ValidationResult.Success;
        }
    }
}

