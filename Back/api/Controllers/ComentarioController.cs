using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comentario")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IComentarioRepository _comentarioRepo;
        public ComentarioController(ApplicationDBContext context, IComentarioRepository comentarioRepo)
        {
            _comentarioRepo = comentarioRepo;
            _context = context;
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
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var comentario = await _comentarioRepo.GetByIdAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return Ok(comentario.ToComentarioDto());
        }

    }
}