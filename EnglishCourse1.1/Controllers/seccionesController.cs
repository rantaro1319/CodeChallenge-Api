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
    public class seccionesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public seccionesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/secciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<secciones>>> Getsecciones()
        {
            return await _context.secciones.ToListAsync();
        }


        // GET: api/secciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<secciones>> Getsecciones(int id)
        {
            var secciones = await _context.secciones.FindAsync(id);

            if (secciones == null)
            {
                return NotFound();
            }

            return secciones;
        }

        // PUT: api/secciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putsecciones(int id, secciones secciones)
        {
            if (id != secciones.Id)
            {
                return BadRequest();
            }

            _context.Entry(secciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!seccionesExists(id))
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

        // POST: api/secciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<secciones>> Postsecciones(secciones secciones)
        {
            _context.secciones.Add(secciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getsecciones", new { id = secciones.Id }, secciones);
        }

        // DELETE: api/secciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<secciones>> Deletesecciones(int id)
        {
            var secciones = await _context.secciones.FindAsync(id);
            if (secciones == null)
            {
                return NotFound();
            }

            _context.secciones.Remove(secciones);
            await _context.SaveChangesAsync();

            return secciones;
        }

        private bool seccionesExists(int id)
        {
            return _context.secciones.Any(e => e.Id == id);
        }
    }
}
