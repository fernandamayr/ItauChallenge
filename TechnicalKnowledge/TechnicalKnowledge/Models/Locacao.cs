using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalKnowledge.Models
{
    public class Locacao
    {
        public int id_locacao { get; set; }
        public int id_cliente { get; set; }
        public int id_filme { get; set; }
        public DateTime? estimativa_devolucao { get; set; }
        public DateTime? devolucao { get; set; }
        public DateTime? data_locacao { get; set; }
        public string observacao { get; set; }
        public string status { get; set; }
        public Erro erro { get; set; }
        public string nome_cliente { get; set; }
        public string nome_filme { get; set; }
    }
}