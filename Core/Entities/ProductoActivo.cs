using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class ProductosActivos
    {
        [JsonPropertyName("productoId")]
        public int ProductoId { get; set; }

        [JsonPropertyName("nombreProducto")]
        public string? NombreProducto { get; set; }

        [JsonPropertyName("proveedorId")]
        public int ProveedorId { get; set; }

        [JsonPropertyName ("precio")]
        public float Precio { get; set; }

        [JsonPropertyName("cantidad")]
        public int Cantidad { get; set; }

        [JsonPropertyName("presentacion")]
        public string? Presentacion { get; set; }

        [JsonPropertyName ("fecha_Caducidad")]
        public DateTime Fecha_Caducidad { get; set; }
    }
}
