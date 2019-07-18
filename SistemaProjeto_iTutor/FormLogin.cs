using SistemaProjeto_iTutor.Cadastros;
using SistemaProjeto_iTutor.Classes;
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

namespace SistemaProjeto_iTutor
{
	public partial class FormLogin : Form
	{
		public FormLogin()
		{
			InitializeComponent();
		}

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "select * from usuario where usuario = @usuario and senha = @senha and statusCadastro=0";
            comando.Parameters.AddWithValue("@usuario", txtUsuario.Text);
            comando.Parameters.AddWithValue("@senha", txtSenha.Text);
            conexao.Open();
            
            SqlDataReader consulta = comando.ExecuteReader(CommandBehavior.CloseConnection);
            if (!consulta.Read())
            {

                MessageBox.Show("Usuário ou senha inválido");
                Limpar.limparComponentes(this);
            }
            else
            {
                consulta.Close();
                conexao.Open();
                
                comando.CommandText = "SELECT levelPermissao, fkprofessor, fkaluno FROM usuario WHERE usuario = '" + txtUsuario.Text + "' and senha = '" + txtSenha.Text + "'";
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable tabela = new DataTable();
                adaptador.Fill(tabela);

                //string lvl = tabela.Rows[0]["levelPermissao"].ToString();
                //int levelPermissao = Convert.ToInt32(lvl);

                

                Autenticacao.levelPermissao = Convert.ToInt32(tabela.Rows[0]["levelPermissao"].ToString());

                if(Autenticacao.levelPermissao == 1) //professor
                {
                    Autenticacao.pkProfessorLogado = Convert.ToInt32(tabela.Rows[0]["fkProfessor"].ToString());
                }
                else if(Autenticacao.levelPermissao == 2) //aluno
                {
                    Autenticacao.pkAlunoLogado = Convert.ToInt32(tabela.Rows[0]["fkAluno"].ToString());
                }
                
                //Autenticacao.levelPermissao = Convert.ToInt32(consulta.GetValue(3));

                Limpar.limparComponentes(this);
                Principal formMenu = new Principal();
                formMenu.Show();
                this.Hide();

            }
            conexao.Close();

        }

        private void lbPrimeiroAcesso_Click(object sender, EventArgs e)
        {
            FormCadastroPrimeiroAcesso primeiroAcesso = new FormCadastroPrimeiroAcesso();
            primeiroAcesso.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = String.Empty;
            txtSenha.Text = String.Empty;
        }

        private void lbPrimeiroAcesso_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lbPrimeiroAcesso_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lbEsqueciSenha_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recurso indisponível no momento. Por favor entre em contato com um de nossos administradores para efetuar a alteração", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
