using Microsoft.EntityFrameworkCore;
using Server_chat_project.Models;

namespace Server_chat_project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ProjectMember> Members { get; set; }
        public DbSet<TaskAssignment> Assignments { get; set; }
        public DbSet<TaskItem> TaskItem { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        //fluent api configuration

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure User-Project many-to-many relationship
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(pm => new { pm.UserId });
                entity.Property(pm => pm.Username).IsRequired().HasMaxLength(150);
                entity.Property(pm => pm.UserEmail).IsRequired().HasMaxLength(150);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(pm => new { pm.ProjectId });
                entity.Property(pm => pm.ProjectName).IsRequired().HasMaxLength(200);
                entity.Property(pm => pm.ProjectDescription).HasMaxLength(1000);

                //creator relationship(User->projects)
                entity.HasOne(pm => pm.Creator)
                .WithMany(pm => pm.Projects)
                .HasForeignKey(pm => pm.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(t => t.TaskItemId);
                entity.Property(t => t.Title).IsRequired().HasMaxLength(200);
                entity.Property(t => t.Status).HasMaxLength(50);

                //project relationship(project-taskitems)
                entity.HasOne(t => t.Project)
                .WithMany(t => t.TaskItems)
                .HasForeignKey(t => t.ProjectId)
                 .OnDelete(DeleteBehavior.NoAction);
            });


            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.CommentId);

                entity.Property(c => c.Content).IsRequired().HasMaxLength(1000);

                // relationship (commeent-task)
                entity.HasOne(c => c.TaskItem).WithMany(t => t.Comments)
                .HasForeignKey(c => c.TaskId).OnDelete(DeleteBehavior.NoAction);

                //user relationship 
                entity.HasOne(c => c.User).WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            });


            //ProjectMember

            modelBuilder.Entity<ProjectMember>(entity =>
            {
                entity.HasKey(pm => new { pm.UserId, pm.ProjectId });
                entity.Property(pm => pm.Role).IsRequired().HasMaxLength(50);

                entity.HasOne(pm => pm.User)
                .WithMany(u => u.ProjectMembers)
                .HasForeignKey(pm => pm.UserId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(pm => pm.Project)
                .WithMany(u => u.ProjectMembers)
                .HasForeignKey(pm => pm.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);


            });

            //TaskAssignment
            modelBuilder.Entity<TaskAssignment>(entity =>
            {
                entity.HasKey(ta => new { ta.UserId, ta.TaskItemId });

                entity.HasOne(ta => ta.User)
                .WithMany(u => u.TaskAssignments)
                .HasForeignKey(ta => ta.UserId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(ta => ta.TaskItem)
                .WithMany(u => u.TaskAssignments)
                .HasForeignKey(ta => ta.TaskItemId)
                .OnDelete(DeleteBehavior.NoAction);


            });

            //role
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => new { r.RoleId });
                entity.Property(r => r.RoleName).IsRequired().HasMaxLength(100);
            });

            //userrole
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });
                entity.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.NoAction);


            });

        }

    }
}
