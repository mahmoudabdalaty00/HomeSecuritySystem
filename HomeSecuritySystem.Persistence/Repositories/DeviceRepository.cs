using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Domain;
using HomeSecuritySystem.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;

namespace HomeSecuritySystem.Persistence.Repositories
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(HSSDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<bool> DeviceExist(string deviceType, string model, string userId)
        {

            var exist = await _dbContext.devices.AnyAsync(
                h => h.DeviceType == deviceType && h.Model == model && h.UserId == userId);

            return await Task.FromResult(exist);

        }


        public async Task<Device> GetDeviceWithDetailsAsync(int id)
        {
            var device = await _dbContext.devices
                .Include(d => d.DeviceType)
                .Include(d => d.Model)
                .Include(d => d.UserId)
                .FirstOrDefaultAsync(d => d.Id == id);
            return device;
        }


        public async Task<List<Device>> GetDeviceWithDetailsAsync()
        {
            var devices = await _dbContext.devices
                .Include(d => d.DeviceType)
                .Include(d => d.Model)
                .Include(d => d.UserId)
                .ToListAsync();
            return devices;
        }


        public async Task<List<Device>> GetDeviceWithDetailsAsync(string userId)
        {
            var devices = await _dbContext.devices
                .Include(d => d.DeviceType)
                .Include(d => d.Model)
                .Include(d => d.UserId)
                .Where(d => d.UserId == userId)
                .ToListAsync();
            return devices;

        }
 
    }
     
}
