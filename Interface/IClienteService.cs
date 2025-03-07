using SistemaCotizaciones.Models;

namespace SistemaCotizaciones.Interface
{
    public interface IClienteService
    {
        void CrearCliente(Cliente cliente);
        Cliente ObtenerCliente(int id);
        IEnumerable<Cliente> ObtenerTodosLosClientes();
        void ActualizarCliente(Cliente cliente);
        void EliminarCliente(int id);
    }
}
