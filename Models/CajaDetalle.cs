using System.ComponentModel.DataAnnotations;

public class CajaDetalle
{
    [Key]
    public int CajaDetalleId { get; set; }
    public int CajaId { get; set; }
    public int ProductoId { get; set; }
    public string? Descripcion { get; set;}
    public int Cantidad { get; set; }   
}