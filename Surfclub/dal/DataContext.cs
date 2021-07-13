using Microsoft.EntityFrameworkCore;
using Surfclub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surfclub.dal
{
   
        public class DataContext : DbContext
        {
        public DbSet<News> News { get; set; }
        public DbSet<User> Users { get; set; }
            public DataContext()
            {
                Database.EnsureCreated();
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=surfClub;Username=postgres;Password=sa");
            }
        }

    }

