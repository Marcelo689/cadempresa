using System;
using System.Windows;
using System.Windows.Forms;

namespace WF_Gestao_Estoque_Gastos.Servicos.Excecoes
{
    public static class Mensagem
    {
        public static void AvisoDeErro(string mensagem)
        {
            System.Windows.MessageBox.Show(mensagem,"Erro!!!", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Error);
        }
        public static void Informacao(string mensagem)
        {
            System.Windows.MessageBox.Show(mensagem, "Erro!!!", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Information);
        }
    }
}
