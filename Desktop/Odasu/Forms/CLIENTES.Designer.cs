namespace Odasu_MySQL.Forms
{
    partial class CLIENTES
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
            this.dataGridViewCliente = new System.Windows.Forms.DataGridView();
            this.lblRelatorio = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.btnIdade = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnTipo = new System.Windows.Forms.Button();
            this.radioButtonPDF = new System.Windows.Forms.RadioButton();
            this.radioButtonTabela = new System.Windows.Forms.RadioButton();
            this.radioButtonNao = new System.Windows.Forms.RadioButton();
            this.lblExportar = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCliente
            // 
            this.dataGridViewCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCliente.Location = new System.Drawing.Point(535, 55);
            this.dataGridViewCliente.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewCliente.Name = "dataGridViewCliente";
            this.dataGridViewCliente.RowHeadersWidth = 51;
            this.dataGridViewCliente.Size = new System.Drawing.Size(467, 431);
            this.dataGridViewCliente.TabIndex = 27;
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
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(73, 88);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(374, 27);
            this.txtSearch.TabIndex = 18;
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
            this.lblPesquisar.TabIndex = 17;
            this.lblPesquisar.Text = "Pesquisar";
            // 
            // btnIdade
            // 
            this.btnIdade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIdade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIdade.Location = new System.Drawing.Point(338, 494);
            this.btnIdade.Margin = new System.Windows.Forms.Padding(4);
            this.btnIdade.Name = "btnIdade";
            this.btnIdade.Size = new System.Drawing.Size(160, 49);
            this.btnIdade.TabIndex = 16;
            this.btnIdade.Text = "IDADE";
            this.btnIdade.UseVisualStyleBackColor = true;
            this.btnIdade.Click += new System.EventHandler(this.btnIdade_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatus.Location = new System.Drawing.Point(506, 494);
            this.btnStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(160, 49);
            this.btnStatus.TabIndex = 15;
            this.btnStatus.Text = "STATUS";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnTipo
            // 
            this.btnTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTipo.Location = new System.Drawing.Point(674, 494);
            this.btnTipo.Margin = new System.Windows.Forms.Padding(4);
            this.btnTipo.Name = "btnTipo";
            this.btnTipo.Size = new System.Drawing.Size(160, 49);
            this.btnTipo.TabIndex = 14;
            this.btnTipo.Text = "TIPO";
            this.btnTipo.UseVisualStyleBackColor = true;
            this.btnTipo.Click += new System.EventHandler(this.btnTipo_Click);
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
            this.btnExportar.Location = new System.Drawing.Point(842, 494);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(160, 49);
            this.btnExportar.TabIndex = 48;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // CLIENTES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.radioButtonPDF);
            this.Controls.Add(this.radioButtonTabela);
            this.Controls.Add(this.radioButtonNao);
            this.Controls.Add(this.lblExportar);
            this.Controls.Add(this.dataGridViewCliente);
            this.Controls.Add(this.lblRelatorio);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.btnIdade);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnTipo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CLIENTES";
            this.Text = "CLIENTES";
            this.Load += new System.EventHandler(this.CONFIGURAÇÕES_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCliente;
        private System.Windows.Forms.Label lblRelatorio;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.Button btnIdade;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnTipo;
        private System.Windows.Forms.RadioButton radioButtonPDF;
        private System.Windows.Forms.RadioButton radioButtonTabela;
        private System.Windows.Forms.RadioButton radioButtonNao;
        private System.Windows.Forms.Label lblExportar;
        private System.Windows.Forms.Button btnExportar;
    }
}