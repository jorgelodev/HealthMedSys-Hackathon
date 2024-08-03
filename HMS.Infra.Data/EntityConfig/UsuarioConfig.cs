using HMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMS.Infra.Data.EntityConfig
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
            .ToTable("Usuarios")
            .HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .IsRequired()
            .HasMaxLength(100);

            builder.Property(u => u.Senha)
                .IsRequired()
            .HasMaxLength(100);

            builder.Property(u => u.Tipo)
                .HasConversion<int>() 
                .IsRequired();
        
            
        }
    }
}
