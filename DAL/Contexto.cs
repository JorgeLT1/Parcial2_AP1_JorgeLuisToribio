using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext 
{
    public DbSet<Producto> Producto { get; set; }
    public DbSet<Caja> Caja { get; set; }
    public DbSet<CajaDetalle> CajaDetalle { get; set; }

    public Contexto(DbContextOptions<Contexto> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Producto>().HasData(
            new Producto{
                ProductoId = 1,
                Descripcion = "Almendra",
                Costo = 150,
                Precio = 5,
                Existencia = 100
            }
        );
        modelBuilder.Entity<Producto>().HasData(
            new Producto{
                ProductoId = 2,
                Descripcion = "Nuez",
                Costo = 250,
                Precio = 40,
                Existencia = 100
            }
        );
        modelBuilder.Entity<Producto>().HasData(
            new Producto{
                ProductoId = 3,
                Descripcion = "Pasas",
                Costo = 200,
                Precio = 60,
                Existencia = 100
            }
        );
        modelBuilder.Entity<Producto>().HasData(
            new Producto{
                ProductoId = 5,
                Descripcion = "Pistachos",
                Costo = 400,
                Precio = 30,
                Existencia = 100
            }
        );    

        modelBuilder.Entity<Producto>().HasData(
            new Producto{
                ProductoId = 6,
                Descripcion = "Mixto",
                Costo = 100,
                Precio = 50,
                Existencia = 10
            }
        );    
    }
}