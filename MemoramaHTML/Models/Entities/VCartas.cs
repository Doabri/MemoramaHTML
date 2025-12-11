using System;
using System.Collections.Generic;

namespace MemoramaHTML.Models.Entities;

public partial class VCartas
{
    public int ConceptId { get; set; }

    public string? CardId { get; set; }

    public string Tipo { get; set; } = null!;

    public string Contenido { get; set; } = null!;

    public string Categoria { get; set; } = null!;
}
