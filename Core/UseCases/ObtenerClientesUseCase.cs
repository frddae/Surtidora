using Core.Entities;
using Core.Interfaces;

namespace Core.UseCases
{
    public class ObtenerClientesUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ObtenerClientesUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public List<Cliente> Execute()
        {
            return _clienteRepository.ObtenerClientes();
        }
    }
}
