using HomeSecuritySystem.Application.Features.House.Commands.CreateHouse;
using HomeSecuritySystem.Application.Features.House.Commands.DeleteHouse;
using HomeSecuritySystem.Application.Features.House.Commands.UpdateHouse;
using HomeSecuritySystem.Application.Features.House.Query.GetAllHouses;
using HomeSecuritySystem.Application.Features.House.Query.GetHouseDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeSecuritySystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {

        private readonly IMediator _mediator;

        public HouseController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<HouseController>
        [HttpGet]
        public async Task<List<HouseDto>> Get()
        {
            //here action start from GetHouseQuery and then go to HouseQueryHandler  using MediatR & IrequestHandler 
            // all actions occures in the background and return the result to the controller
            //all ocurres in GetHouseQueryHandler class
            var houses = await _mediator.Send(new GetHouseQuery());
            return houses;
        }

        // GET api/<HouseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HouseDetailDto>> GetById(int id)
        {
            var house = await _mediator.Send(
                new GetHouseDetailQuery(id) { id = id });
            if (house == null)
            {
                return NotFound();
            }
            return Ok(house);
        }

        // POST api/<HouseController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Post(CreateHouseCommand house)
        {
            //here action start from CreateHouseCommand and then go to CreateHouseCommandHandler  using MediatR & IrequestHandler 
            // all actions occures in the background and return the result to the controller
            //all ocurres in CreateHouseCommandHandler class
            var result =  await _mediator.Send(house);
            return CreatedAtAction(
                nameof(GetById), new { id = result },result);

        }


        // PUT api/<HouseController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateHouseCommand house)
        {
            await _mediator.Send(house);
            return NoContent();

        }

        // DELETE api/<HouseController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteHouseCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();

        }
    }
}
