using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using exam.Models;


namespace exam.Models
{
    public class ActivityViewModel 
    {
        
        
        [Required]
        [MinLength(2,ErrorMessage = "This field require at least 2 Characters")]
        
        
        public string Title { get; set;}
        [Required]
        [ CheckFuture]
        [DataType(DataType.Date)]
        public DateTime Date { get; set;}

        [Required]
        [CheckFuture]
        [DataType(DataType.Time)]
        public DateTime Time { get; set;}

        [Required]
        
        public int Duration { get; set;}

        [Required]
        [MinLength(2,ErrorMessage = "Description must be at least 2 Characters")]
        
        
        public string Description { get; set;}

    }
}