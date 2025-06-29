using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int Nota { get; set; } // De 1 a 5
        public string? Comentario { get; set; } // Opcional
        public DateTime Data { get; set; } = DateTime.Now;

        // Relacionamento
        public int LivroId { get; set; }
        public Livro Livro { get; set; } = null!;

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
    }
}