using MediatR;

namespace HomeSecuritySystem.Application.Features.House.Commands.UpdateHouse
{
    // we use IRequest<unit> to return nothing it is a void
    public class UpdateHouseCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }  

        public string Address { get; set; } 

        public string City { get; set; }  
        public string Region { get; set; }  

        public int PostalCode { get; set; }  

        public string Country { get; set; }  
    }

}
