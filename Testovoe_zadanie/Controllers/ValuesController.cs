using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLib;
using MyLib.Data;

namespace Testovoe_zadanie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zadacha>>> GetZadacha()
        {
            return await _context.Zadacha.ToListAsync();
        }

        // GET: api/Values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zadacha>> GetZadacha(int id)
        {
            var zadacha = await _context.Zadacha.FindAsync(id);

            if (zadacha == null)
            {
                return NotFound();
            }

            return zadacha;
        }

        // PUT: api/Values/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZadacha(int id, Zadacha zadacha)
        {
            if (id != zadacha.Id)
            {
                return BadRequest();
            }

            _context.Entry(zadacha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZadachaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Values
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Zadacha>> PostZadacha(Zadacha zadacha)
        {
            _context.Zadacha.Add(zadacha);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZadacha", new { id = zadacha.Id }, zadacha);
        }

        // DELETE: api/Values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Zadacha>> DeleteZadacha(int id)
        {
            var zadacha = await _context.Zadacha.FindAsync(id);
            if (zadacha == null)
            {
                return NotFound();
            }

            _context.Zadacha.Remove(zadacha);
            await _context.SaveChangesAsync();

            return zadacha;
        }

        private bool ZadachaExists(int id)
        {
            return _context.Zadacha.Any(e => e.Id == id);
        }
    }
}
