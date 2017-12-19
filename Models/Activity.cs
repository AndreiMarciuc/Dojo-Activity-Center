using System;
using System.Collections.Generic;


namespace exam.Models
{
    public class Activity
    {
        public int ActivityId {get; set;}
        public string Title {get; set;}
        public DateTime Date {get; set;}
        public DateTime Time {get; set;}
        public int Duration {get; set;}
        public string Description{get; set;}
        public int Coordinator { get; set;}
        
        public List<UserActivity> JoiningUser{ get; set;}
        public Activity()
        {
            JoiningUser = new List<UserActivity>();
        }
    }
}
