using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comentario
{
    public class ComentarioDto
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public DateTime Data { get; set; } = DateTime.Now;
        public int LivroId { get; set; }
        public string LivroTitulo { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; } = string.Empty;
    }
}