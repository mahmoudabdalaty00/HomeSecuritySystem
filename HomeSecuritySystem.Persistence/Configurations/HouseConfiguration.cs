using HomeSecuritySystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeSecuritySystem.Persistence.Configurations
{
    public class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        //we can use this as conditions to configure the database
        // this is just an example
        /*   
           public void Configure(EntityTypeBuilder<House> builder)
           {
               builder.HasKey(h => h.Id);
               builder.Property(h => h.Name).IsRequired();
               builder.Property(h => h.Address).IsRequired();
               builder.Property(h => h.City).IsRequired();
               builder.Property(h => h.Region).IsRequired();
               builder.Property(h => h.PostalCode).IsRequired();
               builder.Property(h => h.Country).IsRequired();
           }

   */

        // here we are seeding the database to test our work first 
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasData(
                 new House
                 {
                     Id = 1,
                     Name = "House 1",
                     Address = "1234 Main St",
                     City = "City",
                     Region = "Region",
                     PostalCode = 12345,
                     Country = "Country",
                     Devices = null,
                     Users = null,
                 },
                 new House
                 {
                     Id = 2,
                     Name = "House 2",
                     Address = "1234 Main St",
                     City = "City",
                     Region = "Region",
                     PostalCode = 12345,
                     Country = "Country"
                 },
                 new House
                 {
                     Id = 3,
                     Name = "House 3",
                     Address = "1234 Main St",
                     City = "City",
                     Region = "Region",
                     PostalCode = 12345,
                     Country = "Country"
                 },
                 new House
                 {
                     Id = 4,
                     Name = "House 4",
                     Address = "1234 Main St",
                     City = "City",
                     Region = "Region",
                     PostalCode = 12345,
                     Country = "Country"
                 },
                 new House
                 {
                     Id = 5,
                     Name = "House 5",
                     Address = "1234 Main St",
                     City = "City",
                     Region = "Region",
                     PostalCode = 12345,
                     Country = "Country"
                 }

             );
        }



    }
}
