using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TareaDbContext : DbContext
    {
        public TareaDbContext(DbContextOptions<TareaDbContext> options) : base(options)
        {        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de AppUser con JobArea
            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.JobArea)
                .WithMany(j => j.AppUsers)
                .HasForeignKey(u => u.JobAreaId);

            // Configuración de AppUser con JobTask
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.JobTasksList)
                .WithOne(j => j.AppUser)
                .HasForeignKey(j => j.AppUserId);


            // Configuración de AppUser con Comment
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.CommentsList)
                .WithOne(c => c.AppUser)
                .HasForeignKey(c => c.AppUserId);
                

            // Configuración de JobTask con Comment
            modelBuilder.Entity<JobTask>()
                .HasMany(j => j.CommentsLists)
                .WithOne(c => c.JobTask)
                .HasForeignKey(c => c.JobTaskNewId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<JobArea>()
            //    .HasMany( r => r.AppUsers)
            //    .WithOne( u => u.JobArea)
            //    .HasForeignKey( u => u.JobAreaId);

            //modelBuilder.Entity<JobTask>()
            //    .HasOne( u => u.AppUser)
            //    .WithMany( j => j.JobTasksList)
            //    .HasForeignKey( f => f.AppUserId);

            //modelBuilder.Entity<Comment>()
            //    .HasOne(u => u.JobTask)
            //    .WithMany(j => j.CommentsLists)
            //    .HasForeignKey(f => f.JobTaskNewId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Comment>()
            //    .HasOne(u => u.AppUser)
            //    .WithMany(j => j.CommentsList)
            //    .HasForeignKey(f => f.AppUserId)
            //    .OnDelete(DeleteBehavior.Cascade);





            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<JobArea> JobAreas { get; set; }

        public DbSet<JobTask> JobTasks { get; set; }

        public DbSet<Comment> Comments { get; set; }

    }
}