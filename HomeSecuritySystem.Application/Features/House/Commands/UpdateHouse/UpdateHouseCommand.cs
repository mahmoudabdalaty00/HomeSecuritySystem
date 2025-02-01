using MediatR;

namespace HomeSecuritySystem.Application.Features.House.Commands.UpdateHouse
{
    // we use IRequest<unit> to return nothing it is a void
    public class UpdateHouseCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;

        public int PostalCode { get; set; } = 0;

        public string Country { get; set; } = string.Empty;
    }

}
