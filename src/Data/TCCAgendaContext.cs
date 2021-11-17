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

        public DbSet<TCC.Agenda.Models.AgendaModel> Agendas { get; set; }

        public DbSet<TCC.Agenda.Models.EmpresaModel> Empresas { get; set; }

        public DbSet<TCC.Agenda.Models.PlanoModel> Planos { get; set; }

        public DbSet<TCC.Agenda.Models.PrestadorModel> Prestadores { get; set; }

        public DbSet<TCC.Agenda.Models.UsuarioModel> Usuarios { get; set; }

        public DbSet<TCC.Agenda.Models.TipoDeServicoModel> TipoDeServicos { get; set; }
    }
}
