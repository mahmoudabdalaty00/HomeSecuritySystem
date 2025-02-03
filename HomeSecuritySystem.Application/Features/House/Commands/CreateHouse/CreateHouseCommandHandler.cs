using AutoMapper;
using HomeSecuritySystem.Application.Contracts.Logging;
using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Application.Exceptions;
using MediatR;

namespace HomeSecuritySystem.Application.Features.House.Commands.CreateHouse
{
    public class CreateHouseCommandHandler : IRequestHandler<
        CreateHouseCommand, int>
    {
        private readonly IHomeRepository _houseRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CreateHouseCommandHandler> _logger;

        public CreateHouseCommandHandler(
            IHomeRepository houseRepository, IMapper mapper, IAppLogger<CreateHouseCommandHandler> appLogger)
        {
            _mapper = mapper;
            _houseRepository = houseRepository;
            _logger = appLogger;
        }
        public async Task<int> Handle(CreateHouseCommand request, CancellationToken cancellationToken)
        {
            //validate incoming data
            var validator = new CreateHouseCommandValidator(_houseRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogError("Validation errors - {Errors}", validationResult.Errors);
                throw new BadRequestException("Invalid House", validationResult);
            }

            // this is another way to create a new domain house object
            var house = _mapper.Map<Domain.House>(request);

            //create the house & save it to the database
            await _houseRepository.CreateAsync(house);

            //return the id of the house that was created
            return house.Id;
        }
    }
}
