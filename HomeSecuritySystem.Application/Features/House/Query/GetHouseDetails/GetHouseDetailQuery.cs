using MediatR;

namespace HomeSecuritySystem.Application.Features.House.Query.GetHouseDetails
{
    public record GetHouseDetailQuery(int id) : IRequest<HouseDetailDto> ;
}
