namespace appComercio
{
    partial class Cadastro
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
            this.pbTelaLogin = new System.Windows.Forms.PictureBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btnCadastroUsuario = new System.Windows.Forms.Button();
            this.btnApagarUsuario = new System.Windows.Forms.Button();
            this.lblTituloLogin = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.cbSetor = new System.Windows.Forms.ComboBox();
            this.gbTelaCadastro = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtNomeCompleto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbkativo = new System.Windows.Forms.CheckBox();
            this.gbbuscausuario = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCadastrarUsuario = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTelaLogin)).BeginInit();
            this.gbTelaCadastro.SuspendLayout();
            this.gbbuscausuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTelaLogin
            // 
            this.pbTelaLogin.Location = new System.Drawing.Point(390, 83);
            this.pbTelaLogin.Name = "pbTelaLogin";
            this.pbTelaLogin.Size = new System.Drawing.Size(272, 222);
            this.pbTelaLogin.TabIndex = 1;
            this.pbTelaLogin.TabStop = false;
            this.pbTelaLogin.Click += new System.EventHandler(this.pbTelaLogin_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsuario.Location = new System.Drawing.Point(10, 165);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(324, 26);
            this.txtUsuario.TabIndex = 5;
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.SystemColors.Control;
            this.txtSenha.Location = new System.Drawing.Point(7, 216);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(324, 26);
            this.txtSenha.TabIndex = 6;
            // 
            // btnCadastroUsuario
            // 
            this.btnCadastroUsuario.BackColor = System.Drawing.Color.LimeGreen;
            this.btnCadastroUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastroUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCadastroUsuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastroUsuario.Location = new System.Drawing.Point(8, 478);
            this.btnCadastroUsuario.Name = "btnCadastroUsuario";
            this.btnCadastroUsuario.Size = new System.Drawing.Size(129, 45);
            this.btnCadastroUsuario.TabIndex = 8;
            this.btnCadastroUsuario.Text = "Usuários";
            this.btnCadastroUsuario.UseVisualStyleBackColor = false;
            this.btnCadastroUsuario.Click += new System.EventHandler(this.btnCadastroUsuario_Click);
            // 
            // btnApagarUsuario
            // 
            this.btnApagarUsuario.BackColor = System.Drawing.Color.LightCoral;
            this.btnApagarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApagarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApagarUsuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApagarUsuario.Location = new System.Drawing.Point(580, 478);
            this.btnApagarUsuario.Name = "btnApagarUsuario";
            this.btnApagarUsuario.Size = new System.Drawing.Size(124, 45);
            this.btnApagarUsuario.TabIndex = 9;
            this.btnApagarUsuario.Text = "Apagar  ";
            this.btnApagarUsuario.UseVisualStyleBackColor = false;
            this.btnApagarUsuario.Click += new System.EventHandler(this.btnApagarUsuario_Click);
            // 
            // lblTituloLogin
            // 
            this.lblTituloLogin.AutoSize = true;
            this.lblTituloLogin.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloLogin.Location = new System.Drawing.Point(217, 9);
            this.lblTituloLogin.Name = "lblTituloLogin";
            this.lblTituloLogin.Size = new System.Drawing.Size(264, 29);
            this.lblTituloLogin.TabIndex = 10;
            this.lblTituloLogin.Text = "Sistemas De Cadastro";
            this.lblTituloLogin.Click += new System.EventHandler(this.lblTituloLogin_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(11, 143);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(75, 19);
            this.lblUsuario.TabIndex = 13;
            this.lblUsuario.Text = "Usuário:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Senha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Setor:";
            // 
            // cbSetor
            // 
            this.cbSetor.BackColor = System.Drawing.SystemColors.Control;
            this.cbSetor.FormattingEnabled = true;
            this.cbSetor.Items.AddRange(new object[] {
            "",
            "Administrativo",
            "Estoque",
            "Financeiro",
            "Secretariado",
            "Vendas"});
            this.cbSetor.Location = new System.Drawing.Point(5, 272);
            this.cbSetor.Name = "cbSetor";
            this.cbSetor.Size = new System.Drawing.Size(325, 26);
            this.cbSetor.TabIndex = 16;
            // 
            // gbTelaCadastro
            // 
            this.gbTelaCadastro.Controls.Add(this.label5);
            this.gbTelaCadastro.Controls.Add(this.txtMatricula);
            this.gbTelaCadastro.Controls.Add(this.txtNomeCompleto);
            this.gbTelaCadastro.Controls.Add(this.label4);
            this.gbTelaCadastro.Controls.Add(this.cbkativo);
            this.gbTelaCadastro.Controls.Add(this.txtSenha);
            this.gbTelaCadastro.Controls.Add(this.label2);
            this.gbTelaCadastro.Controls.Add(this.cbSetor);
            this.gbTelaCadastro.Controls.Add(this.lblUsuario);
            this.gbTelaCadastro.Controls.Add(this.txtUsuario);
            this.gbTelaCadastro.Controls.Add(this.label1);
            this.gbTelaCadastro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTelaCadastro.Location = new System.Drawing.Point(1, 41);
            this.gbTelaCadastro.Name = "gbTelaCadastro";
            this.gbTelaCadastro.Size = new System.Drawing.Size(344, 333);
            this.gbTelaCadastro.TabIndex = 17;
            this.gbTelaCadastro.TabStop = false;
            this.gbTelaCadastro.Text = "Dados do Cadastro";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 19);
            this.label5.TabIndex = 22;
            this.label5.Text = "Matrícula:";
            // 
            // txtMatricula
            // 
            this.txtMatricula.BackColor = System.Drawing.SystemColors.Control;
            this.txtMatricula.Location = new System.Drawing.Point(11, 104);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(324, 26);
            this.txtMatricula.TabIndex = 21;
            // 
            // txtNomeCompleto
            // 
            this.txtNomeCompleto.BackColor = System.Drawing.SystemColors.Control;
            this.txtNomeCompleto.Location = new System.Drawing.Point(10, 44);
            this.txtNomeCompleto.Name = "txtNomeCompleto";
            this.txtNomeCompleto.Size = new System.Drawing.Size(324, 26);
            this.txtNomeCompleto.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "Nome completo:";
            // 
            // cbkativo
            // 
            this.cbkativo.AutoSize = true;
            this.cbkativo.Location = new System.Drawing.Point(5, 304);
            this.cbkativo.Name = "cbkativo";
            this.cbkativo.Size = new System.Drawing.Size(15, 14);
            this.cbkativo.TabIndex = 18;
            this.cbkativo.UseVisualStyleBackColor = true;
            this.cbkativo.CheckedChanged += new System.EventHandler(this.cbkativo_CheckedChanged);
            // 
            // gbbuscausuario
            // 
            this.gbbuscausuario.Controls.Add(this.btnBuscar);
            this.gbbuscausuario.Controls.Add(this.textBox1);
            this.gbbuscausuario.Location = new System.Drawing.Point(1, 380);
            this.gbbuscausuario.Name = "gbbuscausuario";
            this.gbbuscausuario.Size = new System.Drawing.Size(344, 81);
            this.gbbuscausuario.TabIndex = 18;
            this.gbbuscausuario.TabStop = false;
            this.gbbuscausuario.Text = "Busca usuario";
            this.gbbuscausuario.Enter += new System.EventHandler(this.gbbuscausuario_Enter);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(221, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 34);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar       ";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(7, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(351, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(353, 408);
            this.dataGridView1.TabIndex = 22;
            
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);

            // 
            // btnCadastrarUsuario
            // 
            this.btnCadastrarUsuario.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCadastrarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastrarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCadastrarUsuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarUsuario.Location = new System.Drawing.Point(193, 478);
            this.btnCadastrarUsuario.Name = "btnCadastrarUsuario";
            this.btnCadastrarUsuario.Size = new System.Drawing.Size(129, 45);
            this.btnCadastrarUsuario.TabIndex = 23;
            this.btnCadastrarUsuario.Text = "Cadastrar    ";
            this.btnCadastrarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCadastrarUsuario.UseVisualStyleBackColor = false;
            this.btnCadastrarUsuario.Click += new System.EventHandler(this.btnCadastrarUsuario_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.CadetBlue;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(390, 478);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(129, 45);
            this.btnEditar.TabIndex = 24;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.BtnEditar);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(689, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "X";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(716, 535);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCadastrarUsuario);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gbbuscausuario);
            this.Controls.Add(this.gbTelaCadastro);
            this.Controls.Add(this.lblTituloLogin);
            this.Controls.Add(this.btnApagarUsuario);
            this.Controls.Add(this.btnCadastroUsuario);
            this.Controls.Add(this.pbTelaLogin);
            this.Name = "Cadastro";
            this.Text = "Cadastro";
            this.Load += new System.EventHandler(this.Cadastro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTelaLogin)).EndInit();
            this.gbTelaCadastro.ResumeLayout(false);
            this.gbTelaCadastro.PerformLayout();
            this.gbbuscausuario.ResumeLayout(false);
            this.gbbuscausuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTelaLogin;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnCadastroUsuario;
        private System.Windows.Forms.Button btnApagarUsuario;
        private System.Windows.Forms.Label lblTituloLogin;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ComboBox cbSetor;
        private System.Windows.Forms.GroupBox gbTelaCadastro;
        private System.Windows.Forms.CheckBox cbkativo;
        private System.Windows.Forms.GroupBox gbbuscausuario;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCadastrarUsuario;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtNomeCompleto;
        private System.Windows.Forms.Label label4;
    }
}