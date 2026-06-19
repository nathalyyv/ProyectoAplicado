
using System.ComponentModel.DataAnnotations;

namespace GoldClub.Models
{
    
    /// Representa un producto del inventario de Gold Club.
    /// como no tenemos  base de datos: estos objetos viven unicamente en memoria,
    /// dentro de la lista estatica que mantiene ProductoController.
   
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(120, ErrorMessage = "El nombre no puede exceder 120 caracteres.")]
        [Display(Name = "Nombre del producto")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El código del producto es obligatorio.")]
        [StringLength(40, ErrorMessage = "El código no puede exceder 40 caracteres.")]
        [Display(Name = "Código del producto")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El proveedor es obligatorio.")]
        [StringLength(120, ErrorMessage = "El proveedor no puede exceder 120 caracteres.")]
        [Display(Name = "Proveedor")]
        public string Proveedor { get; set; } = string.Empty;

        [Required]
        [StringLength(80)]
        [Display(Name = "Creado por")]
        public string CreadoPor { get; set; } = "Juan Pérez";

        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Display(Name = "Última actualización")]
        public DateTime? FechaActualizacion { get; set; }
        public bool Activo { get; set; } = true;
    }
}