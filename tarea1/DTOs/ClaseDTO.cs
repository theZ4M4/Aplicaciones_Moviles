using System.ComponentModel.DataAnnotations;
using tarea1.Validaciones;

namespace tarea1.DTOs
{
    public class ClaseDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")] //
        [StringLength(maximumLength: 150, ErrorMessage = "El campo {0} solo puede tener hasta 150 caracteres")]
        [PrimeraLetraMayus]
        public string Nombre { get; set; }
    }
}