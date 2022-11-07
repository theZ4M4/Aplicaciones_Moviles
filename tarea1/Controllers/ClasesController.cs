using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tarea1.DTOs;
using tarea1.Entidades;

namespace tarea1.Controllers
{
    [ApiController]
    [Route("clases")] //ruta del controlador
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]

    public class ClasesController : ControllerBase
    {
        private readonly ApplicatioDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public ClasesController(ApplicatioDbContext context)
        {
            this.dbContext = context;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetClaseDTO>>> Get()
        {
            var clases = await dbContext.Clases.ToListAsync();
            return mapper.Map<List<GetClaseDTO>>(clases);
        }

        [HttpGet("{id:int}", Name = "obtenerclase")] //Se puede usar ? para que no sea obligatorio el parametro /{param=Gustavo}  getAlumno/{id:int}/
        public async Task<ActionResult<ClaseDTOConProfesores>> Get(int id)
        {
            var clase = await dbContext.Clases
                .Include(claseDB => claseDB.ClaseProfesor)
                .ThenInclude(claseProfesorDB => claseProfesorDB.Profesor)
                .FirstOrDefaultAsync(alumnoBD => alumnoBD.Id == id);

            if (clase == null)
            {
                return NotFound();
            }

            return mapper.Map<ClaseDTOConProfesores>(clase);

        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<GetClaseDTO>>> Get([FromRoute] string nombre)
        {
            var clases = await dbContext.Clases.Where(claseBD => claseBD.Nombre.Contains(nombre)).ToListAsync();

            return mapper.Map<List<GetClaseDTO>>(clases);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClaseDTO claseDto)
        {
            //Ejemplo para validar desde el controlador con la BD con ayuda del dbContext

            var existeClaseMismoNombre = await dbContext.Clases.AnyAsync(x => x.Nombre == claseDto.Nombre);

            if (existeClaseMismoNombre)
            {
                return BadRequest($"Ya existe una clase con el nombre {claseDto.Nombre}");
            }

            var clase = mapper.Map<Clase>(claseDto);

            dbContext.Add(clase);
            await dbContext.SaveChangesAsync();

            var claseDTO = mapper.Map<GetClaseDTO>(clase);

            return CreatedAtRoute("obtenerclase", new { id = clase.Id }, claseDTO);
        }

        [HttpPut("{id:int}")] // api/clases/1
        public async Task<ActionResult> Put(ClaseDTO claseCreacionDTO, int id)
        {
            var exist = await dbContext.Clases.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            var clase = mapper.Map<Clase>(claseCreacionDTO);
            clase.Id = id;

            dbContext.Update(clase);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Clases.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El recurso no fue encontrado.");
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