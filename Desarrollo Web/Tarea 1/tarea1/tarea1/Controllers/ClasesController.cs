using Microsoft.AspNetCore.Mvc;
using tarea1.Entidades;

namespace tarea1.Controllers
{
    [ApiController]
    [Route("api/clases")]
    public class ClasesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Clase>> Get()
        {
            return new List<Clase>()
            {
                new Clase() { Id = 1, Nombre = "Matematicas" },
                new Clase() { Id = 2, Nombre = "Historia"}
            };
        }
    }
}
