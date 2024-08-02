using HMS.Infra.Services.DTOs.Pacientes;

namespace HMS.Infra.Services.Interfaces
{
    public interface IPacienteService
    {
        PacienteDto Cadastrar(CadastraPacienteDto pacienteDto);             
        PacienteDto ObterPorId(int id);
          
    }
}
