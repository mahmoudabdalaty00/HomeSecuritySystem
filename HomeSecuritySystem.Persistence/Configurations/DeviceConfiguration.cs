using HomeSecuritySystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeSecuritySystem.Persistence.Configurations
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>

    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasData(
                     new Device
                     {
                         Id = 1,
                         DeviceType = "Sensor",
                         Model = "Model A",
                         Status = true,
                         UserId = "User1"
                     },
                new Device
                {
                    Id = 2,
                    DeviceType = "Camera",
                    Model = "Model B",
                    Status = false,
                    UserId = "User2"
                },
                new Device
                {
                    Id = 3,
                    DeviceType = "Alarm",
                    Model = "Model C",
                    Status = true,
                    UserId = "User3"
                },
                new Device
                {
                    Id = 4,
                    DeviceType = "Sensor",
                    Model = "Model D",
                    Status = true,
                    UserId = "User4"
                },
                new Device
                {
                    Id = 5,
                    DeviceType = "Camera",
                    Model = "Model E",
                    Status = false,
                    UserId = "User5"
                }

                );
        }


    }


}
