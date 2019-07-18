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
using SistemaProjeto_iTutor.Cadastros;
using SistemaProjeto_iTutor.Classes;


namespace SistemaProjeto_iTutor.Utilitarios
{
    public partial class FormUtilitarios : Form
    {
        public FormUtilitarios()
        {
            InitializeComponent();
        }

        string pkUser;
        
        private void FormUtilitarios_Load(object sender, EventArgs e)
        {
            
			try
			{
				string strConexao = Banco.enderecoBanco();
				string sql = "select pkUsuario, usuario as 'Usuário', senha as 'Senha', levelPermissao, dataCriacao as 'Data Criação', statusCadastro from usuario";
				SqlConnection conexao = new SqlConnection(strConexao);
				SqlDataAdapter da = new SqlDataAdapter(sql, conexao);
				DataSet ds = new DataSet();
				conexao.Open();
				da.Fill(ds, "usuario");
				conexao.Close();
				dgvUsuarios.DataSource = ds;
				dgvUsuarios.DataMember = "usuario";

				for (int i = 1; i < dgvUsuarios.Columns.Count; i++)
				{
					dgvUsuarios.Columns[0].Visible = false;
					dgvUsuarios.Columns[i].Visible = true;
				}
				dgvUsuarios.Columns[5].Visible = false;
				dgvUsuarios.Columns[3].Visible = false;
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar.limparComponentes(this);
        }

		
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

			try
			{
				preencherTextBoxUsuario(e);
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

        public void preencherTextBoxUsuario(DataGridViewCellEventArgs e)
        {
            pkUser = dgvUsuarios.Rows[e.RowIndex].Cells["pkUsuario"].Value.ToString();
            txtData.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Data Criação"].Value.ToString();
            txtUser.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Usuário"].Value.ToString();
            txtSenha.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Senha"].Value.ToString();
            string status = dgvUsuarios.Rows[e.RowIndex].Cells["statusCadastro"].Value.ToString();
            if (status == "0") {
				rbnAtivo.Checked = true;
			}
            else
            {
				rbnInativo.Checked = true;
			}

           
            string permissao = dgvUsuarios.Rows[e.RowIndex].Cells["levelPermissao"].Value.ToString();
            if (permissao == "0")
            {
                rbnAdministrador.Checked = true;
            }else if (permissao == "1")
            {
                rbnProfessor.Checked = true;
            }
            else
            {
                rbnAluno.Checked = true;
            }
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
            SqlCommand query = new SqlCommand();

            query.Connection = conexao;
            conexao.Open();

            int status;
            int perfil;
                        
            if (rbnAdministrador.Checked == true)
            {
                perfil = 0;
            }else if (rbnAluno.Checked == true)
            {
                perfil = 2;
            }
            else
            {
                perfil = 1;
            }

            if (rbnAtivo.Checked == true)
            {
                status = 0;
            }
            else
            {
                status = 999;
            }
                        
            query.CommandText = "UPDATE usuario SET usuario = @usuario, senha = @senha, statusCadastro = @status, levelPermissao = @perfil where pkUsuario = @pkUsuario";
            query.Parameters.AddWithValue("@usuario", txtUser.Text);
            query.Parameters.AddWithValue("@senha", txtSenha.Text);
            query.Parameters.AddWithValue("@perfil", perfil);
            query.Parameters.AddWithValue("@pkUsuario", pkUser);
            query.Parameters.AddWithValue("@status", status);
            int cont = query.ExecuteNonQuery();

            if (cont > 0) { MessageBox.Show("Cadastro Alterado com Sucesso"); }
            else { MessageBox.Show("Erro"); }

            conexao.Close();
            FormUtilitarios_Load(null, null);
			LimparCliente();
		}

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;

            string diaHoraAtual = localDate.ToString();
            
            int perfil;
			int status;

            txtData.Text = diaHoraAtual;

            if (rbnAdministrador.Checked == true)
            {
                perfil = 0;
            }
            else if (rbnAluno.Checked == true)
            {
                perfil = 2;
            }
            else
            {
                perfil = 1;
            }

			if (rbnAtivo.Checked == true)
			{
				status = 0;
			}
			else
			{
				status = 999;
			}

			SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
            SqlCommand query = new SqlCommand();

            query.Connection = conexao;
            conexao.Open();

            query.Parameters.AddWithValue("@usuario", txtUser.Text);
            query.Parameters.AddWithValue("@senha", txtSenha.Text);
            query.Parameters.AddWithValue("@dataCriacao", diaHoraAtual);
            query.Parameters.AddWithValue("@statusCadastro", status);
            query.Parameters.AddWithValue("@levelPermissao", perfil);
            query.Parameters.AddWithValue("@solicitacaoAprovada", 1);

            query.CommandText = "INSERT INTO usuario (usuario, senha, dataCriacao, statusCadastro, levelPermissao, solicitacaoAprovada) values (@usuario, @senha, @dataCriacao, @statusCadastro, @levelPermissao, @solicitacaoAprovada)";
            int cont = query.ExecuteNonQuery();

            if (cont > 0) { MessageBox.Show("Cadastro Realizado com Sucesso"); }
            else { MessageBox.Show("Erro ao Cadastrar"); }
            

            FormUtilitarios_Load(null, null);
            conexao.Close();
            LimparCliente();
        }

        private void LimparCliente()
        {
            txtUser.Clear();
            txtSenha.Clear();
			rbnAtivo.Checked = false;
			rbnInativo.Checked = false;
			rbnAdministrador.Checked = false;
            rbnAluno.Checked = false;
            rbnProfessor.Checked = false;
            txtData.Clear();
        }

		
	}

    
}
