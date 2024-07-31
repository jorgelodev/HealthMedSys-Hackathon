using HMS.Infra.Services.DTOs.Paciente;

namespace HMS.Infra.Services.Interfaces
{
    public interface IPacienteService
    {
        PacienteDto Cadastrar(CadastraPacienteDto pacienteDto);
        AlteraPacienteDto Alterar(AlteraPacienteDto alteraPacienteDto);        
        PacienteDto ObterPorId(int id);
        PacienteDto Deletar(int id);        
    }
}
