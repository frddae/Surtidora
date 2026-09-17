using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductoRepository
    {
        List<Producto> ObtenerProductos();
        List<ProductosActivos> ObtenerProductosActivos();
    }
}
