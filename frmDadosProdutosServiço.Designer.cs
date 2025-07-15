using System;

namespace appComercio
{
    partial class frmDadosProdutosServiço
    {
        // Variável necessária para o designer.
        private System.ComponentModel.IContainer components = null;

        // Limpa todos os recursos que estão sendo usados.
        // <param name="disposing">true se os recursos gerenciados devem ser descartados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // Método exigido para suporte ao designer - não modifique
        // o conteúdo deste método com o editor de código.
        private void InitializeComponent()
        {
            this.gbDadosPodutoServiço = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSalvarProdutoServiço = new System.Windows.Forms.Button();
            this.btnEditarProdutorServiços = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.gbDadosPodutoServiço.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            //
            // gbDadosPodutoServiço
            //
            // Configurações e controles do GroupBox para busca de produtos/serviços.
            this.gbDadosPodutoServiço.Controls.Add(this.btnBuscar);
            this.gbDadosPodutoServiço.Controls.Add(this.textBox1);
            this.gbDadosPodutoServiço.Location = new System.Drawing.Point(12, 474);
            this.gbDadosPodutoServiço.Name = "gbDadosPodutoServiço";
            this.gbDadosPodutoServiço.Size = new System.Drawing.Size(338, 68);
            this.gbDadosPodutoServiço.TabIndex = 20;
            this.gbDadosPodutoServiço.TabStop = false;
            this.gbDadosPodutoServiço.Text = "Busca Dados Produto/Serviço";
            this.gbDadosPodutoServiço.Enter += new System.EventHandler(this.gbDadosProdutoServiço_Enter);
            //
            // btnBuscar
            //
            // Botão para iniciar a busca de produtos/serviços.
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(221, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 34);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar        ";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            //
            // textBox1
            //
            // Campo de texto para entrada do termo de busca.
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(6, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 20);
            this.textBox1.TabIndex = 7;
            //
            // button2
            //
            // Botão para apagar ou excluir dados.
            this.button2.BackColor = System.Drawing.Color.LightCoral;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(624, 494);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 45);
            this.button2.TabIndex = 23;
            this.button2.Text = "Apagar    ";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            //
            // btnSalvarProdutoServiço
            //
            // Botão para salvar dados de produtos/serviços.
            this.btnSalvarProdutoServiço.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSalvarProdutoServiço.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvarProdutoServiço.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalvarProdutoServiço.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarProdutoServiço.Location = new System.Drawing.Point(360, 494);
            this.btnSalvarProdutoServiço.Name = "btnSalvarProdutoServiço";
            this.btnSalvarProdutoServiço.Size = new System.Drawing.Size(105, 45);
            this.btnSalvarProdutoServiço.TabIndex = 24;
            this.btnSalvarProdutoServiço.Text = "Salvar     ";
            this.btnSalvarProdutoServiço.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvarProdutoServiço.UseVisualStyleBackColor = false;
            this.btnSalvarProdutoServiço.Click += new System.EventHandler(this.btnSalvarProdutoServiço_Click);
            //
            // btnEditarProdutorServiços
            //
            // Botão para editar dados de produtos/serviços existentes.
            this.btnEditarProdutorServiços.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEditarProdutorServiços.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarProdutorServiços.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditarProdutorServiços.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarProdutorServiços.Location = new System.Drawing.Point(500, 494);
            this.btnEditarProdutorServiços.Name = "btnEditarProdutorServiços";
            this.btnEditarProdutorServiços.Size = new System.Drawing.Size(100, 45);
            this.btnEditarProdutorServiços.TabIndex = 26;
            this.btnEditarProdutorServiços.Text = "Editar     ";
            this.btnEditarProdutorServiços.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarProdutorServiços.UseVisualStyleBackColor = false;
            this.btnEditarProdutorServiços.Click += new System.EventHandler(this.btnEditarProdutorServiços_Click);
            //
            // label1
            //
            // Botão ou label para fechar a janela (representado por 'X').
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(698, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            //
            // dataGridView1
            //
            // DataGridView para exibir os dados de produtos/serviços.
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(719, 425);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            //
            // label2
            //
            // Título da seção de dados gerais.
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(312, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 24);
            this.label2.TabIndex = 30;
            this.label2.Text = "Dados gerais";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // frmDadosProdutosServiço
            //
            // Configurações gerais do formulário DadosProdutosServiço.
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(743, 554);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditarProdutorServiços);
            this.Controls.Add(this.btnSalvarProdutoServiço);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gbDadosPodutoServiço);
            this.Name = "frmDadosProdutosServiço";
            this.Text = "DadosProdutosServiço";
            this.Load += new System.EventHandler(this.frmDadosProdutosServiço_Load);
            this.gbDadosPodutoServiço.ResumeLayout(false);
            this.gbDadosPodutoServiço.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        // Declaração dos componentes do formulário.
        private System.Windows.Forms.GroupBox gbDadosPodutoServiço;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSalvarProdutoServiço;
        private System.Windows.Forms.Button btnEditarProdutorServiços;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
    }
}