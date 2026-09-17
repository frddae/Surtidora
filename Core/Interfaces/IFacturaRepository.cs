using Core.Entities;

namespace Core.Interfaces
{
    public interface IFacturaRepository
    {
        List<Factura> ObtenerFacturas();
    }
}
