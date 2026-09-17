using Core.Entities;
using Core.Interfaces;

namespace Core.UseCases
{
    public class ObtenerFacturasUseCase
    {
        private readonly IFacturaRepository _facturaRepository;

        public ObtenerFacturasUseCase(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }
        public List<Factura> Execute()
        {
            return _facturaRepository.ObtenerFacturas();
        }
    }
}
