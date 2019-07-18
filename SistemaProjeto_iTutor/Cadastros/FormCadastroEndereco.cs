using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaProjeto_iTutor.Cadastros
{
    public partial class FormCadastroEndereco : Form
    {
        public FormCadastroEndereco()
        {
            InitializeComponent();
        }

        private void mskCEP_Leave(object sender, EventArgs e)
        {
            string cep = mskCEP.Text.Replace("-", "");

            if(cep.Length == 8)
            {
                try
                {
                    var webService = new WSCorreios.AtendeClienteClient();
                    var resposta = webService.consultaCEP(mskCEP.Text);
                    txtRua.Text = resposta.end;
                    txtBairro.Text = resposta.bairro;
                    txtCidade.Text = resposta.cidade;
                    txtEstado.Text = resposta.uf;
                }
                catch (Exception)
                {
                    MessageBox.Show("CEP não localizado");
                }
            }
            else
            {
                MessageBox.Show("Informe um valor de CEP válido");
            }
            
        }

        private void mskCEP_Click(object sender, EventArgs e)
        {
            mskCEP.SelectionStart = 0;
        }
    }
}
