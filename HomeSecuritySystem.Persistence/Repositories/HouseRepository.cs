using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Domain;
using HomeSecuritySystem.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;

namespace HomeSecuritySystem.Persistence.Repositories
{
    public class HouseRepository : GenericRepository<House>, IHomeRepository
    {
        public HouseRepository(HSSDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<bool> HouseExist(string name)
        {
            var exist = await _dbContext.houses.AnyAsync(h => h.Name == name);
            return await Task.FromResult(exist);
        }

        public async Task<House> GetHouseWithDetails(int id)
        {
         var house =await _dbContext.houses.Include(
                h => h.Devices).Include(h => h.Users)
                    .FirstOrDefaultAsync(h => h.Id == id);
            return    house;
        }

        public async Task<List<House>> GetHouseWithDetails()
        {
            var houses = await _dbContext.houses.Include(
                      h => h.Devices)
                            .Include(h => h.Users)
                                   .ToListAsync();

            return houses;
        }

        public async Task<List<House>> GetHouseWithDetails(string userid)
        {
             var houses =await _dbContext.houses
                     .Include(h => h.Devices)
                            .Include(h => h.Users)
                                  .Where(h => h.Users
                                            .Any(u => u.Id == userid))
                                                      .ToListAsync();

            return houses;
        }


    }

}
