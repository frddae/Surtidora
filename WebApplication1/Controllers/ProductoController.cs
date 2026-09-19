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
        private readonly InsertarLoteUseCase _insertarLoteUseCase;
        private readonly ObtenerLoteProductosUseCase _obtenerLoteProductosUseCase;

        public ProductosController(ObtenerProductosUseCase obtenerProductosUseCase, ObtenerProductoActivossUseCase obtenerProductoActivossUseCase, InsertarLoteUseCase insertarLoteUseCase, ObtenerLoteProductosUseCase obtenerLoteProductosUseCase)
        {
            _obtenerProductosUseCase = obtenerProductosUseCase;
            _obtenerProductoActivossUseCase = obtenerProductoActivossUseCase;
            _obtenerLoteProductosUseCase = obtenerLoteProductosUseCase;
            _insertarLoteUseCase = insertarLoteUseCase;
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

        [HttpPost]
        [Route("CreateLoteProducto")]
        public IActionResult CreateLoteProducto(LoteProducto loteProducto)
        {
            try
            {
                var result = _insertarLoteUseCase.Execute(loteProducto);
                return Ok(loteProducto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "error al crear el lote de productos",
                    message = ex.Message,
                });
            }
        }
        [HttpGet]
        [Route("GetLoteProductos")]
        public IActionResult GetLoteProductos()
        {
            try
            {
                var productos = _obtenerLoteProductosUseCase.Execute();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "error al obtener los lotes de productos",
                    message = ex.Message,
                });
            }
        }
    }

}