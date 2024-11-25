using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odasu_MySQL
{
    public partial class Principal : Form
    {
        // Variáveis para controle do botão atual e cor do tema
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public Principal()
        {
            InitializeComponent();
            random = new Random();
            btnFecharFormFilho.Enabled = true;
            this.Text = string.Empty; // Define o título do formulário como vazio
            this.ControlBox = false; // Remove a caixa de controle (minimizar, maximizar, fechar)
        }

        private Color SelectThemeColor()
        {
            // Seleciona uma cor aleatória da lista de cores
            int index = random.Next(Colorir.ColorList.Count);
            while (tempIndex == index) // Garante que a nova cor não é a mesma que a anterior
            {
                index = random.Next(Colorir.ColorList.Count);
            }

            tempIndex = index;
            string color = Colorir.ColorList[index];
            try
            {
                return ColorTranslator.FromHtml(color); // Converte a string da cor para Color
            }
            catch (Exception ex)
            {
                // Tratar erro de conversão
                MessageBox.Show("Erro ao converter a cor: " + ex.Message);
                return Color.Black; // Cor padrão em caso de erro
            }
        }

        private void ActivateButton(Object btnSender)
        {
            // Ativa o botão selecionado e muda suas propriedades
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton(); // Desativa o botão anterior
                    Color color = SelectThemeColor(); // Seleciona nova cor
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White; // Altera a cor do texto
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    currentButton.BackColor = Colorir.ChangeColorBrightness(color, -0.1); // Escurecer a cor
                    panelTitulo.BackColor = color; // Altera a cor do painel de título
                    panelLogo.BackColor = Colorir.ChangeColorBrightness(color, -0.3); // Altera a cor do logo
                    Colorir.PrimaryColor = color; // Armazena a cor primária
                    Colorir.SecondaryColor = Colorir.ChangeColorBrightness(color, -0.3); // Armazena a cor secundária
                    btnFecharFormFilho.Visible = true; // Torna visível o botão de fechar
                }
            }
        }

        private void DisableButton()
        {
            // Desativa todos os botões do painel menu
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn is Button)
                {
                    previousBtn.BackColor = Color.FromArgb(9, 154, 154); // Cor original
                    previousBtn.ForeColor = Color.Gainsboro; // Cor original
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            // Fechar o formulário ativo, se houver
            if (activeForm != null)
            {
                activeForm.Close();
            }

            // Ativar o botão que foi pressionado
            ActivateButton(btnSender);

            // Configurar o novo formulário filho
            activeForm = childForm;
            childForm.TopLevel = false; // Define o formulário como não de nível superior
            childForm.FormBorderStyle = FormBorderStyle.None; // Remove a borda do formulário
            childForm.Dock = DockStyle.Fill; // Preenche o painel
            this.panelDesktop.Controls.Add(childForm); // Adiciona o formulário filho ao painel
            this.panelDesktop.Tag = childForm; // Marca o painel com o formulário ativo
            childForm.BringToFront(); // Traz o formulário para frente
            childForm.Show(); // Exibe o formulário
            lblTitulo.Text = childForm.Text; // Atualiza o título

            // Torna o botão de fechar visível
            btnFecharFormFilho.Visible = true;
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.CONFIGURACOES(), sender); // Abre o formulário de cadastro
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ESTOQUE(), sender); // Abre o formulário de estoque
        }

        private void btnFaturamento_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FATURAMENTO(), sender); // Abre o formulário de faturamento
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.PEDIDOS(), sender); // Abre o formulário de pedidos
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.CLIENTES(), sender); // Abre o formulário de configurações
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            btnFecharFormFilho.Visible = false; // Inicialmente esconde o botão de fechar
        }

        private void btnFecharFormFilho_Click(object sender, EventArgs e)
        {
            // Fecha o formulário ativo e reseta o estado
            if (activeForm != null)
            {
                activeForm.Close();
                Reset();
            }
        }

        private void Reset()
        {
            // Reseta o estado do formulário principal
            DisableButton(); // Desativa botões
            lblTitulo.Text = "GESTÃO"; // Restaura o título
            panelTitulo.BackColor = Color.FromArgb(9, 154, 154); // Restaura a cor do painel de título
            panelLogo.BackColor = Color.FromArgb(9, 154, 154); // Restaura a cor do logo
            currentButton = null; // Reseta o botão atual
            btnFecharFormFilho.Visible = false; // Esconde o botão de fechar ao resetar
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            // Confirmação antes de deslogar
            var result = MessageBox.Show("Tem certeza que deseja deslogar?", "Confirmar Deslogar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Mostra o formulário de login
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide(); // Esconde o formulário Principal
            }
        }
    }
}