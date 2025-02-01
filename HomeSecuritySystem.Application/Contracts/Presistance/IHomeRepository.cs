using HomeSecuritySystem.Domain;

namespace HomeSecuritySystem.Application.Contracts.Presistance
{
    public interface IHomeRepository : IGenericRepoistory<House>
    {
        Task<bool> HouseExist(string name);
    }
  
}
