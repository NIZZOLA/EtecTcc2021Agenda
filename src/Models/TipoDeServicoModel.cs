﻿using System;
using System.Collections.Generic;
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
        public Guid TipoDeServicoId { get; set; }

        [MaxLength(40)]
        public string Nome { get; set; }
        public string Detalhes { get; set; }

        public int DuracaoMinutos { get; set; }
        public Decimal ValorCobrado { get; set; }

        public bool Ativo { get; set; }

        [ForeignKey("Empresa")]
        public Guid EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }

        public ICollection<PrestadorTipoDeServico> Prestadores { get; set; }

        public ICollection<AgendaModel> Agendas { get; set; }
    }
}
