using CalculadoraDePrestamos.Modelos.CalculadoraPrestamos;
using CalculadoraDePrestamos.Modelos.CalculadoraPrestamosUsuarios;

namespace CalculadoraDePrestamos.Servicios.CalculadoraPrestamosUsuarios
{
    public class CalculadoraPrestamosUsuario : iCalculadoraPrestamosUsuario
    {


        public ResultadoPrestamo CalcularPrestamo(SolicitudPrestamoUsuario solicitud)
        {
            // Convertir tasa anual a tasa mensual en formato decimal
            decimal tasaMensual = (decimal)Math.Round(solicitud.TasaInteres / 100 / 12, 8);

            // Calcular el número total de pagos
            int totalPagos = solicitud.PlazoAnios * 12;

            // Calcular el pago mensual

            //https://chatgpt.com/c/68503f5f-0180-8009-a00b-23671461e4b1 Explicacion
            //Detallada de la formula francesa
            decimal pagoMensual = solicitud.Monto *
                Math.Round(tasaMensual *
                (decimal)Math.Pow(1 + (double)tasaMensual, totalPagos) /
                (decimal)(Math.Pow(1 + (double)tasaMensual, totalPagos) - 1), 4);




            // Inicializar tabla de amortización
            var tabla = new List<ItemAmortizacion>();

            //saldo
            decimal saldoRestante = solicitud.Monto;

            for (int mes = 1; mes <= totalPagos; mes++)
            {
                decimal pagoInteres = Math.Round(saldoRestante * tasaMensual, 4);
                decimal pagoCapital = Math.Round(pagoMensual - pagoInteres, 4);
                saldoRestante = Math.Round(saldoRestante - pagoCapital, 4);

                tabla.Add(new ItemAmortizacion
                {
                    Mes = mes,
                    Pago = pagoMensual,
                    Capital = pagoCapital,
                    Interes = pagoInteres,
                    SaldoRestante = saldoRestante > 0 ? saldoRestante : 0
                });
            }

            // Calcular resumen con redondeo
            decimal pagoTotal = Math.Round(pagoMensual * totalPagos, 4);
            decimal interesTotal = Math.Round(pagoTotal - solicitud.Monto, 4);

            return new ResultadoPrestamo
            {
                PagoMensual = pagoMensual,
                InteresTotal = interesTotal,
                PagoTotal = pagoTotal,
                TablaAmortizacion = tabla
            };
        }
    }
}