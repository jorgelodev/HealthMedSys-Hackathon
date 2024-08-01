using HMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMS.Infra.Data.EntityConfig
{
    public class HorarioDisponivelConfig : IEntityTypeConfiguration<HorarioDisponivel>
    {
        public void Configure(EntityTypeBuilder<HorarioDisponivel> builder)
        {
            builder
            .ToTable("HorariosDisponiveis")
            .HasKey(h => h.Id);

            builder
            .HasOne(h => h.Medico)
            .WithMany()
            .HasForeignKey(h => h.MedicoId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(h => h.Consulta)
            .WithOne(c => c.HorarioDisponivel)
            .HasForeignKey<Consulta>(c => c.HorarioDisponivelId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
