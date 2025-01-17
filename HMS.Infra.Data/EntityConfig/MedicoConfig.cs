﻿using HMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMS.Infra.Data.EntityConfig
{
    public class MedicoConfig : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder
            .ToTable("Medicos")            
            .HasBaseType<Pessoa>()
            .HasOne(m => m.Usuario)
            .WithMany()
            .HasForeignKey(m => m.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(m => m.NumeroCRM)
            .IsRequired();

            builder
            .HasMany(m => m.HorariosDisponiveis)
            .WithOne(h => h.Medico)
            .HasForeignKey(h => h.MedicoId)
            .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
