using Core.Entities;
using Core.Interfaces;

namespace Core.UseCases
{
    public class ObtenerLoteProductosUseCase
    {
        private readonly IProductoRepository _productoRepository;

        public ObtenerLoteProductosUseCase(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public List<MostrarLoteProducto> Execute()
        {
            return _productoRepository.ObtenerLoteProductos();
        }
    }
}
