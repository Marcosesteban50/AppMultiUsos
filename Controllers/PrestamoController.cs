using System.Threading.Tasks;
using AutoMapper;
using CalculadoraDePrestamos.DTOs;
using CalculadoraDePrestamos.Modelos.CalculadoraPrestamos;
using CalculadoraDePrestamos.Servicios.CalculadoraPrestamos;
using CalculadoraDePrestamos.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace AppMultiUsos.Controllers
{



    [ApiController]
    [Route("api/[controller]")]
    public class PrestamoController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly ICalculadoraPrestamos calculadoraPrestamos;

        public PrestamoController(IMapper mapper, ICalculadoraPrestamos calculadoraPrestamos)
        {

            this.mapper = mapper;
            this.calculadoraPrestamos = calculadoraPrestamos;
        }




        [HttpPost("calcular")]
        [OutputCache]
        public IActionResult Calcular([FromBody] SolicitudPrestamoDTO solicitudPrestamoDTO,
            [FromQuery] PaginacionDTO paginacionDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var resultado = mapper.Map<SolicitudPrestamo>(solicitudPrestamoDTO);
                var resultadoPrestamo = calculadoraPrestamos.CalcularPrestamo(resultado);



                var tablaPaginada = resultadoPrestamo.TablaAmortizacion!
                    .OrderBy(x => x.Mes)
                    .Paginar(paginacionDTO).ToList();

                HttpContext.InsertarParametrosPaginacionEnCabecera(resultadoPrestamo.TablaAmortizacion!);

                var contadorTabla = resultadoPrestamo.TablaAmortizacion!.Count;


                var respuesta = new
                {

                    totalRegistros = contadorTabla,
                    pagina = paginacionDTO.Pagina,
                    recordsPorPagina = paginacionDTO.RecordsPorPagina,
                    TotalPaginas = (int)Math.Ceiling(contadorTabla / (double)paginacionDTO.RecordsPorPagina),
                    tablaAmortizacion = tablaPaginada
                };


                return Ok(respuesta);

            }
            catch (DivideByZeroException)
            {

                return StatusCode(500, $"Error intero: Se intento dividir por 0");
            }
            catch (Exception ex)
            {
                {
                    return StatusCode(500, $"Error interno: {ex.Message}");

                }



            }
        }

    }

}