using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Avaliacao;
using api.Models;

namespace api.Interfaces
{
    public interface IAvaliacaoRepository
    {
        Task<List<Avaliacao>> GetByLivroIdAsync(int LivroId);        
        Task<Avaliacao?> GetByIdAsync(int id);
        Task<Avaliacao> CreateAsync(Avaliacao avaliacaoModel);
        Task<Avaliacao?> UpdateAsync(int id, UpdateAvaliacaoRequestDto avaliacaoDto);
        Task<Avaliacao?> DeleteAsync(int id);
    }
}