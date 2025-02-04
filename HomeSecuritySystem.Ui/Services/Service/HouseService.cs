using HomeSecuritySystem.Ui.Contracts;
using HomeSecuritySystem.Ui.Services.Base;

namespace HomeSecuritySystem.Ui.Services.Service
{
    public class HouseService : BaseHttpService, IHouseService
    {
        public HouseService(IClient client) : base(client)
        {
        }
    }  
}
