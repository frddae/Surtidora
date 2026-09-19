using Core.Entities;
using Core.Interfaces;

namespace Core.UseCases
{
    public class InsertarLoteUseCase
    {
        private readonly IProductoRepository _productoRepository;

        public InsertarLoteUseCase(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public LoteProducto Execute(LoteProducto loteProducto)
        {
            return _productoRepository.InsertarLoteProducto(loteProducto);
        }
    }
}
