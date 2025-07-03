using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Livro
{
    public class CreateLivroRequestDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string CapaUrl { get; set; } = string.Empty;
        public int Paginas { get; set; }
        public DateTime AnoPublicacao { get; set; }
        public int AutorId { get; set; }
        public int GeneroId { get; set; }
    }
}