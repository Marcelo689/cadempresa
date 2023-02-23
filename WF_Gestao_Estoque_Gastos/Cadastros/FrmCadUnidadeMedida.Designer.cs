namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    partial class FrmCadUnidadeMedida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblId = new MaterialSkin.Controls.MaterialLabel();
            this.txtSigla = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtDescricao = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnCancelar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnSalvar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblSigla = new MaterialSkin.Controls.MaterialLabel();
            this.lblDescricao = new MaterialSkin.Controls.MaterialLabel();
            this.listViewUnidade = new System.Windows.Forms.ListView();
            this.desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sigla = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExcluir = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblId);
            this.groupBox1.Controls.Add(this.txtSigla);
            this.groupBox1.Controls.Add(this.txtDescricao);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnSalvar);
            this.groupBox1.Controls.Add(this.lblSigla);
            this.groupBox1.Controls.Add(this.lblDescricao);
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 440);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastro";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Depth = 0;
            this.lblId.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblId.Location = new System.Drawing.Point(38, 244);
            this.lblId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 19);
            this.lblId.TabIndex = 10;
            this.lblId.Visible = false;
            // 
            // txtSigla
            // 
            this.txtSigla.Depth = 0;
            this.txtSigla.Hint = "";
            this.txtSigla.Location = new System.Drawing.Point(25, 176);
            this.txtSigla.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSigla.Name = "txtSigla";
            this.txtSigla.PasswordChar = '\0';
            this.txtSigla.SelectedText = "";
            this.txtSigla.SelectionLength = 0;
            this.txtSigla.SelectionStart = 0;
            this.txtSigla.Size = new System.Drawing.Size(218, 23);
            this.txtSigla.TabIndex = 1;
            this.txtSigla.TabStop = false;
            this.txtSigla.UseSystemPasswordChar = false;
            this.txtSigla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSigla_KeyPress);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Depth = 0;
            this.txtDescricao.Hint = "";
            this.txtDescricao.Location = new System.Drawing.Point(25, 60);
            this.txtDescricao.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.PasswordChar = '\0';
            this.txtDescricao.SelectedText = "";
            this.txtDescricao.SelectionLength = 0;
            this.txtDescricao.SelectionStart = 0;
            this.txtDescricao.Size = new System.Drawing.Size(218, 23);
            this.txtDescricao.TabIndex = 0;
            this.txtDescricao.TabStop = false;
            this.txtDescricao.UseSystemPasswordChar = false;
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Depth = 0;
            this.btnCancelar.Location = new System.Drawing.Point(25, 339);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Primary = true;
            this.btnCancelar.Size = new System.Drawing.Size(91, 43);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Depth = 0;
            this.btnSalvar.Location = new System.Drawing.Point(165, 339);
            this.btnSalvar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Primary = true;
            this.btnSalvar.Size = new System.Drawing.Size(91, 43);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblSigla
            // 
            this.lblSigla.AutoSize = true;
            this.lblSigla.Depth = 0;
            this.lblSigla.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblSigla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSigla.Location = new System.Drawing.Point(21, 134);
            this.lblSigla.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSigla.Name = "lblSigla";
            this.lblSigla.Size = new System.Drawing.Size(46, 19);
            this.lblSigla.TabIndex = 3;
            this.lblSigla.Text = "Sigla:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Depth = 0;
            this.lblDescricao.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDescricao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDescricao.Location = new System.Drawing.Point(21, 29);
            this.lblDescricao.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(81, 19);
            this.lblDescricao.TabIndex = 2;
            this.lblDescricao.Text = "Descrição:";
            // 
            // listViewUnidade
            // 
            this.listViewUnidade.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.desc,
            this.sigla});
            this.listViewUnidade.FullRowSelect = true;
            this.listViewUnidade.GridLines = true;
            this.listViewUnidade.HideSelection = false;
            this.listViewUnidade.Location = new System.Drawing.Point(16, 19);
            this.listViewUnidade.Name = "listViewUnidade";
            this.listViewUnidade.Size = new System.Drawing.Size(260, 310);
            this.listViewUnidade.TabIndex = 10;
            this.listViewUnidade.UseCompatibleStateImageBehavior = false;
            this.listViewUnidade.View = System.Windows.Forms.View.Details;
            this.listViewUnidade.SelectedIndexChanged += new System.EventHandler(this.listViewUnidade_SelectedIndexChanged);
            // 
            // desc
            // 
            this.desc.Text = "Descrição";
            this.desc.Width = 170;
            // 
            // sigla
            // 
            this.sigla.Text = "Sigla";
            this.sigla.Width = 82;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExcluir);
            this.groupBox2.Controls.Add(this.listViewUnidade);
            this.groupBox2.Location = new System.Drawing.Point(312, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 440);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selecionar Unidade";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Depth = 0;
            this.btnExcluir.Location = new System.Drawing.Point(16, 339);
            this.btnExcluir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Primary = true;
            this.btnExcluir.Size = new System.Drawing.Size(91, 43);
            this.btnExcluir.TabIndex = 12;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // FrmCadUnidadeMedida
            // 
            this.ClientSize = new System.Drawing.Size(627, 527);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmCadUnidadeMedida";
            this.Text = "Unidade de Medida";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSigla;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDescricao;
        private MaterialSkin.Controls.MaterialRaisedButton btnCancelar;
        private MaterialSkin.Controls.MaterialRaisedButton btnSalvar;
        private MaterialSkin.Controls.MaterialLabel lblSigla;
        private MaterialSkin.Controls.MaterialLabel lblDescricao;
        private System.Windows.Forms.ListView listViewUnidade;
        private System.Windows.Forms.ColumnHeader desc;
        private System.Windows.Forms.ColumnHeader sigla;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialRaisedButton btnExcluir;
        private MaterialSkin.Controls.MaterialLabel lblId;
    }
}