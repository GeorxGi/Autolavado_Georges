using Proyecto_Autolavado_Georges.Clases.UI;

namespace Proyecto_Autolavado_Georges.Formularios
{
    public partial class IngresarID : Form
    {
        public uint? ReturnID { get; private set; }
        private bool valid = false;
        public IngresarID()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIHandler.OnlyNumbers(sender, e);

            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || Convert.ToInt16(textBox1.Text) < 1) ReturnID = null;
                else ReturnID = Convert.ToUInt32(textBox1.Text);
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
                ReturnID = null;
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
