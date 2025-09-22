using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Livro;
using api.Helpers;
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

        public async Task<Livro> CreateAsync(Livro livroModel)
        {
            await _context.Livros.AddAsync(livroModel);
            await _context.SaveChangesAsync();

            return await _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .FirstAsync(l => l.Id == livroModel.Id);
        }

        public async Task<List<Livro>> GetAllAsync(QueryObject query)
        {
            var livros = _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .Include(l => l.Comentarios)
                .ThenInclude(c => c.Usuario)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Titulo))
            {
                livros = livros.Where(l => l.Titulo.Contains(query.Titulo));
            }

            if (query.AutorId.HasValue)
            {
                livros = livros.Where(l => l.AutorId == query.AutorId.Value);
            }

            if (query.GeneroId.HasValue)
            {
                livros = livros.Where(l => l.GeneroId == query.GeneroId.Value);
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Titulo", StringComparison.OrdinalIgnoreCase))
                    livros = query.IsDescending ? livros.OrderByDescending(l => l.Titulo) : livros.OrderBy(l => l.Titulo);
                else if (query.SortBy.Equals("AnoPublicacao", StringComparison.OrdinalIgnoreCase))
                    livros = query.IsDescending ? livros.OrderByDescending(l => l.AnoPublicacao) : livros.OrderBy(l => l.AnoPublicacao);
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            livros = livros.Skip(skipNumber).Take(query.PageSize);

            return await livros.ToListAsync();
        }

        public async Task<Livro?> GetByIdAsync(int id)
        {
            return await _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .Include(l => l.Comentarios)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Livro?> UpdateAsync(int id, UpdateLivroRequestDto livroDto)
        {
            var existingLivro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == id);

            if (existingLivro == null)
            {
                return null;
            }

            existingLivro.Titulo = livroDto.Titulo;
            existingLivro.ISBN = livroDto.ISBN;
            existingLivro.Descricao = livroDto.Descricao;
            existingLivro.Paginas = livroDto.Paginas;
            existingLivro.AnoPublicacao = livroDto.AnoPublicacao;
            existingLivro.AutorId = livroDto.AutorId;
            existingLivro.GeneroId = livroDto.GeneroId;

            await _context.SaveChangesAsync();

            return await _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Livro?> DeleteAsync(int id)
        {
            var livroModel = await _context.Livros.FirstOrDefaultAsync(x => x.Id == id);

            if (livroModel == null)
            {
                return null;
            }

            _context.Livros.Remove(livroModel);
            await _context.SaveChangesAsync();
            return livroModel;
        }

        public Task<bool> LivroExists(int id)
        {
            return _context.Livros.AnyAsync(l => l.Id == id);
        }

        public async Task<Livro?> GetByIsbnAsync(string isbn)
        {
            return await _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(l => l.ISBN == isbn);
        }
    }
}