using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Livro;
using api.Models;

namespace api.Interfaces
{
    public interface ILivroRepository
    {
        Task<List<Livro>> GetAllAsync();
        Task<Livro?> GetByIdAsync(int id);
        Task<Livro> CreateAsync(Livro livroModel);
        Task<Livro?> UpdateAsync(int id, UpdateLivroRequestDto livroDto);
        Task<Livro?> DeleteAsync(int id);
        Task<bool> LivroExists(int id);
    }
}