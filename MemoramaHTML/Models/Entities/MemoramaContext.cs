using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MemoramaHTML.Models.Entities;

public partial class MemoramaContext : DbContext
{
    public MemoramaContext()
    {
    }

    public MemoramaContext(DbContextOptions<MemoramaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ConceptosHtml> ConceptosHtml { get; set; }

    public virtual DbSet<EstadisticasConceptos> EstadisticasConceptos { get; set; }

    public virtual DbSet<PartidaConceptos> PartidaConceptos { get; set; }

    public virtual DbSet<ResultadosMemorama> ResultadosMemorama { get; set; }

    public virtual DbSet<VCartas> VCartas { get; set; }

    public virtual DbSet<VResultadoResumen> VResultadoResumen { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=Memorama", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<ConceptosHtml>(entity =>
        {
            entity.HasKey(e => e.IdConcepto).HasName("PRIMARY");

            entity.ToTable("conceptos_html");

            entity.HasIndex(e => e.Categoria, "idx_categoria");

            entity.HasIndex(e => e.Termino, "uk_termino").IsUnique();

            entity.Property(e => e.IdConcepto).HasColumnName("id_concepto");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .HasColumnName("categoria");
            entity.Property(e => e.Definicion)
                .HasColumnType("text")
                .HasColumnName("definicion");
            entity.Property(e => e.Ejemplo)
                .HasColumnType("text")
                .HasColumnName("ejemplo");
            entity.Property(e => e.Termino)
                .HasMaxLength(100)
                .HasColumnName("termino");
        });

        modelBuilder.Entity<EstadisticasConceptos>(entity =>
        {
            entity.HasKey(e => e.IdEstadistica).HasName("PRIMARY");

            entity.ToTable("estadisticas_conceptos");

            entity.HasIndex(e => e.IdConcepto, "idx_concepto");

            entity.HasIndex(e => e.UltimaRespuesta, "idx_ultima_respuesta");

            entity.Property(e => e.IdEstadistica).HasColumnName("id_estadistica");
            entity.Property(e => e.IdConcepto).HasColumnName("id_concepto");
            entity.Property(e => e.TiempoPromedioRespuesta)
                .HasDefaultValueSql("'0'")
                .HasColumnName("tiempo_promedio_respuesta");
            entity.Property(e => e.TotalAciertos)
                .HasDefaultValueSql("'0'")
                .HasColumnName("total_aciertos");
            entity.Property(e => e.TotalIntentos)
                .HasDefaultValueSql("'0'")
                .HasColumnName("total_intentos");
            entity.Property(e => e.UltimaRespuesta)
                .HasColumnType("datetime")
                .HasColumnName("ultima_respuesta");

            entity.HasOne(d => d.IdConceptoNavigation).WithMany(p => p.EstadisticasConceptos)
                .HasForeignKey(d => d.IdConcepto)
                .HasConstraintName("fk_concepto_estadistica");
        });

        modelBuilder.Entity<PartidaConceptos>(entity =>
        {
            entity.HasKey(e => e.IdPartidaConcepto).HasName("PRIMARY");

            entity.ToTable("partida_conceptos");

            entity.HasIndex(e => e.IdConcepto, "fk_partida_concepto");

            entity.HasIndex(e => e.IdResultado, "idx_resultado_concepto");

            entity.Property(e => e.IdPartidaConcepto).HasColumnName("id_partida_concepto");
            entity.Property(e => e.IdConcepto).HasColumnName("id_concepto");
            entity.Property(e => e.IdResultado).HasColumnName("id_resultado");

            entity.HasOne(d => d.IdConceptoNavigation).WithMany(p => p.PartidaConceptos)
                .HasForeignKey(d => d.IdConcepto)
                .HasConstraintName("fk_partida_concepto");

            entity.HasOne(d => d.IdResultadoNavigation).WithMany(p => p.PartidaConceptos)
                .HasForeignKey(d => d.IdResultado)
                .HasConstraintName("fk_partida_resultado");
        });

        modelBuilder.Entity<ResultadosMemorama>(entity =>
        {
            entity.HasKey(e => e.IdResultado).HasName("PRIMARY");

            entity.ToTable("resultados_memorama");

            entity.HasIndex(e => e.Categoria, "idx_categoria_res");

            entity.HasIndex(e => e.FechaPartida, "idx_fecha");

            entity.HasIndex(e => e.Puntuacion, "idx_puntuacion");

            entity.Property(e => e.IdResultado).HasColumnName("id_resultado");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .HasColumnName("categoria");
            entity.Property(e => e.Errores).HasColumnName("errores");
            entity.Property(e => e.FechaPartida)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha_partida");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ParesEncontrados).HasColumnName("pares_encontrados");
            entity.Property(e => e.Puntuacion).HasColumnName("puntuacion");
            entity.Property(e => e.TiempoSegundos).HasColumnName("tiempo_segundos");
            entity.Property(e => e.TotalPares).HasColumnName("total_pares");
        });

        modelBuilder.Entity<VCartas>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_cartas");

            entity.Property(e => e.CardId)
                .HasMaxLength(13)
                .HasColumnName("card_id");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("categoria");
            entity.Property(e => e.ConceptId).HasColumnName("concept_id");
            entity.Property(e => e.Contenido)
                .HasColumnType("mediumtext")
                .HasColumnName("contenido");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<VResultadoResumen>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_resultado_resumen");

            entity.Property(e => e.EficienciaPct)
                .HasPrecision(16, 2)
                .HasColumnName("eficiencia_pct");
            entity.Property(e => e.Errores).HasColumnName("errores");
            entity.Property(e => e.FechaPartida)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha_partida");
            entity.Property(e => e.IdResultado).HasColumnName("id_resultado");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ParesEncontrados).HasColumnName("pares_encontrados");
            entity.Property(e => e.Puntuacion).HasColumnName("puntuacion");
            entity.Property(e => e.TiempoHms)
                .HasColumnType("time")
                .HasColumnName("tiempo_hms");
            entity.Property(e => e.TiempoPromedioPorParSeg)
                .HasPrecision(13, 2)
                .HasColumnName("tiempo_promedio_por_par_seg");
            entity.Property(e => e.TiempoSegundos).HasColumnName("tiempo_segundos");
            entity.Property(e => e.TotalPares).HasColumnName("total_pares");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
