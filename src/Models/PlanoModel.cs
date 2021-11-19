using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Agenda.Models
{
    [Table("Planos")]
    public class PlanoModel
    {
        [Key]
        public Guid PlanoId { get; set; }

        [MaxLength(50)]
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        public decimal ValorMensal { get; set; }

        public int LimiteDeUsuario { get; set; }

        public bool Ativo { get; set; }

        public ICollection<EmpresaModel> Empresas { get; set; }
    }
}
