using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Agenda.Models
{
    [Table("Usuario")]
    public class UsuarioModel : PessoaModel
    {
        [Key]
        public Guid UsuarioId { get; set; }

        public ICollection<AgendaModel> Agendas { get; set; }
    }
}
