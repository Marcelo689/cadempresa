using System.Threading;
using System.Windows.Forms;

namespace WF_Gestao_Estoque_Gastos.Servicos
{
    public static class GerenciarTela
    {

        public static void AbrirTela(Form form, bool dialog = false)
        {
            if (dialog )
                form.ShowDialog();
            else
                form.Show();
        }

        public static void AbrirTelaEFecharAtual(Form formAbrir, Form formFechar, bool dialog = false)
        {
            //FecharTela(formFechar);
            if (dialog)
                formAbrir.ShowDialog();
            else
                formAbrir.Show();
        }

        public static void FecharTela(Form form)
        {
            if (form.Visible == true)
            {
                //form.Hide();
                //form.Dispose();
            }
            else
                form.Activate();
        }
    }
}
