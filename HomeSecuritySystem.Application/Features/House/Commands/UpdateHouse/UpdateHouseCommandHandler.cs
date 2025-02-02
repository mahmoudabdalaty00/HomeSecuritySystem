using AutoMapper;
using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Application.Exceptions;
using HomeSecuritySystem.Application.Features.House.Commands.CreateHouse;
using MediatR;

namespace HomeSecuritySystem.Application.Features.House.Commands.UpdateHouse
{
    public class UpdateHouseCommandHandler : IRequestHandler<UpdateHouseCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IHomeRepository _houseRepository;
        public UpdateHouseCommandHandler(IMapper mapper, IHomeRepository houseRepository)
        {
            _mapper = mapper;
            _houseRepository = houseRepository;
        }
        public async Task<Unit> Handle(UpdateHouseCommand request, CancellationToken cancellationToken)
        {
            //validate the request
            var validator = new UpdateHouseCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid House", validationResult);


            //map the request to the Domain house object
            // here we check it exist or not first before deleting
            var existingHouse = await _houseRepository.GetByIdAsync(request.Id);
            if (existingHouse == null)
            {
                throw new NotFoundException(nameof(House), request.Id);
            }
            _mapper.Map(request, existingHouse);

            // Update the house object in the database
            await _houseRepository.UpdateAsync(existingHouse);


            // return the unit
            return Unit.Value;
        }
    }
}



