using Core.Entities;

namespace Core.Interfaces
{
    public interface IClienteRepository
    {
        int CrearCliente(Cliente cliente);
        void EditarCliente(Cliente cliente);
        bool EliminarCliente(int clienteId);
        List<Cliente> ObtenerClientes();
    }
}
