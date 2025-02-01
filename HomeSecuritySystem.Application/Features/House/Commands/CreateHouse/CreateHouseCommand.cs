using MediatR;

namespace HomeSecuritySystem.Application.Features.House.Commands.CreateHouse
{
    //we use Irequest<int> because we want to return the id of the house that was created
    public class CreateHouseCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;

        public int PostalCode { get; set; } = 0;

        public string Country { get; set; } = string.Empty;

    }
}
