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
    public class LivroRepository : ILivroRepository
    {
        private readonly ApplicationDBContext _context;

        public LivroRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<List<Livro>> GetAllAsync()
        {
            return _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .ToListAsync();
        }
    }
}