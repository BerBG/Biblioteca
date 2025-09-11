using api.Models;

namespace api.Interfaces
{
    public interface IColecaoRepository
    {
        Task<List<Livro>> GetUserCollection(Usuario usuario);
        Task<Colecao?> GetByIdAsync(int colecaoId);
        Task<Colecao> CreateAsync(ColecaoLivro colecaoLivro);
        Task<Colecao> DeleteAsync(Colecao colecao);
    }
}