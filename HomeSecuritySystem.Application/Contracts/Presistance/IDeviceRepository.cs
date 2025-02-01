using HomeSecuritySystem.Domain;

namespace HomeSecuritySystem.Application.Contracts.Presistance
{
    public interface IDeviceRepository : IGenericRepoistory<Device>
    {
        Task<bool> DeviceExist(string deviceType, string model);
    }
  
}
