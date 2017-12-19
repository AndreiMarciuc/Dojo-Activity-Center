using System;
using System.Collections.Generic;


namespace exam.Models
{
    public class User
    {
        public int UserID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public List<UserActivity> JoiningActivity{ get; set;}
        public User()
        {
            JoiningActivity = new List<UserActivity>();
        }
    }
}
