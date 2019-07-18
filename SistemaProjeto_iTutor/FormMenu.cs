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
using SistemaProjeto_iTutor.Relatorios;
using SistemaProjeto_iTutor.Cadastros;
using SistemaProjeto_iTutor.Classes;
using SistemaProjeto_iTutor.Utilitarios;

namespace SistemaProjeto_iTutor
{
	public partial class FormMenu : Form
	{
		public FormMenu()
		{
			InitializeComponent();
		}

		private void FormMenu_Load(object sender, EventArgs e)
		{
            //FormLogin flogin = new FormLogin(); /*aparecerá a tela de login e só mostra a principal quando sair desta*/
            //flogin.ShowDialog();
		}

        private void btnDeptoFinanceiro_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCadastrarProfessor_Click(object sender, EventArgs e)
        {
            FormCadastroProfessor formProfessor = new FormCadastroProfessor();
            formProfessor.ShowDialog();
        }


        private void btnAgendamentoAulas_Click(object sender, EventArgs e)
        {
            FormCadastroAula formAula = new FormCadastroAula();
            formAula.ShowDialog();
        }

        private void btnAlunos_Click(object sender, EventArgs e)
        {
            FormCadastroAluno formAluno = new FormCadastroAluno();
            formAluno.ShowDialog();
        }

        private void BtnGerenciarCadastros_Click(object sender, EventArgs e)
        {
            FormUtilitarios formUtilitarios = new FormUtilitarios();
            formUtilitarios.ShowDialog();

            //if (Autenticacao.levelPermissao == 0)
            //{
            //    FormUtilitarios formUtilitarios = new FormUtilitarios();
            //    formUtilitarios.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Usuário sem permissão", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
	
}
