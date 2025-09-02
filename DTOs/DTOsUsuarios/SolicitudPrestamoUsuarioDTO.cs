using System.ComponentModel.DataAnnotations;

namespace CalculadoraDePrestamos.DTOs.DTOsUsuarios
{
    public class SolicitudPrestamoUsuarioDTO
    {

        public int Id { get; set; } 
        public string? UsuarioId { get; set; }
      
        public decimal Monto { get; set; }

      
        public int PlazoAnios { get; set; }

       
        public double TasaInteres { get; set; }
        public DateTime FechaCreacionSolicitud { get; set; }

    }
}
