using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ColecaoLivro
    {
        public int ColecaoId { get; set; }
        public Colecao Colecao { get; set; } = null!;

        public int LivroId { get; set; }
        public Livro Livro { get; set; } = null!;
    }
}