using Core.Entities;
using Core.Interfaces;


namespace Core.UseCases
{
    public class CrearProductoUseCase
    {
        private readonly IProductoRepository _productoRepository;

        public CrearProductoUseCase(IProductoRepository productoRepository)
        {
            this._productoRepository = productoRepository;
        }
        public int Execute(Producto producto)
        {
            return _productoRepository.CrearProducto(producto);
        }
    }
}
