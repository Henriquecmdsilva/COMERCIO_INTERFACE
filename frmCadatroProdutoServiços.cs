using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Collections.Generic; // Necessário para List<dynamic> e .Any()

namespace appComercio
{
    public partial class frmCadatroProdutoServiços : Form
    {
        private bool formatandoMoeda = false;
        private int? currentProductId = null; // Usado para saber se estamos editando um produto existente

        // Construtor padrão, usado para novo cadastro
        public frmCadatroProdutoServiços()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(new string[]
            {
                "CALÇA", "MEIA", "CAMISA", "BONÉ", "TOUCA", "CASACO", "TÊNIS", "SAPATO", "BERMUDA", "SHORT"
            });
            comboBox1.SelectedIndex = -1; // Nenhuma seleção inicial
            comboBox2.Enabled = false; // Começa desabilitado

            comboBox3.Items.AddRange(new string[]
            {
                "MASCULINO", "FEMININO", "AMBOS"
            });
            comboBox3.SelectedIndex = 0; // Padrão inicial

            comboBox4.Items.AddRange(new string[]
            {
                "PRETO", "BRANCO", "AZUL", "VERMELHO", "CINZA",
                "VERDE", "ROSA", "MARROM", "BEGE", "AMARELO"
            });
            comboBox4.SelectedIndex = 0; // Padrão inicial

            textBox2.KeyPress += textBox2_KeyPress; // Evento para validar entrada numérica para quantidade
            textBox3.TextChanged += textBox3_TextChanged; // Evento para formatar o preço como moeda

            // Garante que o texto inicial do botão é "Cadastrar" no modo de criação
            btnCadastrarProutosServiços.Text = "Cadastrar";
        }

        // Construtor sobrecarregado, usado para editar um produto existente
        public frmCadatroProdutoServiços(int productId) : this() // Chama o construtor padrão para inicializar componentes
        {
            currentProductId = productId; // Armazena o ID do produto a ser editado
            btnCadastrarProutosServiços.Text = "Salvar Alterações"; // Altera o texto do botão para "Salvar Alterações"
            _ = LoadProductForEdit(productId); // Chama o método para carregar os dados do produto. Usamos '_' para ignorar o await, pois o construtor não pode ser async diretamente.
        }

        /// <summary>
        /// Carrega os dados de um produto específico para edição.
        /// </summary>
        /// <param name="productId">O ID do produto a ser carregado.</param>
        public async Task LoadProductForEdit(int productId)
        {
            currentProductId = productId; // Confirma o ID do produto atual para edição
            btnCadastrarProutosServiços.Text = "Salvar Alterações"; // Define o texto do botão para "Salvar Alterações"

            try
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

                // Tenta obter o produto pelo ID. Assumimos que a API pode filtrar por 'search' com o ID.
                var response = await client.GetAsync($"CadastroProduto?search={productId}");

                // **CORREÇÃO PRINCIPAL AQUI:**
                // Em vez de response.EnsureSuccessStatusCode(), que lança HttpRequestException
                // quando o status não é de sucesso e pode não ter a propriedade Response
                // diretamente acessível dependendo da versão do .NET, verificamos o status.
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<dynamic> products = JsonConvert.DeserializeObject<List<dynamic>>(jsonResponse);

                    if (products != null && products.Any())
                    {
                        dynamic productToEdit = products.FirstOrDefault(p => p.id == productId);

                        if (productToEdit != null)
                        {
                            comboBox1.SelectedItem = productToEdit.TipoProduto.ToString();
                            comboBox1_SelectedIndexChanged(comboBox1, EventArgs.Empty);
                            comboBox2.SelectedItem = productToEdit.Tamanho.ToString();
                            comboBox3.SelectedItem = productToEdit.Genero.ToString();
                            comboBox4.SelectedItem = productToEdit.Cor.ToString();

                            if (decimal.TryParse(productToEdit.Preco.ToString(), out decimal precoCarregado))
                            {
                                textBox3.Text = precoCarregado.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
                            }
                            else
                            {
                                textBox3.Text = "R$ 0,00";
                            }
                            textBox2.Text = productToEdit.Quantidade.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Produto não encontrado com o ID especificado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LimparCampos();
                            currentProductId = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LimparCampos();
                        currentProductId = null;
                    }
                }
                else // Se o status code NÃO é de sucesso, trata o erro aqui
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Erro ao carregar produto (Status: {response.StatusCode}): {errorContent}", "Erro na API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimparCampos();
                    currentProductId = null;
                }
            }
            // Mantenha apenas o catch genérico para outras exceções de rede ou problemas inesperados
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produto para edição: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimparCampos();
                currentProductId = null;
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
                return;

            comboBox2.Items.Clear();
            comboBox2.Enabled = true;

            string itemSelecionado = comboBox1.SelectedItem.ToString().ToUpper();

            if (itemSelecionado == "TÊNIS" || itemSelecionado == "SAPATO")
            {
                comboBox2.Items.AddRange(new string[] { "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44" });
            }
            else
            {
                comboBox2.Items.AddRange(new string[] { "PP", "P", "M", "G", "GG", "XG", "ÚNICO" }); // Adicionado "ÚNICO"
            }

            comboBox2.SelectedIndex = 0; // Seleciona o primeiro item após carregar
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (formatandoMoeda) return;

            formatandoMoeda = true;

            string texto = textBox3.Text;
            string numeros = new string(texto.Where(char.IsDigit).ToArray());

            if (decimal.TryParse(numeros, out decimal valor))
            {
                valor /= 100;
                textBox3.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
                textBox3.SelectionStart = textBox3.Text.Length;
            }
            else
            {
                textBox3.Text = "R$ 0,00";
                textBox3.SelectionStart = textBox3.Text.Length;
            }

            formatandoMoeda = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void btnCadastrarProutosServiços_Click(object sender, EventArgs e)
        {
            if (!AuthManager.IsAuthenticated)
            {
                MessageBox.Show("Sessão expirada ou não autenticada. Por favor, faça login novamente.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
                return;
            }

            // Validações dos campos
            if (comboBox1.SelectedIndex < 0 || comboBox2.SelectedIndex < 0 ||
                comboBox3.SelectedIndex < 0 || comboBox4.SelectedIndex < 0)
            {
                MessageBox.Show("Todos os campos de seleção devem ser preenchidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string precoTexto = textBox3.Text.Replace("R$", "").Replace(" ", "").Replace(".", "").Replace(",", ".");
            if (!decimal.TryParse(precoTexto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal preco) || preco < 0)
            {
                MessageBox.Show("Preço inválido ou negativo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int quantidade = 0;
            if (!int.TryParse(textBox2.Text, out int parsedQuantidade) || parsedQuantidade < 0)
            {
                MessageBox.Show("Quantidade inválida ou negativa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            quantidade = parsedQuantidade; // Atribui a quantidade parseada


            var productData = new
            {
                TipoProduto = comboBox1.SelectedItem.ToString(),
                Tamanho = comboBox2.SelectedItem.ToString(),
                Genero = comboBox3.SelectedItem.ToString(),
                Cor = comboBox4.SelectedItem.ToString(),
                Preco = preco,
                Quantidade = quantidade
            };

            string json = JsonConvert.SerializeObject(productData);

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
                HttpResponseMessage response;
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                if (currentProductId.HasValue) // Se currentProductId tem um valor, estamos atualizando um produto (PUT)
                {
                    response = await client.PutAsync($"CadastroProduto/{currentProductId.Value}", content);
                }
                else // Caso contrário, estamos cadastrando um novo produto (POST)
                {
                    response = await client.PostAsync("CadastroProduto", content);
                }

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(currentProductId.HasValue ? "Produto atualizado com sucesso!" : "Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    currentProductId = null; // Reseta para o modo de cadastro após sucesso na edição
                    btnCadastrarProutosServiços.Text = "Cadastrar"; // Volta o texto do botão para "Cadastrar"
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Erro ao " + (currentProductId.HasValue ? "atualizar" : "cadastrar") + " produto: " + error, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na comunicação com a API: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            comboBox1.SelectedIndex = -1; // Limpa seleção
            comboBox2.Items.Clear();
            comboBox2.Enabled = false;
            comboBox3.SelectedIndex = 0; // Volta para o padrão
            comboBox4.SelectedIndex = 0; // Volta para o padrão
            textBox3.Text = "R$ 0,00"; // Preço padrão
            textBox2.Text = "0"; // Quantidade padrão
            currentProductId = null; // Garante que está em modo de cadastro novo
            btnCadastrarProutosServiços.Text = "Cadastrar"; // Volta o texto do botão
        }

        // --- Métodos vazios do seu código original (manter para compatibilidade) ---
        // Estes métodos podem ser usados para eventos no designer que você não deseja remover ou que não têm funcionalidade complexa.
        private void gbTelaCadastro_Enter(object sender, EventArgs e) { }
        private void pbTelaLogin_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void btnApagarCadastroProdutosServiços_Click(object sender, EventArgs e) { } // Este botão pode ser removido ou desabilitado no designer, já que a deleção será feita na tela de tarefas/serviços
        private void gbBuscaPodutoServiço_Enter(object sender, EventArgs e) { }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }


        private void label1_Click(object sender, EventArgs e) // Assumindo que este é o botão/label "Voltar" ou "Sair" que leva de volta à tela de Produtos/Serviços
        {
            frmProdutoServiço produtoServicoForm = new frmProdutoServiço(); // Verifique se este é o formulário correto para voltar
            produtoServicoForm.Show();
            this.Hide();
        }

        private void frmCadatroProdutoServiços_Load(object sender, EventArgs e)
        {
            // Verifica a autenticação ao carregar o formulário.
            if (!AuthManager.IsAuthenticated)
            {
                MessageBox.Show("Sessão expirada ou não autenticada. Por favor, faça login novamente.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
                return;
            }
            // Se o formulário foi aberto sem um ID (construtor padrão),
            // ele já estará no modo de cadastro.
            // Se foi aberto com um ID (construtor sobrecarregado),
            // LoadProductForEdit já foi chamado.
        }
    }
}