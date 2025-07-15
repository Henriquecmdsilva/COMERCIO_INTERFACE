using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace appComercio
{
    public partial class frmDadosProdutoServiço : Form
    {
<<<<<<< Updated upstream:frmDadosProdutoServiço.cs
        public frmDadosProdutoServiço()
=======
        private Dictionary<int, Produto> linhasModificadas = new Dictionary<int, Produto>();

        public frmDadosProdutosServiço()
>>>>>>> Stashed changes:frmDadosProdutosServiço.cs
        {
            InitializeComponent();

            if (dataGridView1 != null)
            {
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
            }
        }
<<<<<<< Updated upstream:frmDadosProdutoServiço.cs
=======

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Produto produtoModificado = (Produto)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                if (produtoModificado != null && produtoModificado.Id != 0)
                {
                    if (linhasModificadas.ContainsKey(produtoModificado.Id))
                    {
                        linhasModificadas[produtoModificado.Id] = produtoModificado;
                    }
                    else
                    {
                        linhasModificadas.Add(produtoModificado.Id, produtoModificado);
                    }
                }
            }
        }

        private async void frmDadosProdutosServiço_Load(object sender, EventArgs e)
        {
            if (!AuthManager.IsAuthenticated)
            {
                MessageBox.Show("Sessão expirada ou não autenticada. Por favor, faça login novamente.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
                return;
            }

            await CarregarProdutosNoDataGridView();
            dataGridView1.ReadOnly = true;
            dataGridView1.DefaultCellStyle.BackColor = SystemColors.Window;
        }

        private async Task CarregarProdutosNoDataGridView()
        {
            if (!AuthManager.IsAuthenticated)
            {
                MessageBox.Show("Sessão expirada ou não autenticada. Por favor, faça login novamente.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
                return;
            }

            HttpClient client = AuthManager.GetHttpClient();
            if (client == null)
            {
                MessageBox.Show("Erro interno: Cliente HTTP não disponível. Por favor, faça login novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
                return;
            }

            try
            {
                string urlListarProdutos = "CadastroProduto";
                HttpResponseMessage response = await client.GetAsync(urlListarProdutos);
                string erroContent = string.Empty;

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<Produto> produtos = JsonConvert.DeserializeObject<List<Produto>>(jsonResponse);

                    if (dataGridView1 != null)
                    {
                        dataGridView1.DataSource = produtos;

                        if (dataGridView1.Columns.Contains("Id"))
                        {
                            dataGridView1.Columns["Id"].Visible = false;
                        }
                        if (dataGridView1.Columns.Contains("TipoProduto"))
                        {
                            dataGridView1.Columns["TipoProduto"].HeaderText = "Tipo";
                        }
                        if (dataGridView1.Columns.Contains("Tamanho"))
                        {
                            dataGridView1.Columns["Tamanho"].HeaderText = "Tam.";
                            dataGridView1.Columns["Tamanho"].Width = 60;
                        }
                        if (dataGridView1.Columns.Contains("Genero"))
                        {
                            dataGridView1.Columns["Genero"].HeaderText = "Gênero";
                        }
                        if (dataGridView1.Columns.Contains("Cor"))
                        {
                            dataGridView1.Columns["Cor"].HeaderText = "Cor";
                        }
                        if (dataGridView1.Columns.Contains("Preco"))
                        {
                            dataGridView1.Columns["Preco"].HeaderText = "Preço Unitário";
                            dataGridView1.Columns["Preco"].DefaultCellStyle.Format = "C";
                            dataGridView1.Columns["Preco"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("pt-BR");
                        }
                        if (dataGridView1.Columns.Contains("Quantidade"))
                        {
                            dataGridView1.Columns["Quantidade"].HeaderText = "Estoque";
                            dataGridView1.Columns["Quantidade"].Width = 80;
                        }

                        dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        linhasModificadas.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Erro interno: O controle 'dataGridView1' não foi encontrado no formulário. Verifique o nome do DataGridView no designer do formulário.", "Erro de Configuração", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    erroContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Falha ao carregar produtos. Status da API: {response.StatusCode}.\nDetalhes: {erroContent}", "Erro da API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException httpEx)
            {
                string fullUrl = client.BaseAddress != null ? client.BaseAddress.AbsoluteUri + "CadastroProduto" : "http://127.0.0.1:5000/CadastroProduto";
                MessageBox.Show($"Não foi possível conectar à API: {httpEx.Message}\nVerifique se o servidor Flask está rodando e se a URL '{fullUrl}' está correta.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonSerializationException jsonEx)
            {
                MessageBox.Show($"Erro ao processar os dados da API: {jsonEx.Message}\nVerifique se a classe 'Produto' no C# corresponde à estrutura JSON da API.", "Erro de Formato de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarProdutorServiços_Click(object sender, EventArgs e)
        {
            if (!AuthManager.IsAuthenticated)
            {
                MessageBox.Show("Sessão expirada ou não autenticada. Por favor, faça login novamente.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
                return;
            }

            dataGridView1.ReadOnly = false;
            dataGridView1.DefaultCellStyle.BackColor = Color.LightYellow;
            MessageBox.Show("Modo de edição ativado. Você pode agora editar os dados diretamente na tabela. Clique em 'Salvar' para confirmar as alterações.", "Modo de Edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnSalvarProdutoServiço_Click(object sender, EventArgs e)
        {
            if (!AuthManager.IsAuthenticated)
            {
                MessageBox.Show("Sessão expirada ou não autenticada. Por favor, faça login novamente.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
                return;
            }

            if (linhasModificadas.Count == 0)
            {
                MessageBox.Show("Nenhuma alteração detectada para salvar.", "Nenhuma Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.ReadOnly = true;
                dataGridView1.DefaultCellStyle.BackColor = SystemColors.Window;
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                $"Você tem {linhasModificadas.Count} produto(s) modificado(s) para salvar. Deseja continuar?",
                "Confirmar Salvar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                HttpClient client = AuthManager.GetHttpClient();
                if (client == null)
                {
                    MessageBox.Show("Erro interno: Cliente HTTP não disponível. Por favor, faça login novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmLogin loginForm = new frmLogin();
                    loginForm.Show();
                    this.Hide();
                    return;
                }

                int sucessoCount = 0;
                int falhaCount = 0;

                foreach (var entry in linhasModificadas)
                {
                    Produto produtoParaSalvar = entry.Value;
                    string urlApiAtualizarProduto = $"CadastroProduto/{produtoParaSalvar.Id}";

                    try
                    {
                        string jsonContent = JsonConvert.SerializeObject(produtoParaSalvar);
                        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PutAsync(urlApiAtualizarProduto, httpContent);

                        if (response.IsSuccessStatusCode)
                        {
                            sucessoCount++;
                        }
                        else
                        {
                            falhaCount++;
                            string erroDetalhe = await response.Content.ReadAsStringAsync();
                            Console.WriteLine($"Falha ao salvar produto ID {produtoParaSalvar.Id}. Status: {response.StatusCode}. Detalhes: {erroDetalhe}");
                        }
                    }
                    catch (HttpRequestException httpEx)
                    {
                        falhaCount++;
                        string fullUrl = client.BaseAddress != null ? client.BaseAddress.AbsoluteUri + urlApiAtualizarProduto : "http://127.0.0.1:5000/" + urlApiAtualizarProduto;
                        Console.WriteLine($"Erro de conexão ao salvar produto ID {produtoParaSalvar.Id} na URL '{fullUrl}': {httpEx.Message}");
                    }
                    catch (Exception ex)
                    {
                        falhaCount++;
                        Console.WriteLine($"Erro inesperado ao salvar produto ID {produtoParaSalvar.Id}: {ex.Message}");
                    }
                }

                if (sucessoCount > 0)
                {
                    MessageBox.Show($"{sucessoCount} produto(s) salvo(s) com sucesso!\n{falhaCount} falha(s).", "Salvar Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Nenhum produto foi salvo. {falhaCount} falha(s) ocorreram.", "Salvar Concluído", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                await CarregarProdutosNoDataGridView();
                dataGridView1.ReadOnly = true;
                dataGridView1.DefaultCellStyle.BackColor = SystemColors.Window;
                linhasModificadas.Clear();
            }
            else
            {
                MessageBox.Show("Operação de salvar cancelada.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label1_Click(object sender, EventArgs e) // Provavelmente o botão/label "Voltar"
        {
            // REMOVIDO: AuthManager.ClearApiKey();
            frmProdutoServiço produtoServicoForm = new frmProdutoServiço();
            produtoServicoForm.Show();
            this.Hide();
        }

        private void gbDadosProdutoServiço_Enter(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void btnBuscar_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { } // Este método provavelmente está duplicado, verifique no designer.
        private void gbTelaCadastroProdutoServiço_Enter(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void gbDadosProdutoServiço_Enter_1(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Este evento é disparado quando o conteúdo de uma célula do DataGridView é clicado.
        }

        private async void button2_Click_1(object sender, EventArgs e) // IMPLEMENTAÇÃO DO BOTÃO APAGAR
        {
            if (!AuthManager.IsAuthenticated)
            {
                MessageBox.Show("Sessão expirada ou não autenticada. Por favor, faça login novamente.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um produto para apagar.", "Nenhum Produto Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            Produto produtoParaApagar = selectedRow.DataBoundItem as Produto;

            if (produtoParaApagar == null || produtoParaApagar.Id == 0)
            {
                MessageBox.Show("Não foi possível identificar o produto selecionado para exclusão.", "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                $"Você realmente deseja apagar o produto '{produtoParaApagar.TipoProduto}' (ID: {produtoParaApagar.Id})?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult == DialogResult.Yes)
            {
                HttpClient client = AuthManager.GetHttpClient();
                if (client == null)
                {
                    MessageBox.Show("Erro interno: Cliente HTTP não disponível. Por favor, faça login novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmLogin loginForm = new frmLogin();
                    loginForm.Show();
                    this.Hide();
                    return;
                }

                string urlApiDeletarProduto = $"CadastroProduto/{produtoParaApagar.Id}";

                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(urlApiDeletarProduto);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Produto '{produtoParaApagar.TipoProduto}' (ID: {produtoParaApagar.Id}) apagado com sucesso!", "Sucesso na Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CarregarProdutosNoDataGridView();
                    }
                    else
                    {
                        string erroDetalhe = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Falha ao apagar produto '{produtoParaApagar.TipoProduto}'. Status da API: {response.StatusCode}.\nDetalhes: {erroDetalhe}", "Erro na Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    string fullUrl = client.BaseAddress != null ? client.BaseAddress.AbsoluteUri + urlApiDeletarProduto : "http://127.0.0.1:5000/" + urlApiDeletarProduto;
                    MessageBox.Show($"Não foi possível conectar à API para apagar: {httpEx.Message}\nVerifique se o servidor Flask está rodando e se a URL '{fullUrl}' está correta.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro inesperado ao apagar o produto: {ex.Message}", "Erro Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Operação de exclusão cancelada.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
>>>>>>> Stashed changes:frmDadosProdutosServiço.cs
    }
}
