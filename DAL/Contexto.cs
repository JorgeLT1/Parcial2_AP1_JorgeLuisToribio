using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext 
{
    public DbSet<Producto> Producto { get; set; }
    public DbSet<Caja> Caja { get; set; }
    public DbSet<CajaDetalle> CajaDetalle { get; set; }


    public Contexto(DbContextOptions<Contexto> options): base(options){}
}