using AutoMapper;
using HMS.Domain.Excepctions;
using HMS.Infra.Services.DTOs.Usuarios;
using HMS.Infra.Services.Interfaces;
using HMS.Infra.Services.ViewModels.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HMS.API.Controllers
{

    [Route("autenticacao")]
    [ApiController]
    public class AutenticacaoController : MainController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public AutenticacaoController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        /// <summary>
        /// Realizar Login.
        /// </summary>
        /// <param name="usuarioViewModel">ViewModel para realizar Login.</param>        
        /// <remarks>
        /// 
        /// O usuário poderá realizar login informando e-mail e senha.
        /// 
        /// </remarks>
        /// <response code="200">Login Realizado com sucesso</response>
        /// <response code="400">Login não realizado, é retornado mensagem com o(s) motivo(s).</response>
        /// <response code="401">Login não realizado, acesso não autorizado.</response>
        [HttpPost("login")]
        public IActionResult RealizarLogin(UsuarioViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuarioAutenticado = _usuarioService.AutenticarUsuario(_mapper.Map<UsuarioLogonDto>(model));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Fi4p$Hack@Th0n-2024-Jorge-Oliveira");

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.Email)
                };
            claims.AddRange(usuarioAutenticado.Claims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { Token = tokenHandler.WriteToken(token), UsuarioAutenticado = usuarioAutenticado });
        }
    }
}
