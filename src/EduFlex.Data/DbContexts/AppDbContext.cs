using EduFlex.Domain.Entities.Attendances;
using EduFlex.Domain.Entities.Courses;
using EduFlex.Domain.Entities.Exams;
using EduFlex.Domain.Entities.Groups;
using EduFlex.Domain.Entities.Sessions;
using EduFlex.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace EduFlex.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<UserRole> Roles { get; set; }  
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Exam> Exams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserGroup>()
        .HasKey(ug => ug.Id);

        modelBuilder.Entity<UserGroup>()
            .HasOne(ug => ug.User)
            .WithMany(u => u.UserGroups)
            .HasForeignKey(ug => ug.UserId)
            .OnDelete(DeleteBehavior.NoAction); 

        modelBuilder.Entity<UserGroup>()
            .HasOne(ug => ug.Group)
            .WithMany(g => g.UserGroups)
            .HasForeignKey(ug => ug.GroupId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
