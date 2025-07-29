using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Conta;
using api.Interfaces;
using api.Models;
using api.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    [Route("api/conta")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly ITokenService _tokenService;
        public ContaController(UserManager<Usuario> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastro([FromBody] CadastroDto cadastroDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var usuario = new Usuario
                {
                    UserName = cadastroDto.Email,
                    Nome = cadastroDto.NomeUsuario,
                    Email = cadastroDto.Email
                };

                var usuarioCriado = await _userManager.CreateAsync(usuario, cadastroDto.Senha);

                if (usuarioCriado.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(usuario, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUsuarioDto
                            {
                                UserName = usuario.UserName,
                                Email = usuario.Email,
                                Token = _tokenService.CreateToken(usuario)
                            }
                        );
                    }
                    else
                    {
                        return BadRequest("Erro ao atribuir a role ao usuário.");
                    }
                }
                else
                {
                    return StatusCode(500, usuarioCriado.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}