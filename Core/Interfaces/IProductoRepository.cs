using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductoRepository
    {
        int CrearProducto(Producto producto);
        List<Producto> ObtenerProductos();
        List<Producto> ObtenerProductosActivos();
        LoteProducto InsertarLoteProducto(LoteProducto loteProducto);
        List<MostrarLoteProducto> ObtenerLoteProductos();

    }
}
