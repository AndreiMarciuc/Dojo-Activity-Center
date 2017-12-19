using System;
using System.Collections.Generic;


namespace exam.Models
{
    public class UserActivity
    {
        public int UserActivityId {get; set;}
        public int UserId {get; set;}
        public User JoiningUser{get; set;}
        public int ActivityId {get; set;}
        public Activity JoiningActivity{get; set;}
    }
}
