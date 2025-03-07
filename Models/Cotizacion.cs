namespace SistemaCotizaciones.Models
{
    public class Cotizacion
    {
        public int Id { get; set; }
        public string NumeroCotizacion { get; set; }
        public DateOnly FechaCotizacion { get; set; }
        public int TipoSeguroId { get; set; }
        public TipoSeguro TipoSeguro { get; set; }  
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }  
        public string Moneda { get; set; }
        public string Descripcion { get; set; }
        public decimal SumaAsegurada { get; set; }
        public decimal Tasa { get; set; }
        public decimal PrimaNeta { get; set; }
    }
}
