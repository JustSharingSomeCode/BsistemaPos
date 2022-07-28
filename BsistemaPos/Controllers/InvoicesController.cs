using BsistemaPos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BsistemaPos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        sistemaPosDBContext _context;

        public InvoicesController(sistemaPosDBContext context)
        {
            _context = context;
        }

        // GET: api/<InvoicesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _context.Invoices.ToListAsync();
            return Ok(list);
        }

        // GET api/<InvoicesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            
            if(invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

        // POST api/<InvoicesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return Ok(invoice);
        }

        // PUT api/<InvoicesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Invoice invoice)
        {
            if(id != invoice.InvoiceId)
            {
                return NotFound();
            }

            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
            return Ok(invoice);
        }

        // DELETE api/<InvoicesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);

            if(invoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
