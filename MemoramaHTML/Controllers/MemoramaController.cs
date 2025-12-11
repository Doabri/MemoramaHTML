using MemoramaHTML.Models.DTOs;
using MemoramaHTML.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemoramaHTML.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoramaController : ControllerBase
    {
        private readonly MemoramaService memoramaService;
        private readonly ResultadosService resultadosService;

        public MemoramaController(MemoramaService memoramaService,
                                  ResultadosService resultadosService)
        {
            this.memoramaService = memoramaService;
            this.resultadosService = resultadosService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tablero = memoramaService.ObtenerCartas(); 
            return Ok(tablero);
        }

        [HttpGet("{categoria}")]
        public IActionResult Get(string categoria)
        {
            var tablero = memoramaService.ObtenerCartasPorCategoria(categoria); 
            return Ok(tablero);
        }

        [HttpPost]
        public IActionResult Post(ResultadoPartidaDTO dto)
        {
            resultadosService.GuardarResultado(dto);
            return Ok();
        }
    }
}