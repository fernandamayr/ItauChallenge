using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalKnowledge.Models
{
    public class Clientes
    {
        public string nome_cliente { get; set; }

        public DateTime data_nascimento { get; set; }
        public string status { get; set; }
        public Erro erro { get; set; }
    }
}