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



        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Presupuesto presupuesto)
        {



            try
            {

               

                _dbcontext.Presupuestos.Add(presupuesto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok"});
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }



        [HttpPost]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Presupuesto presupuesto)
        {
            try
            {
                Presupuesto obPresupuesto = _dbcontext.Presupuestos.Find(presupuesto.PresupuestoId);

                if (obPresupuesto == null)
                {
                    return BadRequest("Presupuesto no encontrado.");
                }

                obPresupuesto.Unidad = presupuesto.Unidad is null ? obPresupuesto.Unidad : presupuesto.Unidad;
                obPresupuesto.TipoBienServicio = presupuesto.TipoBienServicio is null ? obPresupuesto.TipoBienServicio : presupuesto.TipoBienServicio;
                obPresupuesto.Cantidad = presupuesto.Cantidad is null ? obPresupuesto.Cantidad : presupuesto.Cantidad;
                obPresupuesto.ValorUnitario = presupuesto.ValorUnitario is null ? obPresupuesto.ValorUnitario : presupuesto.ValorUnitario;
                obPresupuesto.ValorTotal = presupuesto.ValorTotal is null ? obPresupuesto.ValorTotal : presupuesto.ValorTotal;
                obPresupuesto.FechaAdquision = presupuesto.FechaAdquision is null ? obPresupuesto.FechaAdquision : presupuesto.FechaAdquision;
                obPresupuesto.Proveedor = presupuesto.Proveedor is null ? obPresupuesto.Proveedor : presupuesto.Proveedor;
                obPresupuesto.Documentacion = presupuesto.Documentacion is null ? obPresupuesto.Documentacion : presupuesto.Documentacion;

                _dbcontext.Presupuestos.Update(obPresupuesto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }


    }
}
