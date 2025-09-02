using CalculadoraDePrestamos.Modelos.CalculadoraPrestamos;

namespace AppMultiUsos.DTOs
{
    public class SolicitudPrestamoPaginada : SolicitudPrestamo
    {

        public int Pagina { get; set; }
        public int RecordsPorPagina { get; set; }
    }
}
