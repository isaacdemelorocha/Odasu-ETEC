using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odasu_MySQL.Forms
{
    public partial class CLIENTES : Form
    {
        private ClasseConexao conexao = new ClasseConexao();
        DataTable dt = new DataTable();

        public CLIENTES()
        {
            InitializeComponent();
        }

        private void CONFIGURAÇÕES_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadInitialUser();
            FormatarDataGridViewClientes();
        }

        private void LoadInitialUser()
        {
            dataGridViewCliente.DataSource = null;
            dataGridViewCliente.Rows.Clear();

            string query = @"
                SELECT 
                    cod_usuario AS [Código do Usuário],
                    nome_usuario AS [Nome],
                    sobrenome_usuario AS [Sobrenome],
                    cpf_usuario AS [CPF],
                    nasc_usuario AS [Data de Nascimento],
                    cel_usuario AS [Celular],
                    email_usuario AS [Email],
                    status_usuario AS [Status],
                    tipo_conta AS [Tipo de Conta],
                    data_cadastro AS [Data de Cadastro]
                FROM tb_usuario;";

            try
            {
                DataTable dataTable = conexao.executarSQL(query);
                if (dataTable != null)
                {
                    dataGridViewCliente.DataSource = dataTable;
                    dt = dataTable;
                }
                else
                {
                    MessageBox.Show("Nenhum dado encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private void LoadTheme()
        {
            foreach (Control btn in this.Controls)
            {
                if (btn is Button)
                {
                    Button button = (Button)btn;
                    button.BackColor = Colorir.PrimaryColor;
                    button.ForeColor = Color.White;
                    button.FlatAppearance.BorderColor = Colorir.SecondaryColor;
                }
            }
            lblRelatorio.ForeColor = Colorir.SecondaryColor;
            lblExportar.ForeColor = Colorir.PrimaryColor;
            lblPesquisar.ForeColor = Colorir.PrimaryColor;
        }

        private void btnIdade_Click(object sender, EventArgs e)
        {
            RelatorioIdadeUsuarios();
        }

        public void RelatorioTotalUsuariosPorStatus()
        {
            string query = @"
                SELECT 
                    status_usuario AS [Status],
                    COUNT(*) AS [Total de Usuários]
                FROM 
                    tb_usuario
                GROUP BY 
                    status_usuario
                ORDER BY 
                    [Total de Usuários] DESC;";

            FillDataGridView(query);
        }

        public void RelatorioIdadeUsuarios()
        {
            string query = @"
                WITH FaixasEtarias AS (
                    SELECT 
                        CASE 
                            WHEN DATEDIFF(YEAR, nasc_usuario, GETDATE()) < 18 THEN 'Menores de 18'
                            WHEN DATEDIFF(YEAR, nasc_usuario, GETDATE()) BETWEEN 18 AND 24 THEN '18-24 anos'
                            WHEN DATEDIFF(YEAR, nasc_usuario, GETDATE()) BETWEEN 25 AND 34 THEN '25-34 anos'
                            WHEN DATEDIFF(YEAR, nasc_usuario, GETDATE()) BETWEEN 35 AND 44 THEN '35-44 anos'
                            WHEN DATEDIFF(YEAR, nasc_usuario, GETDATE()) BETWEEN 45 AND 54 THEN '45-54 anos'
                            WHEN DATEDIFF(YEAR, nasc_usuario, GETDATE()) >= 55 THEN '55 anos ou mais'
                        END AS faixa_etaria
                    FROM 
                        tb_usuario
                )
                SELECT 
                    faixa_etaria AS [Faixa Etária],
                    COUNT(*) AS [Total de Usuários]
                FROM 
                    FaixasEtarias
                GROUP BY 
                    faixa_etaria
                ORDER BY 
                    [Total de Usuários] DESC;";

            FillDataGridView(query);
        }

        public void RelatorioUsuariosPorTipoConta()
        {
            string query = @"
                SELECT 
                    tipo_conta AS [Tipo de Conta],
                    COUNT(*) AS [Total de Usuários]
                FROM 
                    tb_usuario
                GROUP BY 
                    tipo_conta
                ORDER BY 
                    [Total de Usuários] DESC;";

            FillDataGridView(query);
        }

        private void FillDataGridView(string query)
        {
            try
            {
                DataTable dataTable = conexao.executarSQL(query);
                if (dataTable != null)
                {
                    dataGridViewCliente.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Nenhum dado encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            RelatorioTotalUsuariosPorStatus();
        }

        private void btnTipo_Click(object sender, EventArgs e)
        {
            RelatorioUsuariosPorTipoConta();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (radioButtonTabela.Checked)
            {
                ExportacaoUtil.ExportarTabela(dataGridViewCliente);
            }
            else if (radioButtonPDF.Checked)
            {
                ExportacaoUtil.ExportarPDF(dataGridViewCliente);
            }
            else
            {
                MessageBox.Show("Selecione um formato de exportação.");
            }
        }

        public void FormatarDataGridViewClientes()
        {
            dataGridViewCliente.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridViewCliente.AllowUserToAddRows = false; // ESCONDE A NOVA LINHA DO GRID
            dataGridViewCliente.AllowUserToDeleteRows = false;
            dataGridViewCliente.RowHeadersVisible = false; // ESCONDE O PONTEIRO DO GRID
            dataGridViewCliente.ReadOnly = true;

            dataGridViewCliente.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewCliente.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCliente.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridViewCliente.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewCliente.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewCliente.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridViewCliente.MultiSelect = false;
            dataGridViewCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCliente.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridViewCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dt != null)
            {
                string filter = txtSearch.Text.Trim().Replace("'", "''"); // Escapar aspas simples e remover espaços extras
                DataView dv = new DataView(dt);
                string filterString = "";

                if (filter.Equals("CLIENT", StringComparison.OrdinalIgnoreCase) ||
                    filter.Equals("ADM", StringComparison.OrdinalIgnoreCase))
                {
                    // Filtro para a coluna de Tipo
                    filterString = $"[Tipo de Conta] = '{filter.ToUpper()}'";

                }else if ( filter.Equals("ONLINE", StringComparison.OrdinalIgnoreCase) ||
                           filter.Equals("OFFLINE", StringComparison.OrdinalIgnoreCase))
                {
                    filterString = $"[Status] = '{filter.ToUpper()}'"; //Filtro para Status da Conta
                }
                else if (filter.Length == 11 && long.TryParse(filter, out _)) // CPF sem máscara (11 dígitos numéricos)
                {
                    // Filtro para CPF sem máscara
                    filterString = $"[CPF] LIKE '%{filter}%'";
                }
                else if (filter.Length == 14 && filter.Contains(".") && filter.Contains("-")) // CPF com máscara (XXX.XXX.XXX-XX)
                {
                    // Filtro para CPF com máscara
                    filterString = $"[CPF] LIKE '%{filter}%'";
                }
                else if (int.TryParse(filter, out _)) // É um número inteiro
                {
                    // Filtro para colunas numéricas
                    filterString = $"CONVERT([Código do Usuário], 'System.String') LIKE '%{filter}%'";
                }
                else if (DateTime.TryParse(filter, out _)) // É uma data válida
                {
                    // Filtro para colunas de data
                    filterString = $"CONVERT([Data de Nascimento], 'System.String') LIKE '%{filter}%'";
                }
                else // É texto genérico
                {
                    // Filtro para colunas de texto
                    filterString = $@"
                [Nome] LIKE '%{filter}%' OR 
                [Email] LIKE '%{filter}%' OR 
                [Sobrenome] LIKE '%{filter}%'";
                }

                try
                {
                    dv.RowFilter = filterString;
                    dataGridViewCliente.DataSource = dv;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao aplicar filtro: {ex.Message}");
                }
            }
        }


    }
}
