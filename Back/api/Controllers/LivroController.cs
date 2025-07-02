using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}