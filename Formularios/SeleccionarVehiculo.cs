using Autolavado_GeorgesChakour.Clases;
using Newtonsoft.Json.Linq;
using System.Net.WebSockets;

namespace Proyecto_Autolavado_Georges.Formularios
{
    public partial class SeleccionarVehiculo : Form
    {
        public Vehiculo? VehiculoSeleccionado { get; private set; }
        private Vehiculo[] CarArray;
        Lista<Vehiculo> list;

        private void Seleccionado()
        {
            if (tipoCarrocomboBox.SelectedIndex == -1)
            {
                VehiculoSeleccionado = null;
            }
            else
            {
                VehiculoSeleccionado = CarArray[tipoCarrocomboBox.SelectedIndex];
            }
        }

        /// <summary>
        /// Formulario para seleccionar uno de los vehiculos del cliente ingresado
        /// </summary>
        /// <param name="veh">Vehiculo a modificar</param>
        public SeleccionarVehiculo(Cliente cliente)
        {
            VehiculoSeleccionado = null;
            list = cliente.VehiculosRegistrados;
            InitializeComponent();
        }

        private void CleanRegisterButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormularioVehiculo_Load(object sender, EventArgs e)
        {
            CarArray = new Vehiculo[list.Cant];
            uint i = 0;
            foreach (Vehiculo veh in list)
            {
                CarArray[i++] = veh;
                tipoCarrocomboBox.Items.Add($"{veh.Modelo} - {veh.Placa}");
            }
        }

        private void AcceptRegisterButton_Click(object sender, EventArgs e)
        {
            Seleccionado();
            this.Close();
        }

        private void SeleccionarVehiculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void tipoCarrocomboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Seleccionado();
                this.Close();
            }
        }
    }
}
