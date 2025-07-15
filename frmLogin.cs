using System;
<<<<<<< Updated upstream
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
=======
using System.Net.Http;
>>>>>>> Stashed changes
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace appComercio
{
    public partial class frmLogin : Form
    {
        private TextBox txtUsuario;
        private TextBox txtSenha;

        public frmLogin()
        {
            InitializeComponent();
            txtUsuario = new TextBox
            {
                Location = new Point(100, 50),
                Size = new Size(200, 20)
            };
            txtSenha = new TextBox
            {
                Location = new Point(100, 80),
                Size = new Size(200, 20),
                PasswordChar = '*'
            };
            this.Controls.Add(txtUsuario);
            this.Controls.Add(txtSenha);

            comboBox1.Items.AddRange(new string[] { "Administrativo", "Financeiro", "Vendas", "TI" });
            comboBox1.SelectedIndex = 0;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCadastroUsuario frm = new frmCadastroUsuario();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

<<<<<<< Updated upstream
        private void btnSair(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool ValidarLogin(string nome, string senha, string setor)
        {
            string caminhoArquivo = "usuarios.txt"; // mesmo caminho usado no cadastro
            if (!File.Exists(caminhoArquivo))
                return false;

            var linhas = File.ReadAllLines(caminhoArquivo);
            foreach (var linha in linhas)
            {
                var partes = linha.Split(';');
                if (partes.Length == 3 &&
                    partes[0] == nome &&
                    partes[1] == senha &&
                    partes[2] == setor)
                {
                    return true;
                }
=======
            using (Cadastro cadastro = new Cadastro()) // Abre formulário Cadastro modal
            {
                cadastro.ShowDialog();
>>>>>>> Stashed changes
            }
            return false;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string senha = txtSenha.Text.Trim();
            string setor = comboBox1.Text.Trim();

            // Se o setor não for necessário, passe null para setor
            if (ValidarLogin(usuario, senha, setor))
            {
                frmProdutoServico frm = new frmProdutoServico();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário, senha ou setor inválidos!");
            }
        }

        private void button2_Click(object sender, EventArgs e) // Botão Sair (do aplicativo)
        {
            // --- LIMPAR CHAVE DE API AO SAIR DO APLICATIVO ---
            AuthManager.ClearApiKey(); // Garante que a chave de API seja limpa explicitamente
            // --- FIM DA LIMPEZA ---
            Application.Exit(); // Encerra o aplicativo inteiro
        }

        // button1_Click é o botão de Entrar (Login)
        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Por favor, preencha os campos de usuário e senha.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dadosLogin = new
            {
                NomeUsuario = txtUsuario.Text.Trim(),
                SenhaUsuario = txtSenha.Text.Trim()
            };

            string json = JsonConvert.SerializeObject(dadosLogin);

            // Usa uma nova instância de HttpClient para o login, pois o AuthManager.HttpClient
            // só será configurado APÓS o login bem-sucedido.
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://127.0.0.1:5000/"); // URL base para o endpoint de login

                try
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("Login", content); // Endpoint de login

                    if (response.IsSuccessStatusCode)
                    {
                        var responseJson = await response.Content.ReadAsStringAsync();
                        dynamic result = JsonConvert.DeserializeObject(responseJson);

                        if (result.api_key != null)
                        {
                            // --- CHAVE AQUI: Define a chave de API no AuthManager ---
                            AuthManager.SetApiKey(result.api_key.ToString());

                            MessageBox.Show($"Login realizado com sucesso! Bem-vindo, {dadosLogin.NomeUsuario}!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                            // Abre o formulário principal após o login.
                            // Ele agora usará o HttpClient configurado via AuthManager.
                            frmProdutoServiço produtoForm = new frmProdutoServiço();
                            produtoForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Login bem-sucedido, mas a chave de API não foi recebida da API.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        string erro = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha no login: " + erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar com a API: " + ex.Message + "\nVerifique se o servidor Flask está rodando em http://127.0.0.1:5000/", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gbTelaLogin_Enter(object sender, EventArgs e)
        {

        }
    }
}

