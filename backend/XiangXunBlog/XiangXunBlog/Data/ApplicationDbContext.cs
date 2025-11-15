using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection.Metadata;
using XiangXunBlog.Models;

namespace XiangXunBlog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // USER CONFIG
            modelBuilder.Entity<User>().ToTable("x_users");

            modelBuilder.Entity<User>()
                .HasMany<Post>()
                .WithOne(e => e.Author)
                .HasForeignKey(e => e.AuthorId)
                .IsRequired();

            // POST CONFIG
            modelBuilder.Entity<Post>().ToTable("x_posts");

            //modelBuilder.Entity<Post>().Property(p => p.Created)
            //   .HasDefaultValueSql("CURRENT_TIMESTAMP")
            //   .ValueGeneratedOnAdd();

            //modelBuilder.Entity<Post>().Property(p => p.LastUpdated)
            //    .HasDefaultValueSql("CURRENT_TIMESTAMP")
            //    .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Post>()
                .HasOne(e => e.Author)
                .WithMany()
                .HasForeignKey(e => e.AuthorId)
                .IsRequired();

            modelBuilder.Entity<Post>()
                .HasOne(e => e.Category)
                .WithMany(e => e.Posts)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired();

            // CATEGORY CONFIG
            modelBuilder.Entity<Category>().ToTable("x_categories");

            //modelBuilder.Entity<Category>().Property(c => c.Created)
            //    .HasDefaultValueSql("CURRENT_TIMESTAMP")
            //    .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Posts)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired();


        }
        #endregion

    }
}
