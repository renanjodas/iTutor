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
using SistemaProjeto_iTutor.Classes;


namespace SistemaProjeto_iTutor.Relatorios
{
	public partial class FormRelatorios : Form
	{
		public FormRelatorios()
		{
			InitializeComponent();
		}

		int pkProfessor = Autenticacao.pkProfessorLogado;

		private void FormRelatorios_Load(object sender, EventArgs e)
		{
			if (Autenticacao.levelPermissao == 2) //aluno
			{
				rbnProfessores.Visible = false;
				rbnAlunos.Visible = false;

				//btnAlterar.Location = new Point(679, 363);

			}
			else if (Autenticacao.levelPermissao == 1)
			{
				rbnProfessores.Visible = false;

			}

		}

		private void BtnGerarCubo_Click(object sender, EventArgs e)
		{
			if (Autenticacao.levelPermissao == 1)
			{
				if (rbnAulas.Checked == true)
				{

					try
					{
						string sql = "SELECT s.nome AS 'Nome', a.dataAula AS 'Data Aula', p.nome AS 'Professor', d.nome AS 'Disciplina', e.rua AS 'Endereço', a.statusAula AS 'Status Aula', pg.formaPagamento AS 'Pagamento', u.statusCadastro FROM aula AS a, aluno AS s, usuario AS u, professor AS p, disciplina AS d, endereco AS e, pagamento AS pg WHERE a.fkAluno = s.pkAluno AND u.fkAluno = s.pkAluno AND a.fkPagamento = pg.pkPagamento AND a.fkDisciplina = d.pkDisciplina AND a.fkEndereco = e.pkEndereco AND a.fkProfessor = " + pkProfessor + " AND u.statusCadastro = 0 AND a.dataAula BETWEEN @inicio AND @fim ORDER BY a.dataAula;";

						SqlCommand cmd = new SqlCommand(sql);
						cmd.CommandType = CommandType.Text;

						cmd.Parameters.AddWithValue("@inicio", dtpInicio.Value);
						cmd.Parameters.AddWithValue("@fim", dtpFim.Value);

						DataTable dt = GetDados(cmd);
						dgvCubo.DataSource = dt;


						for (int i = 1; i < dgvCubo.Columns.Count; i++)
						{
							dgvCubo.Columns[0].Visible = false;
							dgvCubo.Columns[i].Visible = true;
						}
						dgvCubo.Columns[5].Visible = false;
						dgvCubo.Columns[3].Visible = false;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else if (rbnAlunos.Checked == true)
				{

					try
					{
						string sql = "SELECT nome AS 'Nome', dataNascimento AS 'Data Nascimento', responsavel AS 'Responsável', telefone AS 'Telefone', statusCadastro, email AS 'E-mail', dataCadastro, case when statusCadastro = 0 then 'Ativo' else 'Inativo' end as Status FROM aluno WHERE dataCadastro BETWEEN @inicio AND @fim ORDER BY dataCadastro;";

						SqlCommand cmd = new SqlCommand(sql);
						cmd.CommandType = CommandType.Text;

						cmd.Parameters.AddWithValue("@inicio", dtpInicio.Value);
						cmd.Parameters.AddWithValue("@fim", dtpFim.Value);

						DataTable dt = GetDados(cmd);
						dgvCubo.DataSource = dt;
						dgvCubo.Columns[4].Visible = false;

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else if (rbnProfessores.Checked == true)
				{

					try
					{
						string sql = "SELECT a.nome AS 'Nome', a.dataNascimento AS 'Data Nascimento', a.telefone AS 'Telefone', a.statusCadastro, a.email AS 'E-mail', d.nome, a.valorHoraAula, a.dataCadastro, case when statusCadastro = 0 then 'Ativo' else 'Inativo' end as Status FROM professor AS a, disciplina AS d WHERE a.pkProfessor = " + pkProfessor + " AND a.fkdisciplina = d.pkDisciplina AND a.dataCadastro BETWEEN @inicio AND @fim ORDER BY a.dataCadastro;";

						SqlCommand cmd = new SqlCommand(sql);
						cmd.CommandType = CommandType.Text;

						cmd.Parameters.AddWithValue("@inicio", dtpInicio.Value);
						cmd.Parameters.AddWithValue("@fim", dtpFim.Value);

						DataTable dt = GetDados(cmd);
						dgvCubo.DataSource = dt;
						dgvCubo.Columns[3].Visible = false;

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				
			}
			else
			{

				if (rbnAulas.Checked == true)
				{
					try
					{
						string sql = "SELECT s.nome AS 'Nome', a.dataAula AS 'Data Aula', p.nome AS 'Professor', d.nome AS 'Disciplina', e.rua AS 'Endereço', a.statusAula AS 'Status Aula', pg.formaPagamento AS 'Pagamento', u.statusCadastro FROM aula AS a, aluno AS s, usuario AS u, professor AS p, disciplina AS d, endereco AS e, pagamento AS pg WHERE a.fkAluno = s.pkAluno AND u.fkAluno = s.pkAluno AND a.fkPagamento = pg.pkPagamento AND a.fkDisciplina = d.pkDisciplina AND a.fkEndereco = e.pkEndereco AND a.fkProfessor = p.pkProfessor AND u.statusCadastro = 0 AND a.dataAula BETWEEN @inicio AND @fim ORDER BY a.dataAula;";

						SqlCommand cmd = new SqlCommand(sql);
						cmd.CommandType = CommandType.Text;

						cmd.Parameters.AddWithValue("@inicio", dtpInicio.Value);
						cmd.Parameters.AddWithValue("@fim", dtpFim.Value);

						DataTable dt = GetDados(cmd);
						dgvCubo.DataSource = dt;


						for (int i = 1; i < dgvCubo.Columns.Count; i++)
						{
							dgvCubo.Columns[0].Visible = false;
							dgvCubo.Columns[i].Visible = true;
						}
						dgvCubo.Columns[5].Visible = false;
						dgvCubo.Columns[3].Visible = false;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else if (rbnAlunos.Checked == true)
				{
					try
					{
						string sql = "SELECT nome AS 'Nome', dataNascimento AS 'Data Nascimento', responsavel AS 'Responsável', telefone AS 'Telefone', statusCadastro, email AS 'E-mail', dataCadastro, case when statusCadastro = 0 then 'Ativo' else 'Inativo' end as Status FROM aluno WHERE dataCadastro BETWEEN @inicio AND @fim ORDER BY dataCadastro;";

						SqlCommand cmd = new SqlCommand(sql);
						cmd.CommandType = CommandType.Text;

						cmd.Parameters.AddWithValue("@inicio", dtpInicio.Value);
						cmd.Parameters.AddWithValue("@fim", dtpFim.Value);

						DataTable dt = GetDados(cmd);
						dgvCubo.DataSource = dt;
						dgvCubo.Columns[4].Visible = false;

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else if (rbnProfessores.Checked == true)
				{

					try
					{
						string sql = "SELECT a.nome AS 'Nome', a.dataNascimento AS 'Data Nascimento', a.telefone AS 'Telefone', a.statusCadastro, a.email AS 'E-mail', d.nome AS 'Disciplina', a.valorHoraAula AS 'Valor Aula', a.dataCadastro AS 'Data Cadastro', case when statusCadastro = 0 then 'Ativo' else 'Inativo' end as Status FROM professor AS a, disciplina AS d WHERE a.fkdisciplina = d.pkDisciplina AND a.dataCadastro BETWEEN @inicio AND @fim ORDER BY a.dataCadastro;";

						SqlCommand cmd = new SqlCommand(sql);
						cmd.CommandType = CommandType.Text;

						cmd.Parameters.AddWithValue("@inicio", dtpInicio.Value);
						cmd.Parameters.AddWithValue("@fim", dtpFim.Value);

						DataTable dt = GetDados(cmd);
						dgvCubo.DataSource = dt;
						dgvCubo.Columns[3].Visible = false;

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				
			}
		}

		private DataTable GetDados(SqlCommand cmd)
		{
			DataTable dt = new DataTable();
			String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conexaoNorthwind"].ConnectionString;

			SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
			SqlDataAdapter sda = new SqlDataAdapter();
			cmd.CommandType = CommandType.Text;
			cmd.Connection = conexao;
			try
			{
				conexao.Open();
				sda.SelectCommand = cmd;
				sda.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				conexao.Close();
				sda.Dispose();
				conexao.Dispose();
			}
		}

		private void BtnLimpar_Click(object sender, EventArgs e)
		{
			Limpar.limparComponentes(this);
		}

		private void BtnSalvar_Click(object sender, EventArgs e)
		{
			Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
			if (dgvCubo.Rows.Count > 0)
			{
				try
				{
					XcelApp.Application.Workbooks.Add(Type.Missing);
					for (int i = 1; i < dgvCubo.Columns.Count + 1; i++)
					{
						XcelApp.Cells[1, i] = dgvCubo.Columns[i - 1].HeaderText;
					}
					//
					for (int i = 0; i < dgvCubo.Rows.Count - 1; i++)
					{
						for (int j = 0; j < dgvCubo.Columns.Count; j++)
						{
							XcelApp.Cells[i + 2, j + 1] = dgvCubo.Rows[i].Cells[j].Value.ToString();
						}
					}
					//
					XcelApp.Columns.AutoFit();
					//
					XcelApp.Visible = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Erro : " + ex.Message);
					XcelApp.Quit();
				}
			}
		}
	}
}
