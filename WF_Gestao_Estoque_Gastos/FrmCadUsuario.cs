using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_Gestao_Estoque_Gastos.Conexao;
using WF_Gestao_Estoque_Gastos.Servicos.Validacoes;

namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    public partial class FrmCadUsuario : MaterialForm
    {
        public MySqlConnection con = new MySqlConnection("server=localhost;database=gestao_estoque_gasto;uid=root;pwd=;sslmode=none");
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader rd;

        public FrmCadUsuario()
        {
            InitializeComponent();
            checkBox.Checked = true;
            checkBox.Text = "Ativo";
            lblCaracterEspecial.BackColor = Color.Red;
            lblOitoCaracteres.BackColor = Color.Red;
            lblNumeros.BackColor = Color.Red;
            lblMinusculas.BackColor = Color.Red;
            lblMaiusculas.BackColor = Color.Red;

            BuscarDadosUsuario();
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            var valido = CamposValidos();
            if (!valido)
            {
                return;
            }

            if (ExisteItemSelecionado())
            {
                AtualizarUsuario();
            }
            else
            {
                if (checkBox.Checked == false)
                {
                    ExibirMensagem.Informacao("Não é possível cadastrar usuário inativo!");
                }
                else
                {
                    CadastrarUsuario();
                }
            }
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DesativarUsuario();
        }

        private void checkBox_Click(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                checkBox.Text = "Ativo";
            }
            else
            {
                checkBox.Text = "Inativo";
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = String.Empty;
            var name = String.Empty;
            var username = String.Empty;
            var acesso = String.Empty;
            var ativo = String.Empty;

            if (listView.SelectedIndices.Count <= 0)
            {
                return;
            }

            var indiceItemSelecionado = Convert.ToInt32(listView.SelectedIndices[0]);
            if (indiceItemSelecionado >= 0)
            {

                id = listView.Items[indiceItemSelecionado].Text;
                name = listView.Items[indiceItemSelecionado].SubItems[1].Text;
                username = listView.Items[indiceItemSelecionado].SubItems[2].Text;
                acesso = listView.Items[indiceItemSelecionado].SubItems[3].Text;
                ativo = listView.Items[indiceItemSelecionado].SubItems[4].Text;

                txtNome.Text = name;
                txtUsuario.Text = username;
                lblid.Text = id;
            }

        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            ConfirmarSenha();
        }

        private void txtConfirmarSenha_Leave(object sender, EventArgs e)
        {
            NivelDeSeguranca();
            ConfirmarSenha();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            NivelDeSeguranca();

            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        private void txtConfirmarSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSenha.Checked)
            {
                txtSenha.PasswordChar = '\0';
                txtConfirmarSenha.PasswordChar = '\0';
            }
            else
            {
                txtSenha.PasswordChar = '*';
                txtConfirmarSenha.PasswordChar = '*';
            }
        }

        private void CadastrarUsuario()
        {

            try
            {
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = ($@"INSERT INTO dbLogin.tblUsuario(
                    Nome, Username, Senha, Acesso, EmpresaId, ManterLogado, Ativo) VALUES
                    ('{txtNome.Text}','{txtUsuario.Text}', '{txtSenha.Text}','1', '1','0','S')");
                int retorno = cmd.ExecuteNonQuery();

                if (retorno < 1)
                {
                    MessageBox.Show("Não foi possível inserir o usuário!");
                }
                else
                {
                    MessageBox.Show("Usuário inserido com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro interno!");
                Console.WriteLine(ex.Message);
                return;
            }
            finally
            {
                LimparCampos();
                con.Close();
            }

            if (!checkBox.Checked)
            {
                MessageBox.Show("Não é possível cadastrar usuário inativo!");
            }
            else

                this.BuscarDadosUsuario();
        }

        private void DesativarUsuario()
        {
            try
            {
                if (listView.SelectedIndices.Count > -1)
                {

                    cmd.CommandText = ($"UPDATE dbLogin.tblUsuario SET Ativo = 'N' WHERE id = {lblid.Text}");

                    con.Open();
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuário foi desativado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro interno");
                Console.WriteLine(ex.Message);
                return;
            }
            finally
            {
                con.Close();
                BuscarDadosUsuario();
                con.Close();
            }
        }

        private void AtualizarUsuario()
        {
            var inserirStatus = String.Empty;

            try
            {
                if (listView.SelectedIndices.Count > -1)
                {
                    if (checkBox.Text == "Ativo")
                    {
                        inserirStatus = "S";
                    }
                    else
                    {
                        inserirStatus = "N";
                    }

                    cmd.CommandText = ($@"UPDATE tblUsuario SET Nome = '{txtNome.Text}',
                                       UserName = '{txtUsuario.Text}', 
                                       Senha = '{txtSenha.Text}', 
                                       Acesso = 1, 
                                       ManterLogado = 1, 
                                       EmpresaId = 1, 
                                       Ativo = '{inserirStatus}'    
                                       WHERE id = {lblid.Text}");

                    con.Open();
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuário atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro interno");
                Console.WriteLine(ex.Message);
                return;
            }
            finally
            {
                con.Close();
                BuscarDadosUsuario();
            }
        }

        private void BuscarDadosUsuario()
        {
            List<Usr> usuarios = new List<Usr>();
            cmd.CommandText = ("SELECT * FROM tblUsuario ORDER BY Nome");

            con.Open();
            cmd.Connection = con;
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                var user = new Usr()
                {
                    Id = Convert.ToInt32(rd["id"].ToString()),
                    Name = rd["Nome"].ToString(),
                    Username = rd["Username"].ToString(),
                    Acesso = rd["Acesso"].ToString(),
                    Ativo = rd["Ativo"].ToString()

                };
                usuarios.Add(user);
            }
            listView.Items.Clear();

            foreach (Usr u in usuarios)
            {
                listView.Items.Add(new ListViewItem(

                    new String[]
                    {
                            u.Id.ToString(),
                            u.Name.ToString(),
                            u.Username.ToString(),
                            u.Acesso.ToString(),
                            u.Ativo.ToString()

                    })
                );
            }
            rd.Close();
            con.Close();
        }
        public void LimparCampos()
        {
            txtUsuario.Text = String.Empty;
            txtSenha.Text = String.Empty;
            txtConfirmarSenha.Text = String.Empty;
            txtNome.Text = String.Empty;
            lblid.Text = String.Empty;
            checkBox.Checked = true;
            listView.SelectedItems.Clear();
        }

        public bool VerificarInputs()
        {
            bool verifica = false;
            if (ValidarString.CamposPreenchido(txtUsuario.Text, txtNome.Text, txtSenha.Text, txtConfirmarSenha.Text))
            {
                verifica = true;
            }

            return verifica;
        }

        private bool ExisteItemSelecionado()
        {
            return listView.SelectedItems.Count > 0;
        }

        private bool ConfirmarSenha()
        {
            var retorno = false;

            if (txtSenha.Text == txtConfirmarSenha.Text && !string.IsNullOrWhiteSpace(txtConfirmarSenha.Text) && !string.IsNullOrEmpty(txtSenha.Text))
            {
                lblConfirmarSenha.BackColor = Color.Green;
                lblConfirmarSenha.Text = "Senhas validadas";
                retorno = true;
            }
            else
            {
                lblConfirmarSenha.BackColor = Color.Red;
                lblConfirmarSenha.Text = "Senhas diferentes";
            }

            if (txtConfirmarSenha.Text == String.Empty && txtSenha.Text == String.Empty)
            {
                lblConfirmarSenha.Text = String.Empty;
                lblConfirmarSenha.BackColor = Color.White;
            }
            return retorno;
        }

        private void NivelDeSeguranca()
        {
            if(ContemMaiusculas())
            {
                lblMaiusculas.BackColor = Color.Green;
            } else
            {
                lblMaiusculas.BackColor = Color.Red;
            }

            if(ContemMinusculas())
            {
                lblMinusculas.BackColor = Color.Green;
            } else
            {
                lblMinusculas.BackColor = Color.Red;
            }

            if (ContemNumeros())
            {
                lblNumeros.BackColor = Color.Green;
            }
            else
            {
                lblNumeros.BackColor = Color.Red;
            }

            if (MinimoCaracteres())
            {
                lblOitoCaracteres.BackColor = Color.Green;
            } else
            {
                lblOitoCaracteres.BackColor = Color.Red;
            }

            if (ContemCaracteresEspeciais())
            {
                lblCaracterEspecial.BackColor = Color.Green;
            } else
            {
                lblCaracterEspecial.BackColor = Color.Red;
            }
        }


        public bool ContemMaiusculas()
        {
            var regex = new Regex("[A-Z]");
            return regex.Match(txtSenha.Text).Success;
        }

        public bool ContemMinusculas()
        {
            var regex = new Regex("[a-z]");
            return regex.Match(txtSenha.Text).Success;
        }

        public bool ContemNumeros()
        {
            var regex = new Regex("[0-9]");
            return regex.Match(txtSenha.Text).Success;
        }

        public bool ContemCaracteresEspeciais()
        {
            var regex = new Regex("[^a-zA-Z 0-9]+");
            return regex.Match(txtSenha.Text).Success;
        }

        public bool MinimoCaracteres()
        {
            if(txtSenha.Text.Length >= 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarNomeDeUsuario()
        {
            var retorno = true;
            var regex = new Regex("[A-Z a-z]");

            if (txtUsuario.Text.Contains(" ") || !regex.Match(txtUsuario.Text).Success)
            {
                retorno = false;
            } 

            return retorno;
        }

        public bool VerificarNome()
        {
            var retorno = true;
            var regex = new Regex("[A-Z a-z]");

            if (!regex.Match(txtNome.Text).Success)
            {
                retorno = false;
            }

            return retorno;
            
        }

        private bool CamposValidos()
        {
            var valido = false;

            if (!VerificarInputs() || !ConfirmarSenha())
            {
                ExibirMensagem.Informacao("Não foi possível cadastrar o usuário, por favor, verifique as informações!");
                return valido;
            }

            if (!VerificarNomeDeUsuario())
            {
                ExibirMensagem.Informacao("Nome de usuário só pode conter letras!");
                return valido;
            }

            if(!VerificarNome())
            {
                ExibirMensagem.Informacao("Nome deve conter apenas letras e espaços!");
                return valido;
            }

            return true;
        }

        class Usr
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }
            public string Acesso { get; set; }
            public string Ativo { get; set; }
        }

    }
}
