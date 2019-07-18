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

namespace SistemaProjeto_iTutor.Cadastros
{
    public partial class FormCadastroProfessor : Form
    {
        public FormCadastroProfessor()
        {
            InitializeComponent();
        }

        int pkProfessor = Autenticacao.pkProfessorLogado;
        int pkProfessorSelecionado = 0;

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FormCadastroProfessor_Load(object sender, EventArgs e)
        {
            btnSalvar.Visible = false;
            preencherComboBoxDisciplina();
            comboFormacaoProfessor.SelectedIndex = -1; //inicia o combo vazio

            SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            
            if (Autenticacao.levelPermissao == 1) //professor
            {
                btnExcluir.Visible = false;
                btnLimpar.Visible = false;
                btnSalvar.Visible = false;
                btnAlterar.Location = new Point(679, 363);

                comando.CommandText = "SELECT fkDisciplina FROM professor WHERE pkProfessor = " + pkProfessor + "";
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable tabela = new DataTable();
                adaptador.Fill(tabela);

                string pkDisciplina = tabela.Rows[0]["fkDisciplina"].ToString();
                
                string sql = "SELECT p.nome, p.cpf, d.nome as disciplina, e.cep, e.rua, e.numero, e.bairro, e.cidade, e.estado, p.email, p.valorHoraAula, p.dataNascimento, p.telefone, u.usuario, u.senha, p.pkProfessor, p.fkDisciplina " +
                    "FROM professor AS p, endereco AS e, usuario AS u, disciplina AS d " +
                    "WHERE p.pkProfessor = " + pkProfessor + " AND e.fkProfessor = " + pkProfessor + " AND u.fkProfessor = " + pkProfessor + " AND d.pkDisciplina = " + pkDisciplina + " AND u.statusCadastro = 0 and p.statusCadastro = 0 ; ";
                SqlDataAdapter da = new SqlDataAdapter(sql, conexao);
                DataSet ds = new DataSet();
                conexao.Open();
                da.Fill(ds, "professor");
                conexao.Close();
                dgvProfessor.DataSource = ds;
                dgvProfessor.DataMember = "professor";

                for (int i = 3; i < dgvProfessor.Columns.Count; i++)
                {
                    dgvProfessor.Columns[i].Visible = false;
                }
            }
            else //admin
            {
                string sql = "SELECT p.nome, p.cpf, d.nome as disciplina, e.cep, e.rua, e.numero, e.bairro, e.cidade, e.estado, p.email, p.valorHoraAula, p.dataNascimento, p.telefone, u.usuario, u.senha, p.pkProfessor, p.fkDisciplina " +
                    "FROM professor AS p, endereco AS e, usuario AS u, disciplina AS d " +
                    "WHERE p.pkProfessor = e.fkProfessor AND p.pkProfessor = u.fkProfessor AND p.fkDisciplina = d.pkDisciplina AND u.statusCadastro = 0 and p.statusCadastro = 0 ; ";
                SqlDataAdapter da = new SqlDataAdapter(sql, conexao);
                DataSet ds = new DataSet();
                conexao.Open();
                da.Fill(ds, "professor");
                conexao.Close();
                dgvProfessor.DataSource = ds;
                dgvProfessor.DataMember = "professor";

                for (int i = 3; i < dgvProfessor.Columns.Count; i++)
                {
                    dgvProfessor.Columns[i].Visible = false;
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar.limparComponentes(this);
        }

        private void dgvProfessor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            preencherTextBoxProfessor(e);
            pkProfessorSelecionado = Convert.ToInt32(dgvProfessor.Rows[e.RowIndex].Cells["pkProfessor"].Value.ToString());
        }

        public void preencherTextBoxProfessor(DataGridViewCellEventArgs e)
        {
            txtNomeProfressor.Text = dgvProfessor.Rows[e.RowIndex].Cells["nome"].Value.ToString();
            txtCPFProfessor.Text = dgvProfessor.Rows[e.RowIndex].Cells["cpf"].Value.ToString();
            comboFormacaoProfessor.SelectedValue = dgvProfessor.Rows[e.RowIndex].Cells["fkDisciplina"].Value.ToString();
            txtEmailProfessor.Text = dgvProfessor.Rows[e.RowIndex].Cells["email"].Value.ToString();
            txtValorHoraAula.Text = dgvProfessor.Rows[e.RowIndex].Cells["valorHoraAula"].Value.ToString();
            txtNascimentoProfessor.Text = dgvProfessor.Rows[e.RowIndex].Cells["dataNascimento"].Value.ToString();
            txtTelefone.Text = dgvProfessor.Rows[e.RowIndex].Cells["telefone"].Value.ToString();
            txtCEPProfessor.Text = dgvProfessor.Rows[e.RowIndex].Cells["cep"].Value.ToString();
            txtRua.Text = dgvProfessor.Rows[e.RowIndex].Cells["rua"].Value.ToString();
            txtNumProfessor.Text = dgvProfessor.Rows[e.RowIndex].Cells["numero"].Value.ToString();
            txtCidadeProfessor.Text = dgvProfessor.Rows[e.RowIndex].Cells["cidade"].Value.ToString();
            txtEstadoProfessor.Text = dgvProfessor.Rows[e.RowIndex].Cells["estado"].Value.ToString();
            txtBairroProfessor.Text = dgvProfessor.Rows[e.RowIndex].Cells["bairro"].Value.ToString();
            txtUsuario.Text = dgvProfessor.Rows[e.RowIndex].Cells["usuario"].Value.ToString();
            txtSenha.Text = dgvProfessor.Rows[e.RowIndex].Cells["senha"].Value.ToString();
        }

        public void preencherComboBoxDisciplina()
        {
            SqlConnection conn = new SqlConnection(Banco.enderecoBanco());
            conn.Open();
            SqlCommand sc = new SqlCommand("SELECT * FROM disciplina", conn);

            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Columns.Add("nome");
            dt.Load(reader);

            comboFormacaoProfessor.ValueMember = "pkDisciplina";
            comboFormacaoProfessor.DisplayMember = "nome";
            comboFormacaoProfessor.DataSource = dt;

            conn.Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ValidarCampos.VerificarConsistencia(txtNomeProfressor.Text, AdaptarParametros.adaptarCPF(txtCPFProfessor.Text), txtNascimentoProfessor.MaskCompleted ? txtNascimentoProfessor.Text : String.Empty, AdaptarParametros.adaptarCEP(txtCEPProfessor.Text), AdaptarParametros.adaptarTelefone(txtTelefone.Text), txtRua.Text, txtNumProfessor.Text, txtBairroProfessor.Text, txtCidadeProfessor.Text, txtEstadoProfessor.Text, txtUsuario.Text, txtSenha.Text, comboFormacaoProfessor.SelectedIndex, txtValorHoraAula.Text, pkProfessorSelecionado);

            if(ValidarCampos.camposIncompletos) { MessageBox.Show(ValidarCampos.respostaFinal); }
            else
            {
                SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
                SqlCommand query = new SqlCommand();
                query.Connection = conexao;
                conexao.Open();

                query.Parameters.AddWithValue("@nome", txtNomeProfressor.Text);
                query.Parameters.AddWithValue("@dataNascimento", AdaptarParametros.adaptarDataNascimento(txtNascimentoProfessor.Text));
                query.Parameters.AddWithValue("@cpf", AdaptarParametros.adaptarCPF(txtCPFProfessor.Text));
                query.Parameters.AddWithValue("@email", txtEmailProfessor.Text);
                query.Parameters.AddWithValue("@valorHoraAula", txtValorHoraAula.Text);
                query.Parameters.AddWithValue("@telefone", AdaptarParametros.adaptarTelefone(txtTelefone.Text));
                query.Parameters.AddWithValue("@pkDisciplina", comboFormacaoProfessor.SelectedValue.ToString());
                query.Parameters.AddWithValue("@pkProfessorSelecionado", pkProfessorSelecionado);

                query.Parameters.AddWithValue("@cep", AdaptarParametros.adaptarCEP(txtCEPProfessor.Text));
                query.Parameters.AddWithValue("@rua", txtRua.Text);
                query.Parameters.AddWithValue("@numero", txtNumProfessor.Text);
                query.Parameters.AddWithValue("@bairro", txtBairroProfessor.Text);
                query.Parameters.AddWithValue("@cidade", txtCidadeProfessor.Text);
                query.Parameters.AddWithValue("@estado", txtEstadoProfessor.Text);

                query.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                query.Parameters.AddWithValue("@senha", txtSenha.Text);

                query.CommandText = "UPDATE professor SET nome = @nome, dataNascimento = @dataNascimento, cpf = @cpf, email = @email, valorHoraAula = @valorHoraAula, telefone = @telefone, fkDisciplina = @pkDisciplina WHERE pkProfessor = @pkProfessorSelecionado AND statusCadastro = 0";
                query.ExecuteNonQuery();

                query.CommandText = "UPDATE endereco SET cep = @cep, rua = @rua, numero = @numero, bairro = @bairro, cidade = @cidade, estado = @estado WHERE fkProfessor = @pkProfessorSelecionado AND statusCadastro = 0";
                query.ExecuteNonQuery();

                query.CommandText = "UPDATE usuario SET usuario = @usuario, senha = @senha WHERE fkProfessor = @pkProfessorSelecionado AND statusCadastro = 0";
                query.ExecuteNonQuery();

                FormCadastroProfessor_Load(null, null);
                conexao.Close();
                MessageBox.Show("Cadastro alterado com sucesso");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
            SqlCommand query = new SqlCommand();
            query.Connection = conexao;
            conexao.Open();

            query.Parameters.AddWithValue("pkProfessor", pkProfessorSelecionado);

            //query.CommandText = "UPDATE professor SET statusCadastro = 999 WHERE pkProfessor = @pkProfessor";
            //query.ExecuteNonQuery();

            query.CommandText = "UPDATE usuario SET statusCadastro = 999 WHERE fkProfessor = @pkProfessor";
            query.ExecuteNonQuery();

            conexao.Close();
            FormCadastroProfessor_Load(null, null);
            MessageBox.Show("Cadastro removido com sucesso");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ValidarCampos.VerificarConsistencia(txtNomeProfressor.Text, AdaptarParametros.adaptarCPF(txtCPFProfessor.Text), txtNascimentoProfessor.MaskCompleted ? txtNascimentoProfessor.Text : String.Empty, AdaptarParametros.adaptarCEP(txtCEPProfessor.Text), AdaptarParametros.adaptarTelefone(txtTelefone.Text), txtRua.Text, txtNumProfessor.Text, txtBairroProfessor.Text, txtCidadeProfessor.Text, txtEstadoProfessor.Text, txtUsuario.Text, txtSenha.Text, comboFormacaoProfessor.SelectedIndex, txtValorHoraAula.Text, pkProfessorSelecionado);

            if (ValidarCampos.camposIncompletos)
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

                query.Parameters.AddWithValue("nome", txtNomeProfressor.Text);
                query.Parameters.AddWithValue("@dataNascimento", AdaptarParametros.adaptarDataNascimento(txtNascimentoProfessor.Text));
                query.Parameters.AddWithValue("@cpf", AdaptarParametros.adaptarCPF(txtCPFProfessor.Text));
                query.Parameters.AddWithValue("@email", txtEmailProfessor.Text);
                query.Parameters.AddWithValue("@valorHoraAula", txtValorHoraAula.Text);
                query.Parameters.AddWithValue("@telefone", AdaptarParametros.adaptarTelefone(txtTelefone.Text));
                query.Parameters.AddWithValue("@fkDisciplina", comboFormacaoProfessor.SelectedValue.ToString());
                query.Parameters.AddWithValue("@statusCadastro", 0);

                query.Parameters.AddWithValue("@cep", AdaptarParametros.adaptarCEP(txtCEPProfessor.Text));
                query.Parameters.AddWithValue("@rua", txtRua.Text);
                query.Parameters.AddWithValue("@numero", txtNumProfessor.Text);
                query.Parameters.AddWithValue("@bairro", txtBairroProfessor.Text);
                query.Parameters.AddWithValue("@cidade", txtCidadeProfessor.Text);
                query.Parameters.AddWithValue("@estado", txtEstadoProfessor.Text);

                query.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                query.Parameters.AddWithValue("@senha", txtSenha.Text);
                query.Parameters.AddWithValue("@levelPermissao", 1);
                query.Parameters.AddWithValue("@dataCriacao", Convert.ToDateTime(diaHoraAtual));

                query.CommandText = "INSERT INTO professor (nome, cpf, dataNascimento, telefone, email, valorHoraAula, statusCadastro, fkDisciplina) VALUES (@nome, @cpf, @dataNascimento, @telefone, @email, @valorHoraAula, @statusCadastro, @fkDisciplina)";
                query.ExecuteNonQuery();

                query.CommandText = "SELECT pkProfessor FROM professor WHERE cpf = '" + AdaptarParametros.adaptarCPF(txtCPFProfessor.Text) + "'";
                DataTable tabela = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(query);
                adaptador.Fill(tabela);
                query.ExecuteNonQuery();

                int pkProfesor = Convert.ToInt32(tabela.Rows[0]["pkProfessor"].ToString());
                query.Parameters.AddWithValue("@fkProfessor", pkProfesor);

                query.CommandText = "INSERT INTO endereco (cep, rua, numero, bairro, cidade, estado, statusCadastro, fkProfessor) VALUES (@cep, @rua, @numero, @bairro, @cidade, @estado, @statusCadastro, @fkProfessor)";
                query.ExecuteNonQuery();

                query.CommandText = "INSERT INTO usuario (usuario, senha, statusCadastro, solicitacaoAprovada, levelPermissao, dataCriacao, fkProfessor) VALUES (@usuario, @senha, @statusCadastro, 1, @levelPermissao, @dataCriacao, @fkProfessor)";
                query.ExecuteNonQuery();

                conexao.Close();
                FormCadastroProfessor_Load(null, null);
            }
        }
    }
}
