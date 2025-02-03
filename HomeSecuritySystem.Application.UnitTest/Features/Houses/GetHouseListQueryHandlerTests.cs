using AutoMapper;
using HomeSecuritySystem.Application.Contracts.Logging;
using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Application.Exceptions;
using HomeSecuritySystem.Application.Features.Device.Query.GetDeviceDetails;
using HomeSecuritySystem.Application.Features.House.Commands.CreateHouse;
using HomeSecuritySystem.Application.Features.House.Commands.DeleteHouse;
using HomeSecuritySystem.Application.Features.House.Commands.UpdateHouse;
using HomeSecuritySystem.Application.Features.House.Query.GetAllHouses;
using HomeSecuritySystem.Application.Features.House.Query.GetHouseDetails;
using HomeSecuritySystem.Application.MappingProfiles;
using HomeSecuritySystem.Application.UnitTest.Mocks.Houses;
using HomeSecuritySystem.Domain;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace HomeSecuritySystem.Application.UnitTest.Features.Houses
{
    public class GetHouseListQueryHandlerTests  
    {
        private readonly Mock<IHomeRepository> _mockRepo;
        private      IMapper _mapper;
        private Mock<IAppLogger<GetHouseQueryHandler>> _mockapploger;

        public GetHouseListQueryHandlerTests()
        {
           _mockRepo = MockHouseRepository.GetMockHouseRepository();
            var mapperConfig = new MapperConfiguration(
                c => {
                    c.AddProfile<HouseProfile>();
                    }) ;


            _mapper = mapperConfig.CreateMapper();
            _mockapploger = new Mock<IAppLogger<GetHouseQueryHandler>>();

        }

        [Fact]
        public async Task GetHouseListQueryHandlerTest  ()
        {
            //Arrange
            var handler = new GetHouseQueryHandler(_mockRepo.Object, _mapper );
            var request = new GetHouseQuery();
            //Act
            var result = await handler.Handle(
                    new GetHouseQuery(), CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<HouseDto>>(result);
            Assert.Equal(7, result.Count);



            result.ShouldBeOfType<List<HouseDto>>();
            result.Count.ShouldBe(7);


          
        }

        [Fact]
        public async Task GetHouseDetailsTest()
        {
            //Arrange
            var handler = new GetHouseDetailQueryHandler(_mockRepo.Object, _mapper);
            var request = new GetHouseDetailQuery( id: 1 );
            //Act
            var result = await handler.Handle(
                    new GetHouseDetailQuery(id : 1), CancellationToken.None);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<HouseDetailDto>(result);
           
            result.ShouldBeOfType<HouseDetailDto>();
          
        }

        [Fact]
        public async Task CreateHouseTest()
        {
            var loggerMock = new Mock<IAppLogger<CreateHouseCommandHandler>>();

            var handler = new CreateHouseCommandHandler(
                _mockRepo.Object, _mapper, loggerMock.Object);
            var request = new CreateHouseCommand
            {
                Id = 30,
                Address = "123 New St, Springfield, IL",
                City = "Springfield",
                Country = "USA",
                PostalCode = 62701,
                Name = "New House",
                Region = "Illinois"
            };
            

            var house = new House
            {
                Id = request.Id,
                Address = request.Address,
                City = request.City,
                Country = request.Country,
                PostalCode = request.PostalCode,
                Name = request.Name,
                Region = request.Region
            };
            _mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<House>())).ReturnsAsync(house);

            var result = await handler.Handle(
                request, CancellationToken.None);

            Assert.IsType<int>(result);
            result.ShouldBeOfType<int>();
        
        }

        [Fact]
        public async Task DeleteHouseTest()
        {
            var loggerMock = new Mock<IAppLogger<DeleteHouseCommandHandler>>();
            var handler = new DeleteHouseCommandHandler(
                _mockRepo.Object,_mapper ,loggerMock.Object);
            var request = new DeleteHouseCommand
            {
                Id = 1
            };
            var house = new House
            {
                Id = request.Id,
                Address = "123 New St, Springfield, IL",
                City = "Springfield",
                Country = "USA",
                PostalCode = 62701,
                Name = "New House",
                Region = "Illinois"
            };
            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(house);
            _mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<House>()));
            var result = await handler.Handle(
                request, CancellationToken.None);
         }

        [Fact]
        public async Task UpdateHouseTest()
        {
            var loggerMock = new Mock<IAppLogger<UpdateHouseCommandHandler>>();
            var handler = new UpdateHouseCommandHandler(
                 _mapper, _mockRepo.Object, loggerMock.Object);
            var request = new UpdateHouseCommand
            {
                Id = 1,
                Address = "123 New St, Springfield, IL",
                City = "Springfield",
                Country = "USA",
                PostalCode = 62701,
                Name = "New House",
                Region = "Illinois"
            };
            var house = new House
            {
                Id = request.Id,
                Address = request.Address,
                City = request.City,
                Country = request.Country,
                PostalCode = request.PostalCode,
                Name = request.Name,
                Region = request.Region
            };
            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(house);
            _mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<House>())).ReturnsAsync(house);
            var result = await handler.Handle(
                request, CancellationToken.None);
         

        }
         
        }
}
