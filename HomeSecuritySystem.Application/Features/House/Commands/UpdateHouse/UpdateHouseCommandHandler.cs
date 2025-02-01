using AutoMapper;
using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Application.Exceptions;
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

            //map the request to the Domain house object
            var house = _mapper.Map<Domain.House>(request);

            // here we check it exist or not first before deleting
            if (house == null)
                throw new NotFoundException(nameof(House), request);

            // update the house object in database
            await _houseRepository.UpdateAsync(house);

            // return the unit
           return Unit.Value;
        }
    }

}
