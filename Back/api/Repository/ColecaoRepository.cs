using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ColecaoRepository : IColecaoRepository
    {
        private readonly ApplicationDBContext _context;

        public ColecaoRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Livro>> GetUserCollection(Usuario usuario)
        {
            return await _context.Colecoes
                .Where(c => c.UsuarioId == usuario.Id)                       // filtra pelo dono
                .SelectMany(c => c.ColecoesLivros.Select(cl => cl.Livro))    // achata para livros
                .Distinct()                                                  // remove duplicados
                .AsNoTracking()                                              // leitura
                .ToListAsync();                                              // executa
        }
    }
}