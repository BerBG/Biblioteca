using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/colecao")]
    public class ColecaoController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly ILivroRepository _livroRepo;
        private readonly IColecaoRepository _colecaoRepo;

        public ColecaoController(UserManager<Usuario> userManager, ILivroRepository livroRepo, IColecaoRepository colecaoRepo)
        {
            _userManager = userManager;
            _livroRepo = livroRepo;
            _colecaoRepo = colecaoRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserCollection()
        {
            var username = User.GetUsername();

            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("Usuário não encontrado.");
            }

            var usuario = await _userManager.FindByNameAsync(username);

            var usuarioColecao = await _colecaoRepo.GetUserCollection(usuario);

            if (usuarioColecao == null)
            {
                return NotFound("Coleção não encontrada.");
            }

            return Ok(usuarioColecao);
        }
    }
}