using Microsoft.EntityFrameworkCore;
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
    }
}
