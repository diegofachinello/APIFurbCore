using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FurbAPICore.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace FurbAPICore.Controllers
{
    [Produces("application/json")]
    [Route("api/Comandas")]
    public class ComandasController : Controller
    {
        private readonly FurbAPICoreContext _context;

        public ComandasController(FurbAPICoreContext context)
        {
            _context = context;
        }

        // GET: api/Comandas
        [HttpGet]
        public IEnumerable<Comanda> GetComanda()
        {
            return _context.Comanda;
        }

        // GET: api/Comandas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComanda([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comanda = await _context.Comanda.SingleOrDefaultAsync(m => m.Id == id);

            if (comanda == null)
            {
                return NotFound();
            }

            return Ok(comanda);
        }

        // PUT: api/Comandas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComanda([FromRoute] int id, [FromBody] Comanda comanda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comanda.Id)
            {
                return BadRequest();
            }

            _context.Entry(comanda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComandaExists(id))
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

        // POST: api/Comandas
        [HttpPost]
        public async Task<IActionResult> PostComanda([FromBody] Comanda comanda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Comanda.Add(comanda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComanda", new { id = comanda.Id }, comanda);
        }

        // DELETE: api/Comandas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComanda([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comanda = await _context.Comanda.SingleOrDefaultAsync(m => m.Id == id);
            if (comanda == null)
            {
                return NotFound();
            }

            _context.Comanda.Remove(comanda);
            await _context.SaveChangesAsync();

            return Ok(comanda);
        }

        private bool ComandaExists(int id)
        {
            return _context.Comanda.Any(e => e.Id == id);
        }
    }
}