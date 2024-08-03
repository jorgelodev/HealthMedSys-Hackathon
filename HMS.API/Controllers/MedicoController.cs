using AutoMapper;
using HMS.Infra.Services.DTOs.Medicos;
using HMS.Infra.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    
    [ApiController]
    [Route("medico")]
    public class MedicoController : MainController
    {
        private readonly IMedicoService _medicoService;
        private readonly IMapper _mapper;

        public MedicoController(IMedicoService medicoService, IMapper mapper)
        {
            _medicoService = medicoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cadastro de médicos.
        /// </summary>
        /// <param name="medicoViewModel">ViewModel para cadastro de médico.</param>        
        /// <remarks>
        /// 
        /// O médico poderá se cadastrar preenchendo os campos: Nome, CPF, Email, Senha e CRM.
        /// 
        /// </remarks>
        /// <response code="200">Cadastro Realizado com sucesso</response>
        /// <response code="400">Cadastro não realizado, é retornado mensagem com o(s) motivo(s).</response>
        [HttpPost]
        public IActionResult Cadastrar(CadastraMedicoViewModel medicoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var medicoCadastrado = _medicoService.Cadastrar(_mapper.Map<CadastraMedicoDto>(medicoViewModel));

            return Ok(medicoCadastrado);

        }

        /// <summary>
        /// Busca por médicos disponíveis. (Requer Autenticação e Autorização)
        /// </summary>    
        /// /// <remarks>
        /// 
        /// Busca por médicos disponíveis. 
        /// 
        /// </remarks>
        /// <response code="200">Alteração Realizada com sucesso</response>
        /// <response code="400">Alteração não realizada, é retornado mensagem com o(s) motivo(s).</response>
        /// <response code="401">Usuário não autenticado.</response>
        /// <response code="403">Usuário não possui permissão de acesso.</response>
        [Authorize(Roles = "Paciente")]
        [HttpGet("disponiveis")]
        public IActionResult Disponiveis()
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);            

            return Ok(_medicoService.Disponiveis());

        }
    }
}
