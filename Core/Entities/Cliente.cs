using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Cliente
    {
        [JsonPropertyName("clienteId")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres")]
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder 50 caracteres")]
        [JsonPropertyName("apellido")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "Documento requerido")]
        [StringLength(50, ErrorMessage = "El documento no puede exceder 50 caracteres")]
        [JsonPropertyName("documento")]
        public string Documento { get; set; } = string.Empty;

        [JsonPropertyName("fechaRegistro")]
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "debe poseer un estado")]
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
    }
}