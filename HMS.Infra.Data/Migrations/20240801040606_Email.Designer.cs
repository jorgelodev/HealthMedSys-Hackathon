﻿// <auto-generated />
using System;
using HMS.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HMS.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240801040606_Email")]
    partial class Email
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HMS.Domain.Entities.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HorarioDisponivelId")
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HorarioDisponivelId")
                        .IsUnique();

                    b.HasIndex("PacienteId");

                    b.ToTable("Consultas", (string)null);
                });

            modelBuilder.Entity("HMS.Domain.Entities.EmailConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("SmtpPort")
                        .HasColumnType("int");

                    b.Property<string>("SmtpServer")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("EmailConfigurations", (string)null);
                });

            modelBuilder.Entity("HMS.Domain.Entities.HorarioDisponivel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHoraFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.ToTable("HorariosDisponiveis", (string)null);
                });

            modelBuilder.Entity("HMS.Domain.Entities.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pessoas", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("HMS.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("HMS.Domain.Entities.Medico", b =>
                {
                    b.HasBaseType("HMS.Domain.Entities.Pessoa");

                    b.Property<string>("NumeroCRM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Medicos", (string)null);
                });

            modelBuilder.Entity("HMS.Domain.Entities.Paciente", b =>
                {
                    b.HasBaseType("HMS.Domain.Entities.Pessoa");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pacientes", (string)null);
                });

            modelBuilder.Entity("HMS.Domain.Entities.Consulta", b =>
                {
                    b.HasOne("HMS.Domain.Entities.HorarioDisponivel", "HorarioDisponivel")
                        .WithOne("Consulta")
                        .HasForeignKey("HMS.Domain.Entities.Consulta", "HorarioDisponivelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HMS.Domain.Entities.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("HorarioDisponivel");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("HMS.Domain.Entities.HorarioDisponivel", b =>
                {
                    b.HasOne("HMS.Domain.Entities.Medico", "Medico")
                        .WithMany("HorariosDisponiveis")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("HMS.Domain.Entities.Medico", b =>
                {
                    b.HasOne("HMS.Domain.Entities.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("HMS.Domain.Entities.Medico", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMS.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("HMS.Domain.Entities.Paciente", b =>
                {
                    b.HasOne("HMS.Domain.Entities.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("HMS.Domain.Entities.Paciente", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMS.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("HMS.Domain.Entities.HorarioDisponivel", b =>
                {
                    b.Navigation("Consulta");
                });

            modelBuilder.Entity("HMS.Domain.Entities.Medico", b =>
                {
                    b.Navigation("HorariosDisponiveis");
                });
#pragma warning restore 612, 618
        }
    }
}
