using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        // Relacionamento inverso
        public ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}