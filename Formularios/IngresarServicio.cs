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
    public partial class IngresarServicio : Form
    {
        public Servicios? Servicio { get; private set; }
        public IngresarServicio()
        {
            Servicio = null;
            InitializeComponent();
        }

        private void balanceoButton_Click(object sender, EventArgs e)
        {
            Servicio = Servicios.Balanceo;
            this.Close();
        }

        private void aceiteButton_Click(object sender, EventArgs e)
        {
            Servicio = Servicios.Aceite;
            this.Close();
        }

        private void aspiradoButton_Click(object sender, EventArgs e)
        {
            Servicio = Servicios.Aspirado;
            this.Close();
        }

        private void lavadoButton_Click(object sender, EventArgs e)
        {
            Servicio = Servicios.Lavado;
            this.Close();
        }

        private void secadoButton_Click(object sender, EventArgs e)
        {
            Servicio = Servicios.Secado;
            this.Close();
        }

        private void IngresarServicio_Load(object sender, EventArgs e)
        {
        }
    }
}
