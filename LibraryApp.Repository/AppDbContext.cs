using LibraryApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repository
{
    public class AppDbContext : DbContext
    {
        // constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // for db tables
        public DbSet<Book> Books { get; set; }

        // set all configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
