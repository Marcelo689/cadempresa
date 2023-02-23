using System;

namespace WF_Gestao_Estoque_Gastos.Servicos
{
    public class CloseDelegate 
    {
        private Action close;

        public CloseDelegate(Action close)
        {
            this.close = close;
        }
    }
}