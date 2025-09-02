namespace CalculadoraDePrestamos.Modelos.CalculadoraPrestamos
{
    public class ItemAmortizacion
    {
        public int Mes { get; set; }
        public decimal Pago { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal SaldoRestante { get; set; }
    }
}
