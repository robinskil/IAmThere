using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAmThereApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IAmThereApi.DAO
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Area> PlaceLocation{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserGroup>()
                .HasKey(ug => new {ug.UserId , ug.GroupId });
            modelBuilder
                .Entity<User>()
                .HasAlternateKey(u => u.Email);
            modelBuilder
                .Entity<Location>()
                .Property(l => l.LocationDefinitionMode)
                .HasConversion(
                    v => v.ToString(),
                    v => (LocationDefinitionMode)Enum.Parse(typeof(LocationDefinitionMode), v));
        }
    }
}
