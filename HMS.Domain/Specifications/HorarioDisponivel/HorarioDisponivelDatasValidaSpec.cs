using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Specifications;

namespace HMS.Domain.Specifications.HorarioDisponivels
{
    public class HorarioDisponivelDatasValidaSpec : ISpecification<HorarioDisponivel>
    {
        public string ErrorMessage => "Data Fim deve ser no mínimo 30 minutos maior que data Inicio";

        public bool IsSatisfiedBy(HorarioDisponivel horarioDisponivel)
        {
            var diferenca = horarioDisponivel.DataHoraFim - horarioDisponivel.DataHoraInicio;

            return diferenca.TotalMinutes >= 30;            
        }
    }
}
