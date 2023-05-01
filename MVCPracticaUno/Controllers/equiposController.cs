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

            var listadoDeEquipos = (from e in _equiposContext.equipos
                                    join m in _equiposContext.marcas on e.marca_id equals m.id_marcas
                                    select new
                                    {
                                        nombre = e.nombre,
                                        descripcion = e.descripcion,
                                        marca_id = e.marca_id,
                                        marca_nombre = m.nombre_marca
                                    }).ToList();
            ViewData["listadoDeEquipos"] = listadoDeEquipos;

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

            //Formularios con Razor y HTML Helper            
        }
    }
}
