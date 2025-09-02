
using AppMultiUsos.Modelos.CalculadoraDivisas;
using AppMultiUsos.Servicios.CalculadoraDivisas;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMultiUsos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraDivisasController : Controller
    {
        private readonly IMapper mapper;
        private readonly iCalculadoraDivisas calculadoraDivisas;

        public CalculadoraDivisasController(IMapper mapper, iCalculadoraDivisas calculadoraDivisas)
        {
            this.mapper = mapper;
            this.calculadoraDivisas = calculadoraDivisas;
        }



        [HttpPost]
        public IActionResult Post([FromBody] CalcularDivisas modelo)
        {



            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                var calculo = calculadoraDivisas.Operar(modelo.Monto, modelo.Desde!, modelo.Hacia!);

                return Ok(new { total = calculo });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

        }



    }
}
