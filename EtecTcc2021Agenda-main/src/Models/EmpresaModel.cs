using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Agenda.Models
{
    [Table("Empresa")]
    public class EmpresaModel
    {
        [Key]
        public Guid EmpresaId { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
        [Display(Name ="Tipo")]
        public bool PessoaFisica { get; set; }
        [MaxLength(18)]
        [Display(Name = "CPF-CNPJ")]
        public string CpfCnpj { get; set; }
        [MaxLength(30)]
        public string Rua { get; set; }
        [MaxLength(10)]
        public string Numero { get; set; }
        [MaxLength(30)]
        public string Bairro { get; set; }
        [MaxLength(30)]
        public string Cidade { get; set; }
        [MaxLength(2)]
        public string Estado { get; set; }
        [MaxLength(10)]
        public string Cep { get; set; }

        [ForeignKey("Plano")]
        public Guid PlanoId { get; set; }
        [Display(Name = "Plano contratação")]
        public PlanoModel Plano { get; set; }

        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }
        [Display(Name = "Data Inativação")]
        public DateTime DataInativacao { get; set; }
        

        public ICollection<PrestadorModel> Prestadores { get; set; }

        public ICollection<TipoDeServicoModel> TiposDeServico { get; set; }
    }
}
