namespace MemoramaHTML.Models.DTOs
{
    public class CartaDTO
    {
        public int ConceptId { get; set; }
        public string CardId { get; set; } = null!;
        public string Tipo { get; set; } = null!;       
        public string Contenido { get; set; } = null!;
        public string Categoria { get; set; } = null!;
    }
}
