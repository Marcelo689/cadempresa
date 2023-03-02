using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using WF_Gestao_Estoque_Gastos.Cadastros;
using WF_Gestao_Estoque_Gastos.Conexao.Cidade;
using WF_Gestao_Estoque_Gastos.Servicos;
using WF_Gestao_Estoque_Gastos.Servicos.Excecoes;

namespace WF_Gestao_Estoque_Gastos
{
    public partial class FrmLogin : MaterialForm
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;
        FrmLogin form;

        public Usuario usuarioLogado;

        public FrmLogin()
        {
            form = this;
            InitializeComponent();
            this.CenterToScreen();
            con = new MySqlConnection("server=localhost;database=gestao_estoque_gasto;uid=root;pwd=;");
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var usuarioLogou = false;

            DesmarcarUsuariosManterLogin();
            var id = 0;

            Empresa empresa = (Empresa) cbxEmpresa.SelectedItem;
            try
            {
                var usuario = txtUsuario.Text;
                var senha = txtSenha.Text;

                con.Open();
                cmd.CommandText = "select * from tblUsuario;";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    var rdrUsuario = reader["username"].ToString();
                    var rdrSenha   = reader["senha"].ToString();
                    if (rdrUsuario == usuario && rdrSenha == senha)
                    {
                        id = int.Parse(reader["id"].ToString());
                        usuarioLogou = true;
                    }
                }

            }
            catch (Exception)
            {
                MensagemErroConexao();
            }
            finally
            {
                con.Close();
                if (usuarioLogou)
                {
                    if (chxManterLogin.Checked)
                        LoginAutomatico(empresa.Id, id);
                    else
                        LoginAutomatico(empresa.Id);
                    GerenciarTela.AbrirTelaEFecharAtual(new FrmPrincipal(form), form, true);
                }
                else
                    ExibirMensagem.Aviso("Usuário e/ou senha incorretos.");
            }

        }
        private void AbrirTelaEFecharAtual()
        {

        }
        public void LoginAutomatico(int empresaId, int id = 0)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                if(id == 0)
                    cmd.CommandText = $"update tblusuario set manterlogado = 0 , set empresaid = {empresaId} ";
                else
                    cmd.CommandText = $"update tblusuario set manterlogado = 1, empresaid = {empresaId} where id = {id}";
                cmd.ExecuteNonQuery();
            }
            catch (Exception errou)
            {
                Debug.WriteLine(errou.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private Empresa BuscaEmpresaPorId(int id) 
        {
            var listaCidades = MetodosTblCidade.RetornaTodasCidades();
            try
            {
                con.Open();
                cmd.CommandText = $"select * from tblempresa where id = {id}";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var idCidade = Convert.ToInt32(reader["idCidade"].ToString());

                    var empresa = new Empresa()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        CNPJ = reader["CNPJ"].ToString(),
                        RazaoSocial = reader["RazaoSocial"].ToString(),
                        Rua = reader["Rua"].ToString(),
                        Bairro = reader["bairro"].ToString(),
                        NumeroEndereco = int.Parse(reader["NumeroEndereco"].ToString()),
                        Complemento = reader["Complemento"].ToString(),
                        Email = reader["Email"].ToString(),
                        Telefone = reader["Telefone"].ToString(),
                        CidadeId = idCidade,
                        NomeFantasia = reader["NomeFantasia"].ToString(),
                    };

                    return empresa;
                }

            }
            catch (Exception)
            {
                MensagemErroConexao();
            }
            finally
            {
                con.Close();
            }
            return null;
        }
        private void PreencheEmpresaDoUsuarioManterLogin(int id)
        {
            var empresa = BuscaEmpresaPorId(id);
            if (empresa != null)
            {
                cbxEmpresa.SelectedValue = empresa.Id;
            }else
            if (cbxEmpresa.Items.Count > 0)
                cbxEmpresa.SelectedIndex = 0;
        }

        private void DesmarcarUsuariosManterLogin()
        {
            try
            {
                con.Open();

                cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE tblusuario SET manterlogado = 0";

                int retornoDoUpdate = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                ExibirMensagem.Informacao("Ops. Erro: " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private bool PreencheUsuarioManterLogin()
        {
            var id = 0;
            var sucesso = false;
            var empresaId = 0;
            try
            {
                con.Open();
                cmd.CommandText = $"select * from tblUsuario where manterlogado = 1";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id                      = int.Parse(reader["id"].ToString());
                    txtUsuario.Text         = reader["nome"].ToString();
                    txtSenha.Text           = reader["senha"].ToString();
                    chxManterLogin.Checked  = int.Parse(reader["manterlogado"].ToString()) == 1;
                    empresaId               = int.Parse(reader["empresaId"].ToString());
                    sucesso                 = true;
                }

            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                MensagemErroConexao();
            }
            finally
            {
                con.Close();
                if (id != 0)
                {
                    usuarioLogado =  RetornaUsuarioLogado(id);
                    if(empresaId != 0)  
                        PreencheEmpresaDoUsuarioManterLogin(empresaId);
                }
            }

            return sucesso;
        }
        private void DesabilitarCampos()
        {
            cbxEmpresa.Enabled = false;
            txtUsuario.Enabled = false;
            txtSenha.Enabled   = false;
            btnEntrar.Enabled  = false;  
            Mensagem.Informacao("Tenha certeza de ter empresa e usuário cadastrados");
        }
        private void HabilitarCampos()
        {
            cbxEmpresa.Enabled = true;
            txtUsuario.Enabled = true;
            txtSenha.Enabled   = true;
            btnEntrar.Enabled  = true;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            var sucesso = PreencheComboEmpresa();
            if (cbxEmpresa.Items.Count > 0)
                cbxEmpresa.SelectedIndex = 0;
            if (sucesso == false)
                DesabilitarCampos();
            else
                HabilitarCampos();

            PreencheUsuarioManterLogin();
        }
        private bool PreencheComboEmpresa()
        {
            var sucesso = false;
            try
            {
                var listaEmpresas = new List<Empresa>();
                con.Open();
                cmd.CommandText = $"select * from tblempresa";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaEmpresas.Add(new Empresa()
                    {
                        Id              = int.Parse(reader["id"].ToString()),
                        CNPJ            = reader["cnpj"].ToString(),
                        NomeFantasia    = reader["NomeFantasia"].ToString(),
                        Bairro          = reader["Bairro"].ToString(),
                        CidadeId        = int.Parse(reader["idCidade"].ToString()),
                        Complemento     = reader["Complemento"].ToString(),
                        Email           = reader["Email"].ToString(),
                        NumeroEndereco  = int.Parse(reader["NumeroEndereco"].ToString()),
                        RazaoSocial     = reader["RazaoSocial"].ToString(),
                        Rua             = reader["Rua"].ToString(),
                        Telefone        = reader["Telefone"].ToString(),
                    });

                }
                cbxEmpresa.DataSource = listaEmpresas;
                cbxEmpresa.DisplayMember = "NomeFantasia";
                cbxEmpresa.ValueMember   = "Id";
                sucesso = true;

            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                MensagemErroConexao();
            }
            finally
            {
                con.Close();
            }
            return sucesso;
        }
        private void chxManterLogin_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void MensagemErroConexao()
        {
            ExibirMensagem.Erro("Falha na conexão.");
        }

        private void cadastrarUsuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GerenciarTela.AbrirTela(new FrmCadUsuario(), true);
        }

        private void cadastrarEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciarTela.AbrirTela(new FrmCadEmpresa(), true);
        }

        private void deslogarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        public Usuario RetornaUsuarioLogado(int id)
        {
            var usuarioLogado = DadosUsuario.GetUsuario();
            if (usuarioLogado.Id != 0)
                return usuarioLogado;
            try
            {
                var usuario = txtUsuario.Text;
                var senha = txtSenha.Text;

                con.Open();
                cmd.CommandText = "select * from tblUsuario where id = " + id;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var ativo = Int16.Parse( reader["ativo"].ToString() );
                    var acesso = int.Parse(reader["acesso"].ToString());
                    var logado   = int.Parse(reader["manterlogado"].ToString());
                    var usuarioObj = new Usuario()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        Nome = reader["nome"].ToString(),
                        Username = reader["username"].ToString(),
                        Senha = reader["senha"].ToString(),
                        Acesso = acesso,
                        ManterLogado = logado == 1,
                        Ativo = ativo == 1,
                        EmpresaId = int.Parse(reader["empresaid"].ToString())
                    };
                    usuarioObj.PreencheDadosUsuario();
                    return usuarioObj;
                }

            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                MensagemErroConexao();
            }
            finally
            {
                con.Close();
            }
            return null;
            
        }

        public void Deslogar()
        {
            LoginAutomatico(usuarioLogado.EmpresaId);
            Application.Exit();
        }
        public void LimparCampos()
        {
            txtSenha.Text = "";
            txtUsuario.Text = "";

            if (cbxEmpresa.Items.Count > 0)
                cbxEmpresa.SelectedIndex = 0;

            chxManterLogin.Checked = false;
        }
        private void deslogarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoginAutomatico(usuarioLogado.EmpresaId);
            LimparCampos(); 
            Application.Exit();
        }

        private void cbxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
