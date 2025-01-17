﻿using AutoMapper;
using HMS.Infra.Services.DTOs.Consultas;
using HMS.Infra.Services.DTOs.HorarioDisponiveis;
using HMS.Infra.Services.DTOs.Usuarios;
using HMS.Infra.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace HMS.API.Controllers
{
    [ApiController]
    [Route("consulta")]
    public class ConsultaController : MainController
    {
        private readonly IConsultaService _consultaService;
        private readonly IMapper _mapper;

        public ConsultaController(IConsultaService consultaService, IMapper mapper)
        {
            _consultaService = consultaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Agendamento de consulta (Requer Autenticação e Autorização).
        /// </summary>
        /// <param name="agendaConsultaViewModel">ViewModel para agendamento de consultas.</param>        
        /// <remarks>
        /// 
        /// O paciente poderá agendar sua consulta informando o campo HorarioDisponivelId.
        /// 
        /// </remarks>
        /// <response code="200">Cadastro Realizado com sucesso</response>
        /// <response code="400">Cadastro não realizado, é retornado mensagem com o(s) motivo(s).</response>
        /// <response code="401">Usuário não autenticado.</response>
        /// <response code="403">Usuário não possui permissão de acesso.</response>
        [Authorize(Roles = "Paciente")]
        [HttpPost]
        public IActionResult Agendar(AgendaConsultaViewModel agendaConsultaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var claimsIdentity = User.Identity as ClaimsIdentity;
                      

            if (claimsIdentity != null)
            {
                var usuarioAutenticadoClaim = claimsIdentity.FindFirst("UsuarioAutenticado");

                if (usuarioAutenticadoClaim != null)
                {
                    var claims = claimsIdentity.Claims;
                    var user = claims.Where(c => c.Type.Equals("UsuarioAutenticado")).FirstOrDefault();

                    var usuarioAutenticado = new UsuarioAutenticadoDto() { Id = int.Parse(user.Value) };

                    //UsuarioAutenticadoDto usuarioAutenticado = JsonSerializer.Deserialize<UsuarioAutenticadoDto>(user.Value);

                    var agendaConsultaDto = new AgendaConsultaDto()
                    {
                        UsuarioAutenticadoDto = usuarioAutenticado,                        
                        HorarioDisponivelId = agendaConsultaViewModel.HorarioDisponivelId
                    };


                    var consultaAgendada = _consultaService.Agendar(agendaConsultaDto);

                    return Ok(consultaAgendada);

                }
            }                    

            return Unauthorized();

        }

       
    }

   

   
}
