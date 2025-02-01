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
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {

            _dbContext.Set<T>().Update(entity);

            //we can use this way to update the entity state if we modified in SaveChangesAsync in my basic code 
            // _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;

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
