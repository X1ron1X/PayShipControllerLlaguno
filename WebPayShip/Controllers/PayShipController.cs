using AppService;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebPayShip.Controllers
{
    [ApiController]
    [Route("api/PayShip")]
    public class PayShipController : ControllerBase
    {
        private readonly Service _appservice;

        public PayShipController()
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

        [HttpGet("cards")]
        public IActionResult GetCards()
        {
            return Ok(_appservice.GetCards());
        }

        [HttpPost("cards")]
        public IActionResult AddCard([FromBody] Card card)
        {
            if (card == null)
                return BadRequest("Card data is required.");

            card.CID = Guid.NewGuid();

            var created = _appservice.AddPayment(card);

            if (!created)
                return Conflict("Card could not be created.");

            return CreatedAtAction(nameof(GetCards), new { id = card.CID }, card);
        }

        [HttpPatch("cards/{id:guid}")]
        public IActionResult UpdateCard(Guid id, [FromBody] Card card)
        {
            if (card == null)
                return BadRequest("Card data is required.");

            var existing = _appservice.GetCards()
                                      .FirstOrDefault(x => x.CID == id);

            if (existing == null)
                return NotFound();

            card.CID = id;

            var updated = _appservice.UpCard(card);

            if (!updated)
                return BadRequest("Failed to update card.");

            return NoContent();
        }

        [HttpGet("banks")]
        public IActionResult GetBanks()
        {
            return Ok(_appservice.GetBanks());
        }

        [HttpPost("banks")]
        public IActionResult AddBank([FromBody] Bank bank)
        {
            if (bank == null)
                return BadRequest("Bank data is required.");

            bank.BID = Guid.NewGuid();

            var created = _appservice.AddPayment(bank);

            if (!created)
                return Conflict("Bank could not be created.");

            return CreatedAtAction(nameof(GetBanks), new { id = bank.BID }, bank);
        }

        [HttpPatch("banks/{id:guid}")]
        public IActionResult UpdateBank(Guid id, [FromBody] Bank bank)
        {
            if (bank == null)
                return BadRequest("Bank data is required.");

            var existing = _appservice.GetBanks()
                                      .FirstOrDefault(x => x.BID == id);

            if (existing == null)
                return NotFound();

            bank.BID = id;

            var updated = _appservice.UpBank(bank);

            if (!updated)
                return BadRequest("Failed to update bank.");

            return NoContent();
        }

        [HttpGet("gcash")]
        public IActionResult GetGcash()
        {
            return Ok(_appservice.GetGcash());
        }

        [HttpPost("gcash")]
        public IActionResult AddGcash([FromBody] Gcash gcash)
        {
            if (gcash == null)
                return BadRequest("Gcash data is required.");

            gcash.GID = Guid.NewGuid();

            var created = _appservice.AddPayment(gcash);

            if (!created)
                return Conflict("Gcash could not be created.");

            return CreatedAtAction(nameof(GetGcash), new { id = gcash.GID }, gcash);
        }

        [HttpPatch("gcash/{id:guid}")]
        public IActionResult UpdateGcash(Guid id, [FromBody] Gcash gcash)
        {
            if (gcash == null)
                return BadRequest("Gcash data is required.");

            var existing = _appservice.GetGcash()
                                      .FirstOrDefault(x => x.GID == id);

            if (existing == null)
                return NotFound();

            gcash.GID = id;

            var updated = _appservice.UpGcash(gcash);

            if (!updated)
                return BadRequest("Failed to update gcash.");

            return NoContent();
        }
    }
}