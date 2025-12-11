using MemoramaHTML.Models.DTOs;
using MemoramaHTML.Models.Entities;
using MemoramaHTML.Repository;

namespace MemoramaHTML.Services
{
    public class ResultadosService
    {
        private readonly Repository<ResultadosMemorama> repository;
        private readonly Repository<PartidaConceptos> partidaConceptosRepository;

        public ResultadosService(
            Repository<ResultadosMemorama> repository,
            Repository<PartidaConceptos> partidaConceptosRepository)
        {
            this.repository = repository;
            this.partidaConceptosRepository = partidaConceptosRepository;
        }

        public void GuardarResultado(ResultadoPartidaDTO dto)
        {
            var resultado = new ResultadosMemorama
            {
                IdUsuario = dto.IdUsuario,
                FechaPartida = DateTime.Now,
                TiempoSegundos = dto.TiempoSegundos,
                Errores = dto.Errores,
                ParesEncontrados = dto.ParesEncontrados,
                TotalPares = dto.TotalPares,
                Categoria = dto.Categoria,
                Puntuacion = dto.Puntuacion ?? CalcularPuntuacion(dto.TiempoSegundos, dto.Errores)
            };

            repository.Insert(resultado);

            foreach (var idConcepto in dto.ConceptosUsados)
            {
                var partidaConcepto = new PartidaConceptos
                {
                    IdResultado = resultado.IdResultado,
                    IdConcepto = idConcepto
                };
                partidaConceptosRepository.Insert(partidaConcepto);
            }
        }

        private int CalcularPuntuacion(int tiempoSegundos, int errores)
        {
            int puntuacion = 1000;
            puntuacion -= tiempoSegundos * 10;
            puntuacion -= errores * 50;
            return Math.Max(puntuacion, 0);
        }
    }
}