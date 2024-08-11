using System.ComponentModel.DataAnnotations;

namespace Tarea_BD_1.Models
{
    public class EmpleadoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\- ]+$", ErrorMessage = "Solo se permiten caracteres alfabéticos y el guion '-'")] // expresion regular
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Salario es obligatorio")]
        public decimal Salario { get; set; }
    }
}
