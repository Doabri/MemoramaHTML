using System;
using System.Collections.Generic;

namespace MemoramaHTML.Models.Entities;

public partial class ResultadosMemorama
{
    public int IdResultado { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaPartida { get; set; }

    public int TiempoSegundos { get; set; }

    public int Errores { get; set; }

    public int ParesEncontrados { get; set; }

    public int TotalPares { get; set; }

    public string? Categoria { get; set; }

    public int? Puntuacion { get; set; }

    public virtual ICollection<PartidaConceptos> PartidaConceptos { get; set; } = new List<PartidaConceptos>();
}
