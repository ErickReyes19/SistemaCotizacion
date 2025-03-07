namespace SistemaCotizaciones.Models
{
    public class TipoSeguro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Cotizacion> Cotizaciones { get; set; } = new List<Cotizacion>();
    }
}
