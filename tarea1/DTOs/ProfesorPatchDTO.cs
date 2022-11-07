using System.ComponentModel.DataAnnotations;
using tarea1.Validaciones;

namespace tarea1.DTOs
{
    public class ProfesorPatchDTO
    {
        [Required]
        [StringLength(maximumLength: 250, ErrorMessage = "El campo {0} solo puede tener hasta 250 caracteres")]
        [PrimeraLetraMayus]
        public string Nombre { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}