namespace SistemaProjeto_iTutor.Relatorios
{
	partial class FormRelatorios
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbnProfessores = new System.Windows.Forms.RadioButton();
			this.rbnAlunos = new System.Windows.Forms.RadioButton();
			this.rbnAulas = new System.Windows.Forms.RadioButton();
			this.tabCubo = new System.Windows.Forms.TabPage();
			this.btnSalvar = new System.Windows.Forms.Button();
			this.dgvCubo = new System.Windows.Forms.DataGridView();
			this.tabFiltro = new System.Windows.Forms.TabPage();
			this.dtpFim = new System.Windows.Forms.DateTimePicker();
			this.dtpInicio = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnGerarCubo = new System.Windows.Forms.Button();
			this.btnLimpar = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.groupBox1.SuspendLayout();
			this.tabCubo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCubo)).BeginInit();
			this.tabFiltro.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbnProfessores);
			this.groupBox1.Controls.Add(this.rbnAlunos);
			this.groupBox1.Controls.Add(this.rbnAulas);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(215, 396);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Consulta";
			// 
			// rbnProfessores
			// 
			this.rbnProfessores.AutoSize = true;
			this.rbnProfessores.Location = new System.Drawing.Point(7, 90);
			this.rbnProfessores.Name = "rbnProfessores";
			this.rbnProfessores.Size = new System.Drawing.Size(186, 21);
			this.rbnProfessores.TabIndex = 2;
			this.rbnProfessores.TabStop = true;
			this.rbnProfessores.Text = "Professores Cadastrados";
			this.rbnProfessores.UseVisualStyleBackColor = true;
			// 
			// rbnAlunos
			// 
			this.rbnAlunos.AutoSize = true;
			this.rbnAlunos.Location = new System.Drawing.Point(6, 63);
			this.rbnAlunos.Name = "rbnAlunos";
			this.rbnAlunos.Size = new System.Drawing.Size(153, 21);
			this.rbnAlunos.TabIndex = 1;
			this.rbnAlunos.TabStop = true;
			this.rbnAlunos.Text = "Alunos Cadastrados";
			this.rbnAlunos.UseVisualStyleBackColor = true;
			// 
			// rbnAulas
			// 
			this.rbnAulas.AutoSize = true;
			this.rbnAulas.Location = new System.Drawing.Point(7, 36);
			this.rbnAulas.Name = "rbnAulas";
			this.rbnAulas.Size = new System.Drawing.Size(142, 21);
			this.rbnAulas.TabIndex = 0;
			this.rbnAulas.TabStop = true;
			this.rbnAulas.Text = "Relatório de Aulas";
			this.rbnAulas.UseVisualStyleBackColor = true;
			// 
			// tabCubo
			// 
			this.tabCubo.Controls.Add(this.btnSalvar);
			this.tabCubo.Controls.Add(this.dgvCubo);
			this.tabCubo.Location = new System.Drawing.Point(4, 22);
			this.tabCubo.Name = "tabCubo";
			this.tabCubo.Padding = new System.Windows.Forms.Padding(3);
			this.tabCubo.Size = new System.Drawing.Size(537, 374);
			this.tabCubo.TabIndex = 1;
			this.tabCubo.Text = "Cubo";
			this.tabCubo.UseVisualStyleBackColor = true;
			// 
			// btnSalvar
			// 
			this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(204)))), ((int)(((byte)(108)))));
			this.btnSalvar.FlatAppearance.BorderSize = 0;
			this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSalvar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSalvar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSalvar.Location = new System.Drawing.Point(402, 334);
			this.btnSalvar.Name = "btnSalvar";
			this.btnSalvar.Size = new System.Drawing.Size(129, 34);
			this.btnSalvar.TabIndex = 17;
			this.btnSalvar.Text = "Gerar Planilha";
			this.btnSalvar.UseVisualStyleBackColor = false;
			this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
			// 
			// dgvCubo
			// 
			this.dgvCubo.AllowUserToAddRows = false;
			this.dgvCubo.AllowUserToDeleteRows = false;
			this.dgvCubo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCubo.Location = new System.Drawing.Point(6, 19);
			this.dgvCubo.Name = "dgvCubo";
			this.dgvCubo.RowHeadersVisible = false;
			this.dgvCubo.Size = new System.Drawing.Size(525, 309);
			this.dgvCubo.TabIndex = 1;
			// 
			// tabFiltro
			// 
			this.tabFiltro.Controls.Add(this.dtpFim);
			this.tabFiltro.Controls.Add(this.dtpInicio);
			this.tabFiltro.Controls.Add(this.label2);
			this.tabFiltro.Controls.Add(this.label1);
			this.tabFiltro.Controls.Add(this.btnGerarCubo);
			this.tabFiltro.Controls.Add(this.btnLimpar);
			this.tabFiltro.Location = new System.Drawing.Point(4, 22);
			this.tabFiltro.Name = "tabFiltro";
			this.tabFiltro.Padding = new System.Windows.Forms.Padding(3);
			this.tabFiltro.Size = new System.Drawing.Size(537, 374);
			this.tabFiltro.TabIndex = 0;
			this.tabFiltro.Text = "Filtros";
			this.tabFiltro.UseVisualStyleBackColor = true;
			// 
			// dtpFim
			// 
			this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFim.Location = new System.Drawing.Point(132, 53);
			this.dtpFim.Name = "dtpFim";
			this.dtpFim.Size = new System.Drawing.Size(99, 20);
			this.dtpFim.TabIndex = 32;
			// 
			// dtpInicio
			// 
			this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpInicio.Location = new System.Drawing.Point(132, 22);
			this.dtpInicio.Name = "dtpInicio";
			this.dtpInicio.Size = new System.Drawing.Size(99, 20);
			this.dtpInicio.TabIndex = 31;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 13);
			this.label2.TabIndex = 30;
			this.label2.Text = "Data Final de Consulta";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(119, 13);
			this.label1.TabIndex = 29;
			this.label1.Text = "Data Inicial de Consulta";
			// 
			// btnGerarCubo
			// 
			this.btnGerarCubo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(204)))), ((int)(((byte)(108)))));
			this.btnGerarCubo.FlatAppearance.BorderSize = 0;
			this.btnGerarCubo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGerarCubo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGerarCubo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnGerarCubo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnGerarCubo.Location = new System.Drawing.Point(9, 112);
			this.btnGerarCubo.Name = "btnGerarCubo";
			this.btnGerarCubo.Size = new System.Drawing.Size(100, 34);
			this.btnGerarCubo.TabIndex = 25;
			this.btnGerarCubo.Text = "Gerar Cubo";
			this.btnGerarCubo.UseVisualStyleBackColor = false;
			this.btnGerarCubo.Click += new System.EventHandler(this.BtnGerarCubo_Click);
			// 
			// btnLimpar
			// 
			this.btnLimpar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(131)))), ((int)(((byte)(194)))));
			this.btnLimpar.FlatAppearance.BorderSize = 0;
			this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLimpar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLimpar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLimpar.Location = new System.Drawing.Point(131, 112);
			this.btnLimpar.Name = "btnLimpar";
			this.btnLimpar.Size = new System.Drawing.Size(100, 34);
			this.btnLimpar.TabIndex = 26;
			this.btnLimpar.Text = "Limpar";
			this.btnLimpar.UseVisualStyleBackColor = false;
			this.btnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabFiltro);
			this.tabControl1.Controls.Add(this.tabCubo);
			this.tabControl1.Location = new System.Drawing.Point(233, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(545, 400);
			this.tabControl1.TabIndex = 2;
			// 
			// FormRelatorios
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(781, 427);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FormRelatorios";
			this.Text = "Relatórios";
			this.Load += new System.EventHandler(this.FormRelatorios_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabCubo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCubo)).EndInit();
			this.tabFiltro.ResumeLayout(false);
			this.tabFiltro.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabPage tabCubo;
		private System.Windows.Forms.TabPage tabFiltro;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnGerarCubo;
		private System.Windows.Forms.Button btnLimpar;
		private System.Windows.Forms.DataGridView dgvCubo;
		private System.Windows.Forms.Button btnSalvar;
		private System.Windows.Forms.RadioButton rbnProfessores;
		private System.Windows.Forms.RadioButton rbnAlunos;
		private System.Windows.Forms.RadioButton rbnAulas;
		private System.Windows.Forms.DateTimePicker dtpFim;
		private System.Windows.Forms.DateTimePicker dtpInicio;
	}
}