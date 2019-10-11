using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendasAspNetCore.Models
{
    public class ItemVendaModel
    {
        public string CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string QtdeProduto { get; set; }
        public string PrecoUnitario { get; set; }
        public string PrecoVenda { get; set; }
        public string Total { get; set; }
        public string Lucro { get; set; }
    }
}
