using System;
using System.Collections.Generic;

namespace MemoramaHTML.Models.Entities;

public partial class ConceptosHtml
{
    public int IdConcepto { get; set; }

    public string Termino { get; set; } = null!;

    public string Definicion { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public string? Ejemplo { get; set; }

    public virtual ICollection<EstadisticasConceptos> EstadisticasConceptos { get; set; } = new List<EstadisticasConceptos>();

    public virtual ICollection<PartidaConceptos> PartidaConceptos { get; set; } = new List<PartidaConceptos>();
}
