using BsistemaPos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BsistemaPos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private sistemaPosDBContext _context;

        public SalesController(sistemaPosDBContext context)
        {
            _context = context;
        }

        // GET: api/<SalesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _context.Sales.ToListAsync();
            return Ok(list);
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sale = await _context.Sales.FindAsync(id);

            if(sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        // POST api/<SalesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Sale sale)
        {
            sale.SubTotal = sale.Quantity * sale.UnitPrice;

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return Ok(sale);
        }

        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Sale sale)
        {
            if(id != sale.SaleId)
            {
                return NotFound();
            }

            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sale = await _context.Sales.FindAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
