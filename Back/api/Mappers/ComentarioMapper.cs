using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comentario;
using api.Models;

namespace api.Mappers
{
    public static class ComentarioMapper
    {
        public static ComentarioDto ToComentarioDto(this Comentario comentarioModel)
        {
            return new ComentarioDto
            {
                Id = comentarioModel.Id,
                Texto = comentarioModel.Texto,
                Data = comentarioModel.Data,
                LivroId = comentarioModel.LivroId,
                LivroTitulo = comentarioModel.Livro?.Titulo ?? string.Empty,
                UsuarioId = comentarioModel.UsuarioId,
                UsuarioNome = comentarioModel.Usuario?.Nome ?? string.Empty
            };
        }

        public static Comentario ToComentarioFromCreate(this CreateComentarioDto comentarioDto, int livroId)
        {
            return new Comentario
            {
                Texto = comentarioDto.Texto,
                UsuarioId = comentarioDto.UsuarioId,
                LivroId = livroId
            };
        }

        public static Comentario ToComentarioFromUpdate(this UpdateComentarioRequestDto comentarioDto)
        {
            return new Comentario
            {
                Texto = comentarioDto.Texto
            };
        }
    }
}