using HomeSecuritySystem.Ui.Contracts;
using HomeSecuritySystem.Ui.Services.Base;

namespace HomeSecuritySystem.Ui.Services.Service
{
    public class DeviceService : BaseHttpService, IDeviceService
    {
        public DeviceService(IClient client) : base(client)
        {

        }
    }
}
