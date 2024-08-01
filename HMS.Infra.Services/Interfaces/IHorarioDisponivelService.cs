using HMS.Infra.Services.DTOs.HorarioDisponiveis;

namespace HMS.Infra.Services.Interfaces
{
    public interface IHorarioDisponivelService
    {
        HorarioDisponivelDto Cadastrar(CadastraHorarioDisponivelDto horarioDisponiveloDto);
        HorarioDisponivelDto Alterar(AlteraHorarioDisponivelDto alteraHorarioDisponivelDto);
        HorarioDisponivelDto ObterPorId(int id);
        HorarioDisponivelDto Deletar(int id);        
    }
}
