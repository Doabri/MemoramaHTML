namespace MemoramaHTML.Models.DTOs
{
    public class ResultadoPartidaDTO
    {
        public int? IdUsuario { get; set; }
        public int TiempoSegundos { get; set; }
        public int Errores { get; set; }
        public int ParesEncontrados { get; set; }
        public int TotalPares { get; set; }
        public string? Categoria { get; set; }
        public int? Puntuacion { get; set; }

        public IEnumerable<int> ConceptosUsados { get; set; } = null!;
    }
}
