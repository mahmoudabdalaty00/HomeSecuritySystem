using HomeSecuritySystem.Domain;
using HomeSecuritySystem.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HomeSecuritySystem.IntegrationTests
{
    public class HSSDatabaseContextTests
    {
        private HSSDatabaseContext _dbContext;

        public HSSDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<HSSDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _dbContext = new HSSDatabaseContext(dbOptions);
        }


        [Fact]
        public async void Save_CreateHouse()
        {
            //arrange part
            var house = new House
            {
                Id = 1,
                Name = "House 1",
                Address = "1234 Main St",
                City = "City",
                Region = "Region",
                PostalCode = 12345,
                Country = "Country"
            };

            //act part
           await _dbContext.houses.AddAsync(house);   
           await _dbContext.SaveChangesAsync();


            //assert part
            house.Id.ShouldBe(1);

        }
    }
}