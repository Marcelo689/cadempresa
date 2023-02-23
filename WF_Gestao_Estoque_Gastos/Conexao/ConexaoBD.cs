using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Gestao_Estoque_Gastos.Conexao
{
    public class ConexaoBD
    {
        public MySqlConnection conectar;
        public ConexaoBD()
        {
            
        }

        public MySqlConnection AbrirConexao()
        {
            conectar.Open();
            return conectar;
        }

        public void FecharConexao()
        {
            conectar.Close();
        }
    }
}