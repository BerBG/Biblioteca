using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Livro
{
    public class UpdateLivroRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "O título não pode exceder 100 caracteres.") ]
        public string Titulo { get; set; } = string.Empty;
        [Required]
        [MaxLength(13, ErrorMessage = "O ISBN não pode exceder 13 caracteres.")]
        [MinLength(10, ErrorMessage = "O ISBN deve ter pelo menos 10 caracteres.")]
        public string ISBN { get; set; } = string.Empty;
        [Required]
        [MaxLength(500, ErrorMessage = "A descrição não pode exceder 500 caracteres.")]
        [MinLength(20, ErrorMessage = "A descrição deve ter pelo menos 20 caracteres.")]
        public string Descricao { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Capa do Livro")]
        public IFormFile CapaImagem { get; set; } = default!;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O número de páginas deve ser maior que zero.")]
        [Display(Name = "Número de Páginas")]
        public int Paginas { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Ano de Publicação")]
        public DateTime AnoPublicacao { get; set; }
        public int AutorId { get; set; }
        public int GeneroId { get; set; }
    }
}