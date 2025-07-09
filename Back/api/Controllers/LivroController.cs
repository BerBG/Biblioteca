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
        public async Task<IActionResult> GetAll()
        {
            var livros = await _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .ToListAsync();

            var livrosDto = livros.Select(l => l.ToLivroDto()).ToList();

            return Ok(livrosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var livro = await _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (livro == null)
            {
                return NotFound();
            }

            return Ok(livro.ToLivroDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLivroRequestDto livroDto)
        {
            var livroModel = livroDto.ToLivroFromCreateDTO();
            await _context.Livros.AddAsync(livroModel);
            await _context.SaveChangesAsync();

            var livroCompleto = await _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(l => l.Id == livroModel.Id);

            if (livroCompleto == null)
            {
                return NotFound();
            }

            var livroDtoResult = LivroMapper.ToLivroDto(livroCompleto);

            return CreatedAtAction(nameof(GetById), new { id = livroModel.Id }, livroDtoResult);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateLivroRequestDto updateDto)
        {
            var livroModel = await _context.Livros.FirstOrDefaultAsync(x => x.Id == id);

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

            await _context.SaveChangesAsync();

            var livroCompleto = await _context.Livros
               .Include(l => l.Autor)
               .Include(l => l.Genero)
               .FirstOrDefaultAsync(l => l.Id == livroModel.Id);

            if (livroCompleto == null)
            {
                return NotFound();
            }

            return Ok(LivroMapper.ToLivroDto(livroCompleto));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var livroModel = await _context.Livros.FirstOrDefaultAsync(x => x.Id == id);

            if (livroModel == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livroModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}