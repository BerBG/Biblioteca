using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly ApplicationDBContext _context;
        public ComentarioRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Comentario>> GetAllAsync()
        {
            return await _context.Comentarios
                .Include(c => c.Livro)
                .Include(c => c.Usuario)
                .ToListAsync();
        }
    }
}