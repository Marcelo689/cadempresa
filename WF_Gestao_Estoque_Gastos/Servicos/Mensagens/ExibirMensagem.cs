using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Gestao_Estoque_Gastos
{
    public static class ExibirMensagem
    {
        public static void Informacao(string mensagem)
        {
            MessageBox.Show(mensagem, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Aviso(string mensagem)
        {
            MessageBox.Show(mensagem, "Alerta!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void Erro(string mensagem)
        {
            MessageBox.Show(mensagem, "Erro!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
