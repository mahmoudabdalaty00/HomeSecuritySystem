using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;

namespace HomeSecuritySystem.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepoistory<T> where T : class
    {

        protected readonly HSSDatabaseContext _dbContext;

        public GenericRepository(HSSDatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }


        public async Task<T> CreateAsync(T entity)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                if (entity is Domain.House)
                {
                    await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT houses ON");
                }
                else if (entity is Domain.Device)
                {
                    await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT devices ON");

                }
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();



                if (entity is Domain.House)
                {
                    await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT houses OFF");
                } 
                else if (entity is Domain.Device)
                {
                    await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT devices OFF");
                }
                await transaction.CommitAsync();
                return entity;
            }

        }

        public async Task<T> UpdateAsync(T entity)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                if (entity is Domain.House house)
                {
                    // Ensure the Id property is set
                    if (house.Id == 0)
                    {
                        throw new ArgumentException("House Id must be specified for update operation.");
                    }

                    await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT houses ON");
                }

                _dbContext.Set<T>().Update(entity);
                await _dbContext.SaveChangesAsync();

                if (entity is Domain.House)
                {
                    await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT houses OFF");
                }

                await transaction.CommitAsync();
                return entity;
            }
        }


        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();


        }



        public async Task<T> GetByIdAsync(int id)
        {
            ///here we need to use AsNoTracking to not track the entity in the context
            var entity = await _dbContext.Set<T>().FindAsync(id).AsTask();
            return entity;

        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            ///here we use AsNoTracking to not track the entity in the context
            var entites = await _dbContext.Set<T>().AsNoTracking().ToListAsync();
            return entites;
        }
    }
}
