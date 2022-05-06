﻿using DataPush.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataPush.Infra
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            CreateTables();
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

        private void CreateTables()
        {
            Database.EnsureDeleted();
            Database.EnsureDeleted();
        }
    }
}