using AutoMapper;
using HMS.Domain.Entities;
using HMS.Domain.Excepctions;
using HMS.Domain.Interfaces.Gateways;
using HMS.Infra.Services.DTOs.HorarioDisponiveis;
using HMS.Infra.Services.Services;
using Moq;

namespace HMS.Tests.Services
{
    public class HorarioDisponivelServiceTests
    {
        private readonly Mock<IHorarioDisponivelGateway> _horarioDisponivelGatewayMock;
        private readonly Mock<IMedicoGateway> _medicoGatewayMock;
        private readonly IMapper _mapper;
        private readonly HorarioDisponivelService _horarioDisponivelService;

        public HorarioDisponivelServiceTests()
        {
            _horarioDisponivelGatewayMock = new Mock<IHorarioDisponivelGateway>();
            _medicoGatewayMock = new Mock<IMedicoGateway>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CadastraHorarioDisponivelDto, HorarioDisponivel>();
                cfg.CreateMap<HorarioDisponivel, HorarioDisponivelDto>();
                cfg.CreateMap<AlteraHorarioDisponivelDto, HorarioDisponivel>();
            });
            _mapper = config.CreateMapper();

            _horarioDisponivelService = new HorarioDisponivelService(_mapper, _horarioDisponivelGatewayMock.Object, _medicoGatewayMock.Object);
        }

        [Fact]
        public void Alterar_DeveRetornarHorarioDisponivelDtoQuandoAlteracaoForBemSucedida()
        {
            // Arrange
            var alteraDto = new AlteraHorarioDisponivelDto
            {
                Id = 1,
                DataHoraInicio = DateTime.Now.AddHours(1),
                DataHoraFim = DateTime.Now.AddHours(2)
            };

            var horarioDisponivel = new HorarioDisponivel
            {
                Id = 1,
                DataHoraInicio = DateTime.Now,
                DataHoraFim = DateTime.Now.AddHours(1),
                MedicoId  = 1
            };

            _horarioDisponivelGatewayMock.Setup(h => h.ObterPorId(1)).Returns(horarioDisponivel);
            _horarioDisponivelGatewayMock.Setup(h => h.Alterar(horarioDisponivel)).Returns(horarioDisponivel);

            // Act
            var result = _horarioDisponivelService.Alterar(alteraDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(alteraDto.DataHoraInicio, result.DataHoraInicio);
            Assert.Equal(alteraDto.DataHoraFim, result.DataHoraFim);
        }

        [Fact]
        public void Alterar_DeveLancarExcecaoQuandoHorarioNaoEncontrado()
        {
            // Arrange
            var alteraDto = new AlteraHorarioDisponivelDto { Id = 1 };

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => _horarioDisponivelService.Alterar(alteraDto));
        }

        [Fact]
        public void Cadastrar_DeveRetornarHorarioDisponivelDtoQuandoCadastroForBemSucedido()
        {
            // Arrange
            var cadastraDto = new CadastraHorarioDisponivelDto
            {
                MedicoId = 1,
                DataHoraInicio = DateTime.Now.AddMinutes(10),
                DataHoraFim = DateTime.Now.AddMinutes(40)
            };

            var medico = new Medico { Id = 1 };
            var horarioDisponivel = new HorarioDisponivel { MedicoId = 1 };

            _medicoGatewayMock.Setup(m => m.ObterPorId(1)).Returns(medico);
            _horarioDisponivelGatewayMock.Setup(h => h.Cadastrar(It.IsAny<HorarioDisponivel>())).Returns(horarioDisponivel);

            _horarioDisponivelGatewayMock.Setup(h => h.HorarioEstaDesocupado(It.IsAny<HorarioDisponivel>())).Returns(true);

            // Act
            var result = _horarioDisponivelService.Cadastrar(cadastraDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(horarioDisponivel.DataHoraInicio, result.DataHoraInicio);
            Assert.Equal(horarioDisponivel.DataHoraFim, result.DataHoraFim);
        }

        [Fact]
        public void Cadastrar_DeveLancarExcecaoQuandoMedicoNaoEncontrado()
        {
            // Arrange
            var cadastraDto = new CadastraHorarioDisponivelDto
            {
                MedicoId = 1,
                DataHoraInicio = DateTime.Now.AddMinutes(10),
                DataHoraFim = DateTime.Now.AddMinutes(40)
            };

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => _horarioDisponivelService.Cadastrar(cadastraDto));
        }
    }
}
