using System.ComponentModel.DataAnnotations;
using tarea1.Validaciones;

namespace tarea1.Entidades
{
    public class Profesor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 250, ErrorMessage = "El campo {0} solo puede tener hasta 250 caracteres")]
        [PrimeraLetraMayus]
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int ClaseId { get; set; }
        public List<ClaseProfesor> ClaseProfesor { get; set; }
    }
}
