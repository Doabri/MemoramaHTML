using System;
using System.Collections.Generic;

namespace MemoramaHTML.Models.Entities;

public partial class EstadisticasConceptos
{
    public int IdEstadistica { get; set; }

    public int IdConcepto { get; set; }

    public int? TotalIntentos { get; set; }

    public int? TotalAciertos { get; set; }

    public float? TiempoPromedioRespuesta { get; set; }

    public DateTime? UltimaRespuesta { get; set; }

    public virtual ConceptosHtml IdConceptoNavigation { get; set; } = null!;
}
