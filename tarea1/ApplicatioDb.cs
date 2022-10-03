using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using tarea1.Controllers;
using tarea1.Entidades;



namespace tarea1
{
    public class ApplicatioDbContext: DbContext
    {
        public ApplicatioDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
    }
}
