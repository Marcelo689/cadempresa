using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WF_Gestao_Estoque_Gastos.Conexao.Cidade;
using WF_Gestao_Estoque_Gastos.Servicos.ComboBoxManager;
using WF_Gestao_Estoque_Gastos.Servicos.Validacoes;

namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    public partial class FrmCadEmpresa : MaterialForm
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;
        public bool listEmpresaSelecionado { get; set; }
        private string _colunaIdCidade = "idcidade";
        private string cnpjAntesDeAlterar;

        public FrmCadEmpresa()
        {
            con = new MySqlConnection("server=localhost;database=gestao_estoque_gasto;pwd=;uid=root;");

            InitializeComponent();
            
        }

        private void LimpaCampos()
        {
            mtxtRazaoSocial.Text = String.Empty;
            mtxtNomeFantasia.Text = String.Empty;
            mtxtCnpj.Text = String.Empty;
            mtxtTelefone.Text = String.Empty;
            mtxtEmail.Text = String.Empty;
            GerenciarComboBox<Cidade>.Deselecionar(cbxCidade);
            mtxtBairro.Text = String.Empty;
            mtxtComplemento.Text = String.Empty;
            mtxtNumero.Text = String.Empty;
            mtxtRua.Text = String.Empty;
            listEmpresaSelecionado = false;
            cnpjAntesDeAlterar = "";
        }

        private void materialLabel9_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e) // btnSalvar
        {

            string razaoSocial = mtxtRazaoSocial.Text;
            string nomeFantasia = mtxtNomeFantasia.Text;
            
            string CNPJ = mtxtCnpj.Text;
            CNPJ = ValidarCampos.RemoveMaskaraCnpj(CNPJ);
            if (!ValidarString.CampoApenasNumerico(CNPJ) && CNPJ.Length == 14)
            {
                ExibirMensagem.Aviso("Digite apenas Numeros, e apenas 14");
                return;
            }
            else if (CNPJ.Length == 0)
                return;
            CNPJ = ValidarCampos.FormatCNPJ(CNPJ); // trata cnpj

            CNPJ = ValidarCampos.RemoverPontosHifensEBarra(CNPJ);
            string telefone = "";
            telefone = ValidarCampos.RemoveMaskaraTelefone(mtxtTelefone.Text);
            if (!ValidarString.CampoApenasNumerico(telefone)){
                ExibirMensagem.Erro("Preencha o telefone apenas com números!");
                return;
            }else if(telefone.Length != 11)
            {
                ExibirMensagem.Erro("Telefone Precisa de 11 números!");
                return;
            }

            string email = mtxtEmail.Text;
            //string idcidade = mtxtCidade.Text; // capturar cidade id
            string idCidade = GerenciarComboBox<Cidade>.RetornaItemSelecionadoCombo(cbxCidade).Id.ToString();

            string bairro = mtxtBairro.Text;
            string complemento = mtxtComplemento.Text;
            int numeroResidencia = 0;
            if (ValidarString.CampoApenasNumerico(mtxtNumero.Text))
                numeroResidencia = ValidarCampos.RetornaZeroCasoVazio(mtxtNumero.Text);
            else
            {
                ExibirMensagem.Erro("Preencha Numero com apenas números");
                return;
            }
            string rua = mtxtRua.Text;

            try
            {
                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = $"SELECT id FROM tblempresa WHERE CNPJ = '{cnpjAntesDeAlterar}' ";
                reader = cmd.ExecuteReader();
                var idEmpresa = 0;
                var existeCnpj = false;
                while (reader.Read())
                {
                    idEmpresa = Convert.ToInt32(reader["id"].ToString()); 
                    existeCnpj = true;
                    listEmpresaSelecionado = true;
                };
                con.Close();
                if (listEmpresaSelecionado)
                {
                    con.Open();

                    cmd = con.CreateCommand();

                    cmd.CommandText = $"UPDATE tblempresa SET CNPJ = @CNPJ, razaoSocial = @razaoSocial, rua = @rua, bairro = @bairro, numeroEndereco = @numeroResidencia, complemento = @complemento, email = @email, telefone = @telefone, nomeFantasia = @nomeFantasia, {_colunaIdCidade} = @idcidade WHERE id ={idEmpresa} ";

                    cmd.Parameters.AddWithValue("CNPJ", CNPJ);
                    cmd.Parameters.AddWithValue("razaoSocial", razaoSocial);
                    cmd.Parameters.AddWithValue("rua", rua);
                    cmd.Parameters.AddWithValue("bairro", bairro);
                    cmd.Parameters.AddWithValue("numeroResidencia", numeroResidencia);
                    cmd.Parameters.AddWithValue("complemento", complemento);
                    cmd.Parameters.AddWithValue("email", email);

                    telefone = ValidarCampos.RemoveMaskaraTelefone(telefone);
                    cmd.Parameters.AddWithValue("telefone", telefone);
                    cmd.Parameters.AddWithValue("nomeFantasia", nomeFantasia);
                    cmd.Parameters.AddWithValue(_colunaIdCidade, idCidade);

                    int retornoDoUpdate = cmd.ExecuteNonQuery();

                    if (retornoDoUpdate > 0)
                    {
                        ExibirMensagem.Informacao("Empresa alterada com sucesso!");
                        LimpaCampos();
                        atualizar_lista();
                    }
                    con.Close();
                }
                else
                {
                    con.Open();

                    cmd = con.CreateCommand();

                    cmd.CommandText = $"INSERT INTO tblempresa (CNPJ,razaoSocial,rua,bairro,numeroEndereco,complemento,email,telefone,nomeFantasia,{_colunaIdCidade}) VALUES (@CNPJ,@razaoSocial,@rua,@bairro,@numeroResidencia,@complemento,@email,@telefone,@nomeFantasia,@idcidade)";

                    cmd.Parameters.AddWithValue("CNPJ", CNPJ);
                    cmd.Parameters.AddWithValue("razaoSocial", razaoSocial);
                    cmd.Parameters.AddWithValue("rua", rua);
                    cmd.Parameters.AddWithValue("bairro", bairro);
                    cmd.Parameters.AddWithValue("numeroResidencia", numeroResidencia);
                    cmd.Parameters.AddWithValue("complemento", complemento);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("telefone", telefone);
                    cmd.Parameters.AddWithValue("nomeFantasia", nomeFantasia);
                    cmd.Parameters.AddWithValue(_colunaIdCidade, idCidade);

                    int retornoDoInsert = cmd.ExecuteNonQuery();

                    if (retornoDoInsert > 0)
                    {
                        ExibirMensagem.Informacao("Empresa cadastrada com sucesso!");
                        LimpaCampos();
                        atualizar_lista();
                    }
                    con.Close();
                }                                
            }
            catch (Exception ex)
            {
                ExibirMensagem.Erro("Erro, contate o suporte técnico para verificar!\n"+ ex.Message);
            }


        }

        private void materialRaisedButton2_Click(object sender, EventArgs e) // btnExcluir
        {
            Excluir_empresa();
        }

       

        public void Excluir_empresa()
        {

            var CNPJEmpresa = ValidarCampos.RemoveMaskaraCnpj(mtxtCnpj.Text);

            if (listViewEmpresa.SelectedIndices.Count <= 0)
            {
                return;
            }
            try
            {

                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM `tblempresa` WHERE CNPJ = @CNPJ";
                cmd.Parameters.AddWithValue("@CNPJ",CNPJEmpresa);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                ExibirMensagem.Erro("Ops. Erro: " + e.Message);
            }
            atualizar_lista();
            LimpaCampos();
        }

        public void atualizar_lista()
        {
            //cria uma lista do tipo Empresas
            List<Empresa> listaEmpresas = new List<Empresa>();

            if(con.State == System.Data.ConnectionState.Closed)
                con.Open();

            //seta a conexão para o comando
            cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"SELECT `id`, `CNPJ`, `razaoSocial`, `rua`, `bairro`, `numeroEndereco`, `complemento`, `email`, `telefone`, `nomeFantasia`, `{_colunaIdCidade}` FROM `tblempresa`";


            /*SELECT tblempresa.id, CNPJ, razaoSocial, rua, bairro, numeroEndereco, complemento, tblcidade.descricaoCidade, email, telefone, nomeFantasia, createEmpresa, updateEmpresa, idUsername
              FROM tblempresa
              INNER JOIN tblcidade ON tblempresa.idcidade = tblcidade.id
              INNER JOIN tblestado ON tblcidade.id = tblestado.id
              INNER JOIN tblpais ON tblestado.id = tblpais.id            
            */

            //executa o comando
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var id = Convert.ToInt32(reader["id"].ToString());
                var cpnj = reader["CNPJ"].ToString();
                var nomeFantasia = reader["nomeFantasia"].ToString();
                var email = reader["email"].ToString();
                var telefone = reader["telefone"].ToString();
                var numeroResidencia = Convert.ToInt32(reader["numeroEndereco"].ToString());

                var complemento = reader["complemento"].ToString();
                var Idcidade = reader[$"{_colunaIdCidade}"].ToString();
                var rua = reader["rua"].ToString();
                var bairro = reader["bairro"].ToString();
                var razaoSocial = reader["razaoSocial"].ToString();

                Empresa empresa = new Empresa()
                {
                    id = id,
                    CNPJ = cpnj,
                    nomeFantasia = nomeFantasia,
                    email = email,
                    telefone = telefone,
                    numeroResidencia = numeroResidencia,
                    complemento = complemento,
                    cidade = Idcidade,
                    rua = rua,
                    bairro = bairro,
                    razaoSocial = razaoSocial,
                };
                listaEmpresas.Add(empresa);
            }
            listViewEmpresa.Items.Clear();
            //adiciona no ListBox os nomes da lista
            foreach (Empresa empresa in listaEmpresas)
            {
                listViewEmpresa.Items.Add(new ListViewItem(new String[]
                {
                    empresa.id.ToString(),                   
                    empresa.nomeFantasia,
                    empresa.CNPJ.ToString(),                   
                    empresa.telefone.ToString(),
                    empresa.email,
                    empresa.razaoSocial,
                    empresa.rua,
                    empresa.bairro,
                    empresa.numeroResidencia.ToString(),
                    empresa.complemento,
                    empresa.cidade,
                }
                ));
            }
            con.Close();

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (listViewEmpresa.SelectedIndices.Count <= 0)
            {
                cnpjAntesDeAlterar = "";
                return;
            }
            else
            {
                btnCancelar.Visible = true;
                mtxtId.Visible = true;
                lblCodigo.Visible = true;
                listEmpresaSelecionado = true;
            }

            var itemSelecionado = Convert.ToInt32(listViewEmpresa.SelectedIndices[0]);

            var id = Convert.ToInt32(listViewEmpresa.Items[itemSelecionado].SubItems[0].Text);

            var nomeFantasia = (listViewEmpresa.Items[itemSelecionado].SubItems[1].Text);

            var cnpj = (listViewEmpresa.Items[itemSelecionado].SubItems[2].Text).ToString();

            var telefone = (listViewEmpresa.Items[itemSelecionado].SubItems[3].Text).ToString();

            var email = (listViewEmpresa.Items[itemSelecionado].SubItems[4].Text);

            var razaoSocial = (listViewEmpresa.Items[itemSelecionado].SubItems[5].Text);

            var rua = (listViewEmpresa.Items[itemSelecionado].SubItems[6].Text);

            var bairro = (listViewEmpresa.Items[itemSelecionado].SubItems[7].Text);

            var numeroEndereco = Convert.ToInt32(listViewEmpresa.Items[itemSelecionado].SubItems[8].Text);

            var complemento = (listViewEmpresa.Items[itemSelecionado].SubItems[9].Text);
                                 
            var Idcidade = (listViewEmpresa.Items[itemSelecionado].SubItems[10].Text);

            var cidade = MetodosTblCidade.RetornaTodasCidades().Where(cid => cid.Id == int.Parse(Idcidade));
            
            var retorno = cidade.FirstOrDefault(); 

            mtxtRazaoSocial.Text = razaoSocial.ToString();
            mtxtNomeFantasia.Text = nomeFantasia.ToString();
            mtxtCnpj.Text = ValidarCampos.FormatCNPJ(cnpj.ToString());
            cnpjAntesDeAlterar = ValidarCampos.RemoveMaskaraCnpj(mtxtCnpj.Text);

            mtxtTelefone.Text = ValidarCampos.FormatarTelefone(telefone.ToString());
            mtxtEmail.Text = email.ToString();
            if(retorno != null)
                GerenciarComboBox<Cidade>.Selecionar(cbxCidade, retorno.DescricaoCidade);
            mtxtBairro.Text = bairro.ToString();
            mtxtComplemento.Text = complemento.ToString();
            mtxtNumero.Text = numeroEndereco.ToString();
            mtxtRua.Text = rua.ToString();
            mtxtId.Text = id.ToString();    
        }

        private void materialLabel11_Click(object sender, EventArgs e)
        {

        }

        class Empresa
        {
            public int id { get; set; }
            public string razaoSocial { get; set; }
            public string rua { get; set; }
            public string nomeFantasia { get; set; }
            public string CNPJ  { get; set; }
            public string telefone { get; set; }
            public string email { get; set; }
            public string cidade { get; set; }
            public string bairro { get; set; }
            public string complemento { get; set; }
            public int numeroResidencia { get; set; }

        }

        private void btnCancelar_Click(object sender, EventArgs e) // cancelar
        {
            LimpaCampos();
            btnCancelar.Visible = false;
            lblCodigo.Visible = false;
            mtxtId.Visible = false;
            atualizar_lista();
        }

        private void mtxtCnpj_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void mtxtCnpj_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void mtxtCnpj_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void mtxtCnpj_Click(object sender, EventArgs e)
        {
            //inutil, evento de click do input cnpj
        }

        private void mtxtCnpj_TextChanged(object sender, EventArgs e)
        {

            //string caractere = ValidarCampos.AdicionaCaracteresMaskara(mtxtCnpj.Text.Length);

            //if (caractere != "")
            //    mtxtCnpj.Text += caractere;
            
        }

        private void FrmCadEmpresa_Load(object sender, EventArgs e)
        {
            var listaCidade = MetodosTblCidade.RetornaTodasCidades();   
            GerenciarComboBox<Cidade>.Preencher(cbxCidade, listaCidade, "DescricaoCidade");
            atualizar_lista();
            LimpaCampos();
        }
    }
}
