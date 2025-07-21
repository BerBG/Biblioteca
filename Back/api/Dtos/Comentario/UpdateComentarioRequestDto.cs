using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comentario
{
    public class UpdateComentarioRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Titulo deve ter no mínimo 5 caracteres.")]
        [MaxLength(100, ErrorMessage = "Titulo deve ter no máximo 100 caracteres.")]
        public string Texto { get; set; } = string.Empty;
    }
}   