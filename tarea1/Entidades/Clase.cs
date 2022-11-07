using System.ComponentModel.DataAnnotations;
using tarea1.Validaciones;

namespace tarea1.Entidades
{
    public class Clase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")] //
        [StringLength(maximumLength: 150, ErrorMessage = "El campo {0} solo puede tener hasta 150 caracteres")]
        [PrimeraLetraMayus]
        public string Nombre { get; set; }   
        
        public List<ClaseProfesor> ClaseProfesor { get; set; }
    }
}
