using CalculadoraDePrestamos.Modelos.CalculadoraPrestamos;
using CalculadoraDePrestamos.Modelos.CalculadoraPrestamosUsuarios;

namespace CalculadoraDePrestamos.Servicios.CalculadoraPrestamosUsuarios
{
    public interface iCalculadoraPrestamosUsuario
    {
        ResultadoPrestamo CalcularPrestamo(SolicitudPrestamoUsuario solicitud);
    }
}
