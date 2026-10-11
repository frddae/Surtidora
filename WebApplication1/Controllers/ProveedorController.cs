using Core.Entities;
using Core.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace SurtidoraApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly CrearProveedorUseCase _crearProveedorUseCase;
        //falta crear el use de caso
        //private readonly ObtenerProveedoresUseCase _obtenerProveedoresUseCase;
        //private readonly ObtenerProveedoresActivosUseCase _obtenerProveedoresActivosUseCase;

        public ProveedorController(CrearProveedorUseCase crearProveedorUseCase)
        {
            _crearProveedorUseCase = crearProveedorUseCase;
            //falta crear el use de caso
            //_obtenerProveedoresUseCase = obtenerProveedoresUseCase;
            //_obtenerProveedoresActivosUseCase = obtenerProveedoresActivosUseCase;
        }
        [HttpPost]
        [Route("CreateProveedor")]
        public IActionResult CreateProveedor(Proveedor proveedor)
        {
            try
            {
                int id = _crearProveedorUseCase.Execute(proveedor);
                proveedor.ProveedorId = id;
                return Ok(proveedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "error al crear el proveedor",
                    message = ex.Message,
                });
            }
        }
    }
}
