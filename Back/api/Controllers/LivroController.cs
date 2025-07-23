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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var livros = await _livroRepo.GetAllAsync();

            var livrosDto = livros.Select(l => l.ToLivroDto());

            return Ok(livrosDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var livro = await _livroRepo.GetByIdAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            return Ok(livro.ToLivroDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateLivroRequestDto livroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var livroModel = livroDto.ToLivroFromCreateDTO();

            if (livroDto.CapaImagem != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens");
                Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + livroDto.CapaImagem.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await livroDto.CapaImagem.CopyToAsync(fileStream);
                }

                // Preenche a URL da capa no model
                livroModel.CapaUrl = "/imagens/" + uniqueFileName;
            }

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var livroModel = await _livroRepo.DeleteAsync(id);

            if (livroModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}