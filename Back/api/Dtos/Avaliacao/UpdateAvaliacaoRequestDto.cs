using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Avaliacao
{
    public class UpdateAvaliacaoRequestDto
    {
        [Required]
        [Range(1, 5, ErrorMessage = "A nota deve ser entre 1 e 5.")]
        public int Nota { get; set; }

        [MaxLength(500, ErrorMessage = "O comentário não pode exceder 500 caracteres.")]
        public string? Comentario { get; set; }
    }
}