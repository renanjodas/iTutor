using SistemaProjeto_iTutor.Cadastros;
using SistemaProjeto_iTutor.Classes;
using SistemaProjeto_iTutor.Utilitarios;
using SistemaProjeto_iTutor.Relatorios;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaProjeto_iTutor
{
    public partial class Principal : Form
    {
		
		public Principal()
        {
            InitializeComponent();
        }

		private void AbrirFormNoPanel<Forms>() where Forms : Form, new()
		{

			Form formulario;
			formulario = panelConteudo.Controls.OfType<Forms>().FirstOrDefault();

			if (formulario == null)
			{
				formulario = new Forms();
				formulario.TopLevel = false;
				formulario.FormBorderStyle = FormBorderStyle.None;
				formulario.Dock = DockStyle.Fill;
				panelConteudo.Controls.Add(formulario);
				panelConteudo.Tag = formulario;
				formulario.Show();
				formulario.BringToFront();
			}
			else
			{
				if (formulario.WindowState == FormWindowState.Minimized)
					formulario.WindowState = FormWindowState.Normal;
				formulario.BringToFront();
			}

		}
        private void btnAlunos_Click(object sender, EventArgs e)
        {
            //AbrirFormNoPanel<FormCadastroAluno>();
            barrinhaLateral.Visible = true;
            barrinhaLateral.Height = btnAlunos.Height;
            barrinhaLateral.Top = btnAlunos.Top;
            panelConteudo.Controls.Clear();
            FormCadastroAluno formAluno = new FormCadastroAluno();
            formAluno.TopLevel = false;
            panelConteudo.Controls.Add(formAluno);
            formAluno.Show();
        }

        private void btnDeslogar_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Hide();
        }

        private void lbFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastrarProfessor_Click(object sender, EventArgs e)
        {
			AbrirFormNoPanel<FormCadastroProfessor>();

            barrinhaLateral.Visible = true;
            barrinhaLateral.Height = btnCadastrarProfessor.Height;
            barrinhaLateral.Top = btnCadastrarProfessor.Top;

            //FormCadastroProfessor formProfessor = new FormCadastroProfessor();
            //formProfessor.ShowDialog();
        }

        private void BtnGerenciarCadastros_Click(object sender, EventArgs e)
        {
			AbrirFormNoPanel<FormGerenciar>();

			barrinhaLateral.Visible = true;
            barrinhaLateral.Height = btnGerenciarCadastros.Height;
            barrinhaLateral.Top = btnGerenciarCadastros.Top;

        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
			AbrirFormNoPanel<FormRelatorios>();

			barrinhaLateral.Visible = true;
			barrinhaLateral.Height = btnRelatorio.Height;
			barrinhaLateral.Top = btnRelatorio.Top;
		}

        private void btnAgendarAulas_Click(object sender, EventArgs e)
        {
			AbrirFormNoPanel<FormCadastroAula>();

			barrinhaLateral.Visible = true;
            barrinhaLateral.Height = btnAgendarAulas.Height;
            barrinhaLateral.Top = btnAgendarAulas.Top;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            if(Autenticacao.levelPermissao == 0) //Admin
            {
                btnAlunos.Visible = true;
                btnAgendarAulas.Visible = true;
                btnCadastrarProfessor.Visible = true;
                btnGerenciarCadastros.Visible = true;
                btnRelatorio.Visible = true;
            }
            else if(Autenticacao.levelPermissao == 1) //professor
            {
                btnAlunos.Visible = false;
                btnAgendarAulas.Visible = true;
                btnCadastrarProfessor.Visible = true;
                btnGerenciarCadastros.Visible = false;
                btnRelatorio.Visible = true;

                btnAgendarAulas.Location = new Point(0, 83);
                btnCadastrarProfessor.Location = new Point(0, 116);
                btnRelatorio.Location = new Point(0, 148);
            }
            else if (Autenticacao.levelPermissao == 2) //aluno
            {
                btnAlunos.Visible = true;
                btnAgendarAulas.Visible = true;
                btnCadastrarProfessor.Visible = false;
                btnGerenciarCadastros.Visible = false;
                btnRelatorio.Visible = false;

            }
        }
    }
}
