using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class ProductosActivos
    {
        [JsonPropertyName("ProductoId")]
        public int ProductoId { get; set; }

        [JsonPropertyName("NombreProducto")]
        public string? NombreProducto { get; set; }

        [JsonPropertyName("Proveedor")]
        public string? Proveedor { get; set; }

        [JsonPropertyName ("precio")]
        public float Precio { get; set; }

        [JsonPropertyName("Cantidad")]
        public int Cantidad { get; set; }

        [JsonPropertyName("Presentacion")]
        public string? Presentacion { get; set; }

        [JsonPropertyName ("Fecha_Caducidad")]
        public DateTime Fecha_Caducidad { get; set; }
    }
}
