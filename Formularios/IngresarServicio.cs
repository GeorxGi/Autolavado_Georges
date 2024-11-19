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
        public string Servicio { get; private set; } = "";
        public IngresarServicio()
        {
            InitializeComponent();
        }

        private void balanceoButton_Click(object sender, EventArgs e)
        {
            Servicio = Servicios.ServiciosDisp[0];
            this.Close();
        }

        private void aceiteButton_Click(object sender, EventArgs e)
        {
            Servicio = Servicios.ServiciosDisp[1];
            this.Close();
        }

        private void aspiradoButton_Click(object sender, EventArgs e)
        {
            Servicio = Servicios.ServiciosDisp[2];
            this.Close();
        }

        private void lavadoButton_Click(object sender, EventArgs e)
        {
            Servicio = Servicios.ServiciosDisp[3];
            this.Close();
        }

        private void secadoButton_Click(object sender, EventArgs e)
        {
            Servicio = Servicios.ServiciosDisp[4];
            this.Close();
        }

        private void IngresarServicio_Load(object sender, EventArgs e)
        {
            balanceoButton.Text = Servicios.ServiciosDisp[0];
            aceiteButton.Text = "Cambio de " + Servicios.ServiciosDisp[1];
            aspiradoButton.Text = Servicios.ServiciosDisp[2];
            lavadoButton.Text = Servicios.ServiciosDisp[3];
            secadoButton.Text = Servicios.ServiciosDisp[4];

        }
    }
}
