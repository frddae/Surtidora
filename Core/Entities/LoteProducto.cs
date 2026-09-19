using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class LoteProducto
    {
        [JsonPropertyName("ProductoId")]
        public int ProductoId { get; set; }

        [JsonPropertyName("CodigoLote")]
        public string? CodigoLote { get; set; }

        [JsonPropertyName("FechaVencimiento")]
        public DateTime FechaVencimiento { get; set; }

        [JsonPropertyName("CantidadInicial")]
        public int CantidadInicial { get; set; }

    }
}
