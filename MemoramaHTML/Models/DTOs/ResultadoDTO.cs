namespace MemoramaHTML.Models.DTOs
{
    public class ResultadoDTO
    {
        public int IdResultado { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime? FechaPartida { get; set; }
        public int TiempoSegundos { get; set; }
        public string TiempoHms { get; set; } = null!;
        public int Errores { get; set; }
        public int ParesEncontrados { get; set; }
        public int TotalPares { get; set; }
        public decimal? TiempoPromedioPorParSeg { get; set; }
        public decimal? EficienciaPct { get; set; }
        public int? Puntuacion { get; set; }
    }
}
