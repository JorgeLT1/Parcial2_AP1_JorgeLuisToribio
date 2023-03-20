using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext 
{
    public DbSet<Producto> Producto { get; set; }
    public Contexto(DbContextOptions<Contexto> options): base(options){}
}