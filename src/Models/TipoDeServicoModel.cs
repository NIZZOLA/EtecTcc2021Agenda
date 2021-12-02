using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Agenda.Models
{

    [Table("TipoDeServico")]
    public class TipoDeServicoModel
    {
        [Key]
        [DisplayName("Código do serviço")]
        public Guid TipoDeServicoId { get; set; }

        [MaxLength(40)]
        public string Nome { get; set; }
        public string Detalhes { get; set; }
                
        [DisplayName("Duração em minutos")]
        public int DuracaoMinutos { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        
        [DisplayName("Valor R$")]
        public Decimal ValorCobrado { get; set; }

        public bool Ativo { get; set; }

        [ForeignKey("Empresa")]
        [DisplayName("Empresa")]
        public Guid EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }

        public ICollection<PrestadorTipoDeServico> Prestadores { get; set; }

        public ICollection<AgendaModel> Agendas { get; set; }
    }
}
