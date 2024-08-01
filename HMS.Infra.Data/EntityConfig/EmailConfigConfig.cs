using HMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMS.Infra.Data.EntityConfig
{
    public class EmailConfigConfig : IEntityTypeConfiguration<EmailConfig>
    {
        public void Configure(EntityTypeBuilder<EmailConfig> builder)
        {

            builder.ToTable("EmailConfigurations");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.SmtpServer)
                    .IsRequired()
                    .HasMaxLength(255);

            builder.Property(e => e.SmtpPort)
                    .IsRequired();

            builder.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255);

            builder.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);
            
        }
    }
}
