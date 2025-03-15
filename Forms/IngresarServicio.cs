using Proyecto_Autolavado_Georges.Clases.DataHandlers;
using Proyecto_Autolavado_Georges.Clases.UI;

namespace Proyecto_Autolavado_Georges.Formularios
{
    public partial class IngresarServicio : Form
    {
        public Services? Servicio { get; private set; }
        public IngresarServicio()
        {
            Servicio = null;
            InitializeComponent();
        }

        private void balanceoButton_Click(object sender, EventArgs e)
        {
            Servicio = Services.Balanceo;
            this.Close();
        }

        private void aceiteButton_Click(object sender, EventArgs e)
        {
            Servicio = Services.Aceite;
            this.Close();
        }

        private void aspiradoButton_Click(object sender, EventArgs e)
        {
            Servicio = Services.Aspirado;
            this.Close();
        }

        private void lavadoButton_Click(object sender, EventArgs e)
        {
            Servicio = Services.Lavado;
            this.Close();
        }

        private void secadoButton_Click(object sender, EventArgs e)
        {
            Servicio = Services.Secado;
            this.Close();
        }

        private void IngresarServicio_Load(object sender, EventArgs e)
        {
            AppSettings.LoadMenuColor(this);
        }

        private void IngresarServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}