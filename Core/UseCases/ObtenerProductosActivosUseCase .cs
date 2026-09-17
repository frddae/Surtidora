using Core.Entities;
using Core.Interfaces;

namespace Core.UseCases
{
    public class ObtenerProductoActivossUseCase
    {
        private readonly IProductoRepository _productoRepository;

        public ObtenerProductoActivossUseCase(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public List<ProductosActivos> Execute()
        {
            return _productoRepository.ObtenerProductosActivos();
        }
    }
}
