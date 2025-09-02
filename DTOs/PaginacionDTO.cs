namespace CalculadoraDePrestamos.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;
        private int recordsPorPagina = 999;
        


        public int RecordsPorPagina
        {
            get => recordsPorPagina;
            set => recordsPorPagina = value;
        }


    }
}
