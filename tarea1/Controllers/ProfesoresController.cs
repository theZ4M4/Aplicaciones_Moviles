using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tarea1.Entidades;

namespace tarea1.Controllers
{
    [ApiController]
    [Route("profesores")]
    public class ProfesoresController : ControllerBase
    {
        private readonly ApplicatioDbContext dbContext;
        public ProfesoresController(ApplicatioDbContext context)
        {
            this.dbContext = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Profesor>>> GetAll()
        {
            return await dbContext.Profesores.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Profesor>> GetById(int id)
        {
            return await dbContext.Profesores.FirstOrDefaultAsync(x => x.Id == id); 
        }

        [HttpPost]
        public async Task<ActionResult> Post(Profesor profesor)
        {
            var existeClase = await dbContext.Clases.AnyAsync(x => x.Id == profesor.ClaseId);

            if (!existeClase)
            {
                return BadRequest($"No existe la clase con el id: {profesor.ClaseId}");
            }

            dbContext.Add(profesor);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Profesor profesor, int id)
        {
            var exist = await dbContext.Profesores.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("El profesor especificado no existe");
            }

            if (profesor.Id != id)
            {
                return BadRequest("El id del profesor no coincide con el establecido en la url");
            }
            dbContext.Update(profesor);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Profesores.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El recurso no fue encontrado");
            }

            dbContext.Remove(new Profesor { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
