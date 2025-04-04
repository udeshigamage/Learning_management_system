﻿// <auto-generated />
using System;
using Learning_management_system.dbcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Learning_management_system.Migrations
{
    [DbContext(typeof(Appdbcontext))]
    [Migration("20250321091815_seventh")]
    partial class seventh
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Learning_management_system.Models.Courses", b =>
                {
                    b.Property<int>("Course_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Course_Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Course_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Createddate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Modifieddate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Course_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Tb_Courses");
                });

            modelBuilder.Entity("Learning_management_system.Models.Courssemodules", b =>
                {
                    b.Property<int>("Module_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Course_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Createddate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Modifieddate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Module_Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Module_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Module_Id");

                    b.HasIndex("Course_Id");

                    b.ToTable("Tb_Coursemodules");
                });

            modelBuilder.Entity("Learning_management_system.Models.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Createddate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("User_Type")
                        .HasColumnType("int");

                    b.HasKey("User_Id");

                    b.ToTable("Tb_Users");
                });

            modelBuilder.Entity("Learning_management_system.Models.Courses", b =>
                {
                    b.HasOne("Learning_management_system.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Learning_management_system.Models.Courssemodules", b =>
                {
                    b.HasOne("Learning_management_system.Models.Courses", "Courses")
                        .WithMany()
                        .HasForeignKey("Course_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
