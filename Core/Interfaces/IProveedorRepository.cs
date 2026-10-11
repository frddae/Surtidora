using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProveedorRepository
    {
        int CrearProveedor(Proveedor proveedor);
        List<Proveedor> ObtenerProveedores();
        public List<Proveedor> ObtenerProveedoresActivos();

    }
}
