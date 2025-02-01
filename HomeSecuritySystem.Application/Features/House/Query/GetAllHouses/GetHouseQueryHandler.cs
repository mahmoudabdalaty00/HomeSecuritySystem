using AutoMapper;
using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Application.Exceptions;
using HomeSecuritySystem.Domain;
using MediatR;

namespace HomeSecuritySystem.Application.Features.House.Query.GetAllHouses
{
    public class GetHouseQueryHandler : IRequestHandler< GetHouseQuery,
        List<HouseDto>>

    {
        private readonly IHomeRepository _houseRepository;
        private readonly IMapper _mapper;

        public GetHouseQueryHandler(
            IHomeRepository houseRepository, IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }

        public async Task<List<HouseDto>> Handle(GetHouseQuery request, CancellationToken cancellationToken)
        {
            //Query DataBase
            var houses = await _houseRepository.GetAllAsync();

            // here we check it exist or not first before deleting
            if (houses == null)
                throw new NotFoundException(nameof(House), request);

            //convert data obj  to Dto obj 
            var housesDto = _mapper.Map<List<HouseDto>>(houses);

            //return Dto obj
            return housesDto;

        }


    }
}
