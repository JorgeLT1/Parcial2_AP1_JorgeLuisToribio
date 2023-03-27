using System.ComponentModel.DataAnnotations;

public class Producto
{
    [Key]
    public int ProductoId {get; set;}
    [Required(ErrorMessage ="La descripcion es requerida.")]
    public string? Descripcion { get; set; }
    [Required(ErrorMessage ="El costo es requerido.")]
    public double Costo { get; set; }
    [Required(ErrorMessage ="El precio es requerido.")]
    public double Precio { get; set; }
    [Required(ErrorMessage ="La existencia es requerida.")]
    public int Existencia { get; set; }    
}