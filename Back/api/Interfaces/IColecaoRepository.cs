using api.Models;

namespace api.Interfaces
{
    public interface IColecaoRepository
    {
        Task<List<Livro>> GetUserCollection(Usuario usuario);
    }
}