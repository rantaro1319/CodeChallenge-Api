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
    public class cursoController : ControllerBase
    {
        private readonly MyDbContext _context;

        public cursoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/curso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<curso>>> Getcurso()
        {
            return await _context.curso.ToListAsync();
        }

        // GET: api/curso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<curso>> Getcurso(int id)
        {
            var curso = await _context.curso.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // PUT: api/curso/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcurso(int id, curso curso)
        {
            if (id != curso.Id)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cursoExists(id))
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

        // POST: api/curso
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<curso>> Postcurso(curso curso)
        {
            _context.curso.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcurso", new { id = curso.Id }, curso);
        }

        // DELETE: api/curso/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<curso>> Deletecurso(int id)
        {
            var curso = await _context.curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _context.curso.Remove(curso);
            await _context.SaveChangesAsync();

            return curso;
        }

        private bool cursoExists(int id)
        {
            return _context.curso.Any(e => e.Id == id);
        }
    }
}
