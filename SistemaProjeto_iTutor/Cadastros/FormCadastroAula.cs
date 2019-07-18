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
using System.Globalization;

namespace SistemaProjeto_iTutor.Cadastros
{
	public partial class FormCadastroAula : Form
	{
		public FormCadastroAula()
		{
			InitializeComponent();
		}

		int pkAluno = Autenticacao.pkAlunoLogado;
		int pkProfessor = Autenticacao.pkProfessorLogado;


		private void FormCadastroAula_Load(object sender, EventArgs e)
		{
            comboAluno();
            comboProfessor();
            comboDisciplina();
            cbEndereco();

            if (Autenticacao.levelPermissao == 2) //aluno
			{
				try
				{
					string sql = "SELECT a.dataAula AS 'Data Aula', a.horaInicial, a.horaFinal, s.nome, p.nome, d.nome AS 'Disciplina', e.rua, a.telefone, a.statusAula AS 'Status', pg.formaPagamento FROM aula AS a, aluno AS s, professor AS p, disciplina AS d, endereco AS e, pagamento AS pg WHERE a.fkAluno =" + pkAluno + " AND a.fkProfessor = p.pkProfessor AND a.fkDisciplina = d.pkDisciplina AND a.fkEndereco = e.pkEndereco AND a.fkPagamento = pg.pkPagamento;";
					SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
					SqlDataAdapter da = new SqlDataAdapter(sql, conexao);
					DataSet ds = new DataSet();
					conexao.Open();
					da.Fill(ds, "aula");
					conexao.Close();
					dgvAulasAgendadas.DataSource = ds;
					dgvAulasAgendadas.DataMember = "aula";

					dgvAulasAgendadas.Columns[1].Visible = false;
					dgvAulasAgendadas.Columns[2].Visible = false;
					dgvAulasAgendadas.Columns[3].Visible = false;
					dgvAulasAgendadas.Columns[4].Visible = false;
					dgvAulasAgendadas.Columns[6].Visible = false;
					dgvAulasAgendadas.Columns[7].Visible = false;
					dgvAulasAgendadas.Columns[9].Visible = false;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if (Autenticacao.levelPermissao == 1) //professor
			{
				try
				{
					string sql = "SELECT a.dataAula AS 'Data Aula', a.horaInicial, a.horaFinal, s.nome, p.nome, d.nome AS 'Disciplina', e.rua, a.telefone, a.statusAula AS 'Status', pg.formaPagamento FROM aula AS a, aluno AS s, professor AS p, disciplina AS d, endereco AS e, pagamento AS pg WHERE a.fkProfessor = " + pkProfessor + " AND a.fkAluno = s.pkAluno AND a.fkDisciplina = d.pkDisciplina AND a.fkEndereco = e.pkEndereco AND a.fkPagamento = pg.pkPagamento;";
					SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
					SqlDataAdapter da = new SqlDataAdapter(sql, conexao);
					DataSet ds = new DataSet();
					conexao.Open();
					da.Fill(ds, "aula");
					conexao.Close();
					dgvAulasAgendadas.DataSource = ds;
					dgvAulasAgendadas.DataMember = "aula";


					for (int i = 1; i < dgvAulasAgendadas.Columns.Count; i++)
					{
						dgvAulasAgendadas.Columns[i].Visible = true;
					}
					dgvAulasAgendadas.Columns[1].Visible = false;
					dgvAulasAgendadas.Columns[2].Visible = false;
					dgvAulasAgendadas.Columns[3].Visible = false;
					dgvAulasAgendadas.Columns[4].Visible = false;
					dgvAulasAgendadas.Columns[6].Visible = false;
					dgvAulasAgendadas.Columns[7].Visible = false;
					dgvAulasAgendadas.Columns[9].Visible = false;
					//cbAluno.SelectedValue = dgvAulasAgendadas.Columns[3].ToString();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else //admin
			{
				try
				{
					string sql = "SELECT dataAula AS 'Data Aula', a.horaInicial, a.horaFinal, s.nome, p.nome, d.nome AS 'Disciplina', e.rua, a.telefone, a.statusAula AS 'Status', pg.formaPagamento FROM aula AS a, aluno AS s, professor AS p, disciplina AS d, endereco AS e, pagamento AS pg WHERE a.fkProfessor = p.pkProfessor AND a.fkAluno = s.pkAluno AND a.fkDisciplina = d.pkDisciplina AND a.fkEndereco = e.pkEndereco AND a.fkPagamento = pg.pkPagamento;";
					SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
					SqlDataAdapter da = new SqlDataAdapter(sql, conexao);
					DataSet ds = new DataSet();
					conexao.Open();
					da.Fill(ds, "aula");
					conexao.Close();
					dgvAulasAgendadas.DataSource = ds;
					dgvAulasAgendadas.DataMember = "aula";


					for (int i = 1; i < dgvAulasAgendadas.Columns.Count; i++)
					{
						dgvAulasAgendadas.Columns[i].Visible = true;
					}
					dgvAulasAgendadas.Columns[0].Visible = false;
					dgvAulasAgendadas.Columns[2].Visible = false;
					dgvAulasAgendadas.Columns[3].Visible = false;
					dgvAulasAgendadas.Columns[4].Visible = false;
					dgvAulasAgendadas.Columns[5].Visible = false;
					dgvAulasAgendadas.Columns[6].Visible = false;
					dgvAulasAgendadas.Columns[8].Visible = false;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

		}

		private void DgvAulasAgendadas_CellClick(object sender, DataGridViewCellEventArgs e)
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
			cbProfessor.Text = dgvAulasAgendadas.Rows[e.RowIndex].Cells[4].Value.ToString();
			cbDisciplina.Text = dgvAulasAgendadas.Rows[e.RowIndex].Cells["Disciplina"].Value.ToString();
			txtTelefone.Text = dgvAulasAgendadas.Rows[e.RowIndex].Cells[7].Value.ToString();
			comboEndereco.Text = dgvAulasAgendadas.Rows[e.RowIndex].Cells[6].Value.ToString();
			dateDataAula.Text = dgvAulasAgendadas.Rows[e.RowIndex].Cells["Data Aula"].Value.ToString();
			dateHoraInicial.Text = dgvAulasAgendadas.Rows[e.RowIndex].Cells[1].Value.ToString();
			dateHoraFinal.Text = dgvAulasAgendadas.Rows[e.RowIndex].Cells[2].Value.ToString();
			cbPagamento.Text = dgvAulasAgendadas.Rows[e.RowIndex].Cells[9].Value.ToString();
			cbStatusAula.Text = dgvAulasAgendadas.Rows[e.RowIndex].Cells["Status"].Value.ToString();

		}

		private void BtnAgendar_Click(object sender, EventArgs e)
		{

            if (Autenticacao.levelPermissao == 2) //aluno
			{
                try
                {
					SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
					SqlCommand query = new SqlCommand();

					query.Connection = conexao;
					conexao.Open();

                    string diaAula = Convert.ToDateTime(dateDataAula.Text).ToString("yyyy-MM-dd");
                    string horaInicial = Convert.ToDateTime(dateHoraInicial.Text).ToString("HH:mm");
                    string horaFinal = Convert.ToDateTime(dateHoraFinal.Text).ToString("HH:mm");
                    TimeSpan date = Convert.ToDateTime(dateHoraFinal.Text) - Convert.ToDateTime(dateHoraInicial.Text);

                    query.Parameters.AddWithValue("@aluno", cbAluno.SelectedValue.ToString());
					query.Parameters.AddWithValue("@professor", cbProfessor.SelectedValue.ToString());
					query.Parameters.AddWithValue("@disciplina", cbDisciplina.SelectedValue.ToString());
					query.Parameters.AddWithValue("@telefone", txtTelefone.Text);
					query.Parameters.AddWithValue("@endereco", comboEndereco.SelectedValue.ToString());
					query.Parameters.AddWithValue("@dataAula", Convert.ToDateTime(diaAula));
					query.Parameters.AddWithValue("@horaInicial", Convert.ToDateTime(horaInicial));
					query.Parameters.AddWithValue("@horaFinal", Convert.ToDateTime(horaFinal));
					query.Parameters.AddWithValue("@pagamento", cbPagamento.SelectedItem.ToString());
					query.Parameters.AddWithValue("@statusAula", cbStatusAula.SelectedItem.ToString());
					query.Parameters.AddWithValue("@conteudo", txtConteudo.Text);
					query.Parameters.AddWithValue("@observacao", txtObservacao.Text);

                    query.Parameters.AddWithValue("@horas", date);
                    query.Parameters.AddWithValue("@statusCadastro", 0);


                    query.CommandText = "INSERT INTO pagamento (horas, diaPagamento, formaPagamento, statusCadastro, fkAluno, fkProfessor) VALUES (@horas, @dataAula, @pagamento, @statusCadastro, @aluno, @professor)";


                    query.CommandText = "INSERT INTO aula (dataAula, horaInicial, horaFinal, fkAluno, fkProfessor, fkDisciplina, fkEndereco, telefone, statusAula, fkPagamento, conteudo, observacao) values (@dataAula, @horaInicial, @horaFinal, @aluno, @professor, @disciplina, @endereco, @telefone, @statusAula, @pagamento, @conteudo, @observacao)";
                    int cont = query.ExecuteNonQuery();

					if (cont > 0) { MessageBox.Show("Cadastro Realizado com Sucesso"); }
					else
					{
						MessageBox.Show("Erro ao Cadastrar");
					}
				}


				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if (Autenticacao.levelPermissao == 1) //professor
			{

				try
				{
					SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
					SqlCommand query = new SqlCommand();

					query.Connection = conexao;
					conexao.Open();

					query.Parameters.AddWithValue("@aluno", cbAluno.SelectedValue);
					query.Parameters.AddWithValue("@professor", cbProfessor.SelectedValue);
					query.Parameters.AddWithValue("@disciplina", cbDisciplina.SelectedValue);
					query.Parameters.AddWithValue("@telefone", txtTelefone.Text);
					query.Parameters.AddWithValue("@endereco", comboEndereco.SelectedValue);
					query.Parameters.AddWithValue("@dataAula", dateDataAula.Text);
					query.Parameters.AddWithValue("@horaInicial", dateHoraInicial.Text);
					query.Parameters.AddWithValue("@horaFinal", dateHoraFinal.Text);
					query.Parameters.AddWithValue("@pagamento", cbPagamento.SelectedValue);
					query.Parameters.AddWithValue("@statusAula", cbStatusAula.SelectedValue);
					query.Parameters.AddWithValue("@conteudo", txtConteudo.Text);
					query.Parameters.AddWithValue("@observacao", txtObservacao.Text);


					query.CommandText = "INSERT INTO aula (dataAula, horaInicial, horaFinal, fkAluno, fkProfessor, fkDisciplina, fkEndereco, telefone, statusAula, fkPagamento, conteudo, observacao) values (@dataAula, @horaInicial, @horaFinal, @aluno, @lprofessor, @disciplina, @endereco, @telefone, @statusAula, @pagamento, @conteudo, @observacao)";
					int cont = query.ExecuteNonQuery();

					if (cont > 0) { MessageBox.Show("Cadastro Realizado com Sucesso"); }
					else
					{
						MessageBox.Show("Erro ao Cadastrar");

					}
				}


				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}


			}
			else //admin
			{
				try
				{
					SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
					SqlCommand query = new SqlCommand();
					query.Connection = conexao;
					conexao.Open();

					query.Parameters.AddWithValue("@aluno", cbAluno.SelectedValue);
					query.Parameters.AddWithValue("@professor", cbProfessor.SelectedValue);
					query.Parameters.AddWithValue("@disciplina", cbDisciplina.SelectedValue);
					query.Parameters.AddWithValue("@telefone", txtTelefone.Text);
					query.Parameters.AddWithValue("@endereco", comboEndereco.SelectedValue);
					query.Parameters.AddWithValue("@dataAula", dateDataAula.Text);
					query.Parameters.AddWithValue("@horaInicial", dateHoraInicial.Text);
					query.Parameters.AddWithValue("@horaFinal", dateHoraFinal.Text);
					query.Parameters.AddWithValue("@pagamento", cbPagamento.SelectedValue);
					query.Parameters.AddWithValue("@statusAula", cbStatusAula.SelectedValue);
					query.Parameters.AddWithValue("@conteudo", txtConteudo.Text);
					query.Parameters.AddWithValue("@observacao", txtObservacao.Text);


					query.CommandText = "INSERT INTO aula (dataAula, horaInicial, horaFinal, fkAluno, fkProfessor, fkDisciplina, fkEndereco, telefone, statusAula, fkPagamento, conteudo, observacao) values (@dataAula, @horaInicial, @horaFinal, @aluno, @lprofessor, @disciplina, @endereco, @telefone, @statusAula, @pagamento, @conteudo, @observacao)";
					int cont = query.ExecuteNonQuery();

					if (cont > 0) { MessageBox.Show("Cadastro Realizado com Sucesso"); }
					else
					{
						MessageBox.Show("Erro ao Cadastrar");

					}
				}


				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}


			}
		}

		public void comboAluno()
		{
			if (Autenticacao.levelPermissao == 2) //aluno
			{
				SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
				SqlCommand cmd = new SqlCommand("SELECT nome, pkAluno FROM aluno WHERE pkAluno = "+pkAluno+" ORDER BY nome DESC;", conexao);

				conexao.Open();
				SqlDataReader reader = cmd.ExecuteReader(); //retorna dados resultantes da consulta SQL
				DataTable table = new DataTable(); //estrutura da tabela do banco de dados ou de outra fonte de informação 
				table.Columns.Add("nome");
				table.Load(reader); //carrega dados na tabela de acordo com a instrução SQL passada

				cbAluno.ValueMember = "pkAluno";
				cbAluno.DisplayMember = "nome";
				cbAluno.DataSource = table;

				conexao.Close();
			}
            else
			{
				SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
				SqlCommand cmd = new SqlCommand("SELECT nome, pkAluno FROM aluno ORDER BY nome DESC;", conexao);

				conexao.Open();
				SqlDataReader reader = cmd.ExecuteReader(); //retorna dados resultantes da consulta SQL
				DataTable table = new DataTable(); //estrutura da tabela do banco de dados ou de outra fonte de informação 
				table.Columns.Add("nome");
				table.Load(reader); //carrega dados na tabela de acordo com a instrução SQL passada

				cbAluno.ValueMember = "pkAluno";
				cbAluno.DisplayMember = "nome";
				cbAluno.DataSource = table;

				conexao.Close();

			}

		}

		public void comboProfessor()
		{
			if (Autenticacao.levelPermissao == 1) //professor
			{
				SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
				SqlCommand cmd = new SqlCommand("SELECT nome, pkProfessor FROM professor WHERE pkProfessor = "+pkProfessor+" ORDER BY nome DESC;", conexao);

				conexao.Open();
				SqlDataReader reader = cmd.ExecuteReader(); //retorna dados resultantes da consulta SQL
				DataTable table = new DataTable(); //estrutura da tabela do banco de dados ou de outra fonte de informação 
				table.Columns.Add("nome");
				table.Load(reader); //carrega dados na tabela de acordo com a instrução SQL passada

				cbProfessor.ValueMember = "pkProfessor";
				cbProfessor.DisplayMember = "nome";
				cbProfessor.DataSource = table;
			}
			else
			{
				SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
				SqlCommand cmd = new SqlCommand("SELECT nome, pkProfessor FROM professor ORDER BY nome DESC;", conexao);

				conexao.Open();
				SqlDataReader reader = cmd.ExecuteReader(); //retorna dados resultantes da consulta SQL
				DataTable table = new DataTable(); //estrutura da tabela do banco de dados ou de outra fonte de informação 
				table.Columns.Add("nome");
				table.Load(reader); //carrega dados na tabela de acordo com a instrução SQL passada

				cbProfessor.ValueMember = "pkProfessor";
				cbProfessor.DisplayMember = "nome";
				cbProfessor.DataSource = table;

			}
		}

		public void comboDisciplina()
		{
			SqlConnection conn = new SqlConnection(Banco.enderecoBanco());
			conn.Open();
			SqlCommand sc = new SqlCommand("SELECT nome FROM disciplina", conn);

			SqlDataReader reader;

			reader = sc.ExecuteReader();
			DataTable dt = new DataTable();

			dt.Columns.Add("nome");
			dt.Load(reader);

			cbDisciplina.ValueMember = "pkDisciplina";
			cbDisciplina.DisplayMember = "nome";
			cbDisciplina.DataSource = dt;

			conn.Close();
		}

		public void cbEndereco()
		{
			SqlConnection conn = new SqlConnection(Banco.enderecoBanco());
			conn.Open();
			SqlCommand sc = new SqlCommand("SELECT rua FROM endereco", conn);

			SqlDataReader reader;

			reader = sc.ExecuteReader();
			DataTable dt = new DataTable();

			dt.Columns.Add("rua");
			dt.Load(reader);

			comboEndereco.ValueMember = "pkEndereco";
			comboEndereco.DisplayMember = "rua";
			comboEndereco.DataSource = dt;

			conn.Close();
		}
	}
}
