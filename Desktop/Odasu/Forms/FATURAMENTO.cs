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
using iTextSharp.text.xml;

namespace Odasu_MySQL.Forms
{
    public partial class FATURAMENTO : Form
    {
        ClasseConexao con;
        DataTable dt;


        private DataTable dataTable;
        private ClasseConexao conexao = new ClasseConexao();

        public FATURAMENTO()
        {
            InitializeComponent();
        }

        private void FATURAMENTO_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadInitialPedidos();
            FormatarDataGridViewFaturamento();
        }



        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns is Button)
                {
                    Button btn = (Button)btns;
                    btn.BackColor = Colorir.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = Colorir.SecondaryColor;
                }
            }

            lblRelatorio.ForeColor = Colorir.SecondaryColor;
            lblExportar.ForeColor = Colorir.PrimaryColor;
            lblPesquisar.ForeColor = Colorir.SecondaryColor;
        }

        private void LoadInitialPedidos()
        {
            dataGridViewFaturamento.DataSource = null;
            dataGridViewFaturamento.Rows.Clear();

            con = new ClasseConexao();

            string query = @"
        SELECT 
            c.nome_categoria AS 'Categoria',
            u.email_usuario AS 'Email',
            u.nome_usuario AS 'nome',
            u.sobrenome_usuario AS 'Sobrenome',
            FORMAT(SUM(p.preco_produto), 'C', 'pt-BR') AS 'Faturamento'
        FROM 
            tb_pedido ped
        JOIN 
            tb_detalhe_pedido dp ON ped.num_pedido = dp.cod_pedido_detalheped
        JOIN 
            tb_produto p ON dp.cod_produto_detalheped = p.cod_produto
        JOIN 
            tb_usuario u ON ped.cod_usuario_pedido = u.cod_usuario
        JOIN 
            tb_categoria c ON p.cod_categoria_produto = c.cod_categoria
        WHERE 
            ped.data_criacao_pedido >= DATEADD(MONTH, -12, CURRENT_TIMESTAMP)
        GROUP BY 
            c.nome_categoria, 
            u.email_usuario, 
            u.nome_usuario,
            u.sobrenome_usuario
        ORDER BY 
            SUM(p.preco_produto) DESC;";

            try
            {
                dt = con.executarSQL(query);  // Preenche a variável dt com dados
                dataGridViewFaturamento.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadTotalFaturamento();
        }

        private void LoadTotalFaturamento()
        {
            dataGridViewFaturamento.DataSource = null;
            dataGridViewFaturamento.Rows.Clear();


            string query = @"
                SELECT
    DATENAME(MONTH, ped.data_criacao_pedido) AS [Mês],
    YEAR(ped.data_criacao_pedido) AS [Ano],
    FORMAT(SUM(p.preco_produto), 'C', 'pt-BR') AS [Faturamento]
FROM tb_detalhe_pedido dp
JOIN tb_produto p ON dp.cod_produto_detalheped = p.cod_produto
JOIN tb_pedido ped ON dp.cod_pedido_detalheped = ped.num_pedido
GROUP BY 
    YEAR(ped.data_criacao_pedido), 
    MONTH(ped.data_criacao_pedido), 
    DATENAME(MONTH, ped.data_criacao_pedido)
ORDER BY 
    YEAR(ped.data_criacao_pedido), 
    MONTH(ped.data_criacao_pedido);";

            try
            {
                DataTable dataTable = conexao.executarSQL(query);

                dataGridViewFaturamento.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadFaturamentoCategoria();


        }

        private void LoadFaturamentoCategoria()
        {
            dataGridViewFaturamento.DataSource = null;
            dataGridViewFaturamento.Rows.Clear();

            string query = @"
                SELECT 
        c.nome_categoria AS [Categoria],
        FORMAT(SUM(p.preco_produto), 'C', 'pt-BR') AS [Faturamento por Categoria]
    FROM tb_detalhe_pedido dp
    JOIN tb_produto p ON dp.cod_produto_detalheped = p.cod_produto
    JOIN tb_categoria c ON p.cod_categoria_produto = c.cod_categoria
    JOIN tb_pedido ped ON dp.cod_pedido_detalheped = ped.num_pedido
    GROUP BY c.nome_categoria
    ORDER BY SUM(p.preco_produto) DESC;";

            try
            {
                DataTable dataTable = conexao.executarSQL(query);
                dataGridViewFaturamento.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFaturamentoUsuario();
        }

        private void LoadFaturamentoUsuario()
        {
            dataGridViewFaturamento.DataSource = null;
            dataGridViewFaturamento.Rows.Clear();

            string query = @"
                SELECT 
        u.nome_usuario AS [Nome],
        u.sobrenome_usuario AS [Sobrenome],
        FORMAT(SUM(p.preco_produto), 'C', 'pt-BR') AS [Faturamento por Usuário]
    FROM tb_detalhe_pedido dp
    JOIN tb_produto p ON dp.cod_produto_detalheped = p.cod_produto
    JOIN tb_pedido ped ON dp.cod_pedido_detalheped = ped.num_pedido
    JOIN tb_usuario u ON ped.cod_usuario_pedido = u.cod_usuario
    GROUP BY u.nome_usuario, u.sobrenome_usuario
    ORDER BY SUM(p.preco_produto) DESC;";

            try
            {
                DataTable dataTable = conexao.executarSQL(query);
                dataGridViewFaturamento.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (radioButtonTabela.Checked)
            {
                ExportacaoUtil.ExportarTabela(dataGridViewFaturamento);
            }
            else if (radioButtonPDF.Checked)
            {
                ExportacaoUtil.ExportarPDF(dataGridViewFaturamento);
            }
            else
            {
                MessageBox.Show("Selecione um formato de exportação.");
            }
        }

        public void FormatarDataGridViewFaturamento()
        {


            //dataGridViewFaturamento.Columns[0].Visible = false; //esconde a coluna ID
            dataGridViewFaturamento.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridViewFaturamento.AllowUserToAddRows = false; //ESCONDE A NOVA LINHA DO GRID
            dataGridViewFaturamento.AllowUserToDeleteRows = false;
            dataGridViewFaturamento.RowHeadersVisible = false; //ESCONDE O PONTEIRO DO GRID
            dataGridViewFaturamento.ReadOnly = true;
            //permite personalizar o grid

            dataGridViewFaturamento.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewFaturamento.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //altera a cor das linhas alternadas no grid
            dataGridViewFaturamento.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridViewFaturamento.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewFaturamento.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewFaturamento.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            //não permite seleção de multiplas linhas    
            dataGridViewFaturamento.MultiSelect = false;
            //ao clicar, seleciona a linha inteira
            dataGridViewFaturamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Expande a célula automáticamente
            dataGridViewFaturamento.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridViewFaturamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewFaturamento.AllowUserToAddRows = false;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dt != null)
            {
                string filter = txtSearch.Text.Trim().Replace("'", "''"); // Escapar aspas simples e remover espaços extras
                DataView dv = new DataView(dt);
                string filterString = "";

                if (int.TryParse(filter, out _)) // Se for um número
                {
                    // Adicione a lógica para filtrar números, se necessário
                }
                else // Se for texto genérico
                {
                    filterString = $@"
                [Categoria] LIKE '%{filter}%' OR 
                [Email] LIKE '%{filter}%' OR 
                [Sobrenome] LIKE '%{filter}%'";
                }

                try
                {
                    dv.RowFilter = filterString;
                    dataGridViewFaturamento.DataSource = dv;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao aplicar filtro: {ex.Message}");
                }
            }
        }
    }
}

