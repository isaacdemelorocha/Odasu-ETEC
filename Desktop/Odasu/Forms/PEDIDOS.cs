using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Odasu_MySQL.Forms
{
    public partial class PEDIDOS : Form
    {
        private ClasseConexao conexao = new ClasseConexao();
        private DataTable dt = new DataTable();

        public PEDIDOS()
        {
            InitializeComponent();
        }

        private void PEDIDOS_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadInitialPedidos();
            FormatardataGridViewPedidos();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns is Button btn)
                {
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
            dataGridViewPedidos.DataSource = null; // Limpa a DataSource
            dt.Clear(); // Limpa o DataTable

            string query = @"
        SELECT 
            p.num_pedido AS [Número do Pedido],
            
            u.nome_usuario AS [Nome do Usuário],
            u.sobrenome_usuario AS [Sobrenome do Usuário],
            p.data_criacao_pedido AS [Data de Criação],
            pr.nome_produto AS [Nome do Produto],
            p.cod_produto_pedido AS [Código do Produto],
            p.cod_usuario_pedido AS [Código do Usuário]
        FROM 
            tb_pedido p
        JOIN 
            tb_usuario u ON p.cod_usuario_pedido = u.cod_usuario
        JOIN 
            tb_detalhe_pedido dp ON p.num_pedido = dp.cod_pedido_detalheped
        JOIN 
            tb_produto pr ON dp.cod_produto_detalheped = pr.cod_produto";

            try
            {
                dt = conexao.executarSQL(query); // Armazena os dados em dt
                dataGridViewPedidos.DataSource = dt; // Define a fonte de dados do DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private void btnPedStatus_Click(object sender, EventArgs e) => LoadPedidosPorStatus();

        private void LoadPedidosPorStatus()
        {
            LoadData(@"
                SELECT 
                    CONVERT(DATE, p.data_criacao_pedido) AS [Data do Pedido],
                    COUNT(p.num_pedido) AS [Total de Pedidos],
                    SUM(pr.preco_produto) AS [Total de Vendas (R$)]
                FROM 
                    tb_pedido p
                JOIN 
                    tb_produto pr ON p.cod_produto_pedido = pr.cod_produto
                GROUP BY 
                    CONVERT(DATE, p.data_criacao_pedido)
                ORDER BY 
                    [Data do Pedido] DESC;");
        }

        private void btnPedProduto_Click(object sender, EventArgs e) => LoadPedidosPorProduto();

        private void LoadPedidosPorProduto()
        {
            LoadData(@"
                SELECT 
                    p.nome_produto AS [Nome do Produto],
                    COUNT(DISTINCT dp.cod_pedido_detalheped) AS [Total de Pedidos]
                FROM 
                    tb_detalhe_pedido dp
                JOIN 
                    tb_produto p ON dp.cod_produto_detalheped = p.cod_produto
                GROUP BY 
                    p.nome_produto
                ORDER BY 
                    [Total de Pedidos] DESC;");
        }

        private void btnPedUsuario_Click(object sender, EventArgs e) => LoadPedidosPorUsuario();

        private void LoadPedidosPorUsuario()
        {
            LoadData(@"
                SELECT 
                    u.nome_usuario AS [Nome do Usuário],
                    u.sobrenome_usuario AS [Sobrenome do Usuário],
                    COUNT(*) AS [Total de Pedidos]
                FROM 
                    tb_pedido ped
                JOIN 
                    tb_usuario u ON ped.cod_usuario_pedido = u.cod_usuario
                GROUP BY 
                    u.nome_usuario, u.sobrenome_usuario
                ORDER BY 
                    [Total de Pedidos] DESC;");
        }

        private void LoadData(string query)
        {
            dataGridViewPedidos.DataSource = null;
            dataGridViewPedidos.Rows.Clear();

            try
            {
                DataTable dataTable = conexao.executarSQL(query);
                dataGridViewPedidos.DataSource = dataTable;
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
                ExportacaoUtil.ExportarTabela(dataGridViewPedidos);
            }
            else if (radioButtonPDF.Checked)
            {
                ExportacaoUtil.ExportarPDF(dataGridViewPedidos);
            }
            else
            {
                MessageBox.Show("Selecione um formato de exportação.");
            }
        }

        public void FormatardataGridViewPedidos()
        {
            dataGridViewPedidos.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridViewPedidos.AllowUserToAddRows = false; // ESCONDE A NOVA LINHA DO GRID
            dataGridViewPedidos.AllowUserToDeleteRows = false;
            dataGridViewPedidos.RowHeadersVisible = false; // ESCONDE O PONTEIRO DO GRID
            dataGridViewPedidos.ReadOnly = true;

            dataGridViewPedidos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewPedidos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewPedidos.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridViewPedidos.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewPedidos.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewPedidos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridViewPedidos.MultiSelect = false;
            dataGridViewPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPedidos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                string filter = txtSearch.Text.Trim().Replace("'", "''"); // Escapar aspas simples e remover espaços extras
                DataView dv = new DataView(dt);
                string filterString = "";

                if (int.TryParse(filter, out _)) // É um número inteiro
                {
                    // Filtro para colunas numéricas
                    filterString = $"[Código do Usuário] = {filter} OR [Código do Produto] = {filter} OR [Número do Pedido] = {filter}";
                }
                else // É texto genérico
                {
                    // Filtro para colunas de texto
                    filterString = $@"
                    [Nome do Usuário] LIKE '%{filter}%' OR 
                    [Sobrenome do Usuário] LIKE '%{filter}%' OR 
                    [Nome do Produto] LIKE '%{filter}%'";
                }

                try
                {
                    dv.RowFilter = filterString;
                    dataGridViewPedidos.DataSource = dv;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao aplicar filtro: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Nenhum dado disponível para filtrar.");
            }
        }
    }
}