using Core.Entities;
using Core.Interfaces;

namespace Core.UseCases
{
    public class ObtenerProductosUseCase
    {
        private readonly IProductoRepository _productoRepository;

        public ObtenerProductosUseCase(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public List<Producto> Execute()
        {
            return _productoRepository.ObtenerProductos();
        }
    }
}
