using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace appComercio
{
    public partial class Cadastro : Form
    {
        private Form parentForm;
        private string editingUserName = null;
        private bool isEditing = false;

        public Cadastro() : this(null) { }

        public Cadastro(Form parent)
        {
            InitializeComponent();
            InitializeDataGridView();
            this.parentForm = parent;
            PopulateSectorComboBox();

            // Adiciona o evento KeyPress para o campo de matrícula para permitir apenas 5 dígitos numéricos
            // Certifique-se de que o nome do controle TextBox para a matrícula no designer seja 'txtMatricula'
            txtMatricula.KeyPress += TxtMatricula_KeyPress;
        }

        // Evento KeyPress para txtMatricula
        private void TxtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas dígitos e a tecla Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora o caractere
            }

            // Limita o número de caracteres a 5
            if (char.IsDigit(e.KeyChar) && txtMatricula.Text.Length >= 5 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignora o caractere se já houver 5 dígitos
            }
        }

        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("IDCadastroUsuario", "ID");
            dataGridView1.Columns.Add("Username", "Usuário");
            dataGridView1.Columns.Add("NomeCompleto", "Nome Completo"); // Nova coluna
            dataGridView1.Columns.Add("Matricula", "Matrícula");       // Nova coluna
            dataGridView1.Columns.Add("Sector", "Setor");
            dataGridView1.Columns.Add("IsActive", "Ativo");
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void PopulateSectorComboBox()
        {
            if (cbSetor.Items.Count == 0 || !cbSetor.Items.Contains("Administrativo"))
            {
                cbSetor.Items.Clear();
                cbSetor.Items.AddRange(new object[] {
                    "Administrativo",
                    "Estoque",
                    "Financeiro",
                    "Secretariado",
                    "Vendas"
                });
            }
        }

        private void lblTituloLogin_Click(object sender, EventArgs e) { }
        private void pbTelaLogin_Click(object sender, EventArgs e) { }
        private void cbkativo_CheckedChanged(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void gbbuscausuario_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();
        }

        private async void button1_Click(object sender, EventArgs e) // btnBuscar
        {
            if (!AuthManager.IsAuthenticated)
            {
                MessageBox.Show("Sessão expirada ou não autenticada. Por favor, faça login novamente.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
                return;
            }

            dataGridView1.Rows.Clear();
            string termoBusca = textBox1.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(termoBusca))
            {
                MessageBox.Show("Por favor, digite um nome de usuário, nome completo, matrícula ou setor para buscar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
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
                // Inclui o termo de busca na URL para que a API possa filtrar
                var response = await client.GetAsync($"CadastroUsuario?search={Uri.EscapeDataString(termoBusca)}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var usuarios = JsonConvert.DeserializeObject<List<dynamic>>(json);

                    if (usuarios.Count == 0)
                    {
                        MessageBox.Show("Nenhum usuário encontrado com o critério especificado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    foreach (var user in usuarios)
                    {
                        dataGridView1.Rows.Add(
                            (int)user.IDCadastroUsuario,
                            (string)user.NomeUsuario,
                            (string)user.NomeCompleto, // Exibe Nome Completo
                            (string)user.Matricula,    // Exibe Matrícula
                            (string)user.SetorUsuario,
                            (bool)user.IsActive
                        );
                    }
                }
                else
                {
                    string erro = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Erro ao buscar usuários. Código: " + response.StatusCode + "\nDetalhes: " + erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de comunicação com a API: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnApagarUsuario_Click(object sender, EventArgs e)
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
                MessageBox.Show("Por favor, selecione um usuário para apagar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int userId = (int)selectedRow.Cells["IDCadastroUsuario"].Value;
            string usernameToDelete = selectedRow.Cells["Username"].Value.ToString();

            DialogResult choiceResult = MessageBox.Show(
                $"Deseja apagar o usuário '{usernameToDelete}' (ID: {userId}) pelo NOME ou pelo ID?\n\n" +
                "Clique 'Sim' para apagar pelo Nome.\n" +
                "Clique 'Não' para apagar pelo ID.",
                "Escolha de Exclusão",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            if (choiceResult == DialogResult.Cancel)
            {
                return;
            }

            string apiUrlRelative = "";
            string confirmationMessage = "";

            if (choiceResult == DialogResult.Yes)
            {
                apiUrlRelative = $"CadastroUsuario/{usernameToDelete}";
                confirmationMessage = $"Tem certeza que deseja apagar o usuário '{usernameToDelete}' pelo nome?";
            }
            else
            {
                apiUrlRelative = $"CadastroUsuario/id/{userId}";
                confirmationMessage = $"Tem certeza que deseja apagar o usuário com ID '{userId}'?";
            }

            DialogResult confirmResult = MessageBox.Show(confirmationMessage, "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

                try
                {
                    var response = await client.DeleteAsync(apiUrlRelative);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Usuário apagado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayUsers();
                        ClearFormAndResetState();
                    }
                    else
                    {
                        string erro = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Erro ao apagar usuário:\n" + erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de comunicação com a API: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }

        private async void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            // Validações básicas dos campos
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtSenha.Text) && !isEditing || // Senha é opcional na edição
                cbSetor.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtNomeCompleto.Text) || // Nome Completo é obrigatório
                string.IsNullOrWhiteSpace(txtMatricula.Text))     // Matrícula é obrigatória
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios: Usuário, Senha (para novo cadastro), Setor, Nome Completo e Matrícula.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validação da matrícula (5 dígitos numéricos)
            if (txtMatricula.Text.Length != 5 || !txtMatricula.Text.All(char.IsDigit))
            {
                MessageBox.Show("A matrícula deve conter exatamente 5 dígitos numéricos.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatricula.Focus();
                return;
            }

            // Se não estiver em modo de edição, verifica a disponibilidade do usuário e da matrícula antes de salvar.
            if (!isEditing)
            {
                bool usuarioDisponivel = await VerificarDisponibilidadeUsuario(txtUsuario.Text.Trim());
                if (!usuarioDisponivel)
                {
                    MessageBox.Show("O nome de usuário já existe. Por favor, escolha outro nome para o campo 'Usuário'.", "Nome de Usuário Indisponível", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }

                bool matriculaDisponivel = await VerificarDisponibilidadeMatricula(txtMatricula.Text.Trim());
                if (!matriculaDisponivel)
                {
                    MessageBox.Show("A matrícula informada já existe. Por favor, insira uma matrícula única.", "Matrícula Indisponível", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatricula.Focus();
                    return;
                }
            }
            // Se estiver em modo de edição, e a matrícula foi alterada, verifica a disponibilidade.
            else if (isEditing && txtMatricula.Text.Trim() != GetOriginalMatriculaFromSelectedRow()) // Assume que você tem um método para obter a matrícula original
            {
                bool matriculaDisponivel = await VerificarDisponibilidadeMatricula(txtMatricula.Text.Trim(), editingUserName);
                if (!matriculaDisponivel)
                {
                    MessageBox.Show("A matrícula informada já existe para outro usuário. Por favor, insira uma matrícula única.", "Matrícula Indisponível", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatricula.Focus();
                    return;
                }
            }


            SaveUser();
        }

        // Helper para obter a matrícula original da linha selecionada (necessário para edição)
        private string GetOriginalMatriculaFromSelectedRow()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                return selectedRow.Cells["Matricula"].Value?.ToString();
            }
            return null;
        }


        private void btnCadastroUsuario_Click(object sender, EventArgs e)
        {
            DisplayUsers();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        // SaveUser (POST para novo cadastro, PUT para atualização)
        private async void SaveUser()
        {
            if (isEditing && !AuthManager.IsAuthenticated)
            {
                MessageBox.Show("Sessão expirada ou não autenticada. Por favor, faça login novamente.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
                return;
            }

            // Já validamos os campos no btnCadastrarUsuario_Click, então aqui assumimos que são válidos.

            object userData;
            if (isEditing && string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                // Na edição, se a senha estiver vazia, não a enviamos para não sobrescrever a existente.
                userData = new
                {
                    NomeUsuario = txtUsuario.Text.Trim(),
                    SetorUsuario = cbSetor.SelectedItem.ToString(),
                    IsActive = cbkativo.Checked,
                    NomeCompleto = txtNomeCompleto.Text.Trim(), // Inclui Nome Completo
                    Matricula = txtMatricula.Text.Trim()       // Inclui Matrícula
                };
            }
            else
            {
                userData = new
                {
                    NomeUsuario = txtUsuario.Text.Trim(),
                    SenhaUsuario = txtSenha.Text.Trim(),
                    SetorUsuario = cbSetor.SelectedItem.ToString(),
                    IsActive = cbkativo.Checked,
                    NomeCompleto = txtNomeCompleto.Text.Trim(), // Inclui Nome Completo
                    Matricula = txtMatricula.Text.Trim()       // Inclui Matrícula
                };
            }

            string json = JsonConvert.SerializeObject(userData);

            HttpClient client = AuthManager.GetHttpClient();
            if (client == null)
            {
                if (!isEditing)
                {
                    // Para o POST de cadastro, se o cliente ainda não estiver autenticado,
                    // podemos usar uma nova instância de HttpClient sem a chave de API.
                    // Isso permite que o cadastro de usuário funcione mesmo sem login.
                    // Para o PUT (edição), a verificação AuthManager.IsAuthenticated já lida com isso.
                    client = new HttpClient();
                    client.BaseAddress = new Uri("http://127.0.0.1:5000/");
                }
                else
                {
                    MessageBox.Show("Erro interno: Cliente HTTP não disponível. Por favor, faça login novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmLogin loginForm = new frmLogin();
                    loginForm.Show();
                    this.Hide();
                    return;
                }
            }

            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;

                if (isEditing)
                {
                    response = await client.PutAsync($"CadastroUsuario/{editingUserName}", content);
                }
                else
                {
                    response = await client.PostAsync("CadastroUsuario", content);
                }

                if (response.IsSuccessStatusCode)
                {
                    if (isEditing)
                    {
                        MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    ClearFormAndResetState();
                    DisplayUsers();
                }
                else
                {
                    string erro = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Erro ao {(isEditing ? "atualizar" : "cadastrar")} usuário:\n" + erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de comunicação com a API: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormAndResetState()
        {
            txtUsuario.Clear();
            txtSenha.Clear();
            cbSetor.SelectedIndex = -1;
            cbkativo.Checked = false;
            txtNomeCompleto.Clear(); // Limpa novo campo
            txtMatricula.Clear();    // Limpa novo campo
            editingUserName = null;
            isEditing = false;
            btnCadastrarUsuario.Text = "Cadastrar Usuário";
            txtUsuario.Enabled = true;
        }

        // Novo método para verificar a disponibilidade do nome de usuário
        private async Task<bool> VerificarDisponibilidadeUsuario(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return false;
            }

            HttpClient client = AuthManager.GetHttpClient();
            if (client == null)
            {
                MessageBox.Show("Não foi possível verificar a disponibilidade do usuário. Por favor, faça login para acessar esta funcionalidade.", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                var response = await client.GetAsync("CadastroUsuario");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var usuarios = JsonConvert.DeserializeObject<List<dynamic>>(json);

                    bool existe = usuarios.Any(u => ((string)u.NomeUsuario).Equals(username, StringComparison.OrdinalIgnoreCase));
                    return !existe;
                }
                else
                {
                    string erro = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Erro ao verificar disponibilidade do usuário. Código: {response.StatusCode}\nDetalhes: {erro}", "Erro da API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de comunicação com a API ao verificar disponibilidade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Novo método para verificar a disponibilidade da matrícula
        private async Task<bool> VerificarDisponibilidadeMatricula(string matricula, string excludeUsername = null)
        {
            if (string.IsNullOrWhiteSpace(matricula))
            {
                return false;
            }

            HttpClient client = AuthManager.GetHttpClient();
            if (client == null)
            {
                MessageBox.Show("Não foi possível verificar a disponibilidade da matrícula. Por favor, faça login para acessar esta funcionalidade.", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                var response = await client.GetAsync("CadastroUsuario");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var usuarios = JsonConvert.DeserializeObject<List<dynamic>>(json);

                    // Verifica se a matrícula existe, excluindo o próprio usuário se estiver em modo de edição
                    bool existe = usuarios.Any(u =>
                        ((string)u.Matricula).Equals(matricula, StringComparison.OrdinalIgnoreCase) &&
                        (excludeUsername == null || !((string)u.NomeUsuario).Equals(excludeUsername, StringComparison.OrdinalIgnoreCase))
                    );
                    return !existe; // Retorna true se a matrícula estiver disponível
                }
                else
                {
                    string erro = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Erro ao verificar disponibilidade da matrícula. Código: {response.StatusCode}\nDetalhes: {erro}", "Erro da API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de comunicação com a API ao verificar disponibilidade da matrícula: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private async void DisplayUsers()
        {
            if (!AuthManager.IsAuthenticated)
            {
                MessageBox.Show("Sessão expirada ou não autenticada. Por favor, faça login novamente.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
                return;
            }

            dataGridView1.Rows.Clear();

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
                var response = await client.GetAsync("CadastroUsuario");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var usuarios = JsonConvert.DeserializeObject<List<dynamic>>(json);

                    if (usuarios.Count == 0)
                    {
                        MessageBox.Show("Nenhum usuário cadastrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    foreach (var user in usuarios)
                    {
                        dataGridView1.Rows.Add(
                            (int)user.IDCadastroUsuario,
                            (string)user.NomeUsuario,
                            (string)user.NomeCompleto, // Exibe Nome Completo
                            (string)user.Matricula,    // Exibe Matrícula
                            (string)user.SetorUsuario,
                            (bool)user.IsActive
                        );
                    }
                }
                else
                {
                    string erro = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Erro ao buscar usuários na API. Código: " + response.StatusCode + "\nDetalhes: " + erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de comunicação com a API: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows.Count > e.RowIndex)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                string username = selectedRow.Cells["Username"].Value.ToString();
                string nomeCompleto = selectedRow.Cells["NomeCompleto"].Value?.ToString();
                string matricula = selectedRow.Cells["Matricula"].Value?.ToString();
                string setor = selectedRow.Cells["Sector"].Value?.ToString();
                bool isActive = (bool)selectedRow.Cells["IsActive"].Value;

                txtUsuario.Text = username;
                txtSenha.Clear(); // A senha não é recuperada por segurança
                txtNomeCompleto.Text = nomeCompleto;
                txtMatricula.Text = matricula;
                cbSetor.SelectedItem = setor;
                cbkativo.Checked = isActive;

                // Ativa o modo edição
                editingUserName = username;
                isEditing = true;

                btnCadastrarUsuario.Text = "Atualizar";
                txtUsuario.Enabled = false; // Usuário não pode ser alterado
            }
        }


        private void Cadastro_Load(object sender, EventArgs e)
        {
            if (AuthManager.IsAuthenticated)
            {
                DisplayUsers();
            }
            else
            {
                MessageBox.Show("Você pode cadastrar novos usuários, mas a funcionalidade de buscar/listar usuários requer que você esteja logado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEditar(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string username = selectedRow.Cells["Username"].Value.ToString();
                string sector = selectedRow.Cells["Sector"].Value.ToString();
                bool isActive = (bool)selectedRow.Cells["IsActive"].Value;
                string nomeCompleto = selectedRow.Cells["NomeCompleto"].Value?.ToString(); // Obtém Nome Completo
                string matricula = selectedRow.Cells["Matricula"].Value?.ToString();     // Obtém Matrícula

                txtUsuario.Text = username;
                txtSenha.Clear();
                cbSetor.SelectedItem = sector;
                cbkativo.Checked = isActive;
                txtNomeCompleto.Text = nomeCompleto; // Preenche Nome Completo
                txtMatricula.Text = matricula;       // Preenche Matrícula

                editingUserName = username;
                isEditing = true;

                btnCadastrarUsuario.Text = "Atualizar";
                txtUsuario.Enabled = false; // Usuário não pode ser alterado na edição
            }
            else
            {
                MessageBox.Show("Por favor, selecione um usuário para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }

        // Eventos adicionados pelo designer, mantenha-os vazios se não tiverem lógica específica
        private void txtNomeCompleto_TextChanged(object sender, EventArgs e) { }
        private void txtMatricula_TextChanged(object sender, EventArgs e) { }

    }
}