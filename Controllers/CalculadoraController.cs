using AutoMapper;
using CalculadoraDePrestamos.DTOs;
using CalculadoraDePrestamos.Modelos.CalculadoraMatematica;
using CalculadoraDePrestamos.Modelos.CalculadoraPrestamos;
using CalculadoraDePrestamos.Servicios.CalculadoraMatematica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace AppMultiUsos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : Controller
    {
        private readonly iCalculadora calculadora;
        private readonly IMapper mapper;

        public CalculadoraController(iCalculadora calculadora,IMapper mapper)
        {
            this.calculadora = calculadora;
            this.mapper = mapper;
        }

        [HttpPost]
        [OutputCache]
        public IActionResult Calcular([FromBody] OperacionCalculadoraDTO operacion)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultadoOperacion = mapper.Map<OperacionCalculadora>(operacion);

            var resultado = calculadora.Operar(resultadoOperacion.Numero1, resultadoOperacion.Operacion!);
            return Ok(new {total = resultado});

            
        }

    }
}
