using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Nacionalidade { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; } = DateTime.MinValue;

        // Relacionamento
        public ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}