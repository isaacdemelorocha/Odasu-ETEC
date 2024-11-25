namespace Odasu_MySQL.Forms
{
    partial class CONFIGURACOES
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
            this.btnInativar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtCel = new System.Windows.Forms.MaskedTextBox();
            this.txtDtNasc = new System.Windows.Forms.MaskedTextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtSenha2 = new System.Windows.Forms.TextBox();
            this.txtSenha1 = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSobrenome = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblSenha2 = new System.Windows.Forms.Label();
            this.lblSenha1 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblCel = new System.Windows.Forms.Label();
            this.lblDtNasc = new System.Windows.Forms.Label();
            this.lblCPF = new System.Windows.Forms.Label();
            this.lblSobrenome = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInativar
            // 
            this.btnInativar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInativar.Location = new System.Drawing.Point(1042, 695);
            this.btnInativar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInativar.Name = "btnInativar";
            this.btnInativar.Size = new System.Drawing.Size(120, 39);
            this.btnInativar.TabIndex = 39;
            this.btnInativar.Text = "INATIVAR";
            this.btnInativar.UseVisualStyleBackColor = true;
            this.btnInativar.Click += new System.EventHandler(this.btnInativar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Location = new System.Drawing.Point(916, 695);
            this.btnAtualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(120, 39);
            this.btnAtualizar.TabIndex = 38;
            this.btnAtualizar.Text = "ATUALIZAR";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Location = new System.Drawing.Point(791, 695);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(120, 39);
            this.btnLimpar.TabIndex = 37;
            this.btnLimpar.Text = "LIMPAR";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.BackColor = System.Drawing.Color.White;
            this.lblID.Font = new System.Drawing.Font("Arial", 13F);
            this.lblID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblID.Location = new System.Drawing.Point(862, 196);
            this.lblID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblID.Name = "lblID";
            this.lblID.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.lblID.Size = new System.Drawing.Size(22, 45);
            this.lblID.TabIndex = 36;
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblCodigo.Location = new System.Drawing.Point(535, 196);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.lblCodigo.Size = new System.Drawing.Size(115, 49);
            this.lblCodigo.TabIndex = 35;
            this.lblCodigo.Text = "Código";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Location = new System.Drawing.Point(666, 695);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(120, 39);
            this.btnPesquisar.TabIndex = 34;
            this.btnPesquisar.Text = "PESQUISAR";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtCel
            // 
            this.txtCel.Font = new System.Drawing.Font("Arial", 13F);
            this.txtCel.Location = new System.Drawing.Point(862, 462);
            this.txtCel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCel.Mask = "(00)00000-0000";
            this.txtCel.Name = "txtCel";
            this.txtCel.Size = new System.Drawing.Size(300, 32);
            this.txtCel.TabIndex = 27;
            // 
            // txtDtNasc
            // 
            this.txtDtNasc.Font = new System.Drawing.Font("Arial", 13F);
            this.txtDtNasc.Location = new System.Drawing.Point(862, 409);
            this.txtDtNasc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDtNasc.Mask = "00/00/0000";
            this.txtDtNasc.Name = "txtDtNasc";
            this.txtDtNasc.Size = new System.Drawing.Size(300, 32);
            this.txtDtNasc.TabIndex = 25;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrar.Location = new System.Drawing.Point(540, 695);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(120, 39);
            this.btnCadastrar.TabIndex = 33;
            this.btnCadastrar.Text = "CADASTRAR";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // txtCPF
            // 
            this.txtCPF.Font = new System.Drawing.Font("Arial", 13F);
            this.txtCPF.Location = new System.Drawing.Point(862, 356);
            this.txtCPF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(300, 32);
            this.txtCPF.TabIndex = 23;
            // 
            // txtSenha2
            // 
            this.txtSenha2.Font = new System.Drawing.Font("Arial", 13F);
            this.txtSenha2.Location = new System.Drawing.Point(862, 621);
            this.txtSenha2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSenha2.MaxLength = 255;
            this.txtSenha2.Name = "txtSenha2";
            this.txtSenha2.PasswordChar = '*';
            this.txtSenha2.Size = new System.Drawing.Size(300, 32);
            this.txtSenha2.TabIndex = 32;
            // 
            // txtSenha1
            // 
            this.txtSenha1.Font = new System.Drawing.Font("Arial", 13F);
            this.txtSenha1.Location = new System.Drawing.Point(862, 568);
            this.txtSenha1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSenha1.MaxLength = 255;
            this.txtSenha1.Name = "txtSenha1";
            this.txtSenha1.PasswordChar = '*';
            this.txtSenha1.Size = new System.Drawing.Size(300, 32);
            this.txtSenha1.TabIndex = 31;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Arial", 13F);
            this.txtEmail.Location = new System.Drawing.Point(862, 515);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 32);
            this.txtEmail.TabIndex = 29;
            // 
            // txtSobrenome
            // 
            this.txtSobrenome.Font = new System.Drawing.Font("Arial", 13F);
            this.txtSobrenome.Location = new System.Drawing.Point(862, 303);
            this.txtSobrenome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSobrenome.MaxLength = 100;
            this.txtSobrenome.Name = "txtSobrenome";
            this.txtSobrenome.Size = new System.Drawing.Size(300, 32);
            this.txtSobrenome.TabIndex = 21;
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Arial", 13F);
            this.txtNome.Location = new System.Drawing.Point(862, 249);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(300, 32);
            this.txtNome.TabIndex = 18;
            this.txtNome.Tag = "";
            // 
            // lblSenha2
            // 
            this.lblSenha2.AutoSize = true;
            this.lblSenha2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblSenha2.Location = new System.Drawing.Point(535, 620);
            this.lblSenha2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSenha2.Name = "lblSenha2";
            this.lblSenha2.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.lblSenha2.Size = new System.Drawing.Size(209, 49);
            this.lblSenha2.TabIndex = 30;
            this.lblSenha2.Text = "Repita a Senha";
            // 
            // lblSenha1
            // 
            this.lblSenha1.AutoSize = true;
            this.lblSenha1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblSenha1.Location = new System.Drawing.Point(535, 567);
            this.lblSenha1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSenha1.Name = "lblSenha1";
            this.lblSenha1.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.lblSenha1.Size = new System.Drawing.Size(108, 49);
            this.lblSenha1.TabIndex = 28;
            this.lblSenha1.Text = "Senha";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblEmail.Location = new System.Drawing.Point(535, 514);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.lblEmail.Size = new System.Drawing.Size(108, 49);
            this.lblEmail.TabIndex = 26;
            this.lblEmail.Text = "E-mail";
            // 
            // lblCel
            // 
            this.lblCel.AutoSize = true;
            this.lblCel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblCel.Location = new System.Drawing.Point(535, 461);
            this.lblCel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblCel.Name = "lblCel";
            this.lblCel.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.lblCel.Size = new System.Drawing.Size(115, 49);
            this.lblCel.TabIndex = 24;
            this.lblCel.Text = "Celular";
            // 
            // lblDtNasc
            // 
            this.lblDtNasc.AutoSize = true;
            this.lblDtNasc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblDtNasc.Location = new System.Drawing.Point(535, 408);
            this.lblDtNasc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblDtNasc.Name = "lblDtNasc";
            this.lblDtNasc.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.lblDtNasc.Size = new System.Drawing.Size(265, 49);
            this.lblDtNasc.TabIndex = 22;
            this.lblDtNasc.Text = "Data de Nascimento";
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblCPF.Location = new System.Drawing.Point(535, 355);
            this.lblCPF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.lblCPF.Size = new System.Drawing.Size(85, 49);
            this.lblCPF.TabIndex = 20;
            this.lblCPF.Text = "CPF";
            // 
            // lblSobrenome
            // 
            this.lblSobrenome.AutoSize = true;
            this.lblSobrenome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblSobrenome.Location = new System.Drawing.Point(535, 302);
            this.lblSobrenome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSobrenome.Name = "lblSobrenome";
            this.lblSobrenome.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.lblSobrenome.Size = new System.Drawing.Size(166, 49);
            this.lblSobrenome.TabIndex = 19;
            this.lblSobrenome.Text = "Sobrenome";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblNome.Location = new System.Drawing.Point(535, 249);
            this.lblNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblNome.Name = "lblNome";
            this.lblNome.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.lblNome.Size = new System.Drawing.Size(103, 49);
            this.lblNome.TabIndex = 17;
            this.lblNome.Text = "Nome";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.label1.Location = new System.Drawing.Point(473, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(740, 740);
            this.label1.TabIndex = 40;
            // 
            // CONFIGURACOES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnInativar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtCel);
            this.Controls.Add(this.txtDtNasc);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.txtSenha2);
            this.Controls.Add(this.txtSenha1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtSobrenome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblSenha2);
            this.Controls.Add(this.lblSenha1);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblCel);
            this.Controls.Add(this.lblDtNasc);
            this.Controls.Add(this.lblCPF);
            this.Controls.Add(this.lblSobrenome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CONFIGURACOES";
            this.Text = "CONFIGURAÇÕES";
            this.Load += new System.EventHandler(this.CADASTRO_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInativar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.MaskedTextBox txtCel;
        private System.Windows.Forms.MaskedTextBox txtDtNasc;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.TextBox txtSenha2;
        private System.Windows.Forms.TextBox txtSenha1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSobrenome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblSenha2;
        private System.Windows.Forms.Label lblSenha1;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblCel;
        private System.Windows.Forms.Label lblDtNasc;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.Label lblSobrenome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label1;
    }
}