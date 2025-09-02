using CalculadoraDePrestamos.DTOs;

namespace CalculadoraDePrestamos.Utilidades
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Paginar<T>(this IEnumerable<T> enumerable,
            PaginacionDTO paginacionDTO)
        {
            return enumerable
                .Skip((paginacionDTO.Pagina - 1) * paginacionDTO.RecordsPorPagina)
                .Take(paginacionDTO.RecordsPorPagina);
        }
    }
}
