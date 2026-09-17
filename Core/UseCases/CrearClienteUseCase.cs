using Core.Entities;
using Core.Interfaces;

namespace Core.UseCases
{
    public class CrearClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public CrearClienteUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public int Execute(Cliente cliente)
        {
            return _clienteRepository.CrearCliente(cliente);
        }
    }
}
