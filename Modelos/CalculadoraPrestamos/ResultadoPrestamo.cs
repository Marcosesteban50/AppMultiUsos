namespace CalculadoraDePrestamos.Modelos.CalculadoraPrestamos
{
    public class ResultadoPrestamo
    {
        public decimal PagoMensual { get; set; }
        public decimal InteresTotal { get; set; }
        public decimal PagoTotal { get; set; }
        public List<ItemAmortizacion>? TablaAmortizacion { get; set; }
    }
}
