using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class ProductoBLL {
  private Contexto _contexto;

  public ProductoBLL(Contexto contexto) {
    _contexto = contexto;
  }

  public bool Existe(int productoId) {
    return _contexto.Producto.Any(o => o.ProductoId == productoId);
  }

  private bool Insertar(Producto producto) {
    _contexto.Producto.Add(producto);
    return _contexto.SaveChanges() > 0;
  }

  private bool Modificar(Producto producto) {
    var carroExistente = _contexto.Producto.Find(producto.ProductoId);
    if (carroExistente == null) {
        return false;
    }

    _contexto.Entry(carroExistente).CurrentValues.SetValues(producto);
    return _contexto.SaveChanges() > 0;
}


  public bool Guardar(Producto producto) {
    if (producto == null || producto.ProductoId <= 0) {
      return false; 
    }

    if (!Existe(producto.ProductoId)) {
      return this.Insertar(producto);
    } else {
      return this.Modificar(producto);
    }
  }

  public bool Eliminar(Producto producto) {
    if (Existe(producto.ProductoId)) {
      var CarroEliminar = _contexto.Producto.Find(producto.ProductoId);
      _contexto.Entry(CarroEliminar).State = EntityState.Deleted;
      return _contexto.SaveChanges() > 0;
    } else {
      return false;
    }
  }

  public Producto ? Buscar(int productoId) {
    return _contexto.Producto
      .Where(o => o.ProductoId == productoId)
      .AsNoTracking()
      .SingleOrDefault();
  }

  public List < Producto > GetList(Expression < Func < Producto, bool >> criterio) {
    return _contexto.Producto.AsNoTracking().Where(criterio).ToList();
  }

}