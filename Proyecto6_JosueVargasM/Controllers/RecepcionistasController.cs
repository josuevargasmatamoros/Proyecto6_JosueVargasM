using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto6_JosueVargasM.Models;
using Proyecto6_JosueVargasM.ModelsDTO;

namespace Proyecto6_JosueVargasM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionistasController : ControllerBase
    {
        private readonly ProyectoP6JosueContext _context;

        public RecepcionistasController(ProyectoP6JosueContext context)
        {
            _context = context;
        }

        // GET: api/Recepcionistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recepcionistum>>> GetRecepcionista()
        {
            return await _context.Recepcionista.ToListAsync();
        }

        // GET: api/Recepcionistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recepcionistum>> GetRecepcionistum(int id)
        {
            var recepcionistum = await _context.Recepcionista.FindAsync(id);

            if (recepcionistum == null)
            {
                return NotFound();
            }

            return recepcionistum;
        }

        //GET: api/Users/GetUserData?pUserName=algo
        //este get permite obtenerr los datos puntuales de un usuario 
        //usando el correo como parametro
        [HttpGet("GetRecepcionistumData")]
        public ActionResult<IEnumerable<RecepcionistaDTO>> GetRecepcionistumData(string Nombre)
        {
            //el proposito de usar el DTO aca es combinar los datos de las tablas
            //user y userRole y devolver un solo objeto json con diha informacion
            //admas no se sabra como se llaman los atributos proginales

            //para hacer esa consulta no ususaremos sp como en progra5
            //sino, qyue usaremos linq que permite hacer consultas sobre
            //colecciones directamenrte en la progra

            var query = (from us in _context.Recepcionista
                         join ur in _context.UsuarioRols on us.UsuarioRolId equals ur.UsuarioRolId
                         where us.Nombre == Nombre && us.Activo == true
                         select new
                         {
                             idrecepcionista = us.Idrecepcionista,
                             nombre = us.Nombre,
                             apellidos = us.Apellidos,
                             cedula = us.Cedula,                           
                             activo = us.Activo,
                             idrol = us.UsuarioRolId,
                             rol = ur.Descripcion

                         }
                     ).ToList();
            //ahora que tenemos el resultado de la consulta en la variable
            //query, procedemos acrear el resultado de la funxcion

            //crear el objeto respuesta
            List<RecepcionistaDTO> listausuarios = new List<RecepcionistaDTO>();

            //ahora hacemos un recorrido de las posibles iteraciones de
            //la variable query y llenamos en cadda una de ellos un nuevo
            //objeto dto

            foreach (var item in query)
            {
                RecepcionistaDTO newUser = new RecepcionistaDTO()
                {
                    Idrecepcionista = item.idrecepcionista,
                    Nombre = item.nombre,
                    Cedula = item.cedula,                    
                    Apellidos = item.apellidos,
                    Activo = item.activo,
                    UsuarioRolId = item.idrol,
                    
                };
                listausuarios.Add(newUser);
            }
            if (listausuarios == null || listausuarios.Count() == 0)
            {
                return NotFound();

            }

            return listausuarios;
        }

        // PUT: api/Recepcionistas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecepcionistum(int id, Recepcionistum recepcionistum)
        {
            if (id != recepcionistum.Idrecepcionista)
            {
                return BadRequest();
            }

            _context.Entry(recepcionistum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecepcionistumExists(id))
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

        // POST: api/Recepcionistas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recepcionistum>> PostRecepcionistum(Recepcionistum recepcionistum)
        {
            _context.Recepcionista.Add(recepcionistum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecepcionistumExists(recepcionistum.Idrecepcionista))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecepcionistum", new { id = recepcionistum.Idrecepcionista }, recepcionistum);
        }

        // DELETE: api/Recepcionistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecepcionistum(int id)
        {
            var recepcionistum = await _context.Recepcionista.FindAsync(id);
            if (recepcionistum == null)
            {
                return NotFound();
            }

            _context.Recepcionista.Remove(recepcionistum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecepcionistumExists(int id)
        {
            return _context.Recepcionista.Any(e => e.Idrecepcionista == id);
        }
    }
}
