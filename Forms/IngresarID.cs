using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Autolavado_Georges.Formularios
{
    public partial class IngresarID : Form
    {
        public int ReturnID { get; private set; }
        private bool valid = false;
        public IngresarID()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Interfaz.OnlyNumbers(sender, e);

            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || Convert.ToInt16(textBox1.Text) < 1) ReturnID = -1;
                else ReturnID = Convert.ToInt32(textBox1.Text);
                valid = true;
                this.Close();
            }
            else if (e.KeyChar == (char)27)
            {
                textBox1.Text = "";
                this.Close();
            }
        }

        private void IngresarID_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!valid && string.IsNullOrWhiteSpace(textBox1.Text))
            {
                ReturnID = -1;
            }
        }

        private void IngresarID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
