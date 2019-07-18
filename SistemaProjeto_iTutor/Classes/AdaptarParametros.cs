using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProjeto_iTutor.Classes
{
    public static class AdaptarParametros
    {
        public static string adaptarCPF(string cpf)
        {
            return cpf.Trim().Replace(",", "").Replace("-", "");
        }

        //public static string adaptarDataNascimento(string dataNascimento)
        //{
        //    string dia = dataNascimento.Substring(0, 2);
        //    string mes = dataNascimento.Substring(3, 2);
        //    string ano = dataNascimento.Substring(6, 4);
        //    dataNascimento = ano + "-" + mes + "-" + dia;

        //    return dataNascimento;
        //}

        public static DateTime adaptarDataNascimento(string dataNascimento)
        {
            string dia = dataNascimento.Substring(0, 2);
            string mes = dataNascimento.Substring(3, 2);
            string ano = dataNascimento.Substring(6, 4);
            dataNascimento = ano + "-" + mes + "-" + dia;

            return Convert.ToDateTime(dataNascimento);
        }

        public static string adaptarTelefone(string telefone)
        {
            return telefone.Trim().Replace(")", "").Replace("(", "");
        }

        public static string adaptarCEP(string cep)
        {
            return cep.Trim().Replace("-", "");
        }
    }
}
