using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Proveedor
    {
        [JsonPropertyName("proveedorId")]
        public int ProveedorId { get; set; }

        [JsonPropertyName("nombreProveedor")]
        public string? NombreProveedor { get; set; }

        [JsonPropertyName("direccion")]
        public string? Direccion { get; set; }

        [JsonPropertyName("telefono")]
        public string? Telefono { get; set; }

        //fecha de ingreso

        [JsonPropertyName("activo")]
        public bool Activo { get; set; }
    }
}
