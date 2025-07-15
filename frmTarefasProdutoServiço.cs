using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Não é necessário System.Net.Http ou System.Net.Http.Headers aqui,
// pois este formulário não faz chamadas diretas à API.

namespace appComercio
{
    public partial class frmTarefasProdutoServiço : Form
    {
        public frmTarefasProdutoServiço()
        {
            InitializeComponent();
        }
<<<<<<< Updated upstream:frmTarefasProdutoServiço.cs
=======

        private void ProdutoServiço_Load(object sender, EventArgs e)
        {
            // Opcional: Se você quiser que este formulário só apareça se estiver autenticado
            // if (!AuthManager.IsAuthenticated)
            // {
            //     MessageBox.Show("Sessão expirada ou não autenticada. Por favor, faça login novamente.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //     frmLogin loginForm = new frmLogin();
            //     loginForm.Show();
            //     this.Hide();
            //     return;
            // }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Evento de pintura do layout panel (geralmente não precisa de código)
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            // --- VERIFICAÇÃO DE AUTENTICAÇÃO ANTES DE ABRIR O FORMULÁRIO ---
            if (!AuthManager.IsAuthenticated)
            {
                MessageBox.Show("Sessão expirada ou não autenticada. Por favor, faça login novamente.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
                return; // Interrompe a abertura do formulário
            }
            // --- FIM DA VERIFICAÇÃO ---

            frmCadatroProdutoServiços produtoServicoForm = new frmCadatroProdutoServiços();
            produtoServicoForm.Show();
            this.Hide();
        }

        private void bntDados_Click(object sender, EventArgs e)
        {
            // --- VERIFICAÇÃO DE AUTENTICAÇÃO ANTES DE ABRIR O FORMULÁRIO ---
            if (!AuthManager.IsAuthenticated)
            {
                MessageBox.Show("Sessão expirada ou não autenticada. Por favor, faça login novamente.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
                return; // Interrompe a abertura do formulário
            }
            // --- FIM DA VERIFICAÇÃO ---

            frmDadosProdutosServiço produtoServicoForm = new frmDadosProdutosServiço();
            produtoServicoForm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e) // Provavelmente o botão/label "Sair" ou "Voltar ao Login"
        {
            // Ao invés de limpar a chave de API aqui, simplesmente volta para o formulário de login.
            // O logout explícito (AuthManager.ClearApiKey()) agora é feito APENAS no botão "Sair" do frmLogin.
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }

        private void btnTarefas_Click(object sender, EventArgs e)
        {
            // --- VERIFICAÇÃO DE AUTENTICAÇÃO ANTES DE ABRIR O FORMULÁRIO ---
            if (!AuthManager.IsAuthenticated)
            {
                MessageBox.Show("Sessão expirada ou não autenticada. Por favor, faça login novamente.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
                return; // Interrompe a abertura do formulário
            }
            // --- FIM DA VERIFICAÇÃO ---

            // **CÓDIGO CORRIGIDO:** Instancia e exibe o formulário 'frmTarefasProdutosServiço' APENAS UMA VEZ
            frmTarefasProdutosServiço tarefasProdutosServicoForm = new frmTarefasProdutosServiço();
            tarefasProdutosServicoForm.Show();
            this.Hide();
        }
>>>>>>> Stashed changes:frmProdutoServiço.cs
    }
}