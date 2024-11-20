﻿// <auto-generated />
using System;
using EduFlex.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EduFlex.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EduFlex.Domain.Entities.Attendances.Attendance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("SessionId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.HasIndex("UserId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Courses.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Exams.Exam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("ExamResult")
                        .HasColumnType("real");

                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Groups.Group", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("TeacherId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Sessions.Session", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Users.UserGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Users.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Attendances.Attendance", b =>
                {
                    b.HasOne("EduFlex.Domain.Entities.Sessions.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EduFlex.Domain.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Session");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Exams.Exam", b =>
                {
                    b.HasOne("EduFlex.Domain.Entities.Groups.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EduFlex.Domain.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Groups.Group", b =>
                {
                    b.HasOne("EduFlex.Domain.Entities.Courses.Course", "Course")
                        .WithMany("Groups")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EduFlex.Domain.Entities.Users.User", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Sessions.Session", b =>
                {
                    b.HasOne("EduFlex.Domain.Entities.Groups.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Users.UserGroup", b =>
                {
                    b.HasOne("EduFlex.Domain.Entities.Groups.Group", "Group")
                        .WithMany("UserGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EduFlex.Domain.Entities.Users.User", "User")
                        .WithMany("UserGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Users.UserRole", b =>
                {
                    b.HasOne("EduFlex.Domain.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Courses.Course", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Groups.Group", b =>
                {
                    b.Navigation("UserGroups");
                });

            modelBuilder.Entity("EduFlex.Domain.Entities.Users.User", b =>
                {
                    b.Navigation("UserGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
