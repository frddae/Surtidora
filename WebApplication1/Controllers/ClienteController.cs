using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using Infrastructure.Data;
using Core.Entities;
using Core.UseCases;
using Microsoft.AspNetCore.RateLimiting;

namespace SurtidoraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly CrearClienteUseCase _crearClienteUseCase;
        private readonly EditarClienteUseCase _editarClienteUseCase;
        private readonly EliminarClienteUseCase _eliminarClienteUseCase;
        private readonly ObtenerClientesUseCase _getClientUseCase;

        public ClienteController(CrearClienteUseCase crearClienteUseCase, EditarClienteUseCase editarClienteUseCase,
                                    EliminarClienteUseCase eliminarClienteUseCase, ObtenerClientesUseCase getClientUseCase)
        {
            _crearClienteUseCase = crearClienteUseCase;
            _editarClienteUseCase = editarClienteUseCase;
            _eliminarClienteUseCase = eliminarClienteUseCase;
            _getClientUseCase = getClientUseCase;
        }

        [HttpGet("GetClients")] 
        public IActionResult GetClients()
        {
            try
            {
                var clientes = _getClientUseCase.Execute();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "error al obtener clientes",
                    message = ex.Message,
                });      
            }
        }

        [HttpPost("CrearClientes")]
        public IActionResult crearCliente([FromBody] Cliente cliente)
        {
            try
            {
                int id = _crearClienteUseCase.Execute(cliente);
                cliente.ClienteId = id;
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "error al crear al cliente (be)",
                    message = ex.Message,
                });
            }     
        }

        [HttpPut("EditarClientes")] 
        public IActionResult EditarCliente([FromBody] Cliente cliente) 
        {
            try
            {
                _editarClienteUseCase.Execute(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "error al editar al cliente",
                    message = ex.Message,
                });
            }        
        }

        [HttpPut("EliminarClientes/{id}")]
        public async Task<ActionResult<bool>> EliminarCliente(int id) 
        {
            try
            {
                bool clienteExiste = _eliminarClienteUseCase.Execute(id);
                return Ok(clienteExiste);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "error al elminar al cliente",
                    message = ex.Message,
                });
            }           
        }
    }
}
