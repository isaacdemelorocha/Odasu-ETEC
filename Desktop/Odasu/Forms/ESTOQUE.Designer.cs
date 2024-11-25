namespace Odasu_MySQL.Forms
{
    partial class ESTOQUE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewEstoque = new System.Windows.Forms.DataGridView();
            this.radioButtonNao = new System.Windows.Forms.RadioButton();
            this.lblExportar = new System.Windows.Forms.Label();
            this.lblRelatorio = new System.Windows.Forms.Label();
            this.btnEstqCategoria = new System.Windows.Forms.Button();
            this.btnEstqAtivo = new System.Windows.Forms.Button();
            this.btnEstqInativo = new System.Windows.Forms.Button();
            this.radioButtonTabela = new System.Windows.Forms.RadioButton();
            this.radioButtonPDF = new System.Windows.Forms.RadioButton();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEstoque
            // 
            this.dataGridViewEstoque.AllowUserToAddRows = false;
            this.dataGridViewEstoque.AllowUserToDeleteRows = false;
            this.dataGridViewEstoque.AllowUserToOrderColumns = true;
            this.dataGridViewEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEstoque.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewEstoque.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEstoque.Location = new System.Drawing.Point(533, 55);
            this.dataGridViewEstoque.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewEstoque.Name = "dataGridViewEstoque";
            this.dataGridViewEstoque.RowHeadersWidth = 51;
            this.dataGridViewEstoque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEstoque.Size = new System.Drawing.Size(469, 431);
            this.dataGridViewEstoque.TabIndex = 41;
            // 
            // radioButtonNao
            // 
            this.radioButtonNao.AutoSize = true;
            this.radioButtonNao.Checked = true;
            this.radioButtonNao.Location = new System.Drawing.Point(73, 214);
            this.radioButtonNao.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonNao.Name = "radioButtonNao";
            this.radioButtonNao.Size = new System.Drawing.Size(57, 20);
            this.radioButtonNao.TabIndex = 39;
            this.radioButtonNao.TabStop = true;
            this.radioButtonNao.Text = "NÃO";
            this.radioButtonNao.UseVisualStyleBackColor = true;
            // 
            // lblExportar
            // 
            this.lblExportar.AutoSize = true;
            this.lblExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportar.Location = new System.Drawing.Point(67, 162);
            this.lblExportar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExportar.Name = "lblExportar";
            this.lblExportar.Size = new System.Drawing.Size(121, 29);
            this.lblExportar.TabIndex = 38;
            this.lblExportar.Text = "Exportar?";
            // 
            // lblRelatorio
            // 
            this.lblRelatorio.AutoSize = true;
            this.lblRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelatorio.Location = new System.Drawing.Point(528, 11);
            this.lblRelatorio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRelatorio.Name = "lblRelatorio";
            this.lblRelatorio.Size = new System.Drawing.Size(114, 29);
            this.lblRelatorio.TabIndex = 37;
            this.lblRelatorio.Text = "Relatório";
            // 
            // btnEstqCategoria
            // 
            this.btnEstqCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEstqCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstqCategoria.Location = new System.Drawing.Point(338, 494);
            this.btnEstqCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.btnEstqCategoria.Name = "btnEstqCategoria";
            this.btnEstqCategoria.Size = new System.Drawing.Size(160, 49);
            this.btnEstqCategoria.TabIndex = 30;
            this.btnEstqCategoria.Text = "CATEGORIA";
            this.btnEstqCategoria.UseVisualStyleBackColor = true;
            this.btnEstqCategoria.Click += new System.EventHandler(this.btnRelEst_Click);
            // 
            // btnEstqAtivo
            // 
            this.btnEstqAtivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEstqAtivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstqAtivo.Location = new System.Drawing.Point(506, 494);
            this.btnEstqAtivo.Margin = new System.Windows.Forms.Padding(4);
            this.btnEstqAtivo.Name = "btnEstqAtivo";
            this.btnEstqAtivo.Size = new System.Drawing.Size(160, 49);
            this.btnEstqAtivo.TabIndex = 29;
            this.btnEstqAtivo.Text = "ATIVO";
            this.btnEstqAtivo.UseVisualStyleBackColor = true;
            this.btnEstqAtivo.Click += new System.EventHandler(this.btnEstqAtivo_Click);
            // 
            // btnEstqInativo
            // 
            this.btnEstqInativo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEstqInativo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstqInativo.Location = new System.Drawing.Point(674, 494);
            this.btnEstqInativo.Margin = new System.Windows.Forms.Padding(4);
            this.btnEstqInativo.Name = "btnEstqInativo";
            this.btnEstqInativo.Size = new System.Drawing.Size(160, 49);
            this.btnEstqInativo.TabIndex = 28;
            this.btnEstqInativo.Text = "INATIVO";
            this.btnEstqInativo.UseVisualStyleBackColor = true;
            this.btnEstqInativo.Click += new System.EventHandler(this.btnEstqInativo_Click);
            // 
            // radioButtonTabela
            // 
            this.radioButtonTabela.AutoSize = true;
            this.radioButtonTabela.Location = new System.Drawing.Point(73, 242);
            this.radioButtonTabela.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonTabela.Name = "radioButtonTabela";
            this.radioButtonTabela.Size = new System.Drawing.Size(55, 20);
            this.radioButtonTabela.TabIndex = 42;
            this.radioButtonTabela.Text = "CSV";
            this.radioButtonTabela.UseVisualStyleBackColor = true;
            // 
            // radioButtonPDF
            // 
            this.radioButtonPDF.AutoSize = true;
            this.radioButtonPDF.Location = new System.Drawing.Point(72, 270);
            this.radioButtonPDF.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonPDF.Name = "radioButtonPDF";
            this.radioButtonPDF.Size = new System.Drawing.Size(55, 20);
            this.radioButtonPDF.TabIndex = 43;
            this.radioButtonPDF.Text = "PDF";
            this.radioButtonPDF.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Location = new System.Drawing.Point(842, 494);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(160, 49);
            this.btnExportar.TabIndex = 44;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblPesquisar.Location = new System.Drawing.Point(68, 55);
            this.lblPesquisar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(126, 29);
            this.lblPesquisar.TabIndex = 31;
            this.lblPesquisar.Text = "Pesquisar";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtSearch.Location = new System.Drawing.Point(73, 88);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(374, 27);
            this.txtSearch.TabIndex = 32;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // ESTOQUE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.radioButtonPDF);
            this.Controls.Add(this.radioButtonTabela);
            this.Controls.Add(this.dataGridViewEstoque);
            this.Controls.Add(this.radioButtonNao);
            this.Controls.Add(this.lblExportar);
            this.Controls.Add(this.lblRelatorio);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.btnEstqCategoria);
            this.Controls.Add(this.btnEstqAtivo);
            this.Controls.Add(this.btnEstqInativo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ESTOQUE";
            this.Text = "ESTOQUE";
            this.Load += new System.EventHandler(this.ESTOQUE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEstoque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewEstoque;
        private System.Windows.Forms.RadioButton radioButtonNao;
        private System.Windows.Forms.Label lblExportar;
        private System.Windows.Forms.Label lblRelatorio;
        private System.Windows.Forms.Button btnEstqCategoria;
        private System.Windows.Forms.Button btnEstqAtivo;
        private System.Windows.Forms.Button btnEstqInativo;
        private System.Windows.Forms.RadioButton radioButtonTabela;
        private System.Windows.Forms.RadioButton radioButtonPDF;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.TextBox txtSearch;
    }
}