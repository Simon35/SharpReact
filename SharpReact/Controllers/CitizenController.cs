using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharpReact.Model;

namespace SharpReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenController : ControllerBase
    {
        private readonly CitizenContext _citizenContext;

        public CitizenController(CitizenContext citizenContext)
        {
            _citizenContext = citizenContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Citizen>>>  GetCitizens()
        {
            if(_citizenContext.Citizens == null)
            {
                return NotFound();
            }

            return await _citizenContext.Citizens.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Citizen>> GetCitizensById(int id)
        {
            if (_citizenContext.Citizens == null)
            {
                return NotFound();
            }
            var citi = await _citizenContext.Citizens.FindAsync(id);
            if (citi == null)
            {
                return NotFound();
            }

            return citi;
        }

        [HttpPost]
        public async Task<ActionResult<Citizen>> SaveCitizen(Citizen citizen)
        {
            _citizenContext.Citizens.Add(citizen);
            await _citizenContext.SaveChangesAsync();
            return CreatedAtAction(nameof(SaveCitizen), new { id = citizen.Id }, citizen);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Citizen>> UpdateCitizen(int id, Citizen citizen)
        {
            if (id != citizen.Id)
            {
                return BadRequest();
            }

            _citizenContext.Entry(citizen).State = EntityState.Modified;
            try
            {
                await _citizenContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;

            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCitizen(int id)
        {
            if (_citizenContext.Citizens == null)
            {
                return NotFound();
            }

            var citi = await _citizenContext.Citizens.FindAsync(id);
            if (citi == null)
            {
                return NotFound();
            }

            _citizenContext.Citizens.Remove(citi);
            await _citizenContext.SaveChangesAsync();
            return Ok();
        }


    }
}
