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

        public void PreencheDadosUsuario()
        {
            DadosUsuario.Id           = Id;
            DadosUsuario.Senha        = Senha;
            DadosUsuario.Nome         = Nome;
            DadosUsuario.Username     = Username;
            DadosUsuario.ManterLogado = ManterLogado;
            DadosUsuario.EmpresaId    = EmpresaId;
            DadosUsuario.Acesso       = Acesso;
            DadosUsuario.Ativo        = Ativo;
        }
    }
    public static class DadosUsuario
    {
        public static int Id { get; set; }
        public static string Nome { get; set; }
        public static string Username { get; set; }
        public static string Senha { get; set; }
        public static int Acesso { get; set; }
        public static bool ManterLogado { get; set; }
        public static int EmpresaId { get; set; }
        public static bool Ativo { get; set; }

        public static Usuario GetUsuario()
        {
            return new Usuario
            {
                Id = DadosUsuario.Id,
                Nome = DadosUsuario.Nome,
                Senha = DadosUsuario.Senha,
                Username = DadosUsuario.Username,
                ManterLogado = DadosUsuario.ManterLogado,
                EmpresaId = DadosUsuario.EmpresaId,
                Acesso = DadosUsuario.Acesso,
                Ativo = DadosUsuario.Ativo,
            };
        }
    }

}