using Microsoft.EntityFrameworkCore;
using SistemaCotizaciones.Context;
using SistemaCotizaciones.Interface;
using SistemaCotizaciones.Models;
using System.Collections.Generic;

namespace SistemaCotizaciones.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        // Aquí usas tu contexto de base de datos para interactuar con los clientes
        private readonly ContextoDB _context;

        public ClienteRepository(ContextoDB context)
        {
            _context = context;
        }

        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public Cliente GetById(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public void Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
