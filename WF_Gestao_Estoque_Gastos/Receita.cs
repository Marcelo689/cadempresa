using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Gestao_Estoque_Gastos
{
    public class Receita
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorLucro { get; set; }
        public decimal? ValorVenda { get; set; }
        public decimal ValorTotal { get; set; }
    }

    public class ReceitaIngrediente
    {
        public int Id { get; set; }
        public int ReceitaId { get; set; }
        public int IngredienteId { get; set; }
    }
}
