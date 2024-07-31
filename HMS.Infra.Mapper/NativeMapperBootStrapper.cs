using AutoMapper;
using HMS.Domain.Entities;
using HMS.Infra.Services.DTOs.Paciente;
using Microsoft.Extensions.DependencyInjection;

namespace HMS.Infra.Mapper
{
    public class NativeMapperBootStrapper : Profile
    {
        public NativeMapperBootStrapper()
        {
            // ViewModels x DTOs
            CreateMap<PacienteViewModel, PacienteDto>().ReverseMap();
            CreateMap<AlteraPacienteViewModel, AlteraPacienteDto>().ReverseMap();
            CreateMap<CadastraPacienteViewModel, CadastraPacienteDto>().ReverseMap();
           

            // Entities x DTOs 
            CreateMap<Paciente, PacienteDto>().ReverseMap();
            CreateMap<Paciente, AlteraPacienteDto>().ReverseMap();
            CreateMap<Paciente, CadastraPacienteDto>().ReverseMap();
            CreateMap<Usuario, CadastraPacienteDto>().ReverseMap();




            //CreateMap<Usuario, UsuarioDto>().ReverseMap();
            //CreateMap<Usuario, AlteraUsuarioDto>().ReverseMap();
            //CreateMap<Usuario, CadastraUsuarioDto>().ReverseMap();

        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NativeMapperBootStrapper));
        }
    }
}