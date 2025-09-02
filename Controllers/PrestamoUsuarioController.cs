using System.Security.Claims;
using AppMultiUsos.Servicios;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CalculadoraDePrestamos.Data;
using CalculadoraDePrestamos.DTOs;
using CalculadoraDePrestamos.DTOs.DTOsUsuarios;
using CalculadoraDePrestamos.Modelos.CalculadoraPrestamosUsuarios;
using CalculadoraDePrestamos.Servicios.CalculadoraPrestamosUsuarios;
using CalculadoraDePrestamos.Utilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace AppMultiUsos.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    
    public class PrestamoUsuarioController : Controller
    {
        private readonly IMapper mapper;
        private readonly iCalculadoraPrestamosUsuario calculadoraPrestamos;
        private readonly ApplicationDbContext dbContext;
        private readonly IOutputCacheStore outputCacheStore;
        private readonly IServicioUsuarios servicioUsuarios;

        public PrestamoUsuarioController(IMapper mapper, iCalculadoraPrestamosUsuario calculadoraPrestamos,
            ApplicationDbContext dbContext, IOutputCacheStore outputCacheStore
          ,IServicioUsuarios servicioUsuarios)
        {
            this.mapper = mapper;
            this.calculadoraPrestamos = calculadoraPrestamos;
            this.dbContext = dbContext;
            this.outputCacheStore = outputCacheStore;
            this.servicioUsuarios = servicioUsuarios;
        }







        [HttpGet]
        [OutputCache(Tags = ["prestamos"])]
        public async Task<ActionResult<List<SolicitudPrestamoUsuarioDTO>>> Get()
        {

            var usuarioId = await servicioUsuarios.ObtenerUsuarioId();

            if (usuarioId == null)
            {
                return Unauthorized("No esta autorizado");
            }

            var result = await dbContext.SolicitudPrestamos.
                Where(x => x.UsuarioId == usuarioId).
                 ProjectTo<SolicitudPrestamoUsuarioDTO>
                 (mapper.ConfigurationProvider).ToListAsync();

            
            
            

            if (result.Count == 0)
            {
                return NotFound("No hay prestamos");
            }

            return result;

        }

      



        [HttpPost("calcular")]
        public async Task<IActionResult> Calcular([FromBody] SolicitudPrestamoUsuarioCreacionDTO solicitudPrestamoUsuarioCreacionDTO,
            [FromQuery] PaginacionDTO paginacionDTO)
        {



            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuarioId = await servicioUsuarios.ObtenerUsuarioId();


            if (usuarioId == null)
            {
                return Unauthorized("No esta autorizado");
            }

            //SolicitudCreacioDTO -> SolicitudPrestamoUsuario
            var solicitud = mapper.Map<SolicitudPrestamoUsuario>(solicitudPrestamoUsuarioCreacionDTO);

            solicitud.UsuarioId = usuarioId;

            try
            {

                var resultado = mapper.Map<SolicitudPrestamoUsuario>(solicitud);
                var resultadoPrestamo = calculadoraPrestamos.CalcularPrestamo(resultado);

                dbContext.SolicitudPrestamos.Add(solicitud);
                await dbContext.SaveChangesAsync();

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
                    Data = tablaPaginada
                  
                };


                
                await outputCacheStore.EvictByTagAsync("prestamos", default);

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
