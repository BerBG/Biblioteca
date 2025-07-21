using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Dtos.Livro;
using api.Interfaces;

namespace api.Controllers
{
    [Route("api/livro")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ILivroRepository _livroRepo;
        public LivroController(ApplicationDBContext context, ILivroRepository livroRepo)
        {
            _livroRepo = livroRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var livros = await _livroRepo.GetAllAsync();

            var livrosDto = livros.Select(l => l.ToLivroDto());

            return Ok(livrosDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var livro = await _livroRepo.GetByIdAsync(id);

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
            var livroCompleto = await _livroRepo.CreateAsync(livroModel);

            if (livroCompleto == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = livroCompleto.Id }, livroCompleto.ToLivroDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateLivroRequestDto updateDto)
        {
            var livroModel = await _livroRepo.UpdateAsync(id, updateDto);

            if (livroModel == null)
            {
                return NotFound();
            }

            return Ok(livroModel.ToLivroDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var livroModel = await _livroRepo.DeleteAsync(id);

            if (livroModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}