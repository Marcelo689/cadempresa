using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WF_Gestao_Estoque_Gastos.Servicos.Validacoes
{
    public static class ValidarString
    {
        public static bool CamposPreenchido(params string[] campos)
        {
            foreach (var campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo))
                    return false;
            }
            return true;
        }
        public static bool CampoApenasNumerico(string entrada)
        {
            var apenasNumeros = new Regex("^\\d+$");
            return apenasNumeros.Match(entrada).Success;
        }
    }
}
