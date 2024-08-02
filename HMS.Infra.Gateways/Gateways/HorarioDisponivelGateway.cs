using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Interfaces.Repositories;

namespace HMS.Infra.Gateways.Gateways
{
    public class HorarioDisponivelGateway : IHorarioDisponivelGateway
    {
        private readonly IHorarioDisponivelRepository _horarioDisponivelRepository;

        public HorarioDisponivelGateway(IHorarioDisponivelRepository horarioDisponivelRepository)
        {
            _horarioDisponivelRepository = horarioDisponivelRepository;
        }

        public HorarioDisponivel Alterar(HorarioDisponivel horarioDisponivel)
        {
            return _horarioDisponivelRepository.Alterar(horarioDisponivel);
        }

        public HorarioDisponivel Cadastrar(HorarioDisponivel horarioDisponivel)
        {
            return _horarioDisponivelRepository.Cadastrar(horarioDisponivel);
        }

        public HorarioDisponivel Deletar(int id)
        {
            return _horarioDisponivelRepository.Deletar(id);
        }

        public HorarioDisponivel ObterPorId(int id)
        {
            return _horarioDisponivelRepository.ObterPorId(id);
        }

        public bool HorarioEstaDesocupado(HorarioDisponivel horarioDisponivel)
        {
            var horarioEstaDesocupado = !_horarioDisponivelRepository.Buscar(h =>
                h.MedicoId == horarioDisponivel.MedicoId &&
                ((horarioDisponivel.DataHoraInicio >= h.DataHoraInicio && horarioDisponivel.DataHoraInicio < h.DataHoraFim) ||
                 (horarioDisponivel.DataHoraFim > h.DataHoraInicio && horarioDisponivel.DataHoraFim <= h.DataHoraFim) ||
                 (horarioDisponivel.DataHoraInicio <= h.DataHoraInicio && horarioDisponivel.DataHoraFim >= h.DataHoraFim))).
                 Any();

            return horarioEstaDesocupado;

        }
    }
}
