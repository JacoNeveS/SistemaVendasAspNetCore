using SistemaVendasAspNetCore.Uteis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendasAspNetCore.Models
{
    public class RelatorioModel
    {
        public DateTime DataDe { get; set; }
        public DateTime DataAte { get; set; }
    }
    public class GraficoProdutos
    {
        public double QtdeVendido { get; set; }
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }

        public List<GraficoProdutos> RetornarGrafico()
        {
            DAL objDAL = new DAL();
            string sql = "SELECT SUM(qtde_produto) AS qtde, p.nome AS produto FROM itens_venda i INNER JOIN produto p ON i.produto_id = p.id GROUP BY p.nome";
            DataTable dt = objDAL.RetDataTable(sql);

            List<GraficoProdutos> lista = new List<GraficoProdutos>();
            GraficoProdutos item;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new GraficoProdutos();
                item.QtdeVendido = double.Parse(dt.Rows[i]["qtde"].ToString());
                item.DescricaoProduto = dt.Rows[i]["produto"].ToString();
                lista.Add(item);
            }
            return lista;
        }
    }
}
