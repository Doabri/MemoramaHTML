using System;
using System.Collections.Generic;

namespace MemoramaHTML.Models.Entities;

public partial class VResultadoResumen
{
    public int IdResultado { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaPartida { get; set; }

    public int TiempoSegundos { get; set; }

    public TimeOnly? TiempoHms { get; set; }

    public int Errores { get; set; }

    public int ParesEncontrados { get; set; }

    public int TotalPares { get; set; }

    public decimal? TiempoPromedioPorParSeg { get; set; }

    public decimal? EficienciaPct { get; set; }

    public int? Puntuacion { get; set; }
}
