using Core.Entities;
using Core.Interfaces;

namespace Core.UseCases
{
    public class ObtenerProveedoresUseCase
    {
        private readonly IProveedorRepository _proveedorRepository;
        public ObtenerProveedoresUseCase(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }
        public List<Proveedor> Execute()
        {
            return _proveedorRepository.ObtenerProveedores();
        }
    }
}
