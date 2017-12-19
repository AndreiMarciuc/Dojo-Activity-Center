using Microsoft.EntityFrameworkCore;
 
namespace exam.Models
{
    public class ExamContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ExamContext(DbContextOptions<ExamContext> options) : base(options) { }
        public DbSet<User> Users {get; set;} 
        public DbSet<Activity> Activities {get; set;} 
        public DbSet<UserActivity> UserActivities {get; set;} 
    }
}