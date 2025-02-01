using MediatR;
 

namespace HomeSecuritySystem.Application.Features.House.Commands.DeleteHouse
{
    public class DeleteHouseCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
