using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using tarea1.Entidades;



namespace tarea1
{
    public class ApplicatioDbContext : DbContext
    {
        public ApplicatioDbContext(DbContextOptions options) : base(options)
        {
        }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<ClaseProfesor>()
                    .HasKey(al => new { al.ClaseId, al.ProfesorId });
            }
    public DbSet<Clase> Clases { get; set; }
    public DbSet<Profesor> Profesores { get; set; }
    }
}
