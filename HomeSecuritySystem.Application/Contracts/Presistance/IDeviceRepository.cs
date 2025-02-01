using HomeSecuritySystem.Domain;

namespace HomeSecuritySystem.Application.Contracts.Presistance
{
    public interface IDeviceRepository : IGenericRepoistory<Device>
    {
        Task<bool> DeviceExist(string deviceType, string model ,string userId);


         Task<Device> GetDeviceWithDetailsAsync(int id);
         Task<List<Device>> GetDeviceWithDetailsAsync();
         Task<List<Device>> GetDeviceWithDetailsAsync(string userId);


          


    }
  
}
