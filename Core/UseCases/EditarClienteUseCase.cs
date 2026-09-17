using Core.Entities;
using Core.Interfaces;

namespace Core.UseCases
{
    public class EditarClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public EditarClienteUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Execute(Cliente cliente)
        {
            _clienteRepository.EditarCliente(cliente);
        }
    }
}
