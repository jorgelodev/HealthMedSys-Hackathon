using AutoMapper;
using HMS.Domain.Entities;
using HMS.Domain.Excepctions;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.UseCases.HorarioDisponiveis;
using HMS.Infra.Services.DTOs.HorarioDisponiveis;
using HMS.Infra.Services.Interfaces;

namespace HMS.Infra.Services.Services
{
    public class HorarioDisponivelService : IHorarioDisponivelService
    {         
        private readonly IHorarioDisponivelGateway _horarioDisponivelGateway;        
        private readonly IMapper _mapper;

        public HorarioDisponivelService(IMapper mapper, IHorarioDisponivelGateway horarioDisponivelGateway)
        {            
            _mapper = mapper;
            _horarioDisponivelGateway = horarioDisponivelGateway;
        }

        public HorarioDisponivelDto Alterar(AlteraHorarioDisponivelDto alteraHorarioDisponivelDto)
        {
            var horarioDisponivel = _horarioDisponivelGateway.ObterPorId(alteraHorarioDisponivelDto.Id) ??
                throw new DomainValidationException("Horário não encontrado");


            horarioDisponivel.DataHoraInicio = alteraHorarioDisponivelDto.DataHoraInicio;
            horarioDisponivel.DataHoraFim = alteraHorarioDisponivelDto.DataHoraFim;

            var alterarHorarioDisponivelUseCase = new AlterarHorarioDisponivelUseCase(horarioDisponivel, _horarioDisponivelGateway);

            alterarHorarioDisponivelUseCase.Alterar();

            return _mapper.Map<HorarioDisponivelDto>(_horarioDisponivelGateway.Alterar(horarioDisponivel));
        }

        public HorarioDisponivelDto Cadastrar(CadastraHorarioDisponivelDto cadastraHorarioDisponivelDto)
        {
            var horarioDisponivel = _mapper.Map<HorarioDisponivel>(cadastraHorarioDisponivelDto);            
           

            var cadastrarMedicoUseCase = new CadastrarHorarioDisponivelUseCase(horarioDisponivel, _horarioDisponivelGateway);            

            horarioDisponivel = cadastrarMedicoUseCase.Cadastrar();

            horarioDisponivel = _horarioDisponivelGateway.Cadastrar(horarioDisponivel);            

            return _mapper.Map<HorarioDisponivelDto>(horarioDisponivel);
        }

        public HorarioDisponivelDto Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public HorarioDisponivelDto ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
