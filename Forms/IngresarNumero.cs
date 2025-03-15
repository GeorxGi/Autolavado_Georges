using Proyecto_Autolavado_Georges.Clases.UI;

namespace Proyecto_Autolavado_Georges.Formularios
{
    public partial class IngresarNumero : Form
    {
        public decimal ReturnNumber { get; private set; }
        private bool valid = false;
        private readonly decimal Min, Max;
        private readonly bool AcceptDecimals;

        public IngresarNumero(string mensaje, decimal min, decimal max, bool acceptdecimals)
        {
            InitializeComponent();
            label1.Text = mensaje;
            Min = min;
            Max = max;
            AcceptDecimals = acceptdecimals;
        }
        public IngresarNumero(string mensaje, decimal min, bool acceptdecimals)
        {
            InitializeComponent();
            label1.Text = mensaje;
            Min = min;
            Max = decimal.MaxValue;
            AcceptDecimals = acceptdecimals;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (AcceptDecimals)
            {
                //If there is already a semicolon, handle input
                if (textBox1.Text.Contains('.') || textBox1.Text.Contains(','))
                {
                    UIHandler.OnlyNumbers(sender, e);
                }
                //There are not semicolons
                else
                {
                    UIHandler.OnlyNumbersWithDecimal(sender, e);
                }
            }
            else UIHandler.OnlyNumbers(sender, e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || Convert.ToDecimal(textBox1.Text) < 1) ReturnNumber = -1;
                else ReturnNumber = Convert.ToDecimal(textBox1.Text);
                valid = true;

                if (ReturnNumber < Min || ReturnNumber > Max)
                {
                    ReturnNumber = -1;
                    valid = false;
                }

                this.Close();
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                textBox1.Text = string.Empty;
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
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void IngresarNumero_Load(object sender, EventArgs e)
        {
        }
    }
}
