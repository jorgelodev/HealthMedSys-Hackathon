using AutoMapper;
using HMS.Domain.Entities;
using HMS.Infra.Services.DTOs.Consultas;
using HMS.Infra.Services.DTOs.HorarioDisponiveis;
using HMS.Infra.Services.DTOs.Medicos;
using HMS.Infra.Services.DTOs.Pacientes;
using HMS.Infra.Services.DTOs.Usuarios;
using HMS.Infra.Services.ViewModels.Usuarios;
using Microsoft.Extensions.DependencyInjection;

namespace HMS.Infra.Mapper
{
    public class NativeMapperBootStrapper : Profile
    {
        public NativeMapperBootStrapper()
        {
            // ViewModels x DTOs

            // Paciente //
            CreateMap<PacienteViewModel, PacienteDto>().ReverseMap(); 
            CreateMap<CadastraPacienteViewModel, CadastraPacienteDto>().ReverseMap();            

            // Medico //
            CreateMap<MedicoViewModel, MedicoDto>().ReverseMap();
            CreateMap<CadastraMedicoViewModel, CadastraMedicoDto>().ReverseMap();

            // HorarioDisponivel //
            CreateMap<HorarioDisponivelViewModel, HorarioDisponivelDto>().ReverseMap();
            CreateMap<AlteraHorarioDisponivelViewModel, AlteraHorarioDisponivelDto>().ReverseMap();
            CreateMap<CadastraHorarioDisponivelViewModel, CadastraHorarioDisponivelDto>().ReverseMap();

            // Consulta //

            CreateMap<AgendaConsultaViewModel, AgendaConsultaDto>().ReverseMap();

            // Usuario

            CreateMap<UsuarioViewModel, UsuarioLogonDto>().ReverseMap();


            // Entities x DTOs 

            // Paciente //
            CreateMap<Paciente, PacienteDto>().ReverseMap();
            CreateMap<Paciente, CadastraPacienteDto>().ReverseMap();
            CreateMap<Usuario, CadastraPacienteDto>().ReverseMap();

            // Medico //
            CreateMap<Medico, MedicoDto>().ReverseMap();
            CreateMap<Medico, CadastraMedicoDto>().ReverseMap();            
            CreateMap<Usuario, CadastraMedicoDto>().ReverseMap();            
            CreateMap<Medico, MedicosDisponiveisDto>().ReverseMap();

            // HorarioDisponivel //
            CreateMap<HorarioDisponivel, HorarioDisponivelDto>().ReverseMap();
            CreateMap<HorarioDisponivel, AlteraHorarioDisponivelDto>().ReverseMap();
            CreateMap<HorarioDisponivel, CadastraHorarioDisponivelDto>().ReverseMap();
            CreateMap<HorarioDisponivel, HorarioDisponivelListaMedicoDto>().ReverseMap();

            // Consulta //
            CreateMap<Consulta, ConsultaDto>().ReverseMap();
            CreateMap<Consulta, AgendaConsultaDto>().ReverseMap();

            // Usuario
            CreateMap<Usuario, UsuarioLogonDto>().ReverseMap();
            CreateMap<Usuario, UsuarioAutenticadoDto>().ReverseMap();


        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NativeMapperBootStrapper));
        }
    }
}