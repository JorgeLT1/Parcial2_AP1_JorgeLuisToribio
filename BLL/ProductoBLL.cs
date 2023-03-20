using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class ProductoBLL{
    private Contexto _Contexto;

    public ProductoBLL(Contexto contexto) {
        _Contexto = contexto;
    }
 public List<Producto>GetList(Expression<Func<Producto, bool>> criterio){
    return _Contexto.Producto.AsNoTracking().Where(criterio).ToList();
    }
    
}