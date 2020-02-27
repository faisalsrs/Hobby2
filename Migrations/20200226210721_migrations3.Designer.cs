﻿// <auto-generated />
using System;
using BeltExam3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeltExam3.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200226210721_migrations3")]
    partial class migrations3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BeltExam3.Models.Hobby", b =>
                {
                    b.Property<int>("HobbyId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("HobbyId");

                    b.HasIndex("UserId");

                    b.ToTable("Hobbies");
                });

            modelBuilder.Entity("BeltExam3.Models.JOIN", b =>
                {
                    b.Property<int>("JOINId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("EventId");

                    b.Property<int?>("PostJOINHobbyId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("JOINId");

                    b.HasIndex("PostJOINHobbyId");

                    b.HasIndex("UserId");

                    b.ToTable("Join");
                });

            modelBuilder.Entity("BeltExam3.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("createdAt");

                    b.Property<string>("fname")
                        .IsRequired();

                    b.Property<string>("lname")
                        .IsRequired();

                    b.Property<string>("password");

                    b.Property<DateTime>("updatedAt");

                    b.Property<string>("username")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BeltExam3.Models.Hobby", b =>
                {
                    b.HasOne("BeltExam3.Models.User", "Creator")
                        .WithMany("CreatedHobbies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeltExam3.Models.JOIN", b =>
                {
                    b.HasOne("BeltExam3.Models.Hobby", "PostJOIN")
                        .WithMany("CreatedJOINs")
                        .HasForeignKey("PostJOINHobbyId");

                    b.HasOne("BeltExam3.Models.User", "UserJOIN")
                        .WithMany("CreatedJOINs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
