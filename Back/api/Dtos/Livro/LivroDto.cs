using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Livro
{
    public class LivroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string CapaUrl { get; set; } = string.Empty;
        public int Paginas { get; set; }
        public bool Disponivel { get; set; } = true;
        public DateTime AnoPublicacao { get; set; } = DateTime.MinValue;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public int AutorId { get; set; }
        public string AutorNome { get; set; } = string.Empty;
        public int GeneroId { get; set; }
        public string GeneroNome { get; set; } = string.Empty;
    }
}