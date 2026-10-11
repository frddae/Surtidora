using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Producto
    {
        [JsonPropertyName("productoId")]
        public int ProductoId { get; set; }
        [JsonPropertyName("proveedor")]
        public int ProveedorId { get; set; }

        [JsonPropertyName("nombreProducto")]
        public string? NombreProducto { get; set; }

        [JsonPropertyName ("precio")]
        public float Precio { get; set; }

        [JsonPropertyName ("activo")]
        public bool Activo { get; set; }
    }
}
