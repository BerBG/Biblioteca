using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Dtos.Livro;

namespace api.Controllers
{
    [Route("api/livro")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public LivroController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var livros = _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .ToList()
                .Select(LivroMapper.ToLivroDto)
                .ToList();

            return Ok(livros);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var livro = _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .FirstOrDefault(l => l.Id == id);

            if (livro == null)
            {
                return NotFound();
            }

            return Ok(LivroMapper.ToLivroDto(livro));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateLivroRequestDto livroDto)
        {
            var livro = livroDto.ToLivroFromCreateDTO();
            _context.Livros.Add(livro);
            _context.SaveChanges();

            var livroCompleto = _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .FirstOrDefault(l => l.Id == livro.Id);

            if (livroCompleto == null)
            {
                return NotFound();
            }

            return Ok(LivroMapper.ToLivroDto(livroCompleto));
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateLivroRequestDto updateDto)
        {
            var livroModel = _context.Livros.FirstOrDefault(x => x.Id == id);

            if (livroModel == null)
            {
                return NotFound();
            }

            livroModel.Titulo = updateDto.Titulo;
            livroModel.ISBN = updateDto.ISBN;
            livroModel.Descricao = updateDto.Descricao;
            livroModel.CapaUrl = updateDto.CapaUrl;
            livroModel.Paginas = updateDto.Paginas;
            livroModel.AnoPublicacao = updateDto.AnoPublicacao;
            livroModel.AutorId = updateDto.AutorId;
            livroModel.GeneroId = updateDto.GeneroId;

            _context.SaveChanges();

            var livroCompleto = _context.Livros
               .Include(l => l.Autor)
               .Include(l => l.Genero)
               .FirstOrDefault(l => l.Id == livroModel.Id);

            if (livroCompleto == null)
            {
                return NotFound();
            }

            return Ok(LivroMapper.ToLivroDto(livroCompleto));
        }
    }
}