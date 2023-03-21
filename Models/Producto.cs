
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Producto
{
    [Key]
    public int ProductoId {get; set;}
    [Required(ErrorMessage = "La descripcion es requerida.")]
    public string? Descripcion { get; set; }
    [Required(ErrorMessage ="El costo es requerido, favor introduzca el campo.")]
    public double Costo { get; set; }
    [Required(ErrorMessage ="El precio es requerido, favor introduzca el campo.")]
    public double Precio { get; set; }
    [Required(ErrorMessage ="La existencia es requeida, favor introduzca el campo.")]
    public string? Existencia { get; set; }    
}