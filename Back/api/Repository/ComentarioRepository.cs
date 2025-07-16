using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comentario;
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

        public async Task<Comentario> CreateAsync(Comentario comentarioModel)
        {
            await _context.Comentarios.AddAsync(comentarioModel);
            await _context.SaveChangesAsync();
            return comentarioModel;
        }

        public async Task<List<Comentario>> GetAllAsync()
        {
            return await _context.Comentarios
                .Include(c => c.Livro)
                .Include(c => c.Usuario)
                .ToListAsync();
        }

        public async Task<Comentario?> GetByIdAsync(int id)
        {
            return await _context.Comentarios
                .Include(c => c.Livro)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comentario?> UpdateAsync(int id, UpdateComentarioRequestDto comentarioModel)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null) return null;

            comentario.Texto = comentarioModel.Texto;
            comentario.Data = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return comentario;
        }
        
        public async Task<Comentario?> DeleteAsync(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null) return null;

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();
            return comentario;
        }


    }
}