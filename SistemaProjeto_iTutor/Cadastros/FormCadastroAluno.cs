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

namespace SistemaProjeto_iTutor.Cadastros
{
    

    public partial class FormCadastroAluno : Form
    {
        public FormCadastroAluno()
        {
            InitializeComponent();
        }

        int pkAluno = Autenticacao.pkAlunoLogado;

        private void FormCadastroAluno_Load(object sender, EventArgs e)
        {
            btnSalvar.Visible = false;
            if (Autenticacao.levelPermissao == 2) //aluno
            {
                btnExcluir.Visible = false;
                btnLimpar.Visible = false;
                btnSalvar.Visible = false;

                btnAlterar.Location = new Point(679, 363);

                try
                {
                    string sql = "SELECT a.nome, a.cpf,a.dataNascimento, a.responsavel, a.telefone, e.cep, e.rua, e.numero, e.bairro, e.estado, e.cidade, u.usuario, u.senha, a.pkAluno FROM aluno AS a, endereco AS e, usuario AS u WHERE a.pkAluno = " + pkAluno + " AND e.fkAluno = " + pkAluno + " AND u.fkAluno = " + pkAluno + " AND u.statusCadastro = 0 and a.statusCadastro = 0 ;";
                    SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
                    SqlDataAdapter da = new SqlDataAdapter(sql, conexao);
                    DataSet ds = new DataSet();
                    conexao.Open();
                    da.Fill(ds, "aluno");
                    conexao.Close();
                    dgvAluno.DataSource = ds;
                    dgvAluno.DataMember = "aluno";
                    
                    for (int i = 2; i < dgvAluno.Columns.Count; i++)
                    {
                        dgvAluno.Columns[i].Visible = false;
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
                    string strConexao = Banco.enderecoBanco();
                    string sql = "select a.nome, a.cpf,a.dataNascimento, a.responsavel, a.telefone, e.cep, e.rua, e.numero, e.bairro, e.estado, e.cidade, u.usuario, u.senha, a.pkAluno from ((aluno as a inner join endereco as e on a.pkAluno = e.fkAluno) inner join  usuario as u on a.pkAluno = u.fkAluno) where u.statusCadastro = 0 and a.statusCadastro = 0;";
                    SqlConnection conexao = new SqlConnection(strConexao);
                    SqlDataAdapter da = new SqlDataAdapter(sql, conexao);
                    DataSet ds = new DataSet();
                    conexao.Open();
                    da.Fill(ds, "aluno");
                    conexao.Close();
                    dgvAluno.DataSource = ds;
                    dgvAluno.DataMember = "aluno";

                    for (int i = 2; i < dgvAluno.Columns.Count; i++)
                    {
                        dgvAluno.Columns[i].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar.limparComponentes(this);
        }

        private void dgvAluno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                preencherTextBoxAluno(e);
                pkAluno = Convert.ToInt32(dgvAluno.Rows[e.RowIndex].Cells["pkAluno"].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void preencherTextBoxAluno(DataGridViewCellEventArgs e)
        {
            txtNomeAluno.Text = dgvAluno.Rows[e.RowIndex].Cells["nome"].Value.ToString();
            txtCPF.Text = dgvAluno.Rows[e.RowIndex].Cells["cpf"].Value.ToString();
            txtNomeResponsavel.Text = dgvAluno.Rows[e.RowIndex].Cells["responsavel"].Value.ToString();
            txtDataNascimento.Text = dgvAluno.Rows[e.RowIndex].Cells["dataNascimento"].Value.ToString();
            txtTelefone.Text = dgvAluno.Rows[e.RowIndex].Cells["telefone"].Value.ToString();
            txtCEP.Text = dgvAluno.Rows[e.RowIndex].Cells["cep"].Value.ToString();
            txtRua.Text = dgvAluno.Rows[e.RowIndex].Cells["rua"].Value.ToString();
            txtNumero.Text = dgvAluno.Rows[e.RowIndex].Cells["numero"].Value.ToString();
            txtCidade.Text = dgvAluno.Rows[e.RowIndex].Cells["cidade"].Value.ToString();
            txtEstado.Text = dgvAluno.Rows[e.RowIndex].Cells["estado"].Value.ToString();
            txtBairro.Text = dgvAluno.Rows[e.RowIndex].Cells["bairro"].Value.ToString();
            txtUsuario.Text = dgvAluno.Rows[e.RowIndex].Cells["usuario"].Value.ToString();
            txtSenha.Text = dgvAluno.Rows[e.RowIndex].Cells["senha"].Value.ToString();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ValidarCampos.VerificarConsistencia(txtNomeAluno.Text, AdaptarParametros.adaptarCPF(txtCPF.Text), txtDataNascimento.MaskCompleted ? txtDataNascimento.Text : String.Empty, AdaptarParametros.adaptarCEP(txtCEP.Text), AdaptarParametros.adaptarTelefone(txtTelefone.Text), txtRua.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text, txtEstado.Text, txtUsuario.Text, txtSenha.Text, pkAluno);

            if(ValidarCampos.camposIncompletos)
            {
                MessageBox.Show(ValidarCampos.respostaFinal);
            }
            else
            {
                SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
                SqlCommand query = new SqlCommand();

                query.Connection = conexao;
                conexao.Open();

                /* =========================================================             
                    string textoQuery = "UPDATE aluno SET ";
                    if(txtNomeAluno.Text!="") { textoQuery = textoQuery + "nome = @nome"; query.Parameters.AddWithValue("@nome", txtNomeAluno.Text); }
                    query.Parameters.AddWithValue("@pkAluno", pkAluno);
                    textoQuery += " where pkAluno = @pkAluno and statusCadastro = 0";
                    query.CommandText = textoQuery;

             ****** Fazer validação dos campos para que só seja feito update nos campos que estejam preenchidos (!= "")
                 =========================================================  */

                query.CommandText = "UPDATE aluno SET nome = @nome, cpf = @cpf, dataNascimento = @dataNascimento, responsavel = @responsavel, telefone = @telefone where pkAluno = @pkAluno and statusCadastro = 0";
                query.Parameters.AddWithValue("@nome", txtNomeAluno.Text);
                query.Parameters.AddWithValue("@dataNascimento", AdaptarParametros.adaptarDataNascimento(txtDataNascimento.Text));
                query.Parameters.AddWithValue("@cpf", AdaptarParametros.adaptarCPF(txtCPF.Text));
                query.Parameters.AddWithValue("@telefone", AdaptarParametros.adaptarTelefone(txtTelefone.Text));
                query.Parameters.AddWithValue("@responsavel", txtNomeResponsavel.Text);
                query.Parameters.AddWithValue("@pkAluno", pkAluno);
                query.ExecuteNonQuery();

                query.CommandText = "UPDATE endereco SET rua = @rua, numero = @numero, cep = @cep, bairro = @bairro, cidade = @cidade, estado = @estado where fkAluno = @pkAluno and statusCadastro = 0";
                query.Parameters.AddWithValue("@rua", txtRua.Text);
                query.Parameters.AddWithValue("@numero", txtNumero.Text);
                query.Parameters.AddWithValue("@cep", AdaptarParametros.adaptarCEP(txtCEP.Text));
                query.Parameters.AddWithValue("@bairro", txtBairro.Text);
                query.Parameters.AddWithValue("@cidade", txtCidade.Text);
                query.Parameters.AddWithValue("@estado", txtEstado.Text);
                query.Parameters.AddWithValue("@fkAluno", pkAluno);
                query.ExecuteNonQuery();

                query.CommandText = "UPDATE usuario SET usuario = @usuario, senha = @senha where fkAluno = @pkAluno and statusCadastro = 0";
                query.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                query.Parameters.AddWithValue("@senha", txtSenha.Text);
                query.ExecuteNonQuery();
                conexao.Close();
                FormCadastroAluno_Load(null, null);
                MessageBox.Show("Cadastro alterado com sucesso");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
            SqlCommand query = new SqlCommand();

            query.Connection = conexao;
            conexao.Open();

            query.Parameters.AddWithValue("@pkAluno", pkAluno);

            //query.CommandText = "UPDATE aluno SET statusCadastro = 999 where pkAluno = @pkAluno";
            //query.ExecuteNonQuery();

            query.CommandText = "UPDATE usuario SET statusCadastro = 999 where fkAluno = @pkAluno";

            int cont = query.ExecuteNonQuery();

            if (cont > 0)   {  MessageBox.Show("Removido com sucesso"); }
            else            { MessageBox.Show("Erro ao remover"); }


            FormCadastroAluno_Load(null, null);
            conexao.Close();
            Limpar.limparComponentes(this);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ValidarCampos.VerificarConsistencia(txtNomeAluno.Text, AdaptarParametros.adaptarCPF(txtCPF.Text), txtDataNascimento.MaskCompleted ? txtDataNascimento.Text : String.Empty, AdaptarParametros.adaptarCEP(txtCEP.Text), AdaptarParametros.adaptarTelefone(txtTelefone.Text), txtRua.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text, txtEstado.Text, txtUsuario.Text, txtSenha.Text, pkAluno);

            if(ValidarCampos.camposIncompletos)
            {
                MessageBox.Show(ValidarCampos.respostaFinal);
            }
            else
            {
                DateTime localDate = DateTime.Now;

                string diaHoraAtual = localDate.ToString();
                string diaAtual = diaHoraAtual.Substring(0, 2);
                string mesAtual = diaHoraAtual.Substring(3, 2);
                string anoAtual = diaHoraAtual.Substring(6, 4);
                string horaAtual = diaHoraAtual.Substring(11, 8);

                diaHoraAtual = anoAtual + "-" + mesAtual + "-" + diaAtual + " " + horaAtual;

                SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
                SqlCommand query = new SqlCommand();

                query.Connection = conexao;
                conexao.Open();

                query.Parameters.AddWithValue("@nome", txtNomeAluno.Text);
                query.Parameters.AddWithValue("@dataNascimento", AdaptarParametros.adaptarDataNascimento(txtDataNascimento.Text));
                query.Parameters.AddWithValue("@cpf", AdaptarParametros.adaptarCPF(txtCPF.Text));
                query.Parameters.AddWithValue("@statusCadastro", 0);
                query.Parameters.AddWithValue("@telefone", AdaptarParametros.adaptarTelefone(txtTelefone.Text));

                query.Parameters.AddWithValue("@cep", AdaptarParametros.adaptarCEP(txtCEP.Text));
                query.Parameters.AddWithValue("@rua", txtRua.Text);
                query.Parameters.AddWithValue("@numero", txtNumero.Text);
                query.Parameters.AddWithValue("@bairro", txtBairro.Text);
                query.Parameters.AddWithValue("@cidade", txtCidade.Text);
                query.Parameters.AddWithValue("@estado", txtEstado.Text);

                query.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                query.Parameters.AddWithValue("@senha", txtSenha.Text);
                query.Parameters.AddWithValue("@dataCriacao", Convert.ToDateTime(diaHoraAtual));
                query.Parameters.AddWithValue("@solicitacaoAprovada", 1);

                query.CommandText = "IF NOT EXISTS (SELECT cpf FROM aluno WHERE cpf = @cpf) INSERT INTO aluno (nome, dataNascimento, cpf, statusCadastro, telefone) values (@nome, @dataNascimento, @cpf, @statusCadastro, @telefone)";

                int linhasAfetadas = query.ExecuteNonQuery();
                if(linhasAfetadas > 0)
                {
                    query.CommandText = "SELECT pkAluno FROM aluno WHERE cpf = '" + AdaptarParametros.adaptarCPF(txtCPF.Text) + "'";
                    DataTable tabela = new DataTable();
                    SqlDataAdapter adaptador = new SqlDataAdapter(query);
                    adaptador.Fill(tabela);
                    query.ExecuteNonQuery();

                    int pkAluno = Convert.ToInt32(tabela.Rows[0]["pkAluno"].ToString());
                    query.Parameters.AddWithValue("@fkProfessor", DBNull.Value);
                    query.Parameters.AddWithValue("@fkAluno", pkAluno);

                    query.CommandText = "INSERT INTO endereco (cep, rua, numero, bairro, cidade, estado, statusCadastro, fkAluno, fkProfessor) VALUES (@cep, @rua, @numero, @bairro, @cidade, @estado, @statusCadastro, @fkAluno, @fkProfessor)";
                    query.ExecuteNonQuery();

                    query.Parameters.AddWithValue("@levelPermissao", 2);
                    query.CommandText = "INSERT INTO usuario (usuario, senha, levelPermissao, dataCriacao, solicitacaoAprovada, statusCadastro,fkAluno, fkProfessor) VALUES (@usuario, @senha, @levelPermissao, @dataCriacao, @solicitacaoAprovada, @statusCadastro,@fkAluno, @fkProfessor)";
                    query.ExecuteNonQuery();

                    FormCadastroAluno_Load(null, null);
                    conexao.Close();
                    MessageBox.Show("Registro cadastrado com sucesso");
                }
                else
                {
                    MessageBox.Show("Já existe um registro com esse CPF");
                }
            }
        }
	}
}
