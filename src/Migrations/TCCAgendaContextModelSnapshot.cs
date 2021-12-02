﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCC.Agenda.Data;

namespace TCC.Agenda.Migrations
{
    [DbContext(typeof(TCCAgendaContext))]
    partial class TCCAgendaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TCC.Agenda.Models.AgendaModel", b =>
                {
                    b.Property<Guid>("AgendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CanceladoPrestador")
                        .HasColumnType("bit");

                    b.Property<bool>("CanceladoUsuario")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataHoraAgendada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraDoCancelamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraTermino")
                        .HasColumnType("datetime2");

                    b.Property<string>("MotivoDoCancelamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PrestadorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Realizado")
                        .HasColumnType("bit");

                    b.Property<Guid>("TipoDeServicoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValorCobrado")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AgendaId");

                    b.HasIndex("PrestadorId");

                    b.HasIndex("TipoDeServicoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("TCC.Agenda.Models.EmpresaModel", b =>
                {
                    b.Property<Guid>("EmpresaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Cep")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Cidade")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CpfCnpj")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInativacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estado")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Numero")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("PessoaFisica")
                        .HasColumnType("bit");

                    b.Property<Guid>("PlanoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Rua")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("EmpresaId");

                    b.HasIndex("PlanoId");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("TCC.Agenda.Models.PlanoModel", b =>
                {
                    b.Property<Guid>("PlanoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LimiteDeUsuario")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorMensal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PlanoId");

                    b.ToTable("Planos");
                });

            modelBuilder.Entity("TCC.Agenda.Models.PrestadorModel", b =>
                {
                    b.Property<Guid>("PrestadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Bairro")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("Bloqueado")
                        .HasColumnType("bit");

                    b.Property<string>("Cep")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Cidade")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Email")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Endereco")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Estado")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Senha")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("PrestadorId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Prestador");
                });

            modelBuilder.Entity("TCC.Agenda.Models.PrestadorTipoDeServico", b =>
                {
                    b.Property<int>("PrestadorTipoDeServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("PercentualDeParticipacao")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("PrestadorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TipoDeServicoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PrestadorTipoDeServicoId");

                    b.HasIndex("PrestadorId");

                    b.HasIndex("TipoDeServicoId");

                    b.ToTable("PrestadorTipoDeServico");
                });

            modelBuilder.Entity("TCC.Agenda.Models.TipoDeServicoModel", b =>
                {
                    b.Property<Guid>("TipoDeServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Detalhes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DuracaoMinutos")
                        .HasColumnType("int");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal>("ValorCobrado")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TipoDeServicoId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("TipoDeServico");
                });

            modelBuilder.Entity("TCC.Agenda.Models.UsuarioModel", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("Bloqueado")
                        .HasColumnType("bit");

                    b.Property<string>("Cep")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Cidade")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Email")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Endereco")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Estado")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Senha")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("TCC.Agenda.Models.AgendaModel", b =>
                {
                    b.HasOne("TCC.Agenda.Models.PrestadorModel", "Prestador")
                        .WithMany("Agendas")
                        .HasForeignKey("PrestadorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCC.Agenda.Models.TipoDeServicoModel", "TipoDeServico")
                        .WithMany("Agendas")
                        .HasForeignKey("TipoDeServicoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCC.Agenda.Models.UsuarioModel", "Usuario")
                        .WithMany("Agendas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Prestador");

                    b.Navigation("TipoDeServico");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TCC.Agenda.Models.EmpresaModel", b =>
                {
                    b.HasOne("TCC.Agenda.Models.PlanoModel", "Plano")
                        .WithMany("Empresas")
                        .HasForeignKey("PlanoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plano");
                });

            modelBuilder.Entity("TCC.Agenda.Models.PrestadorModel", b =>
                {
                    b.HasOne("TCC.Agenda.Models.EmpresaModel", "Empresa")
                        .WithMany("Prestadores")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("TCC.Agenda.Models.PrestadorTipoDeServico", b =>
                {
                    b.HasOne("TCC.Agenda.Models.PrestadorModel", "Prestador")
                        .WithMany("TiposDeServico")
                        .HasForeignKey("PrestadorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCC.Agenda.Models.TipoDeServicoModel", "TipoDeServico")
                        .WithMany("Prestadores")
                        .HasForeignKey("TipoDeServicoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Prestador");

                    b.Navigation("TipoDeServico");
                });

            modelBuilder.Entity("TCC.Agenda.Models.TipoDeServicoModel", b =>
                {
                    b.HasOne("TCC.Agenda.Models.EmpresaModel", "Empresa")
                        .WithMany("TiposDeServico")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("TCC.Agenda.Models.EmpresaModel", b =>
                {
                    b.Navigation("Prestadores");

                    b.Navigation("TiposDeServico");
                });

            modelBuilder.Entity("TCC.Agenda.Models.PlanoModel", b =>
                {
                    b.Navigation("Empresas");
                });

            modelBuilder.Entity("TCC.Agenda.Models.PrestadorModel", b =>
                {
                    b.Navigation("Agendas");

                    b.Navigation("TiposDeServico");
                });

            modelBuilder.Entity("TCC.Agenda.Models.TipoDeServicoModel", b =>
                {
                    b.Navigation("Agendas");

                    b.Navigation("Prestadores");
                });

            modelBuilder.Entity("TCC.Agenda.Models.UsuarioModel", b =>
                {
                    b.Navigation("Agendas");
                });
#pragma warning restore 612, 618
        }
    }
}
