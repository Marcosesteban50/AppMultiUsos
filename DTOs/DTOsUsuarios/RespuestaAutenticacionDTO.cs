namespace AppMultiUsos.DTOs.DTOsUsuarios
{
    public class RespuestaAutenticacionDTO
    {
        public required string Token { get; set; }  
        public DateTime Expiracion { get; set; }
    }
}
