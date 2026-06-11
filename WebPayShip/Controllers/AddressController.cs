/*using AppService;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebPayShip.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AddressController : ControllerBase
    {
        private readonly Service _appservice;

        public AddressController()
        {
            _appservice = new Service();
        }

        [HttpGet("addresses")]
        public IActionResult GetAddresses()
        {
            return Ok(_appservice.GetAddresses());
        }

        [HttpPost("addresses")]
        public IActionResult CreateAddress([FromBody] ADD add)
        {
            if (add == null)
                return BadRequest("Address data is required.");

            add.AID = Guid.NewGuid();

            var created = _appservice.Address(add);

            if (!created)
                return Conflict("Address could not be created.");

            return CreatedAtAction(nameof(GetAddresses), new { id = add.AID }, add);
        }

        [HttpPatch("addresses/{id:guid}")]
        public IActionResult UpdateAddress(Guid id, [FromBody] ADD add)
        {
            if (add == null)
                return BadRequest("Address data is required.");

            var existing = _appservice.GetAddresses()
                                       .FirstOrDefault(x => x.AID == id);

            if (existing == null)
                return NotFound();

            add.AID = id;

            var updated = _appservice.UpAdd(add);

            if (!updated)
                return BadRequest("Failed to update address.");

            return NoContent();
        }
    }
}
*/