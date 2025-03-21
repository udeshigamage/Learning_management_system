﻿using Learning_management_system.Models;
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


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //customize Tb_users table
            //modelBuilder.Entity<User>().HasKey();
        }

    }

}
