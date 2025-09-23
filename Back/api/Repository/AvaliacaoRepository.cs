using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Avaliacao;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly ApplicationDBContext _context;
        public AvaliacaoRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Avaliacao> CreateAsync(Avaliacao avaliacaoModel)
        {
            throw new NotImplementedException();
        }

        public async Task<Avaliacao?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Avaliacao?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Avaliacao>> GetByLivroIdAsync(int LivroId)
        {
            throw new NotImplementedException();
        }

        public async Task<Avaliacao?> UpdateAsync(int id, UpdateAvaliacaoRequestDto avaliacaoDto)
        {
            throw new NotImplementedException();
        }
    }
}