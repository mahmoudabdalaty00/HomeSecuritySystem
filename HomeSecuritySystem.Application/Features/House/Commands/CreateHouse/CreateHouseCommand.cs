using MediatR;

namespace HomeSecuritySystem.Application.Features.House.Commands.CreateHouse
{
    //we use Irequest<int> because we want to return the id of the house that was created
    public class CreateHouseCommand : IRequest<int>
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
