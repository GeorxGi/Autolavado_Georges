namespace Proyecto_Autolavado_Georges.Formularios
{
    public partial class IngresarNumero : Form
    {
        public int ReturnNumber { get; private set; }
        private bool valid = false;
        private int Min, Max;
        public IngresarNumero(string mensaje, int min, int max)
        {
            InitializeComponent();
            label1.Text = mensaje;
            Min = min; Max = max;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Interfaz.OnlyNumbers(sender, e);

            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || Convert.ToInt16(textBox1.Text) < 1) ReturnNumber = -1;
                else ReturnNumber = Convert.ToInt32(textBox1.Text);
                valid = true;

                if (ReturnNumber < Min || ReturnNumber > Max)
                {
                    ReturnNumber = -1;
                    valid = false;
                }

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
                ReturnNumber = -1;
            }
        }

        private void IngresarNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
