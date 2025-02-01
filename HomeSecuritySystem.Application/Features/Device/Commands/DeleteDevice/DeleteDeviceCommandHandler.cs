using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Application.Exceptions;
using HomeSecuritySystem.Domain;
using MediatR;

namespace HomeSecuritySystem.Application.Features.Device.Commands.DeleteDevice
{
    public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand, Unit>
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeleteDeviceCommandHandler(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<Unit> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            //retrieve  domain entity obj from the database
            var device = await _deviceRepository.GetByIdAsync(request.Id);

            //verify that obj is exist in the database
            // here we check it exist or not first before deleting
            if (device == null)
                throw new NotFoundException(nameof(Device), request.Id);


            //delete the entity
            await _deviceRepository.DeleteAsync(device);

            //return unit
            return Unit.Value;
        }
    }

}
