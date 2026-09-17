using Core.Entities;
using Core.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace SurtidoraApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly ObtenerFacturasUseCase _obtenerFacturasUseCase;
        public FacturaController(ObtenerFacturasUseCase obtenerFacturasUseCase)
        {
            _obtenerFacturasUseCase = obtenerFacturasUseCase;   
        }

        [HttpGet]
        [Route("getFacturas")]
        public IActionResult getFacturas() 
        {
            try
            {
                var facturas = _obtenerFacturasUseCase.Execute();
                return Ok(facturas);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, new
                {
                    error = "error al obtener facutras",
                    message = ex.Message
                });
            }
        }
    }
}
