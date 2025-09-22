using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comentario;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using api.Models;

namespace api.Controllers
{
    [Route("api/comentario")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioRepository _comentarioRepo;
        private readonly ILivroRepository _livroRepo;
        private readonly UserManager<Usuario> _userManager;
        public ComentarioController(IComentarioRepository comentarioRepo, ILivroRepository livroRepo, UserManager<Usuario> userManager)
        {
            _comentarioRepo = comentarioRepo;
            _livroRepo = livroRepo;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comentarios = await _comentarioRepo.GetAllAsync();

            var comentarioDto = comentarios
                .Select(c => c.ToComentarioDto())
                .ToList();

            return Ok(comentarioDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comentario = await _comentarioRepo.GetByIdAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return Ok(comentario.ToComentarioDto());
        }

        [HttpPost("{livroId:int}")]
        public async Task<IActionResult> Create([FromRoute] int livroId, CreateComentarioDto comentarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _livroRepo.LivroExists(livroId))
            {
                return BadRequest("Livro não encontrado.");
            }

            var username = User.GetUsername();
            var usuario = await _userManager.FindByNameAsync(username);

            var comentarioModel = comentarioDto.ToComentarioFromCreate(livroId);
            comentarioModel.UsuarioId = usuario.Id;
            await _comentarioRepo.CreateAsync(comentarioModel);

            return CreatedAtAction(nameof(GetById), new { id = comentarioModel.Id }, comentarioModel.ToComentarioDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateComentarioRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comentario = await _comentarioRepo.UpdateAsync(id, updateDto.ToComentarioFromUpdate());

            if (comentario == null)
            {
                return NotFound("Comentário não encontrado.");
            }

            return Ok(comentario.ToComentarioDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comentario = await _comentarioRepo.DeleteAsync(id);

            if (comentario == null)
            {
                return NotFound("Comentário não encontrado.");
            }

            return Ok(comentario);
        }
    }
}