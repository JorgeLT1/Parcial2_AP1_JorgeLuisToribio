using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class CajaBLL{
    private Contexto _Contexto;

    public CajaBLL(Contexto contexto) {
        _Contexto = contexto;
    }

    public bool Existe(int CajaId) {
        return _Contexto.Caja.Any(o => o.CajaId == CajaId);
    }

    private bool Insertar(Caja caja) {
       InsertarDetalle(caja);
        _Contexto.Caja.Add(caja);
        return _Contexto.SaveChanges() > 0;
    }

  private bool Modificar(Caja caja) {
    ModificarDetalle(caja);
    var CajaExistente = _Contexto.Caja.Find(caja.CajaId);
    if (CajaExistente == null) {
        return false;
    }

    _Contexto.Entry(CajaExistente).CurrentValues.SetValues(caja);
    return _Contexto.SaveChanges() > 0;
}


   public bool Guardar(Caja caja) {
      if (!Existe(caja.CajaId)) {
      return this.Insertar(caja);
   } else {
      return this.Modificar(caja);
   }
}

public bool Eliminar(int cajaId)
{
    var caja = _Contexto.Caja.Include(p => p.cajaDetalle).FirstOrDefault(p => p.CajaId == cajaId);

    if (caja != null)
    {
        foreach (var detalle in caja.cajaDetalle)
        {
            var producto = _Contexto.Producto.Find(detalle.ProductoId);
            if (producto == null)
            {
                continue;
            }
            producto.Existencia += detalle.Cantidad;
            _Contexto.Entry(producto).State = EntityState.Modified;
        }

        _Contexto.RemoveRange(caja.cajaDetalle);
        _Contexto.Entry(caja).State = EntityState.Deleted;

        int filasAfectadas = _Contexto.SaveChanges();
        return filasAfectadas > 0;
    }
    else
    {
        return false;
    }
}

    public Caja? Buscar(int cajaId){
        return _Contexto.Caja.Include(o => o.cajaDetalle).Where(o => o.CajaId == cajaId).SingleOrDefault();
    }
    
    public List<Caja>GetList(Expression<Func<Caja, bool>> criterio){
        return _Contexto.Caja.AsNoTracking().Where(criterio).ToList();
    }  

public void InsertarDetalle(Caja caja)
{

    if (caja.cajaDetalle?.Any() == true)
    {
        foreach (var item in caja.cajaDetalle)
        {
            var producto = _Contexto.Producto.Find(item.ProductoId);

            if (producto != null)
            {
                producto.Existencia -= item.Cantidad;
                _Contexto.Entry(producto).State = EntityState.Modified;
            }
        }
        _Contexto.SaveChanges();
    }

    var Pruducido = _Contexto.Producto.Find(caja.ProductoId);
        if (caja.Cantidad != 0 && Pruducido != null)
        {
            Pruducido.Existencia += caja.Cantidad;
            _Contexto.Entry(Pruducido).State = EntityState.Modified;
            _Contexto.SaveChanges();
        }
}

    
public void ModificarDetalle(Caja caja)
{
    var Pruducido = _Contexto.Producto.Find(caja.ProductoId);
        if (caja.Cantidad != 0 && Pruducido != null)
        {
            Pruducido.Existencia += caja.Cantidad;
            _Contexto.Entry(Pruducido).State = EntityState.Modified;
            _Contexto.SaveChanges();
        }

    foreach (var detalle in caja.cajaDetalle)
    {
        var producto = _Contexto.Producto.FirstOrDefault(p => p.ProductoId == detalle.ProductoId);
        if (producto != null)
        {
            producto.Existencia -= detalle.Cantidad;
            _Contexto.Entry(producto).State = EntityState.Modified;
        }
    }
    
    _Contexto.SaveChanges();
}


}