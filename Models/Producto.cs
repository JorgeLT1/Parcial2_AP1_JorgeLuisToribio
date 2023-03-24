using System.ComponentModel.DataAnnotations;

public class Producto
{
    [Key]
    public int ProductoId {get; set;}
    public string? Descripcion { get; set; }
    public double Costo { get; set; }
    public double Precio { get; set; }
    public int Existencia { get; set; }    
}