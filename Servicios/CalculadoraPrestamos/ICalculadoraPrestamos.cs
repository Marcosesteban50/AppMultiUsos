using CalculadoraDePrestamos.Modelos.CalculadoraPrestamos;

namespace CalculadoraDePrestamos.Servicios.CalculadoraPrestamos
{
    public interface ICalculadoraPrestamos
    {
        ResultadoPrestamo CalcularPrestamo(SolicitudPrestamo solicitud);
    }
}
