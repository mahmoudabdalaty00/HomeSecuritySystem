namespace HomeSecuritySystem.Application.Contracts.Presistance
{
    public interface IGenericRepoistory<T> where T : class
    {

        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);


    }
  
}
