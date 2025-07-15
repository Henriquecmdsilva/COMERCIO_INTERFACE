using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace appComercio
{
    public partial class frmTarefasProdutosServiço : Form
    {
        // Remova esta linha, pois o HttpClient agora é gerenciado pelo AuthManager.
        // private static readonly HttpClient client = new HttpClient(); 

        private int produtoIdAtual = -1;

        public frmTarefasProdutosServiço()
        {
            InitializeComponent();
            // Define a operação de adição como padrão ao iniciar o formulário.
            radioButton1.Checked = true;

            // Define um texto inicial para o TextBox de resultados
            txtResultadoEstoque.Text = "Aguardando operação de estoque...";
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string nomeProduto = txtProduto.Text.Trim();
            if (string.IsNullOrWhiteSpace(nomeProduto))
            {
                MessageBox.Show("Digite o nome do produto.");
                txtResultadoEstoque.Text = "Erro: Digite o nome do produto para buscar."; // Feedback no TextBox
                return;
            }

            // Limpa os campos de detalhes do produto antes de cada nova busca
            txtProdutoNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            dataGridView1.Rows.Clear();
            produtoIdAtual = -1; // Reseta o ID do produto para evitar operações em produto errado

            txtResultadoEstoque.Text = $"Buscando produto '{nomeProduto}'..."; // Feedback no TextBox

            // Obtém a instância do HttpClient gerenciada pelo AuthManager.
            HttpClient httpClient = AuthManager.GetHttpClient();
            if (httpClient == null)
            {
                string errorMessage = "Erro: Cliente HTTP não configurado. Por favor, faça login ou verifique a configuração da chave da API.";
                MessageBox.Show(errorMessage);
                txtResultadoEstoque.Text = errorMessage; // Feedback no TextBox
                return;
            }

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"CadastroProduto?search={nomeProduto}");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var produtos = JsonConvert.DeserializeObject<dynamic>(json);

                    bool produtoEncontrado = false;
                    foreach (var produto in produtos)
                    {
                        // Compara o TipoProduto da API com o nome buscado
                        if (produto.TipoProduto.ToString().Equals(nomeProduto, StringComparison.OrdinalIgnoreCase))
                        {
                            produtoIdAtual = (int)produto.id;
                            txtProdutoNome.Text = produto.TipoProduto.ToString();
                            txtPreco.Text = produto.Preco.ToString();
                            txtQuantidade.Text = produto.Quantidade.ToString();

                            // Adiciona as colunas ao DataGridView se ainda não existirem
                            if (dataGridView1.Columns.Count == 0)
                            {
                                dataGridView1.Columns.Add("TipoProduto", "Tipo de Produto");
                                dataGridView1.Columns.Add("Tamanho", "Tamanho");
                                dataGridView1.Columns.Add("Genero", "Gênero");
                                dataGridView1.Columns.Add("Cor", "Cor");
                                dataGridView1.Columns.Add("Preco", "Preço");
                                dataGridView1.Columns.Add("Quantidade", "Quantidade");
                            }

                            dataGridView1.Rows.Add(produto.TipoProduto.ToString(), produto.Tamanho.ToString(),
                                produto.Genero.ToString(), produto.Cor.ToString(),
                                produto.Preco.ToString(), produto.Quantidade.ToString());

                            produtoEncontrado = true;
                            txtResultadoEstoque.Text = $"Produto '{nomeProduto}' encontrado e carregado."; // Feedback no TextBox
                            break;
                        }
                    }

                    if (!produtoEncontrado)
                    {
                        MessageBox.Show("Produto não encontrado.");
                        txtResultadoEstoque.Text = "Produto não encontrado."; // Feedback no TextBox
                    }
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    string message = $"Erro ao buscar produto na API. Status: {response.StatusCode}. Detalhes: {errorContent}";
                    MessageBox.Show(message);
                    txtResultadoEstoque.Text = message; // Feedback no TextBox
                }
            }
            catch (Exception ex)
            {
                string message = $"Erro inesperado ao buscar produto: {ex.Message}";
                MessageBox.Show(message);
                txtResultadoEstoque.Text = message; // Feedback no TextBox
            }
        }

        private async void btnExecutar_Click(object sender, EventArgs e)
        {
            if (produtoIdAtual == -1)
            {
                MessageBox.Show("Busque um produto primeiro antes de tentar operar o estoque.");
                txtResultadoEstoque.Text = "Erro: Nenhum produto selecionado. Busque primeiro."; // Feedback no TextBox
                return;
            }

            if (!int.TryParse(txtQuantidade.Text, out int valorOperacao))
            {
                MessageBox.Show("Informe uma quantidade válida para a operação.");
                txtResultadoEstoque.Text = "Erro: Informe uma quantidade numérica válida."; // Feedback no TextBox
                return;
            }

            string operacao = ObterOperacaoSelecionada();
            if (operacao == null)
            {
                MessageBox.Show("Selecione uma operação (adição, subtração, etc.).");
                txtResultadoEstoque.Text = "Erro: Selecione uma operação (+, -, *, /)."; // Feedback no TextBox
                return;
            }

            txtResultadoEstoque.Text = $"Executando operação '{operacao}' com valor '{valorOperacao}'..."; // Feedback no TextBox

            // Obtém a instância do HttpClient gerenciada pelo AuthManager.
            HttpClient httpClient = AuthManager.GetHttpClient();
            if (httpClient == null)
            {
                string errorMessage = "Erro: Cliente HTTP não configurado. Por favor, faça login ou verifique a configuração da chave da API.";
                MessageBox.Show(errorMessage);
                txtResultadoEstoque.Text = errorMessage; // Feedback no TextBox
                return;
            }

            var conteudo = new
            {
                operacao = operacao,
                valor = valorOperacao
            };

            var json = JsonConvert.SerializeObject(conteudo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PutAsync($"AtualizarEstoque/{produtoIdAtual}", content);

                if (response.IsSuccessStatusCode)
                {
                    string resultado = await response.Content.ReadAsStringAsync();
                    var jsonObj = JObject.Parse(resultado);

                    // Exibe o resultado no TextBox
                    txtResultadoEstoque.Text = $"Estoque atualizado: Nova quantidade = {jsonObj["nova_quantidade"]}";

                    txtQuantidade.Text = jsonObj["nova_quantidade"].ToString(); // Atualiza o campo de quantidade na tela
                }
                else
                {
                    string erro = await response.Content.ReadAsStringAsync();
                    string message = $"Erro ao atualizar estoque: {erro}";
                    MessageBox.Show(message); // Mantém o pop-up para erros de atualização
                    txtResultadoEstoque.Text = message; // Feedback no TextBox
                }
            }
            catch (Exception ex)
            {
                string message = $"Erro inesperado ao executar operação: {ex.Message}";
                MessageBox.Show(message);
                txtResultadoEstoque.Text = message; // Feedback no TextBox
            }
        }

        private string ObterOperacaoSelecionada()
        {
            if (radioButton1.Checked) return "+";
            if (radioButton2.Checked) return "-";
            if (radioButton3.Checked) return "*";
            if (radioButton4.Checked) return "/";
            return null;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new frmProdutoServiço().Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            new frmCadatroProdutoServiços().Show();
            this.Hide();
        }

        // --- Métodos vazios para eventos do designer que não têm lógica específica ---
        private void radioButton4_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton3_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void groupBox3_Enter(object sender, EventArgs e) { } // Este groupBox3 agora deve conter o txtResultadoEstoque
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void txtProduto_TextChanged(object sender, EventArgs e) { }
        private void txtPreco_TextChanged(object sender, EventArgs e) { }
        private void txtQuantidade_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}