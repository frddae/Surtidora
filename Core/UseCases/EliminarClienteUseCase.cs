using Core.Entities;
using Core.Interfaces;

namespace Core.UseCases
{
    public class EliminarClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public EliminarClienteUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool Execute(int clienteId)
        {
           return _clienteRepository.EliminarCliente(clienteId);
        }
    }
}
