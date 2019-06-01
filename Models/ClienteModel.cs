using SistemaVendasAspNetCore.Uteis;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SistemaVendasAspNetCore.Models
{
    //ava taylor
    public class ClienteModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Cliente!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o CPF ou CNPJ!")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe o E-mail!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O E-mail informado é inválido!")]
        public string Email { get; set; }

        public string Senha { get; set; }

        public List<ClienteModel> ListarTodosClientes()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;
            DAL objDAL = new DAL();
            string sql = "SELECT id, nome, cpf_cnpj, email, senha FROM cliente ORDER BY nome ASC";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ClienteModel
                {
                    Id = dt.Rows[i]["id"].ToString(),
                    Nome = dt.Rows[i]["nome"].ToString(),
                    CPF = dt.Rows[i]["cpf_cnpj"].ToString(),
                    Email = dt.Rows[i]["email"].ToString(),
                    Senha = dt.Rows[i]["senha"].ToString()
                };
                lista.Add(item);
            }
            return lista;
        }

        public ClienteModel RetornarCliente(int? id)
        {
            ClienteModel item;
            DAL objDAL = new DAL();
            string sql = $"SELECT id, nome, cpf_cnpj, email, senha FROM cliente WHERE id ='{id}'  ORDER BY nome ASC";
            DataTable dt = objDAL.RetDataTable(sql);

            item = new ClienteModel
            {
                Id = dt.Rows[0]["id"].ToString(),
                Nome = dt.Rows[0]["nome"].ToString(),
                CPF = dt.Rows[0]["cpf_cnpj"].ToString(),
                Email = dt.Rows[0]["email"].ToString(),
                Senha = dt.Rows[0]["senha"].ToString()
            };

            return item;
        }

        public void Gravar()
        {
            DAL objDAL = new DAL();
            string sql = string.Empty;
            if (Id != null)
            {
                sql = $"UPDATE cliente SET nome='{Nome}', cpf_cnpj='{CPF}', email='{Email}' WHERE id='{Id}'";
            }
            else
            {
                sql = $"INSERT INTO cliente(nome, cpf_cnpj, email, senha) VALUES ('{Nome}', '{CPF}', '{Email}', '1234')";
            }
            objDAL.ExecutarComandoSQL(sql);
        }

        public void Excluir(int id)
        {
            DAL objDAL = new DAL();
            string sql = $"DELETE FROM cliente WHERE id='{id}'";
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
