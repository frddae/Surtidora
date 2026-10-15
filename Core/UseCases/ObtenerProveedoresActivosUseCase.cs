using Core.Entities;
using Core.Interfaces;

namespace Core.UseCases
{
    public class ObtenerProveedoresActivosUseCase
    {
        private readonly IProveedorRepository _proveedorRepository;
        public ObtenerProveedoresActivosUseCase(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }
        public List<Proveedor> Execute()
        {
            return _proveedorRepository.ObtenerProveedoresActivos();
        }
    }
}
