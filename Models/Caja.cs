using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Caja
{
    [Key]
    public int CajaId { get; set; }
    [Required(ErrorMessage ="La fecha es requeridad.")]
    public DateTime Fecha { get; set; }
    [Required(ErrorMessage ="El concepto es requerido.")]
    public string? Concepto {get; set;}
    [Required(ErrorMessage ="La cantidad es requerida.")]
    public int Cantidad { get; set; }
    [ForeignKey("CajaId")]
    public List<CajaDetalle> cajaDetalle { get; set; } = new List<CajaDetalle>();
}