using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Agenda.Models
{

    [Table("PrestadorTipoDeServico")]
    public class PrestadorTipoDeServico
    {
        [Key]
        public int PrestadorTipoDeServicoId { get; set; }

        [ForeignKey("Prestador")]
        public Guid PrestadorId { get; set; }
        public PrestadorModel Prestador { get; set; }

        [ForeignKey("TipoDeServico")]
        public Guid TipoDeServicoId { get; set; }
        public TipoDeServicoModel TipoDeServico { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal PercentualDeParticipacao { get; set; }
    }
}
