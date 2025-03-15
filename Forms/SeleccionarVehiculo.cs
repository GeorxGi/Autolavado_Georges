using Proyecto_Autolavado_Georges.Clases.DataClasses;
using Proyecto_Autolavado_Georges.Clases.DataHandlers;
using Proyecto_Autolavado_Georges.Clases.UI;
using Proyecto_Autolavado_Georges.Clases.UserClasses;

namespace Proyecto_Autolavado_Georges.Formularios
{
    public partial class SeleccionarVehiculo : Form
    {
        public enum GetVehicleMode
        {
            OnlyInService,
            OnlyAvailable,
            All
        }

        public Vehiculo PickedVehicle { get; private set; }
        private Vehiculo[] CarArray;
        private readonly CustomLinkedList<Vehiculo> ClientsVehicle;
        private readonly GetVehicleMode FilterMode;

        private void Seleccionado()
        {
            if (tipoCarrocomboBox.SelectedIndex == -1)
            {
                PickedVehicle = null;
            }
            else
            {
                PickedVehicle = CarArray[tipoCarrocomboBox.SelectedIndex];
            }
        }

        /// <summary>
        /// Formulario para seleccionar uno de los vehiculos del cliente ingresado
        /// </summary>
        /// <param name="veh">Vehiculo a modificar</param>
        public SeleccionarVehiculo(Cliente cliente, GetVehicleMode filter)
        {
            PickedVehicle = null;
            ClientsVehicle = cliente.VehiculosRegistrados;
            InitializeComponent();
            FilterMode = filter;
        }

        private void FormularioVehiculo_Load(object sender, EventArgs e)
        {
            AppSettings.LoadMenuColor(this);
            CarArray = new Vehiculo[ClientsVehicle.Count];
            uint i = 0;

            switch (FilterMode)
            {
                case GetVehicleMode.OnlyInService:
                    foreach (Vehiculo veh in ClientsVehicle)
                    {
                        if (veh.ServicioUbicado.HasValue)
                        {
                            CarArray[i++] = veh;
                            tipoCarrocomboBox.Items.Add($"{veh.Modelo} - {veh.Placa}");
                        }
                    }
                break;

                case GetVehicleMode.OnlyAvailable:
                    foreach (Vehiculo veh in ClientsVehicle)
                    {
                        if (!veh.ServicioUbicado.HasValue)
                        {
                            CarArray[i++] = veh;
                            tipoCarrocomboBox.Items.Add($"{veh.Modelo} - {veh.Placa}");
                        }
                    }
                break;

                case GetVehicleMode.All:
                    foreach (Vehiculo veh in ClientsVehicle)
                    {
                        CarArray[i++] = veh;
                        tipoCarrocomboBox.Items.Add($"{veh.Modelo} - {veh.Placa}");
                    }
                break;
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
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

        private void CancelRoundButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
