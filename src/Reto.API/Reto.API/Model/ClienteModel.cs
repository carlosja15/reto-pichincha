using Newtonsoft.Json;
using Reto.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Reto.API.Model
{
    [JsonObject]
    public class ClienteModel
    {
        [JsonProperty]
        [Required(ErrorMessage = "El cliente debe tener un nombre")]
        public string Nombre { get; set; } = default!;
        [JsonProperty]
        [Required(ErrorMessage = "El cliente debe tener una edad")]
        public int Edad { get; set; }
        [JsonProperty]
        [Required(ErrorMessage = "El cliente debe tener un genero")]
        public GeneroPersona Genero { get; set; }
        [JsonProperty]
        [Required(ErrorMessage = "El cliente debe tener una identificacion")]
        public string Identificacion { get; set; } = default!;
        [JsonProperty]
        [Required(ErrorMessage = "El cliente debe tener una dirección")]
        public string Direccion { get; set; } = default!;
        [JsonProperty]
        [Required(ErrorMessage = "El cliente debe tener un número de telefono")]
        public string Telefono { get; set; } = default!;
        [JsonProperty]
        [Required(ErrorMessage = "El cliente debe tener una contraseña")]
        public string Contrasenia { get; set; } = default!;
    }
}
