namespace MemoramaHTML.Models.DTOs
{
    public class TableroDTO
    {
        public IEnumerable<CartaDTO> Cartas { get; set; } = null!;
        public int TotalPares { get; set; }
        public string? Categoria { get; set; }
    }
}
