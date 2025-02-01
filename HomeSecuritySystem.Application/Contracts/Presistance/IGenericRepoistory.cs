namespace HomeSecuritySystem.Application.Contracts.Presistance
{
    public interface IGenericRepoistory<T> where T : class
    {

        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);

        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);


    }
  
}
