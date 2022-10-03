using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tarea1.Entidades;

namespace tarea1.Controllers
{
    [ApiController]
    [Route("clases")] //ruta del controlador
    

    public class ClasesController : ControllerBase
    {
        private readonly ApplicatioDbContext dbContext;
        public ClasesController(ApplicatioDbContext context)
        {
            this.dbContext = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Clase>>> Get()
        {
            return await dbContext.Clases.Include(x => x.profesores).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Clase clase)
        {
            dbContext.Add(clase);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")] //clases/1
        public async Task<ActionResult> Put(Clase clase, int id)
        {
            if (clase.Id != id)
            {
                return BadRequest("El id de la clase no coincide con el del URL");
            }
            dbContext.Update(clase);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Clases.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Clase()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
