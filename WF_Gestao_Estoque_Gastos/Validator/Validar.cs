using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Gestao_Estoque_Gastos.Validator
{
    public static class Validar
    {
        public static bool CampoPreenchido(params string [] listEntrada)
        {
            foreach (var entrada in listEntrada)
            {
                if (string.IsNullOrWhiteSpace(entrada))
                    return false;
            }
            return true;
        }
    }
}
