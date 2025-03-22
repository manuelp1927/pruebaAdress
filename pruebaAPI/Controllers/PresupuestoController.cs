using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using pruebaAPI.Models;

namespace pruebaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestoController : ControllerBase
    {

        public readonly PruebaContext _dbcontext; 

        public PresupuestoController(PruebaContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Presupuesto> lista = new List<Presupuesto>();

            try
            {
                lista = _dbcontext.Presupuestos.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new {mensaje = ex.Message, Response = lista});
            }
        }

        [HttpGet]
        [Route("Obtener/{idPresupuesto:int}")]
        public IActionResult Obtener (int idPresupuesto)
        {
            Presupuesto obPresupuesto = _dbcontext.Presupuestos.Find(idPresupuesto);

            if (obPresupuesto == null)
            {
                return BadRequest("Presupuesto no encontrado.");
            }

            try
            {
               // obPresupuesto = _dbcontext.Presupuestos.Include(c => c.PresupuestoId).Where(p => p.PresupuestoId == idPresupuesto).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = obPresupuesto });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = obPresupuesto });
            }
        }



    }
}
