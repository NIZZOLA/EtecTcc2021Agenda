using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Agenda.Models
{
    [Table("Prestador")]
    public class PrestadorModel : PessoaModel
    {
        [Key]
        public Guid PrestadorId { get; set; }

        [ForeignKey("Empresa")]
        public Guid EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }

        public bool Admin { get; set; }

        // informa que existem vários tipos de serviço associados ao prestador
        public ICollection<PrestadorTipoDeServico> TiposDeServico { get; set; }

        public ICollection<AgendaModel> Agendas { get; set; }
    }
}
