using AutoMapper;
using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Application.Exceptions;
using MediatR;

namespace HomeSecuritySystem.Application.Features.House.Commands.DeleteHouse
{
    public class DeleteHouseCommandHandler : IRequestHandler<DeleteHouseCommand, Unit>
    {
        private readonly IHomeRepository _homeRepository;
        private readonly IMapper _mapper;

        public DeleteHouseCommandHandler(IHomeRepository homeRepository, IMapper mapper)
        {
            _homeRepository = homeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteHouseCommand request, CancellationToken cancellationToken)
        {
           
            //retrieve domain object
            var house = await _homeRepository.GetByIdAsync(request.Id);

            // here we check it exist or not first 
             if (house == null)
                 throw new NotFoundException(nameof(House), request.Id);
             

            //delete the record from the database
            await _homeRepository.DeleteAsync(house);

            //return the record id  
            return Unit.Value;
        }
    }
}
