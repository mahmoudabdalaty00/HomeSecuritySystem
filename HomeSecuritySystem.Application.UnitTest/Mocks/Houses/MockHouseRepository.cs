using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Domain;
using Moq;

namespace HomeSecuritySystem.Application.UnitTest.Mocks.Houses
{
    public class MockHouseRepository
    {

        public static  Mock<IHomeRepository> GetMockHouseRepository()
        {
            var houses = new List<House>
            {
                new House
                {
                    Id =7,
                    Address = "Rua do Ouro, 340, 4150-630 Porto",
                    City = "Porto",
                    Country = "Portugal",
                    PostalCode = 4150-630,
                    Name = "f4b3e2b1-4f4b-4b7f-8f1e-3e2b1f4b3e2b",
                    Region = "Porto",
                },
                new House
                {
                    Id =6,
                    Address = "Rua do Ouro, 340, 4150-630 Porto",
                    City = "Porto",
                    Country = "Portugal",
                    PostalCode = 4150-630,
                    Name = "f4b3e2b1-4f4b-4b7f-8f1e-3e2b1f4b3e2b",
                    Region = "Porto",
                },
                new House
                {
                    Id = 1,
                    Address = "123 Main St, Springfield, IL",
                    City = "Springfield",
                    Country = "USA",
                    PostalCode = 62701,
                    Name = "House1",
                    Region = "Illinois",
                },
                new House
                {
                    Id = 2,
                    Address = "456 Elm St, Shelbyville, IL",
                    City = "Shelbyville",
                    Country = "USA",
                    PostalCode = 62565,
                    Name = "House2",
                    Region = "Illinois",
                },
                new House
                {
                    Id = 3,
                    Address = "789 Oak St, Capital City, IL",
                    City = "Capital City",
                    Country = "USA",
                    PostalCode = 62706,
                    Name = "House3",
                    Region = "Illinois",
                },
                new House
                {
                    Id = 4,
                    Address = "101 Maple St, Ogdenville, IL",
                    City = "Ogdenville",
                    Country = "USA",
                    PostalCode = 62563,
                    Name = "House4",
                    Region = "Illinois",
                },
                new House
                {
                    Id = 5,
                    Address = "202 Birch St, North Haverbrook, IL",
                    City = "North Haverbrook",
                    Country = "USA",
                    PostalCode = 62564,
                    Name = "House5",
                    Region = "Illinois",
                }

            };
            var mokRep = new Mock<IHomeRepository>();
            mokRep.Setup(repo => repo.GetAllAsync()).ReturnsAsync(houses);

            mokRep.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
              .ReturnsAsync((int id) => houses.FirstOrDefault(
                  x => x.Id == id));

            mokRep.Setup(repo => repo.CreateAsync(It.IsAny<House>()))
                .ReturnsAsync((House house) => house);
                

             mokRep.Setup(repo => repo.UpdateAsync(It.IsAny<House>()))
                .ReturnsAsync((House house) =>
                {
                    var index = houses.FindIndex(x => x.Id == house.Id);
                    if (index == -1)
                    {
                        return null;
                    }
                    houses[index] = house;
                    return house;
                });
        
            /*
            //mokRep.Setup(repo => repo.DeleteAsync(It.IsAny<House>()))
            //    .ReturnsAsync((House house) =>
            //    {
            //        var index = houses.FindIndex(x => x.Id == house.Id);
            //        if (index == -1)
            //        {
            //            return null;
            //        }
            //        var deleted = houses[index];
            //        houses.RemoveAt(index);
            //        return deleted;
            //    });


            */

           
            return mokRep;
        }

    }
}
