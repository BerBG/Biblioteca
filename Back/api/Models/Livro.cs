using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty; // Identificador único internacional
        public string Descricao { get; set; } = string.Empty;
        public string CapaUrl { get; set; } = string.Empty; // URL da imagem da capa
        public int Paginas { get; set; }
        public bool Disponivel { get; set; } = true;
        public DateTime AnoPublicacao { get; set; } = DateTime.MinValue;
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        // Chaves estrangeiras
        public int AutorId { get; set; }
        public int GeneroId { get; set; }

        // Navegação
        public Autor Autor { get; set; } = null!;
        public Genero Genero { get; set; } = null!;

        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
        public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
        public ICollection<ColecaoLivro> ColecoesLivros { get; set; } = new List<ColecaoLivro>();
    }
}