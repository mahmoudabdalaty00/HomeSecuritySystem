using HomeSecuritySystem.Domain;

namespace HomeSecuritySystem.Application.Contracts.Presistance
{
    public interface IHomeRepository : IGenericRepoistory<House>
    {
        Task<bool> HouseExist(string name);


        Task<House> GetHouseWithDetails(int id);
        Task<List<House>> GetHouseWithDetails();
        Task<List<House>> GetHouseWithDetails(string userid);


    }

}
