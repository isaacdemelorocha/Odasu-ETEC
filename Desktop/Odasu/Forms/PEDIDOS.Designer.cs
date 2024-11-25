namespace Odasu_MySQL.Forms
{
    partial class PEDIDOS
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
            this.dataGridViewPedidos = new System.Windows.Forms.DataGridView();
            this.lblRelatorio = new System.Windows.Forms.Label();
            this.btnPedData = new System.Windows.Forms.Button();
            this.btnPedProduto = new System.Windows.Forms.Button();
            this.btnPedUsuario = new System.Windows.Forms.Button();
            this.radioButtonPDF = new System.Windows.Forms.RadioButton();
            this.radioButtonTabela = new System.Windows.Forms.RadioButton();
            this.radioButtonNao = new System.Windows.Forms.RadioButton();
            this.lblExportar = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPedidos
            // 
            this.dataGridViewPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPedidos.Location = new System.Drawing.Point(535, 55);
            this.dataGridViewPedidos.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewPedidos.Name = "dataGridViewPedidos";
            this.dataGridViewPedidos.RowHeadersWidth = 51;
            this.dataGridViewPedidos.Size = new System.Drawing.Size(467, 431);
            this.dataGridViewPedidos.TabIndex = 27;
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
            // btnPedData
            // 
            this.btnPedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPedData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedData.Location = new System.Drawing.Point(339, 494);
            this.btnPedData.Margin = new System.Windows.Forms.Padding(4);
            this.btnPedData.Name = "btnPedData";
            this.btnPedData.Size = new System.Drawing.Size(160, 49);
            this.btnPedData.TabIndex = 16;
            this.btnPedData.Text = "DATA";
            this.btnPedData.UseVisualStyleBackColor = true;
            this.btnPedData.Click += new System.EventHandler(this.btnPedStatus_Click);
            // 
            // btnPedProduto
            // 
            this.btnPedProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPedProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedProduto.Location = new System.Drawing.Point(507, 494);
            this.btnPedProduto.Margin = new System.Windows.Forms.Padding(4);
            this.btnPedProduto.Name = "btnPedProduto";
            this.btnPedProduto.Size = new System.Drawing.Size(160, 49);
            this.btnPedProduto.TabIndex = 15;
            this.btnPedProduto.Text = "PRODUTO";
            this.btnPedProduto.UseVisualStyleBackColor = true;
            this.btnPedProduto.Click += new System.EventHandler(this.btnPedProduto_Click);
            // 
            // btnPedUsuario
            // 
            this.btnPedUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPedUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedUsuario.Location = new System.Drawing.Point(675, 494);
            this.btnPedUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.btnPedUsuario.Name = "btnPedUsuario";
            this.btnPedUsuario.Size = new System.Drawing.Size(160, 49);
            this.btnPedUsuario.TabIndex = 14;
            this.btnPedUsuario.Text = "USUÁRIO";
            this.btnPedUsuario.UseVisualStyleBackColor = true;
            this.btnPedUsuario.Click += new System.EventHandler(this.btnPedUsuario_Click);
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
            this.btnExportar.Location = new System.Drawing.Point(843, 494);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(160, 49);
            this.btnExportar.TabIndex = 49;
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
            this.txtSearch.TabIndex = 52;
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
            this.lblPesquisar.TabIndex = 51;
            this.lblPesquisar.Text = "Pesquisar";
            // 
            // PEDIDOS
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
            this.Controls.Add(this.dataGridViewPedidos);
            this.Controls.Add(this.lblRelatorio);
            this.Controls.Add(this.btnPedData);
            this.Controls.Add(this.btnPedProduto);
            this.Controls.Add(this.btnPedUsuario);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PEDIDOS";
            this.Text = "PEDIDOS";
            this.Load += new System.EventHandler(this.PEDIDOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPedidos;
        private System.Windows.Forms.Label lblRelatorio;
        private System.Windows.Forms.Button btnPedData;
        private System.Windows.Forms.Button btnPedProduto;
        private System.Windows.Forms.Button btnPedUsuario;
        private System.Windows.Forms.RadioButton radioButtonPDF;
        private System.Windows.Forms.RadioButton radioButtonTabela;
        private System.Windows.Forms.RadioButton radioButtonNao;
        private System.Windows.Forms.Label lblExportar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblPesquisar;
    }
}