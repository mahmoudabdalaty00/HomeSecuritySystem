using MediatR;

namespace HomeSecuritySystem.Application.Features.House.Query.GetAllHouses
{
    public record GetHouseQuery : IRequest<List<HouseDto>>;
}
