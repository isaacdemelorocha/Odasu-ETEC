using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;


namespace Odasu_MySQL
{
    public partial class Login : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public Login()
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            this.ControlBox = false;

            // Adiciona o evento KeyDown ao maskedTextBoxSenha
            maskedTextBoxSenha.KeyDown += new KeyEventHandler(maskedTextBoxSenha_KeyDown);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Inicialização se necessário
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            // Confirmação antes de sair
            var result = MessageBox.Show("Tem certeza que deseja sair?", "Confirmar Saída", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Encerra a aplicação
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // Remove a máscara do CPF
            string cpf = maskedTextBoxCPF.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
            string senha = maskedTextBoxSenha.Text;

            if (AutenticarUsuario(cpf, senha))
            {
                Principal principal = new Principal();
                principal.Show();
                this.Hide(); // Esconde o formulário de login
            }
            else
            {
                MessageBox.Show("CPF ou senha inválidos, ou você não tem permissão para acessar.");
            }
        }

        private bool AutenticarUsuario(string cpf, string senha)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=odasu;User ID=sa;Password=1234;"; // Ajuste conforme necessário
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT tipo_conta FROM tb_usuario WHERE cpf_usuario = @cpf AND senha_usuario = @senha";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@cpf", cpf);
                    command.Parameters.AddWithValue("@senha", senha); // Considere usar hashing para senhas

                    string tipoConta = command.ExecuteScalar() as string;

                    // Verifica se o tipo de conta é ADM
                    return tipoConta != null && tipoConta.Equals("ADM", StringComparison.OrdinalIgnoreCase);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
                return false;
            }
        }

        private void maskedTextBoxCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            // Lógica se necessário
        }

        private void maskedTextBoxSenha_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            // Lógica se necessário
        }

        // Método para lidar com a tecla pressionada no maskedTextBoxSenha
        private void maskedTextBoxSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar_Click(sender, e);
            }
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
            // Lógica se necessário
        }
    }
}
