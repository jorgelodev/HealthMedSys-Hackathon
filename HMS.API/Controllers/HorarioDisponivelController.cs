using AutoMapper;
using HMS.Infra.Services.DTOs.HorarioDisponiveis;
using HMS.Infra.Services.DTOs.Medicos;
using HMS.Infra.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    [ApiController]
    [Route("horario-disponivel")]
    public class HorarioDisponivelController : MainController
    {
        private readonly IHorarioDisponivelService _horarioDisponivelService;
        private readonly IMapper _mapper;

        public HorarioDisponivelController(IHorarioDisponivelService horarioDisponivelService, IMapper mapper)
        {
            _horarioDisponivelService = horarioDisponivelService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cadastro de Horários Disponíveis.
        /// </summary>
        /// <param name="horarioDisponivelViewModel">ViewModel para cadastro de Horário Disponível.</param>        
        /// <remarks>
        /// 
        /// O médico poderá cadastrar horários disponíveis preenchendo os campos: MedicoId, DataHoraInicio e DataHoraFim.
        /// 
        /// </remarks>
        /// <response code="200">Cadastro Realizado com sucesso</response>
        /// <response code="400">Cadastro não realizado, é retornado mensagem com o(s) motivo(s).</response>
        [HttpPost]
        public IActionResult Cadastrar(CadastraHorarioDisponivelViewModel horarioDisponivelViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var horarioDisponivelCadastrado = _horarioDisponivelService.Cadastrar(_mapper.Map<CadastraHorarioDisponivelDto>(horarioDisponivelViewModel));
            
            return Ok(horarioDisponivelCadastrado);

        }

        /// <summary>
        /// Alteração de horários disponíveis.
        /// </summary>
        /// <param name="alteraHorarioDisponivelViewModel">ViewModel para alterar horário disponível.</param>        
        /// <remarks>
        /// 
        /// Informe o id do horário disponível, DataHoraInicio e DataHoraFim para realizar a alteração. 
        /// 
        /// </remarks>
        /// <response code="200">Alteração Realizada com sucesso</response>
        /// <response code="400">Alteração não realizada, é retornado mensagem com o(s) motivo(s).</response>
        [HttpPut]
        public IActionResult Alterar(AlteraHorarioDisponivelViewModel alteraHorarioDisponivelViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var alteraMedicoDto = _horarioDisponivelService.Alterar(_mapper.Map<AlteraHorarioDisponivelDto>(alteraHorarioDisponivelViewModel));

            return Ok(alteraMedicoDto);

        }
    }
}
