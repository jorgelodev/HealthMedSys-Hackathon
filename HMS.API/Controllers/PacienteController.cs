using AutoMapper;
using HMS.Infra.Services.DTOs.Paciente;
using HMS.Infra.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    [ApiController]
    [Route("paciente")]
    public class PacienteController : MainController
    {
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public PacienteController(IPacienteService pacienteService, IMapper mapper)
        {
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cadastro de pacientes.
        /// </summary>
        /// <param name="pacienteViewModel">ViewModel para cadastro de paciente.</param>        
        /// <remarks>
        /// 
        /// O paciente poderá se cadastrar preenchendo os campos: Nome, CPF, Email e Senha.
        /// 
        /// </remarks>
        /// <response code="200">Cadastro Realizado com sucesso</response>
        /// <response code="400">Cadastro não realizado, é retornado mensagem com o(s) motivo(s).</response>
        [HttpPost]
        public IActionResult Cadastrar(CadastraPacienteViewModel pacienteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var livroCadastrado = _pacienteService.Cadastrar(_mapper.Map<CadastraPacienteDto>(pacienteViewModel));

            return Ok(livroCadastrado);

        }

        /// <summary>
        /// Alteração de pacientes.
        /// </summary>
        /// <param name="alteraPacienteViewModel">ViewModel para alterar paciente.</param>        
        /// <remarks>
        /// 
        /// Informe o nome e id do paciente para realizar a alteração. 
        /// 
        /// </remarks>
        /// <response code="200">Alteração Realizada com sucesso</response>
        /// <response code="400">Alteração não realizada, é retornado mensagem com o(s) motivo(s).</response>
        [HttpPut]
        public IActionResult Alterar(AlteraPacienteViewModel alteraPacienteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var alteraLivroDto = _pacienteService.Alterar(_mapper.Map<AlteraPacienteDto>(alteraPacienteViewModel));

            return Ok(alteraLivroDto);

        }
    }
}
