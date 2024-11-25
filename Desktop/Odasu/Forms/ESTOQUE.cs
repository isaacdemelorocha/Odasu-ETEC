using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Odasu_MySQL.Forms
{
    public partial class ESTOQUE : Form
    {
        private ClasseConexao conexao = new ClasseConexao();
        DataTable dt = new DataTable();

        public ESTOQUE()
        {
            InitializeComponent();
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
            lblPesquisar.ForeColor = Colorir.PrimaryColor;
        }

        private void ESTOQUE_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadInitialStock();
            FormatardataGridViewEstoque();
        }

        private void LoadInitialStock()
        {
            dataGridViewEstoque.DataSource = null;
            dataGridViewEstoque.Rows.Clear();

            string query = @"
                SELECT 
                    cod_produto AS [Código do Produto],
                    nome_produto AS [Nome do Produto],
                    descricao_produto AS [Descrição],
                    preco_produto AS [Preço],
                    status_produto AS [Status],
                    cod_categoria_produto AS [Código da Categoria]
                FROM tb_produto";

            try
            {
                dt = conexao.executarSQL(query); // Atualiza o DataTable global
                dataGridViewEstoque.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private void GerarRelatorioEstoque()
        {
            dataGridViewEstoque.DataSource = null;
            dataGridViewEstoque.Rows.Clear();

            string query = @"
                     SELECT 
    c.nome_categoria AS [Categoria],
    COUNT(p.cod_produto) AS [Total de Produtos],
    p.nome_produto AS [Nome do Produto],
    p.descricao_produto AS [Descrição],
    p.preco_produto AS [Preço],
    p.status_produto AS [Status],
    p.cod_produto AS [Código do Produto]
FROM tb_categoria c
LEFT JOIN tb_produto p ON c.cod_categoria = p.cod_categoria_produto
GROUP BY 
    c.nome_categoria,
    p.nome_produto,
    p.descricao_produto,
    p.preco_produto,
    p.status_produto,
    p.cod_produto
HAVING COUNT(p.cod_produto) > 0";
            try
            {
                dt = conexao.executarSQL(query); // Atualiza o DataTable global
                dataGridViewEstoque.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private void btnRelEst_Click(object sender, EventArgs e)
        {
            GerarRelatorioEstoque();
        }

        private void btnEstqAtivo_Click(object sender, EventArgs e)
        {
            LoadActiveStock();
        }

        private void LoadActiveStock()
        {
            dataGridViewEstoque.DataSource = null;
            dataGridViewEstoque.Rows.Clear();

            string query = @"
                SELECT 
                    p.cod_produto AS [Código do Produto],
                    p.nome_produto AS [Nome do Produto],
                    p.descricao_produto AS [Descrição],
                    p.preco_produto AS [Preço],
                    p.status_produto AS [Status],
                    c.nome_categoria AS [Categoria]
                FROM tb_produto p
                JOIN tb_categoria c ON p.cod_categoria_produto = c.cod_categoria
                WHERE p.status_produto = 'ATIVO'";

            try
            {
                dt = conexao.executarSQL(query); // Atualiza o DataTable global
                dataGridViewEstoque.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private void btnEstqInativo_Click(object sender, EventArgs e)
        {
            LoadInactiveStock();
        }

        private void LoadInactiveStock()
        {
            dataGridViewEstoque.DataSource = null;
            dataGridViewEstoque.Rows.Clear();

            string query = @"
                SELECT 
                    p.cod_produto AS [Código do Produto],
                    p.nome_produto AS [Nome do Produto],
                    p.descricao_produto AS [Descrição],
                    p.preco_produto AS [Preço],
                    p.status_produto AS [Status],
                    c.nome_categoria AS [Categoria]
                FROM tb_produto p
                JOIN tb_categoria c ON p.cod_categoria_produto = c.cod_categoria
                WHERE p.status_produto = 'INATIVO'";

            try
            {
                dt = conexao.executarSQL(query); // Atualiza o DataTable global
                dataGridViewEstoque.DataSource = dt;
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
                ExportacaoUtil.ExportarTabela(dataGridViewEstoque);
            }
            else if (radioButtonPDF.Checked)
            {
                ExportacaoUtil.ExportarPDF(dataGridViewEstoque);
            }
            else
            {
                MessageBox.Show("Selecione um formato de exportação.");
            }
        }

        public void FormatardataGridViewEstoque()
        {
            dataGridViewEstoque.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridViewEstoque.AllowUserToAddRows = false; // ESCONDE A NOVA LINHA DO GRID
            dataGridViewEstoque.AllowUserToDeleteRows = false;
            dataGridViewEstoque.RowHeadersVisible = false; // ESCONDE O PONTEIRO DO GRID
            dataGridViewEstoque.ReadOnly = true;

            dataGridViewEstoque.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewEstoque.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewEstoque.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridViewEstoque.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewEstoque.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewEstoque.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridViewEstoque.MultiSelect = false;
            dataGridViewEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEstoque.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridViewEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dt != null)
            {
                string filter = txtSearch.Text.Trim();
                DataView dv = new DataView(dt);
                List<string> filterConditions = new List<string>();

                bool hasCategoriaColumn = dt.Columns.Contains("Categoria");

                if (filter.Equals("ATIVO", StringComparison.OrdinalIgnoreCase) ||
                    filter.Equals("INATIVO", StringComparison.OrdinalIgnoreCase))
                {
                    filterConditions.Add($"[Status] = '{filter.ToUpper()}'");
                }
                else if (int.TryParse(filter, out _))
                {
                    filterConditions.Add($"CONVERT([Código do Produto], 'System.String') LIKE '%{filter}%'");
                }

                else if (decimal.TryParse(filter, out decimal preco))
                {
                    filterConditions.Add($"[Preço] = {preco}");
                }

                else
                {
                    filterConditions.Add($"[Nome do Produto] LIKE '%{filter}%'");
                    filterConditions.Add($"[Descrição] LIKE '%{filter}%'");

                    if (hasCategoriaColumn)
                    {
                        filterConditions.Add($"[Categoria] LIKE '%{filter}%'");
                    }
                }

                string filterString = string.Join(" OR ", filterConditions);

                try
                {
                    dv.RowFilter = filterString;
                    dataGridViewEstoque.DataSource = dv;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao aplicar filtro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
    }
    }
}