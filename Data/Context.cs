﻿using Microsoft.EntityFrameworkCore;
using System;

namespace Wendel_d7_avaliacao.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(GetUsers());
            base.OnModelCreating(modelBuilder);
        }

        private static User[] GetUsers()
        {
            return new User[]
            {
            new User
            {
                Id = Guid.NewGuid(),
                Name = "CTEDS",
                Email = "admin@email.com",
                Password = "admin123"
            }
            };
        }
    }
}
