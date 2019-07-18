using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaProjeto_iTutor.Classes
{
    public static class Limpar
    {
        public static void limparComponentes(Control controles)
        {
            foreach (Control c in controles.Controls)
            {
                if (c is TextBox) { (c as TextBox).Text = String.Empty; }
                else if (c is ComboBox) { (c as ComboBox).SelectedIndex = -1; }
                else if (c is RadioButton) { (c as RadioButton).Checked = false; }
                else if (c is CheckBox) { (c as CheckBox).Checked = false; }
                else if (c is MaskedTextBox) { (c as MaskedTextBox).Text = String.Empty; }
                else if (c is GroupBox)
                {
                    for (int i = 0; i < c.Controls.Count; i++)
                    {
                        if (c.Controls[i] is RadioButton) { (c.Controls[i] as RadioButton).Checked = false; }
                        else if (c.Controls[i] is CheckBox) { (c.Controls[i] as CheckBox).Checked = false; }
                    }
                }
            }
        }
    }
}
