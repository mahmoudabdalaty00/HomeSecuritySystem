using HomeSecuritySystem.Application.Features.Device.Commands.CreateDevice;
using HomeSecuritySystem.Application.Features.Device.Commands.DeleteDevice;
using HomeSecuritySystem.Application.Features.Device.Commands.UpdateDevice;
using HomeSecuritySystem.Application.Features.Device.Query.GetAllDevicesw;
using HomeSecuritySystem.Application.Features.Device.Query.GetDeviceDetails;
using HomeSecuritySystem.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeSecuritySystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {

        private readonly IMediator _mediator;

        public DeviceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<DeviceController>
        [HttpGet]
        public async Task<List<DeviceDto>> Get()
        {
           var devices = await _mediator.Send(new GetDevicesQuery());
            return devices;
        }

        // GET api/<DeviceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceDetailDto>> GetById(int id)
        {
           var device = await _mediator.Send(
               new GetDeviceDetailQuery(id) { Id = id});
            if (device == null)
            {
                return NotFound();
            }
            return device;
        }

        // POST api/<DeviceController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Post(CreateDeviceCommand device)
        {
            var result = await _mediator.Send(device);
            return CreatedAtAction(
                nameof(GetById), new { id = result }, result);
        }

        // PUT api/<DeviceController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateDeviceCommand device)
        {
           await _mediator.Send(device);
            return Ok();

        }

        // DELETE api/<DeviceController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var device = await _mediator.Send(
                new DeleteDeviceCommand { Id = id });
            await _mediator.Send(device);
            return NoContent();
        }
    }
}
