namespace SistemaProjeto_iTutor.Utilitarios
{
    partial class FormUtilitarios
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
			this.components = new System.ComponentModel.Container();
			this.usuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label14 = new System.Windows.Forms.Label();
			this.txtSenha = new System.Windows.Forms.TextBox();
			this.btnSalvar = new System.Windows.Forms.Button();
			this.btnAlterar = new System.Windows.Forms.Button();
			this.btnLimpar = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupPerfil = new System.Windows.Forms.GroupBox();
			this.rbnAdministrador = new System.Windows.Forms.RadioButton();
			this.rbnProfessor = new System.Windows.Forms.RadioButton();
			this.rbnAluno = new System.Windows.Forms.RadioButton();
			this.txtData = new System.Windows.Forms.MaskedTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbnInativo = new System.Windows.Forms.RadioButton();
			this.rbnAtivo = new System.Windows.Forms.RadioButton();
			this.dgvUsuarios = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).BeginInit();
			this.groupPerfil.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
			this.SuspendLayout();
			// 
			// usuarioBindingSource
			// 
			this.usuarioBindingSource.DataMember = "usuario";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(598, 14);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(45, 16);
			this.label14.TabIndex = 171;
			this.label14.Text = "Senha";
			// 
			// txtSenha
			// 
			this.txtSenha.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSenha.Location = new System.Drawing.Point(601, 31);
			this.txtSenha.Name = "txtSenha";
			this.txtSenha.Size = new System.Drawing.Size(120, 22);
			this.txtSenha.TabIndex = 154;
			// 
			// btnSalvar
			// 
			this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(204)))), ((int)(((byte)(108)))));
			this.btnSalvar.FlatAppearance.BorderSize = 0;
			this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSalvar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSalvar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSalvar.Location = new System.Drawing.Point(445, 295);
			this.btnSalvar.Name = "btnSalvar";
			this.btnSalvar.Size = new System.Drawing.Size(93, 34);
			this.btnSalvar.TabIndex = 155;
			this.btnSalvar.Text = "Cadastrar";
			this.btnSalvar.UseVisualStyleBackColor = false;
			this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
			// 
			// btnAlterar
			// 
			this.btnAlterar.BackColor = System.Drawing.Color.PaleVioletRed;
			this.btnAlterar.FlatAppearance.BorderSize = 0;
			this.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAlterar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAlterar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAlterar.Location = new System.Drawing.Point(545, 295);
			this.btnAlterar.Name = "btnAlterar";
			this.btnAlterar.Size = new System.Drawing.Size(78, 34);
			this.btnAlterar.TabIndex = 156;
			this.btnAlterar.Text = "Alterar";
			this.btnAlterar.UseVisualStyleBackColor = false;
			this.btnAlterar.Click += new System.EventHandler(this.BtnAlterar_Click);
			// 
			// btnLimpar
			// 
			this.btnLimpar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(131)))), ((int)(((byte)(194)))));
			this.btnLimpar.FlatAppearance.BorderSize = 0;
			this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLimpar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLimpar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLimpar.Location = new System.Drawing.Point(629, 295);
			this.btnLimpar.Name = "btnLimpar";
			this.btnLimpar.Size = new System.Drawing.Size(78, 34);
			this.btnLimpar.TabIndex = 157;
			this.btnLimpar.Text = "Limpar";
			this.btnLimpar.UseVisualStyleBackColor = false;
			this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(421, 75);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(83, 16);
			this.label8.TabIndex = 165;
			this.label8.Text = "Data Criação";
			// 
			// txtUser
			// 
			this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUser.Location = new System.Drawing.Point(420, 32);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(164, 22);
			this.txtUser.TabIndex = 142;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(417, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 16);
			this.label1.TabIndex = 159;
			this.label1.Text = "Usuário";
			// 
			// groupPerfil
			// 
			this.groupPerfil.Controls.Add(this.rbnAdministrador);
			this.groupPerfil.Controls.Add(this.rbnProfessor);
			this.groupPerfil.Controls.Add(this.rbnAluno);
			this.groupPerfil.Location = new System.Drawing.Point(421, 145);
			this.groupPerfil.Name = "groupPerfil";
			this.groupPerfil.Size = new System.Drawing.Size(301, 48);
			this.groupPerfil.TabIndex = 175;
			this.groupPerfil.TabStop = false;
			this.groupPerfil.Text = "Perfil Usuário";
			// 
			// rbnAdministrador
			// 
			this.rbnAdministrador.AutoSize = true;
			this.rbnAdministrador.Location = new System.Drawing.Point(198, 20);
			this.rbnAdministrador.Name = "rbnAdministrador";
			this.rbnAdministrador.Size = new System.Drawing.Size(88, 17);
			this.rbnAdministrador.TabIndex = 2;
			this.rbnAdministrador.TabStop = true;
			this.rbnAdministrador.Text = "Administrador";
			this.rbnAdministrador.UseVisualStyleBackColor = true;
			// 
			// rbnProfessor
			// 
			this.rbnProfessor.AutoSize = true;
			this.rbnProfessor.Location = new System.Drawing.Point(104, 19);
			this.rbnProfessor.Name = "rbnProfessor";
			this.rbnProfessor.Size = new System.Drawing.Size(69, 17);
			this.rbnProfessor.TabIndex = 1;
			this.rbnProfessor.TabStop = true;
			this.rbnProfessor.Text = "Professor";
			this.rbnProfessor.UseVisualStyleBackColor = true;
			// 
			// rbnAluno
			// 
			this.rbnAluno.AutoSize = true;
			this.rbnAluno.Location = new System.Drawing.Point(20, 20);
			this.rbnAluno.Name = "rbnAluno";
			this.rbnAluno.Size = new System.Drawing.Size(52, 17);
			this.rbnAluno.TabIndex = 0;
			this.rbnAluno.TabStop = true;
			this.rbnAluno.Text = "Aluno";
			this.rbnAluno.UseVisualStyleBackColor = true;
			// 
			// txtData
			// 
			this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtData.Location = new System.Drawing.Point(421, 94);
			this.txtData.Mask = "00/00/0000";
			this.txtData.Name = "txtData";
			this.txtData.ReadOnly = true;
			this.txtData.Size = new System.Drawing.Size(137, 22);
			this.txtData.TabIndex = 177;
			this.txtData.ValidatingType = typeof(System.DateTime);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbnInativo);
			this.groupBox1.Controls.Add(this.rbnAtivo);
			this.groupBox1.Location = new System.Drawing.Point(588, 75);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(134, 48);
			this.groupBox1.TabIndex = 180;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Status Cadastro";
			// 
			// rbnInativo
			// 
			this.rbnInativo.AutoSize = true;
			this.rbnInativo.Location = new System.Drawing.Point(77, 20);
			this.rbnInativo.Name = "rbnInativo";
			this.rbnInativo.Size = new System.Drawing.Size(57, 17);
			this.rbnInativo.TabIndex = 1;
			this.rbnInativo.TabStop = true;
			this.rbnInativo.Text = "Inativo";
			this.rbnInativo.UseVisualStyleBackColor = true;
			// 
			// rbnAtivo
			// 
			this.rbnAtivo.AutoSize = true;
			this.rbnAtivo.Location = new System.Drawing.Point(7, 20);
			this.rbnAtivo.Name = "rbnAtivo";
			this.rbnAtivo.Size = new System.Drawing.Size(49, 17);
			this.rbnAtivo.TabIndex = 0;
			this.rbnAtivo.TabStop = true;
			this.rbnAtivo.Text = "Ativo";
			this.rbnAtivo.UseVisualStyleBackColor = true;
			// 
			// dgvUsuarios
			// 
			this.dgvUsuarios.AllowUserToAddRows = false;
			this.dgvUsuarios.AllowUserToDeleteRows = false;
			this.dgvUsuarios.AllowUserToResizeColumns = false;
			this.dgvUsuarios.AllowUserToResizeRows = false;
			this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvUsuarios.Location = new System.Drawing.Point(12, 14);
			this.dgvUsuarios.Name = "dgvUsuarios";
			this.dgvUsuarios.RowHeadersVisible = false;
			this.dgvUsuarios.Size = new System.Drawing.Size(399, 340);
			this.dgvUsuarios.TabIndex = 181;
			this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
			// 
			// FormUtilitarios
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(765, 388);
			this.ControlBox = false;
			this.Controls.Add(this.dgvUsuarios);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txtData);
			this.Controls.Add(this.groupPerfil);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.txtSenha);
			this.Controls.Add(this.btnSalvar);
			this.Controls.Add(this.btnAlterar);
			this.Controls.Add(this.btnLimpar);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtUser);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FormUtilitarios";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Utilitários";
			((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).EndInit();
			this.groupPerfil.ResumeLayout(false);
			this.groupPerfil.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupPerfil;
        private System.Windows.Forms.RadioButton rbnAdministrador;
        private System.Windows.Forms.RadioButton rbnProfessor;
        private System.Windows.Forms.RadioButton rbnAluno;
        private System.Windows.Forms.BindingSource usuarioBindingSource;
        private System.Windows.Forms.MaskedTextBox txtData;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbnInativo;
		private System.Windows.Forms.RadioButton rbnAtivo;
		private System.Windows.Forms.DataGridView dgvUsuarios;
	}
}