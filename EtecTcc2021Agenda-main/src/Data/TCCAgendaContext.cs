using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCC.Agenda.Models;

namespace TCC.Agenda.Data
{
    public class TCCAgendaContext : DbContext
    {
        public TCCAgendaContext (DbContextOptions<TCCAgendaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrestadorTipoDeServico>(entity =>
            {
                entity.HasOne(a => a.Prestador)
                    .WithMany(b => b.TiposDeServico)
                    .HasForeignKey(c => c.PrestadorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.TipoDeServico)
                    .WithMany(b => b.Prestadores)
                    .HasForeignKey(c => c.TipoDeServicoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PrestadorModel>(entity =>
            {
                entity.HasOne(a => a.Empresa)
                    .WithMany(b => b.Prestadores)
                    .HasForeignKey(c => c.EmpresaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AgendaModel>(entity =>
            {
                entity.HasOne(a => a.Prestador)
                   .WithMany(b => b.Agendas)
                   .HasForeignKey(c => c.PrestadorId)
                   .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(a => a.Usuario)
                   .WithMany(b => b.Agendas)
                   .HasForeignKey(c => c.UsuarioId)
                   .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(a => a.TipoDeServico)
                    .WithMany(b => b.Agendas)
                    .HasForeignKey(c => c.TipoDeServicoId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }


        public DbSet<TCC.Agenda.Models.AgendaModel> Agendas { get; set; }

        public DbSet<TCC.Agenda.Models.EmpresaModel> Empresas { get; set; }

        public DbSet<TCC.Agenda.Models.PlanoModel> Planos { get; set; }

        public DbSet<TCC.Agenda.Models.PrestadorModel> Prestadores { get; set; }

        public DbSet<TCC.Agenda.Models.UsuarioModel> Usuarios { get; set; }

        public DbSet<TCC.Agenda.Models.TipoDeServicoModel> TipoDeServicos { get; set; }
    }
}
