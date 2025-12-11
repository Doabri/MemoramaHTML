using MemoramaHTML.Models.DTOs;
using MemoramaHTML.Models.Entities;
using MemoramaHTML.Repository;

namespace MemoramaHTML.Services
{
    public class MemoramaService
    {
        private readonly Repository<ConceptosHtml> repository;

        public MemoramaService(Repository<ConceptosHtml> repository)
        {
            this.repository = repository;
        }

        public TableroDTO ObtenerCartas(int cantidad = 12)
        {
            var conceptos = repository.GetAll().ToList();
            var conceptosAleatorios = conceptos
                .OrderBy(x => Guid.NewGuid())
                .Take(cantidad / 2)
                .ToList();

            var cartas = new List<CartaDTO>();
            foreach (var concepto in conceptosAleatorios)
            {
                cartas.Add(new CartaDTO
                {
                    ConceptId = concepto.IdConcepto,      
                    CardId = $"T_{concepto.IdConcepto}", 
                    Contenido = concepto.Termino,
                    Tipo = "termino",
                    Categoria = concepto.Categoria
                });

                cartas.Add(new CartaDTO
                {
                    ConceptId = concepto.IdConcepto,      
                    CardId = $"D_{concepto.IdConcepto}", 
                    Contenido = concepto.Definicion,
                    Tipo = "definicion",
                    Categoria = concepto.Categoria
                });
            }

            cartas = cartas.OrderBy(x => Guid.NewGuid()).ToList();

            return new TableroDTO
            {
                Cartas = cartas,
                TotalPares = cantidad / 2,
                Categoria = null
            };
        }

        public TableroDTO ObtenerCartasPorCategoria(string categoria, int cantidad = 12)
        {
            var conceptos = repository.GetAll()
                .Where(x => x.Categoria == categoria)
                .ToList();

            var conceptosAleatorios = conceptos
                .OrderBy(x => Guid.NewGuid())
                .Take(cantidad / 2)
                .ToList();

            var cartas = new List<CartaDTO>();

            foreach (var concepto in conceptosAleatorios)
            {
                cartas.Add(new CartaDTO
                {
                    ConceptId = concepto.IdConcepto,
                    CardId = $"T_{concepto.IdConcepto}",
                    Contenido = concepto.Termino,
                    Tipo = "termino",
                    Categoria = concepto.Categoria
                });

                cartas.Add(new CartaDTO
                {
                    ConceptId = concepto.IdConcepto,
                    CardId = $"D_{concepto.IdConcepto}",
                    Contenido = concepto.Definicion,
                    Tipo = "definicion",
                    Categoria = concepto.Categoria
                });
            }

            cartas = cartas.OrderBy(x => Guid.NewGuid()).ToList();

            return new TableroDTO
            {
                Cartas = cartas,
                TotalPares = cantidad / 2,
                Categoria = categoria
            };
        }
    }
}
