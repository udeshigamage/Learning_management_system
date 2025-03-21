using Learning_management_system.Models;
using Microsoft.EntityFrameworkCore;


namespace Learning_management_system.dbcontext
{
    public class Appdbcontext:DbContext
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Courses> Courses { get; set; }

        public DbSet<Courssemodules> Courssemodules { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Assignment> Assignment { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        public DbSet<Quizes> Quizes { get; set; }

        public DbSet <Quizquestions> Quizquestions { get; set; }

        public DbSet <Quizoptions> Quizoptions { get; set; }

        public DbSet<Quizresult> Quizresult { get; set; }

        public DbSet<Announcement> Announcement { get; set; }

        public DbSet<Certifications> Certifications { get; set; }

        public DbSet<Forums> Forums { get; set; }

        public DbSet<Forumposts> Forumposts { get; set; }

        public DbSet<Liveclasses> Liveclasses { get; set; }






        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //customize Tb_users table
            //modelBuilder.Entity<User>().HasKey();
        }

    }

}
