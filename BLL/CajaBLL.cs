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
   if (caja == null || caja.CajaId <= 0) {
      return false; // Libro no válido, no se puede guardar
   }
   
   if (!Existe(caja.CajaId)) {
      return this.Insertar(caja);
   } else {
      return this.Modificar(caja);
   }
}

 public bool Eliminar(Caja caja)
{
    if (Existe(caja.CajaId))
    {
        var CajaEliiminar = _Contexto.Caja.Find(caja.CajaId);
        _Contexto.Entry(CajaEliiminar).State = EntityState.Deleted;
        return _Contexto.SaveChanges() > 0;
    }
    else
    {
        return false; 
    }
}

    public Caja? Buscar(int cajaId){
         return _Contexto.Caja
             .Where(o => o.CajaId== cajaId)
             .Include(o =>  o.cajaDetalle)
             .AsNoTracking()
             .SingleOrDefault();
    }
    
    public List<Producto>GetList(Expression<Func<Producto, bool>> criterio){
        return _Contexto.Producto.AsNoTracking().Where(criterio).ToList();
    }

    public void InsertarDetalle(Caja caja)
    {
        if (caja == null) throw new ArgumentNullException(nameof(caja));

        caja.cajaDetalle ??= new List<CajaDetalle>();

        _Contexto.SaveChanges();
    }
    
public void ModificarDetalle(Caja cajaActual)
{
    var detallesOriginales = _Contexto.CajaDetalle
        .AsNoTracking()
        .Where(d => d.CajaId == cajaActual.CajaId)
        .ToList();
}
}