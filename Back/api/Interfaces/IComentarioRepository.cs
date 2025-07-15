using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comentario;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Interfaces
{
    public interface IComentarioRepository
    {
        Task<List<Comentario>> GetAllAsync();
        Task<Comentario?> GetByIdAsync(int id);
        Task<Comentario?> CreateAsync(Comentario comentarioModel);
        Task<Comentario?> UpdateAsync(int id, UpdateComentarioRequestDto comentarioModel);
        Task<Comentario?> DeleteAsync(int id);
    }
}