using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WF_Gestao_Estoque_Gastos.Servicos.ComboBoxManager
{
    public static class GerenciarComboBox<Entidade> where Entidade : new()
    {
        public static bool ExisteItemSelecionadoCombo(ComboBox list)
        {
            return list.SelectedIndex != -1;
        }
        public static Entidade RetornaItemSelecionadoCombo(ComboBox combo)
        {
            if (ExisteItemSelecionadoCombo(combo))
                return (Entidade) combo.SelectedItem;
            return new Entidade();
        }

        public static void Deselecionar(ComboBox combo)
        {
            combo.SelectedIndex = -1;
        }

        public static void Selecionar(ComboBox combo, string value)
        {
            combo.SelectedValue = Convert.ToInt64(value);
        }

        public static void Preencher(ComboBox combo, List<Entidade> lista, string descricao, string id = "Id")
        {
            combo.DataSource    = lista;
            combo.DisplayMember = descricao;
            combo.ValueMember   = id.ToString();
        }
    }
}
