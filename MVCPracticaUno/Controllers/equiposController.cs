using Microsoft.AspNetCore.Mvc;
using MVCPracticaUno.Models;

namespace MVCPracticaUno.Controllers
{
    public class equiposController : Controller
    {
        private readonly equiposDBContext _equiposContext;
        public equiposController(equiposDBContext equiposContext)
        {
            _equiposContext = equiposContext;


        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create([Bind("nombre ,descripcion ,tipo_equipo_id ,marca_id ,estado_equipo_id ,anio_compra ,costo ,vida_util, modelo ")] equipos equipoNuevo)
        {
            try
            {
                _equiposContext.equipos.Add(equipoNuevo);
                _equiposContext.SaveChanges();

                return View("Index");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
            
        }
    }
}
