using AutoMapper;
using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Application.Exceptions;
using MediatR;

namespace HomeSecuritySystem.Application.Features.House.Query.GetHouseDetails
{
    public class GetHouseDetailQueryHandler : IRequestHandler<GetHouseDetailQuery, HouseDetailDto>
    {

         private readonly IHomeRepository _houseRepository;
        private readonly IMapper _mapper;

        public GetHouseDetailQueryHandler(
            IHomeRepository houseRepository, IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }

        public async Task<HouseDetailDto> Handle(
            GetHouseDetailQuery request, CancellationToken cancellationToken)
        {
            //query database
            var house = await _houseRepository.GetByIdAsync(request.id);
            // here we check it exist or not first before deleting
            if (house == null)
                throw new NotFoundException(nameof(House), request);


            //convert data obj to Dto obj
            var houseDto = _mapper.Map<HouseDetailDto>(house);

            //return Dto obj
            return houseDto;
        }
    }
}
