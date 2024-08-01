using HMS.Infra.Services.DTOs.Medicos;

namespace HMS.Infra.Services.Interfaces
{
    public interface IMedicoService
    {
        MedicoDto Cadastrar(CadastraMedicoDto medicoDto);
        AlteraMedicoDto Alterar(AlteraMedicoDto alteraMedicoDto);
        ICollection<MedicosDisponiveisDto> Disponiveis();
        MedicoDto ObterPorId(int id);
        MedicoDto Deletar(int id);        
    }
}
