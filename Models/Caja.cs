using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Caja
{
    [Key]
    public int CajaId { get; set; }
    [Required(ErrorMessage ="La fecha es requeridad.")]
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    [Required(ErrorMessage ="El concepto es requerido.")]
    public string? Concepto {get; set;}
    public int Cantidad { get; set; }
    [ForeignKey("CajaId")]
    public int ProductoId { get; set; }
    public List<CajaDetalle> cajaDetalle { get; set; } = new List<CajaDetalle>();

}