using SistemaCotizaciones.Interface;
using SistemaCotizaciones.Models;
using SistemaCotizaciones.Repositories;

namespace SistemaCotizaciones.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void CrearCliente(Cliente cliente)
        {
            _clienteRepository.Add(cliente);
        }

        public Cliente ObtenerCliente(int id)
        {
            return _clienteRepository.GetById(id);
        }

        public IEnumerable<Cliente> ObtenerTodosLosClientes()
        {
            return _clienteRepository.GetAll();
        }

        public void ActualizarCliente(Cliente cliente)
        {
            _clienteRepository.Update(cliente);
        }

        public void EliminarCliente(int id)
        {
            _clienteRepository.Delete(id);
        }
    }
}
