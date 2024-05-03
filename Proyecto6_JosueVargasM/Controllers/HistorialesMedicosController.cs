using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto6_JosueVargasM.Models;

namespace Proyecto6_JosueVargasM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialesMedicosController : ControllerBase
    {
        private readonly ProyectoP6JosueContext _context;

        public HistorialesMedicosController(ProyectoP6JosueContext context)
        {
            _context = context;
        }

        // GET: api/HistorialesMedicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialMedico>>> GetHistorialMedicos()
        {
            return await _context.HistorialMedicos.ToListAsync();
        }

        // GET: api/HistorialesMedicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialMedico>> GetHistorialMedico(int id)
        {
            var historialMedico = await _context.HistorialMedicos.FindAsync(id);

            if (historialMedico == null)
            {
                return NotFound();
            }

            return historialMedico;
        }

        // PUT: api/HistorialesMedicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialMedico(int id, HistorialMedico historialMedico)
        {
            if (id != historialMedico.Idhistorial)
            {
                return BadRequest();
            }

            _context.Entry(historialMedico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialMedicoExists(id))
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

        // POST: api/HistorialesMedicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistorialMedico>> PostHistorialMedico(HistorialMedico historialMedico)
        {
            _context.HistorialMedicos.Add(historialMedico);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HistorialMedicoExists(historialMedico.Idhistorial))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHistorialMedico", new { id = historialMedico.Idhistorial }, historialMedico);
        }

        // DELETE: api/HistorialesMedicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialMedico(int id)
        {
            var historialMedico = await _context.HistorialMedicos.FindAsync(id);
            if (historialMedico == null)
            {
                return NotFound();
            }

            _context.HistorialMedicos.Remove(historialMedico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialMedicoExists(int id)
        {
            return _context.HistorialMedicos.Any(e => e.Idhistorial == id);
        }
    }
}
