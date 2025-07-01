using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }
        
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Colecao> Colecoes { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<ColecaoLivro> ColecoesLivros { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ColecaoLivro>(b =>
            {
                b.HasKey(cl => new { cl.ColecaoId, cl.LivroId });

                b.HasOne(cl => cl.Colecao)
                    .WithMany(c => c.ColecoesLivros)
                    .HasForeignKey(cl => cl.ColecaoId);

                b.HasOne(cl => cl.Livro)
                    .WithMany(l => l.ColecoesLivros)
                    .HasForeignKey(cl => cl.LivroId);
            });
        }
    }
}