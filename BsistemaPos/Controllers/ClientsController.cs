using BsistemaPos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BsistemaPos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private sistemaPosDBContext _context;

        public ClientsController(sistemaPosDBContext sistemaPosDBContext)
        {
            this._context = sistemaPosDBContext;
        }

        // GET: api/<ClientsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _context.Clients.ToListAsync();
            return Ok(list);
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var client = await _context.Clients.FindAsync(id);

            if(client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // POST api/<ClientsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return Ok(client);
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Client client)
        {
            if(id != client.ClientId)
            {
                return NotFound();
            }

            _context.Clients.Update(client);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var client = await _context.Clients.FindAsync(id);

            if(client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
