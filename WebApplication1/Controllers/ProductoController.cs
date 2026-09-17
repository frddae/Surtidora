using Core.Entities;
using Core.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace SurtidoraApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
  
        public class ProductosController : ControllerBase
        {
            private readonly ObtenerProductosUseCase _obtenerProductosUseCase;
            private readonly ObtenerProductoActivossUseCase _obtenerProductoActivossUseCase;

            public ProductosController(ObtenerProductosUseCase obtenerProductosUseCase, ObtenerProductoActivossUseCase obtenerProductoActivossUseCase)
            {
                _obtenerProductosUseCase = obtenerProductosUseCase;
                _obtenerProductoActivossUseCase = obtenerProductoActivossUseCase;
            }

            [HttpGet]
            [Route("GetProducts")]
            public IActionResult GetProducts()
            {
                try
                {
                    var productos = _obtenerProductosUseCase.Execute();
                    return Ok(productos);
                }
                catch (Exception ex) 
                {
                    return StatusCode(500, new
                    {
                        error = "error al obtener los productos",
                        message = ex.Message,
                    });
                }
            }
        [HttpGet]
        [Route("GetActiveProducts")]
        public IActionResult GetActiveProducts()
        {
            try
            {
                var productos = _obtenerProductoActivossUseCase.Execute();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "error al obtener los productos",
                    message = ex.Message,
                });
            }
        }
    }
    
}
