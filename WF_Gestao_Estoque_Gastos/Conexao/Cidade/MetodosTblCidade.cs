using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Gestao_Estoque_Gastos.Conexao.Cidade
{
    public class Cidade
    {
        public int Id { get; set; }
        public string DescricaoCidade { get; set; }
        public int IdEstado { get; set; }
    }
    public static class MetodosTblCidade
    {
        private static MySqlConnection con;
        private static MySqlCommand cmd;
        private static MySqlDataReader reader;

        private static void AbrirConexao()
        {
            con = new MySqlConnection("server=localhost;database=gestao_estoque_gasto;uid=root;pwd=;");
            cmd = new MySqlCommand();
            cmd.Connection = con;
            con.Open();
        }

        private static void FecharConexao()
        {
            con.Close();
        }
        public static List<Cidade> RetornaTodasCidades()
        {
            var lista = new List<Cidade>();
            AbrirConexao();

            var queryNomeEmpresa = $"select id , descricaoCidade, idEstado from tblcidade";

            cmd.CommandText = queryNomeEmpresa;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var id = Convert.ToInt32(reader["Id"].ToString());
                var descricaoCidade = reader["descricaoCidade"].ToString();
                var IdEstado = Convert.ToInt32(reader["idEstado"].ToString());
                var cidade = new Cidade()
                {
                    Id = id,
                    DescricaoCidade = descricaoCidade,
                    IdEstado = IdEstado
                };
                lista.Add(cidade);
            }

            FecharConexao();
            return lista;
        }

    }
}
