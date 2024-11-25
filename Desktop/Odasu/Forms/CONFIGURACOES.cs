using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odasu_MySQL.Forms
{
    public partial class CONFIGURACOES : Form
    {
        public CONFIGURACOES()
        {
            InitializeComponent(); // Inicializa os componentes do formulário
        }

        private void CADASTRO_Load(object sender, EventArgs e)
        {
            LoadTheme(); // Carrega o tema ao iniciar o formulário
        }

        private void LoadTheme()
        {
            // Aplica o tema aos botões no formulário
            foreach (Control btns in this.Controls)
            {
                if (btns is Button)
                {
                    Button btn = (Button)btns;
                    btn.BackColor = Colorir.PrimaryColor; // Define a cor de fundo
                    btn.ForeColor = Color.White; // Define a cor do texto
                    btn.FlatAppearance.BorderColor = Colorir.SecondaryColor; // Define a cor da borda
                }
            }

            // Define a cor dos rótulos
            lblCodigo.ForeColor = Colorir.SecondaryColor;
            lblNome.ForeColor = Colorir.SecondaryColor;
            lblSobrenome.ForeColor = Colorir.SecondaryColor;
            lblCPF.ForeColor = Colorir.SecondaryColor;
            lblDtNasc.ForeColor = Colorir.SecondaryColor;
            lblCel.ForeColor = Colorir.SecondaryColor;
            lblEmail.ForeColor = Colorir.SecondaryColor;
            lblSenha1.ForeColor = Colorir.SecondaryColor;
            lblSenha2.ForeColor = Colorir.SecondaryColor;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se todos os campos estão preenchidos corretamente
                if (!AreFieldsValid())
                {
                    MessageBox.Show("Preencha todos os campos corretamente.");
                    ClearFields(); // Limpa os campos
                    txtNome.Focus(); // Foca no campo Nome
                    return;
                }

                // Validação e formatação do CPF
                string cpf = txtCPF.Text.Replace(".", "").Replace("-", "").Trim();
                if (cpf.Length != 11 || !long.TryParse(cpf, out _))
                {
                    MessageBox.Show("CPF inválido. O formato correto é 000.000.000-00.");
                    txtCPF.Focus(); // Foca no campo CPF
                    return;
                }

                // Cria um novo usuário
                CadastroUsuario cadUsuario = new CadastroUsuario
                {
                    nome = txtNome.Text,
                    sobrenome = txtSobrenome.Text,
                    cpf = cpf, // Usa o CPF limpo
                    celular = txtCel.Text,
                    email = txtEmail.Text,
                    senha = txtSenha1.Text,
                    nascimento = DateTime.Parse(txtDtNasc.Text) // Atribui diretamente
                };

                // Tenta cadastrar o usuário
                if (cadUsuario.cadastrarUsuario())
                {
                    MessageBox.Show($"O usuário {cadUsuario.nome} foi cadastrado com sucesso!");
                    ClearFields(); // Limpa os campos após cadastro
                    txtNome.Focus(); // Foca no campo Nome
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
                    txtCPF.Focus(); // Foca no campo CPF
                    return;
                }

                // Instancia a classe CadastroUsuario para buscar o usuário
                CadastroUsuario cadUsuario = new CadastroUsuario();
                CadastroUsuario usuarioEncontrado = cadUsuario.buscarUsuario(cpf);
                if (usuarioEncontrado != null)
                {
                    // Preencher os campos com os dados do usuário encontrado
                    lblID.Text = usuarioEncontrado.id;
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
            // Verifica se todos os campos obrigatórios estão preenchidos e se as senhas coincidem
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
            // Limpa todos os campos de entrada
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
            ClearFields(); // Limpa os campos ao clicar no botão Limpar
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se todos os campos estão preenchidos corretamente
                if (!AreFieldsValid())
                {
                    MessageBox.Show("Preencha todos os campos corretamente.");
                    ClearFields(); // Limpa os campos
                    txtNome.Focus(); // Foca no campo Nome
                    return;
                }

                // Validação e formatação do CPF
                string cpf = txtCPF.Text.Replace(".", "").Replace("-", "").Trim();
                if (cpf.Length != 11 || !long.TryParse(cpf, out _))
                {
                    MessageBox.Show("CPF inválido. O formato correto é 000.000.000-00.");
                    txtCPF.Focus(); // Foca no campo CPF
                    return;
                }

                // Atualiza o usuário
                CadastroUsuario cadUsuario = new CadastroUsuario
                {
                    nome = txtNome.Text,
                    sobrenome = txtSobrenome.Text,
                    cpf = cpf, // Usa o CPF limpo
                    celular = txtCel.Text,
                    email = txtEmail.Text,
                    senha = txtSenha1.Text,
                    nascimento = DateTime.Parse(txtDtNasc.Text) // Atribui diretamente
                };

                // Tenta atualizar o usuário
                if (cadUsuario.atualizarUsuario(cpf)) // Passa o CPF limpo aqui
                {
                    MessageBox.Show($"O usuário {cadUsuario.nome} foi atualizado com sucesso!");
                    ClearFields(); // Limpa os campos após atualização
                    txtNome.Focus(); // Foca no campo Nome
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
                    txtCPF.Focus(); // Foca no campo CPF
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

       
    }
}