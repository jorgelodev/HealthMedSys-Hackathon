﻿using HMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HMS.Infra.Data.EntityConfig
{
    public class ConsultConfig : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder
            .ToTable("Consultas")
            .HasKey(c => c.Id);

            builder
                .HasOne(c => c.Paciente)
                .WithMany()
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(c => c.HorarioDisponivel)
            .WithOne(h => h.Consulta)
            .HasForeignKey<Consulta>(c => c.HorarioDisponivelId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
