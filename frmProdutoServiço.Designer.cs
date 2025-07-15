namespace appComercio
{
    partial class frmProdutoServiço
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
            this.lblTituloLogin = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.btnTarefas = new System.Windows.Forms.Button();
            this.bntDados = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloLogin
            // 
            this.lblTituloLogin.AutoSize = true;
            this.lblTituloLogin.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloLogin.Location = new System.Drawing.Point(256, 59);
            this.lblTituloLogin.Name = "lblTituloLogin";
            this.lblTituloLogin.Size = new System.Drawing.Size(225, 29);
            this.lblTituloLogin.TabIndex = 12;
            this.lblTituloLogin.Text = "Produtos/Serviços";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tableLayoutPanel1.Controls.Add(this.btnCadastro, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTarefas, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.bntDados, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(181, 158);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(414, 111);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // btnCadastro
            // 
            this.btnCadastro.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCadastro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCadastro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastro.Location = new System.Drawing.Point(3, 3);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(129, 97);
            this.btnCadastro.TabIndex = 9;
            this.btnCadastro.Text = "Cadastro      ";
            this.btnCadastro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCadastro.UseVisualStyleBackColor = false;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // btnTarefas
            // 
            this.btnTarefas.BackColor = System.Drawing.Color.SteelBlue;
            this.btnTarefas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTarefas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTarefas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarefas.Location = new System.Drawing.Point(280, 3);
            this.btnTarefas.Name = "btnTarefas";
            this.btnTarefas.Size = new System.Drawing.Size(134, 94);
            this.btnTarefas.TabIndex = 11;
            this.btnTarefas.Text = "Tarefas       ";
            this.btnTarefas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTarefas.UseVisualStyleBackColor = false;
            this.btnTarefas.Click += new System.EventHandler(this.btnTarefas_Click);
            // 
            // bntDados
            // 
            this.bntDados.BackColor = System.Drawing.Color.SteelBlue;
            this.bntDados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntDados.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntDados.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntDados.Location = new System.Drawing.Point(138, 3);
            this.bntDados.Name = "bntDados";
            this.bntDados.Size = new System.Drawing.Size(136, 97);
            this.bntDados.TabIndex = 10;
            this.bntDados.Text = "Dados       ";
            this.bntDados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntDados.UseVisualStyleBackColor = false;
            this.bntDados.Click += new System.EventHandler(this.bntDados_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(774, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmProdutoServiço
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblTituloLogin);
            this.Name = "frmProdutoServiço";
            this.Text = "ProdutoServiço";
            this.Load += new System.EventHandler(this.ProdutoServiço_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloLogin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Button bntDados;
        private System.Windows.Forms.Button btnTarefas;
        private System.Windows.Forms.Label label1;
    }
}