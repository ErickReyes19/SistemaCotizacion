using SistemaCotizaciones.Models;

namespace SistemaCotizaciones.Interface
{
    public interface IClienteRepository
    {
        void Add(Cliente cliente);
        Cliente GetById(int id);
        IEnumerable<Cliente> GetAll();
        void Update(Cliente cliente);
        void Delete(int id);
    }
}
