using Core.Entities;
using Core.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace SurtidoraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly CrearProveedorUseCase _crearProveedorUseCase;
        private readonly ObtenerProveedoresUseCase _obtenerProveedoresUseCase;
        private readonly ObtenerProveedoresActivosUseCase _obtenerProveedoresActivosUseCase;

        public ProveedorController(CrearProveedorUseCase crearProveedorUseCase, ObtenerProveedoresUseCase obtenerProveedoresUseCase,
                                    ObtenerProveedoresActivosUseCase obtenerProveedoresActivosUseCase){
            this._crearProveedorUseCase = crearProveedorUseCase;
            this._obtenerProveedoresUseCase = obtenerProveedoresUseCase;
            this._obtenerProveedoresActivosUseCase = obtenerProveedoresActivosUseCase;
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

        [HttpGet]
        [Route("GetProveedores")]
        public IActionResult GetProveedores()
        {
            try
            {
                var proveedores = _obtenerProveedoresUseCase.Execute();
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "error al obtener los proveedores",
                    message = ex.Message,
                });
            }
        }

        [HttpGet]
        [Route("GetProveedoresActivos")]
        public IActionResult GetProveedoresActivos()
        {
            try
            {
                var proveedores = _obtenerProveedoresActivosUseCase.Execute();
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "error al obtener los proveedores activos",
                    message = ex.Message,
                });
            }
        }
    }
}
