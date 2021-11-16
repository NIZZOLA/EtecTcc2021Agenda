using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Agenda.Models
{
    [Table("Agenda")]
    public class AgendaModel
    {
        [Key]
        public Guid AgendaId { get; set; }

        [ForeignKey("Usuario")]
        public Guid UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }

        [ForeignKey("Prestador")]
        public Guid PrestadorId { get; set; }
        public PrestadorModel Prestador { get; set; }

        public DateTime DataHoraAgendada { get; set; }

        public DateTime DataHoraTermino { get; set; }

        [ForeignKey("TipoDeServico")]
        public Guid TipoDeServicoId { get; set; }
        public TipoDeServicoModel TipoDeServico { get; set; }

        public decimal ValorCobrado { get; set; }

        public bool Realizado { get; set; }
        public bool CanceladoUsuario { get; set; }
        public bool CanceladoPrestador { get; set; }
        public string MotivoDoCancelamento { get; set; }
        public DateTime DataHoraDoCancelamento { get; set; }
    }
}