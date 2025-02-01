using HomeSecuritySystem.Domain;
using HomeSecuritySystem.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSecuritySystem.Persistence.DBContext
{
    public  class HSSDatabaseContext : DbContext
    {
        public HSSDatabaseContext(DbContextOptions<HSSDatabaseContext> options) : base(options)
        {

        }

        public DbSet<House> houses { get; set; }

        public DbSet<Device> devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //we can use this to configure the database entities in the domain were we make configurations  
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(HSSDatabaseContext).Assembly);
            //or we can use this  way where we need to use line to every entity configuration
            //not recommended
            //modelBuilder.ApplyConfiguration(new HouseConfiguration());


            // or we can use this to seed the database instead of using  the above state 
            /*  modelBuilder.Entity<House>().HasData(
                     new House
                     {
                         Id = 1,
                         Name = "House 1",
                         Address = "1234 Main St",
                         City = "City",
                         Region = "Region",
                         PostalCode = 12345,
                         Country = "Country"
                     }
                 );
            */

            base.OnModelCreating(modelBuilder);
        }
    }
}
