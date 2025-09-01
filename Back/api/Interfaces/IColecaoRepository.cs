using api.Models;

namespace api.Interfaces
{
    public interface IColecaoRepository
    {
        Task<List<Livro>> GetUserCollection(Usuario usuario);
        Task<Colecao?> GetByIdAsync(int colecaoId);
        Task<bool> CreateAsync(ColecaoLivro colecaoLivro);
    }
}