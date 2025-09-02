using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CalculadoraDePrestamos.Validaciones;
using Microsoft.AspNetCore.Identity;

namespace CalculadoraDePrestamos.Modelos.CalculadoraPrestamosUsuarios
{
    public class SolicitudPrestamoUsuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El {0} es requerido")]
        [Rango]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [RangoAños]
        public int PlazoAnios { get; set; }

        [Required(ErrorMessage = "La tasa de interés es requerida")]
        [TasaInteres]
        public double TasaInteres { get; set; }

        public DateTime FechaCreacionSolicitud { get; set; } = DateTime.Now;

        public string UsuarioId { get; set; } = null!;

        public IdentityUser Usuario { get; set; } = null!;

    }
}
