using System.ComponentModel.DataAnnotations;
using tarea1.Validaciones;

namespace tarea1.DTOs
{
    public class ProfesorCreacionDTO
    {
        [Required]
        [StringLength(maximumLength: 250, ErrorMessage = "El campo {0} solo puede tener hasta 250 caracteres")]
        [PrimeraLetraMayus]
        public string Nombre { get; set; }

        public DateTime FechaCreacion { get; set; }

        public List<int> ClasesIds { get; set; }
    }
}