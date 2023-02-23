using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using WF_Gestao_Estoque_Gastos.Cadastros;
using WF_Gestao_Estoque_Gastos.Servicos;

namespace WF_Gestao_Estoque_Gastos
{
    public partial class FrmPrincipal : MaterialForm
    {
        FrmLogin FormLogin;
        private Usuario usuarioLogado;
        public FrmPrincipal()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        public FrmPrincipal(int id)
        {
            InitializeComponent();
            this.CenterToScreen();
            PreencheUsuario(id);
        }

        public FrmPrincipal(int id, FrmLogin formLogin)
        {
            FormLogin = formLogin;
            InitializeComponent();
            this.CenterToScreen();
            PreencheUsuario(id);
        }
        
        private void PreencheUsuario(int id)
        {
            usuarioLogado = FormLogin.RetornaUsuarioLogado(id);
            if(usuarioLogado != null)
            {
                lblNomeUsuario.Text = "Usuário: " + usuarioLogado.Nome;
            }
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciarTela.AbrirTela(new FrmCadEmpresa(), true);
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciarTela.AbrirTela(new FrmCadUsuario(), true);
        }

        private void ingredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciarTela.AbrirTela(new FrmCadIngrediente(), true);
        }

        private void unidadeDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciarTela.AbrirTela(new FrmCadUnidadeMedida(), true);
        }

        private void FrmPrincipal_Shown(object sender, EventArgs e)
        {
            //GerenciarTela.AbrirTelaEFecharAtual(FormLogin, this, true);
        }

        private void deslogarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin.LoginAutomatico(usuarioLogado.EmpresaId);
            FormLogin.LimparCampos();
            this.Close();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
