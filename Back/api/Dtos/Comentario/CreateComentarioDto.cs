using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comentario
{
    public class CreateComentarioDto
    {
        public string Texto { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
    }
}