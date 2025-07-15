using api.Models;
using api.Dtos.Livro;
using api.Mappers;

public static class LivroMapper
{
    public static LivroDto ToLivroDto(this Livro livroModel)
    {
        return new LivroDto
        {
            Id = livroModel.Id,
            Titulo = livroModel.Titulo,
            ISBN = livroModel.ISBN,
            Descricao = livroModel.Descricao,
            CapaUrl = livroModel.CapaUrl,
            Paginas = livroModel.Paginas,
            Disponivel = livroModel.Disponivel,
            AnoPublicacao = livroModel.AnoPublicacao,
            DataCadastro = livroModel.DataCadastro,
            AutorId = livroModel.AutorId,
            AutorNome = livroModel.Autor.Nome,
            GeneroId = livroModel.GeneroId,
            GeneroNome = livroModel.Genero.Nome,
            Comentarios = livroModel.Comentarios.Select(c => c.ToComentarioDto()).ToList()
        };
    }

    public static Livro ToLivroFromCreateDTO(this CreateLivroRequestDto livroDto)
    {
        return new Livro
        {
            Titulo = livroDto.Titulo,
            ISBN = livroDto.ISBN,
            Descricao = livroDto.Descricao,
            CapaUrl = livroDto.CapaUrl,
            Paginas = livroDto.Paginas,
            Disponivel = true,
            AnoPublicacao = livroDto.AnoPublicacao,
            AutorId = livroDto.AutorId,
            GeneroId = livroDto.GeneroId
        };
    }
}