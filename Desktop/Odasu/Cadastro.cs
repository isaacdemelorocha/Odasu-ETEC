using System.Data.SqlClient;
using System.Windows.Forms;
using System;

namespace Odasu_MySQL
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializações necessárias
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AreFieldsValid())
                {
                    MessageBox.Show("Preencha todos os campos corretamente.");
                    ClearFields();
                    txtNome.Focus();
                    return;
                }

                // Validação e formatação do CPF
                string cpf = txtCPF.Text.Replace(".", "").Replace("-", "").Trim();
                if (cpf.Length != 11 || !long.TryParse(cpf, out _))
                {
                    MessageBox.Show("CPF inválido. O formato correto é 000.000.000-00.");
                    txtCPF.Focus();
                    return;
                }

                // Cria um novo usuário
                CadastroUsuario cadUsuario = new CadastroUsuario
                {
                    nome = txtNome.Text,
                    sobrenome = txtSobrenome.Text,
                    cpf = cpf, // Altera para usar o CPF limpo
                    celular = txtCel.Text,
                    email = txtEmail.Text,
                    senha = txtSenha1.Text,
                    nascimento = DateTime.Parse(txtDtNasc.Text) // Atribui diretamente
                };

                // Tenta cadastrar o usuário
                if (cadUsuario.cadastrarUsuario())
                {
                    MessageBox.Show($"O usuário {cadUsuario.nome} foi cadastrado com sucesso!");
                    ClearFields();
                    txtNome.Focus();
                }
                else
                {
                    MessageBox.Show("Não foi possível cadastrar o usuário.");
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Formato de entrada inválido: " + fe.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar o usuário: " + ex.Message);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obter o CPF ou outro identificador do campo de entrada
                string cpf = txtCPF.Text.Replace(".", "").Replace("-", "").Trim();
                if (cpf.Length != 11 || !long.TryParse(cpf, out _))
                {
                    MessageBox.Show("CPF inválido. O formato correto é 000.000.000-00.");
                    txtCPF.Focus();
                    return;
                }

                // Instancia a classe CadastroUsuario para buscar o usuário
                CadastroUsuario cadUsuario = new CadastroUsuario();
                CadastroUsuario usuarioEncontrado = cadUsuario.buscarUsuario(cpf);
                if (usuarioEncontrado != null)
                {
                    // Preencher os campos com os dados do usuário encontrado
                    txtNome.Text = usuarioEncontrado.nome;
                    txtSobrenome.Text = usuarioEncontrado.sobrenome;
                    txtCel.Text = usuarioEncontrado.celular;
                    txtEmail.Text = usuarioEncontrado.email;
                    txtDtNasc.Text = usuarioEncontrado.nascimento.ToString("dd/MM/yyyy"); // Formato de data ajustado
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar o usuário: " + ex.Message);
            }
        }

        private bool AreFieldsValid()
        {
            return !string.IsNullOrWhiteSpace(txtNome.Text) &&
                   !string.IsNullOrWhiteSpace(txtSobrenome.Text) &&
                   !string.IsNullOrWhiteSpace(txtCPF.Text) &&
                   !string.IsNullOrWhiteSpace(txtDtNasc.Text) &&
                   !string.IsNullOrWhiteSpace(txtCel.Text) &&
                   !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                   !string.IsNullOrWhiteSpace(txtSenha1.Text) &&
                   txtSenha1.Text == txtSenha2.Text; // Verifica se as senhas coincidem
        }

        private void ClearFields()
        {
            txtNome.Clear();
            txtSobrenome.Clear();
            txtCPF.Clear();
            txtDtNasc.Clear();
            txtCel.Clear();
            txtEmail.Clear();
            txtSenha1.Clear();
            txtSenha2.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AreFieldsValid())
                {
                    MessageBox.Show("Preencha todos os campos corretamente.");
                    ClearFields();
                    txtNome.Focus();
                    return;
                }

                // Validação e formatação do CPF
                string cpf = txtCPF.Text.Replace(".", "").Replace("-", "").Trim();
                if (cpf.Length != 11 || !long.TryParse(cpf, out _))
                {
                    MessageBox.Show("CPF inválido. O formato correto é 000.000.000-00.");
                    txtCPF.Focus();
                    return;
                }

                // Atualiza o usuário
                CadastroUsuario cadUsuario = new CadastroUsuario
                {
                    nome = txtNome.Text,
                    sobrenome = txtSobrenome.Text,
                    cpf = cpf, // Use o CPF limpo
                    celular = txtCel.Text,
                    email = txtEmail.Text,
                    senha = txtSenha1.Text,
                    nascimento = DateTime.Parse(txtDtNasc.Text) // Atribui diretamente
                };

                // Tenta atualizar o usuário
                if (cadUsuario.atualizarUsuario(cpf)) // Passa o CPF limpo aqui
                {
                    MessageBox.Show($"O usuário {cadUsuario.nome} foi atualizado com sucesso!");
                    ClearFields();
                    txtNome.Focus();
                }
                else
                {
                    MessageBox.Show("Não foi possível atualizar o usuário.");
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Formato de entrada inválido: " + fe.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o usuário: " + ex.Message);
            }
        }

        private void btnInativar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obter o CPF do campo de entrada
                string cpf = txtCPF.Text.Replace(".", "").Replace("-", "").Trim();
                if (cpf.Length != 11 || !long.TryParse(cpf, out _))
                {
                    MessageBox.Show("CPF inválido. O formato correto é 000.000.000-00.");
                    txtCPF.Focus();
                    return;
                }

                // Criar uma instância de CadastroUsuario
                CadastroUsuario cadUsuario = new CadastroUsuario();

                // Tentar inativar o usuário
                if (cadUsuario.inativarUsuario(cpf))
                {
                    MessageBox.Show($"O usuário com CPF {cpf} foi inativado com sucesso!");
                    ClearFields(); // Limpa os campos após a inativação
                }
                else
                {
                    MessageBox.Show("Não foi possível inativar o usuário.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inativar o usuário: " + ex.Message);
            }
        }

        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}