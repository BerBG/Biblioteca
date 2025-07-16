using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comentario;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comentario")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioRepository _comentarioRepo;
        private readonly ILivroRepository _livroRepo;
        public ComentarioController(IComentarioRepository comentarioRepo, ILivroRepository livroRepo)
        {
            _comentarioRepo = comentarioRepo;
            _livroRepo = livroRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comentarios = await _comentarioRepo.GetAllAsync();

            var comentarioDto = comentarios
                .Select(c => c.ToComentarioDto())
                .ToList();

            return Ok(comentarioDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comentario = await _comentarioRepo.GetByIdAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return Ok(comentario.ToComentarioDto());
        }

        [HttpPost("{livroId}")]
        public async Task<IActionResult> Create([FromRoute] int livroId, CreateComentarioDto comentarioDto)
        {
            if (!await _livroRepo.LivroExists(livroId))
            {
                return BadRequest("Livro não encontrado.");
            }

            var comentarioModel = comentarioDto.ToComentarioFromCreate(livroId);
            await _comentarioRepo.CreateAsync(comentarioModel);

            return CreatedAtAction(nameof(GetById), new { id = comentarioModel.Id }, comentarioModel.ToComentarioDto());
        }
    }
}