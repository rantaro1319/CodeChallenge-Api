using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnglishCourse1._1.Modelos;

namespace EnglishCourse1._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class profesoresController : ControllerBase
    {
        private readonly MyDbContext _context;

        public profesoresController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/profesores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<profesores>>> Getprofesores()
        {
            return await _context.profesores.ToListAsync();
        }

        // GET: api/profesores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<profesores>> Getprofesores(int id)
        {
            var profesores = await _context.profesores.FindAsync(id);

            if (profesores == null)
            {
                return NotFound();
            }

            return profesores;
        }

        // PUT: api/profesores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putprofesores(int id, profesores profesores)
        {
            if (id != profesores.Id)
            {
                return BadRequest();
            }

            _context.Entry(profesores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!profesoresExists(id))
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

        // POST: api/profesores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<profesores>> Postprofesores(profesores profesores)
        {
            _context.profesores.Add(profesores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getprofesores", new { id = profesores.Id }, profesores);
        }

        // DELETE: api/profesores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<profesores>> Deleteprofesores(int id)
        {
            var profesores = await _context.profesores.FindAsync(id);
            if (profesores == null)
            {
                return NotFound();
            }

            _context.profesores.Remove(profesores);
            await _context.SaveChangesAsync();

            return profesores;
        }

        private bool profesoresExists(int id)
        {
            return _context.profesores.Any(e => e.Id == id);
        }
    }
}
