using Core.Entities;
using Core.Interfaces;
namespace Core.UseCases
{
    public class CrearProveedorUseCase
    {
        private readonly IProveedorRepository _proveedorRepository;
        public CrearProveedorUseCase(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }
        public int Execute(Proveedor proveedor)
        {
            return _proveedorRepository.CrearProveedor(proveedor);
        }
    }
}
