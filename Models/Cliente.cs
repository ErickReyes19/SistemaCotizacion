namespace SistemaCotizaciones.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Identidad { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string TipoCliente { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public ICollection<Cotizacion> Cotizaciones { get; set; } = new List<Cotizacion>();
    }
}
