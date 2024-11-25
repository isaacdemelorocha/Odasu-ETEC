namespace Odasu_MySQL.Forms
{
    partial class FATURAMENTO
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
            this.lblRelatorio = new System.Windows.Forms.Label();
            this.btnFatTotal = new System.Windows.Forms.Button();
            this.btnFatCategoria = new System.Windows.Forms.Button();
            this.btnFatUsuario = new System.Windows.Forms.Button();
            this.dataGridViewFaturamento = new System.Windows.Forms.DataGridView();
            this.radioButtonPDF = new System.Windows.Forms.RadioButton();
            this.radioButtonTabela = new System.Windows.Forms.RadioButton();
            this.radioButtonNao = new System.Windows.Forms.RadioButton();
            this.lblExportar = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaturamento)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRelatorio
            // 
            this.lblRelatorio.AutoSize = true;
            this.lblRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelatorio.Location = new System.Drawing.Point(528, 11);
            this.lblRelatorio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRelatorio.Name = "lblRelatorio";
            this.lblRelatorio.Size = new System.Drawing.Size(114, 29);
            this.lblRelatorio.TabIndex = 23;
            this.lblRelatorio.Text = "Relatório";
            // 
            // btnFatTotal
            // 
            this.btnFatTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFatTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFatTotal.Location = new System.Drawing.Point(340, 494);
            this.btnFatTotal.Margin = new System.Windows.Forms.Padding(4);
            this.btnFatTotal.Name = "btnFatTotal";
            this.btnFatTotal.Size = new System.Drawing.Size(160, 49);
            this.btnFatTotal.TabIndex = 16;
            this.btnFatTotal.Text = "TOTAL";
            this.btnFatTotal.UseVisualStyleBackColor = true;
            this.btnFatTotal.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnFatCategoria
            // 
            this.btnFatCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFatCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFatCategoria.Location = new System.Drawing.Point(508, 494);
            this.btnFatCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.btnFatCategoria.Name = "btnFatCategoria";
            this.btnFatCategoria.Size = new System.Drawing.Size(160, 49);
            this.btnFatCategoria.TabIndex = 15;
            this.btnFatCategoria.Text = "CATEGORIA";
            this.btnFatCategoria.UseVisualStyleBackColor = true;
            this.btnFatCategoria.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnFatUsuario
            // 
            this.btnFatUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFatUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFatUsuario.Location = new System.Drawing.Point(676, 494);
            this.btnFatUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.btnFatUsuario.Name = "btnFatUsuario";
            this.btnFatUsuario.Size = new System.Drawing.Size(160, 49);
            this.btnFatUsuario.TabIndex = 14;
            this.btnFatUsuario.Text = "USUÁRIO";
            this.btnFatUsuario.UseVisualStyleBackColor = true;
            this.btnFatUsuario.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewFaturamento
            // 
            this.dataGridViewFaturamento.AllowUserToAddRows = false;
            this.dataGridViewFaturamento.AllowUserToDeleteRows = false;
            this.dataGridViewFaturamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFaturamento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewFaturamento.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewFaturamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFaturamento.Location = new System.Drawing.Point(535, 55);
            this.dataGridViewFaturamento.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewFaturamento.Name = "dataGridViewFaturamento";
            this.dataGridViewFaturamento.ReadOnly = true;
            this.dataGridViewFaturamento.RowHeadersWidth = 51;
            this.dataGridViewFaturamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFaturamento.Size = new System.Drawing.Size(469, 431);
            this.dataGridViewFaturamento.TabIndex = 42;
            // 
            // radioButtonPDF
            // 
            this.radioButtonPDF.AutoSize = true;
            this.radioButtonPDF.Location = new System.Drawing.Point(72, 270);
            this.radioButtonPDF.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonPDF.Name = "radioButtonPDF";
            this.radioButtonPDF.Size = new System.Drawing.Size(55, 20);
            this.radioButtonPDF.TabIndex = 47;
            this.radioButtonPDF.Text = "PDF";
            this.radioButtonPDF.UseVisualStyleBackColor = true;
            // 
            // radioButtonTabela
            // 
            this.radioButtonTabela.AutoSize = true;
            this.radioButtonTabela.Location = new System.Drawing.Point(73, 242);
            this.radioButtonTabela.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonTabela.Name = "radioButtonTabela";
            this.radioButtonTabela.Size = new System.Drawing.Size(55, 20);
            this.radioButtonTabela.TabIndex = 46;
            this.radioButtonTabela.Text = "CSV";
            this.radioButtonTabela.UseVisualStyleBackColor = true;
            // 
            // radioButtonNao
            // 
            this.radioButtonNao.AutoSize = true;
            this.radioButtonNao.Checked = true;
            this.radioButtonNao.Location = new System.Drawing.Point(73, 214);
            this.radioButtonNao.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonNao.Name = "radioButtonNao";
            this.radioButtonNao.Size = new System.Drawing.Size(57, 20);
            this.radioButtonNao.TabIndex = 45;
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
            this.lblExportar.TabIndex = 44;
            this.lblExportar.Text = "Exportar?";
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Location = new System.Drawing.Point(844, 494);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(160, 49);
            this.btnExportar.TabIndex = 48;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtSearch.Location = new System.Drawing.Point(73, 88);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(374, 27);
            this.txtSearch.TabIndex = 50;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblPesquisar.Location = new System.Drawing.Point(68, 55);
            this.lblPesquisar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(126, 29);
            this.lblPesquisar.TabIndex = 49;
            this.lblPesquisar.Text = "Pesquisar";
            // 
            // FATURAMENTO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.radioButtonPDF);
            this.Controls.Add(this.radioButtonTabela);
            this.Controls.Add(this.radioButtonNao);
            this.Controls.Add(this.lblExportar);
            this.Controls.Add(this.dataGridViewFaturamento);
            this.Controls.Add(this.lblRelatorio);
            this.Controls.Add(this.btnFatTotal);
            this.Controls.Add(this.btnFatCategoria);
            this.Controls.Add(this.btnFatUsuario);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FATURAMENTO";
            this.Text = "FATURAMENTO";
            this.Load += new System.EventHandler(this.FATURAMENTO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaturamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRelatorio;
        private System.Windows.Forms.Button btnFatTotal;
        private System.Windows.Forms.Button btnFatCategoria;
        private System.Windows.Forms.Button btnFatUsuario;
        private System.Windows.Forms.DataGridView dataGridViewFaturamento;
        private System.Windows.Forms.RadioButton radioButtonPDF;
        private System.Windows.Forms.RadioButton radioButtonTabela;
        private System.Windows.Forms.RadioButton radioButtonNao;
        private System.Windows.Forms.Label lblExportar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblPesquisar;
    }
}