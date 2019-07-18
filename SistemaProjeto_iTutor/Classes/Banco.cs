using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProjeto_iTutor.Classes
{
    public static class Banco
    {
        public static string enderecoBanco()
        {

            //return "server=DESKTOP-EBQVT0A\\SQLEXPRESS;database=iTutor;UID=sa;password=123456";
            return "server=LAPTOP-RRGSDFI2\\SQLEXPRESS;database=iTutor;UID=sa;password=123456";
            //return "server=DESKTOP-O714ESL\\SQLEXPRESS;database=sandBox;UID=sa;password=123456";
            //return "server=SENAC\\SQLEXPRESS; database=iTutor;UID=sa;password=123456";
            //return "itutordb.cyvkzho0k0lr.sa-east-1.rds.amazonaws.com,1433; database=itutorDB;UID=itutor123;password=iTutor_123$senac";
            //return "server=DESKTOP-8CNT6OP; database=iTutor;UID=sa;password=123456";
        }
    }
}
