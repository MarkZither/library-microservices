﻿using System;
using Library.Authors.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Authors.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaceOfBirth>().HasData(
                new PlaceOfBirth()
                {
                    Id = 1,
                    City = "São Paulo",
                    State = "São Paulo",
                    Country = "Brazil",
                },
                new PlaceOfBirth()
                {
                    Id = 2,
                    City = "Brasilia",
                    State = "Federal District",
                    Country = "Brazil",
                }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "Jack",
                    Surname = "Daniels",
                    PlaceOfBirthId = 1,
                    Birth = new DateTime(1953, 10,20)
                },
                new Author
                {
                    Id = 2,
                    Name = "Old",
                    Surname = "Parr",
                    PlaceOfBirthId = 2,
                    Birth = new DateTime(1962, 4, 12)
                }
            );
        }
    }
}