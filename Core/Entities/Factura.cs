using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Factura
    {
        [JsonPropertyName("FacturaId")]
        public int FacturaId { get; set; }
        
        [JsonPropertyName("ClienteId")]
        public int ClienteId { get; set; }
        [JsonPropertyName ("FechaFactura")]
        public DateTime FechaFactura { get; set; }

        [JsonPropertyName("Monto")]
        public int Monto { get; set; }

        [JsonPropertyName ("comentario")]
        [StringLength (50, ErrorMessage = "comentario no puede exeder 50 caracteres")]
        public string? Comentario { get; set; }

    }
}
