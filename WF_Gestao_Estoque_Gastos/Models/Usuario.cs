namespace WF_Gestao_Estoque_Gastos
{
    public class Usuario
    {
          public int Id { get; set; }
          public string Nome { get; set; }
          public string Username { get; set; }
          public string Senha { get; set; }
          public int Acesso { get; set; }
          public bool ManterLogado { get; set; }
          public int EmpresaId { get; set; }
          public bool Ativo { get; set; }
        
    }
}