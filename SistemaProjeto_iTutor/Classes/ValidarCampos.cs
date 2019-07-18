using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaProjeto_iTutor.Classes
{
    public static class ValidarCampos
    {
        public static string respostaFinal = String.Empty;
        public static bool camposIncompletos = false;

        public static void VerificarConsistencia(string nome, string cpf, int indexPerfilUsuario, string nascimento, string cep, string telefone, string rua, string numero, string bairro, string cidade, string estado, string usuario, string senha, string perfilUsuario, int indexFormacaoAcademica, string valorHoraAula)
        {
            camposIncompletos = false;
            respostaFinal = String.Empty;
            string resposta = "Os seguintes campos precisam ser preenchidos: ";

            if (string.IsNullOrWhiteSpace(nome))
            {
                camposIncompletos = true;
                resposta += "\n - Nome";
            }

            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length < 11)
            {
                camposIncompletos = true;
                resposta += "\n - CPF";
            }
            
            if (string.IsNullOrWhiteSpace(nascimento))
            {
                camposIncompletos = true;
                resposta += "\n - Data de nascimento";
            }
            else
            {
                DateTime result;
                if (!DateTime.TryParse(nascimento, out result))
                {
                    camposIncompletos = true;
                    resposta += "\n - Data de nascimento";
                }
            }

            if (string.IsNullOrWhiteSpace(cep) || cep.Length < 8)
            {
                camposIncompletos = true;
                resposta += "\n - CEP";
            }

            if (string.IsNullOrWhiteSpace(telefone) || telefone.Length < 10)
            {
                camposIncompletos = true;
                resposta += "\n - Telefone";
            }

            if (string.IsNullOrWhiteSpace(rua))
            {
                camposIncompletos = true;
                resposta += "\n - Rua";
            }

            if (string.IsNullOrWhiteSpace(numero))
            {
                camposIncompletos = true;
                resposta += "\n - Número";
            }

            if (string.IsNullOrWhiteSpace(bairro))
            {
                camposIncompletos = true;
                resposta += "\n - Bairro";
            }

            if (string.IsNullOrWhiteSpace(cidade))
            {
                camposIncompletos = true;
                resposta += "\n - Cidade";
            }

            if (string.IsNullOrWhiteSpace(estado))
            {
                camposIncompletos = true;
                resposta += "\n - Estado";
            }

            if (string.IsNullOrWhiteSpace(usuario))
            {
                camposIncompletos = true;
                resposta += "\n - Usuário";
            }
            else
            {
                SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
                SqlCommand query = new SqlCommand();
                query.Connection = conexao;
                conexao.Open();

                query.CommandText = "SELECT COUNT (usuario) as valor FROM usuario WHERE usuario = @usuario";
                query.Parameters.AddWithValue("@usuario", usuario);
                int usuarioJaCadastrado = (int)query.ExecuteScalar();
                if (usuarioJaCadastrado > 0)
                {
                    camposIncompletos = true;
                    resposta += "\n - Usuário (já existe um cadastro com esse usuário)";
                }
            }

            if (string.IsNullOrWhiteSpace(senha) || senha.Length == 0)
            {
                camposIncompletos = true;
                resposta += "\n - Senha";
            }

            if (indexPerfilUsuario == -1)
            {
                camposIncompletos = true;
                resposta += "\n - Perfil usuário";
            }
            else
            {
                if (perfilUsuario == "Professor")
                {
                    if (indexFormacaoAcademica == -1)
                    {
                        camposIncompletos = true;
                        resposta += "\n - Formação acadêmica";
                    }

                    if (string.IsNullOrWhiteSpace(valorHoraAula))
                    {
                        camposIncompletos = true;
                        resposta += "\n - Valor hora/aula";
                    }
                }
            }

            if (camposIncompletos)
            {
                respostaFinal = resposta;
            }
        }

        //Aluno
        public static void VerificarConsistencia(string nome, string cpf, string nascimento, string cep, string telefone, string rua, string numero, string bairro, string cidade, string estado, string usuario, string senha, int pkAlunoSelecionado)
        {
            camposIncompletos = false;
            respostaFinal = String.Empty;
            string resposta = "Os seguintes campos precisam ser peenchidos: ";

            if (string.IsNullOrWhiteSpace(nome))
            {
                camposIncompletos = true;
                resposta += "\n - Nome";
            }

            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length < 11)
            {
                camposIncompletos = true;
                resposta += "\n - CPF";
            }

            if (string.IsNullOrWhiteSpace(nascimento))
            {
                camposIncompletos = true;
                resposta += "\n - Data de nascimento";
            }
            else
            {
                DateTime result;
                if (!DateTime.TryParse(nascimento, out result))
                {
                    camposIncompletos = true;
                    resposta += "\n - Data de nascimento";
                }
            }

            if (string.IsNullOrWhiteSpace(cep) || cep.Length < 8)
            {
                camposIncompletos = true;
                resposta += "\n - CEP";
            }

            if (string.IsNullOrWhiteSpace(telefone) || telefone.Length < 10)
            {
                camposIncompletos = true;
                resposta += "\n - Telefone";
            }

            if (string.IsNullOrWhiteSpace(rua))
            {
                camposIncompletos = true;
                resposta += "\n - Rua";
            }

            if (string.IsNullOrWhiteSpace(numero))
            {
                camposIncompletos = true;
                resposta += "\n - Número";
            }

            if (string.IsNullOrWhiteSpace(bairro))
            {
                camposIncompletos = true;
                resposta += "\n - Bairro";
            }

            if (string.IsNullOrWhiteSpace(cidade))
            {
                camposIncompletos = true;
                resposta += "\n - Cidade";
            }

            if (string.IsNullOrWhiteSpace(estado))
            {
                camposIncompletos = true;
                resposta += "\n - Estado";
            }

            if (string.IsNullOrWhiteSpace(usuario))
            {
                camposIncompletos = true;
                resposta += "\n - Usuário";
            }
            else
            {
                SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
                SqlCommand query = new SqlCommand();
                query.Connection = conexao;
                conexao.Open();
                query.CommandText = "SELECT usuario FROM usuario WHERE fkAluno = @pkAlunoSelecionado";
                query.Parameters.AddWithValue("@pkAlunoSelecionado", pkAlunoSelecionado);
                query.ExecuteNonQuery();
                string alunoPreAlteracao = (string)query.ExecuteScalar();

                if (alunoPreAlteracao.Equals(usuario))
                {
                    //MessageBox.Show("IGuais. pode prosseguir com o cadastro");

                    //ExecuteNonQuery conta somente as linhas afetadas (insert, update e delete. Não funciona para select pq não modifica linhas)
                }
                else
                {
                    query.CommandText = "SELECT COUNT (usuario) as valor FROM usuario WHERE usuario = @usuario";
                    query.Parameters.AddWithValue("@usuario", usuario);
                    query.ExecuteNonQuery();
                    int usuarioJaCadastrado = (int)query.ExecuteScalar();
                    if (usuarioJaCadastrado > 0)
                    {
                        camposIncompletos = true;
                        resposta += "\n - Usuário (já existe um cadastro com esse usuário)";
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(senha) || senha.Length == 0)
            {
                camposIncompletos = true;
                resposta += "\n - Senha";
            }
            
            if (camposIncompletos)
            {
                respostaFinal = resposta;
            }
        }

        //Professor
        public static void VerificarConsistencia(string nome, string cpf, string nascimento, string cep, string telefone, string rua, string numero, string bairro, string cidade, string estado, string usuario, string senha, int indexFormacaoAcademica, string valorHoraAula, int pkProfessorSelecionado)
        {
            camposIncompletos = false;
            respostaFinal = String.Empty;
            string resposta = "Os seguintes campos precisam ser peenchidos: ";

            if (string.IsNullOrWhiteSpace(nome))
            {
                camposIncompletos = true;
                resposta += "\n - Nome";
            }

            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length < 11)
            {
                camposIncompletos = true;
                resposta += "\n - CPF";
            }

            if (string.IsNullOrWhiteSpace(nascimento))
            {
                camposIncompletos = true;
                resposta += "\n - Data de nascimento";
            }
            else
            {
                DateTime result;
                if (!DateTime.TryParse(nascimento, out result))
                {
                    camposIncompletos = true;
                    resposta += "\n - Data de nascimento";
                }
            }

            if (string.IsNullOrWhiteSpace(cep) || cep.Length < 8)
            {
                camposIncompletos = true;
                resposta += "\n - CEP";
            }

            if (string.IsNullOrWhiteSpace(telefone) || telefone.Length < 10)
            {
                camposIncompletos = true;
                resposta += "\n - Telefone";
            }

            if (string.IsNullOrWhiteSpace(rua))
            {
                camposIncompletos = true;
                resposta += "\n - Rua";
            }

            if (string.IsNullOrWhiteSpace(numero))
            {
                camposIncompletos = true;
                resposta += "\n - Número";
            }

            if (string.IsNullOrWhiteSpace(bairro))
            {
                camposIncompletos = true;
                resposta += "\n - Bairro";
            }

            if (string.IsNullOrWhiteSpace(cidade))
            {
                camposIncompletos = true;
                resposta += "\n - Cidade";
            }

            if (string.IsNullOrWhiteSpace(estado))
            {
                camposIncompletos = true;
                resposta += "\n - Estado";
            }

            if (string.IsNullOrWhiteSpace(usuario))
            {
                camposIncompletos = true;
                resposta += "\n - Usuário";
            }
            else
            {
                SqlConnection conexao = new SqlConnection(Banco.enderecoBanco());
                SqlCommand query = new SqlCommand();

                query.Connection = conexao;
                conexao.Open();
                query.CommandText = "SELECT usuario FROM usuario WHERE fkProfessor = @pkProfessorSelecionado";
                query.Parameters.AddWithValue("@pkProfessorSelecionado", pkProfessorSelecionado);
                query.ExecuteNonQuery();
                string professorPreAlteracao = (string)query.ExecuteScalar();
                
                if(professorPreAlteracao.Equals(usuario))
                {
                    //MessageBox.Show("IGuais. pode prosseguir com o cadastro");

                    //ExecuteNonQuery conta somente as linhas afetadas (insert, update e delete. Não funciona para select pq não modifica linhas)
                }
                else
                {
                    query.CommandText = "SELECT COUNT (usuario) as valor FROM usuario WHERE usuario = @usuario";
                    query.Parameters.AddWithValue("@usuario", usuario);
                    query.ExecuteNonQuery();
                    int usuarioJaCadastrado = (int)query.ExecuteScalar();
                    if (usuarioJaCadastrado > 0)
                    {
                        camposIncompletos = true;
                        resposta += "\n - Usuário (já existe um cadastro com esse usuário)";
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(senha) || senha.Length == 0)
            {
                camposIncompletos = true;
                resposta += "\n - Senha";
            }

            if (indexFormacaoAcademica == -1)
            {
                camposIncompletos = true;
                resposta += "\n - Formação acadêmica";
            }

            if (string.IsNullOrWhiteSpace(valorHoraAula))
            {
                camposIncompletos = true;
                resposta += "\n - Valor hora/aula";
            }

            if (camposIncompletos)
            {
                respostaFinal = resposta;
            }
        }

    }
}
