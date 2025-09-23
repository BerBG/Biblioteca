using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Avaliacao
{
    public class AvaliacaoDto
    {
        public int Id { get; set; }
        public int Nota { get; set; }
        public string? Comentario { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public int LivroId { get; set; }
        public string UsuarioNome { get; set; } = string.Empty;
    }
}