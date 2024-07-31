using HMS.Infra.Services.DTOs.Paciente;

namespace HMS.Infra.Services.Interfaces
{
    public interface IPacienteService
    {
        PacienteDto Cadastrar(CadastraPacienteViewModel PacienteDto);
        AlteraPacienteViewModel Alterar(AlteraPacienteViewModel alteraPacienteDto);        
        PacienteDto ObterPorId(int id);
        PacienteDto Deletar(int id);        
    }
}
