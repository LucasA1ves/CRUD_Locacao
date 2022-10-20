using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudLocacao.Models;
using CrudLocacao.Repository;

namespace CrudLocacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImovelController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ImovelController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Imovel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imoveis>>> GetImoveis()
        {
            return await _context.Imoveis.ToListAsync();
        }

        // GET: api/Imovel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Imoveis>> GetImoveis(int id)
        {
            var imoveis = await _context.Imoveis.FindAsync(id);

            if (imoveis == null)
            {
                return NotFound();
            }

            return imoveis;
        }

        // PUT: api/Imovel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImoveis(int id, Imoveis imoveis)
        {
            if (id != imoveis.Id)
            {
                return BadRequest();
            }

            _context.Entry(imoveis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImoveisExists(id))
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

        // POST: api/Imovel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Imoveis>> PostImoveis(Imoveis imoveis)
        {
            _context.Imoveis.Add(imoveis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImoveis", new { id = imoveis.Id }, imoveis);
        }

        // DELETE: api/Imovel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImoveis(int id)
        {
            var imoveis = await _context.Imoveis.FindAsync(id);
            if (imoveis == null)
            {
                return NotFound();
            }

            _context.Imoveis.Remove(imoveis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImoveisExists(int id)
        {
            return _context.Imoveis.Any(e => e.Id == id);
        }
    }
}
