using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WF_Gestao_Estoque_Gastos.Servicos.Excecoes;

namespace WF_Gestao_Estoque_Gastos.Servicos.ListViewManager
{
    public static class ListViewManager
    {
        public static bool ExisteItemSelecionadoListView(ListView list)
        {
            return list.SelectedIndex != -1;
        }
        public static int RetornaIndiceSelecionadoListView(ListView list)
        {
            return list.SelectedIndex;
        }

        public static object RetornaListViewSelecionado(ListView list)
        {
            if (ExisteItemSelecionadoListView(list))
                return list.SelectedItem;
            Mensagem.Informacao("Não existia item selecionado no listView");
            return null;
        }

    }
}
