using Microsoft.EntityFrameworkCore;

namespace CalculadoraDePrestamos.Utilidades
{
    public static class HttpContextExetensions
    {
        public static void InsertarParametrosPaginacionEnCabecera<T>
            (this HttpContext context, IEnumerable<T> enumerable)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var cantidad = enumerable.Count();
            context.Response.Headers.Append("cantidad-total-registros", cantidad.ToString());

        }
    }
}
