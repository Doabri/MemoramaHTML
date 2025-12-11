using System;
using System.Collections.Generic;

namespace MemoramaHTML.Models.Entities;

public partial class PartidaConceptos
{
    public int IdPartidaConcepto { get; set; }

    public int IdResultado { get; set; }

    public int IdConcepto { get; set; }

    public virtual ConceptosHtml IdConceptoNavigation { get; set; } = null!;

    public virtual ResultadosMemorama IdResultadoNavigation { get; set; } = null!;
}
