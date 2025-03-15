using Proyecto_Autolavado_Georges.Clases.UI;
using Proyecto_Autolavado_Georges.Clases.UserClasses;

namespace Proyecto_Autolavado_Georges.Formularios
{
    public partial class IngresarModificarVehiculo : Form
    {
        public Vehiculo? CarroNuevo { get; private set; }
        private readonly bool ModoModificar;

        /// <summary>
        /// Formulario para registrar vehiculo
        /// </summary>
        public IngresarModificarVehiculo()
        {
            ModoModificar = false;
            InitializeComponent();
        }
        /// <summary>
        /// Formulario en forma de modificar vehiculo
        /// </summary>
        /// <param name="veh">Vehiculo a modificar</param>
        public IngresarModificarVehiculo(Vehiculo veh)
        {
            CarroNuevo = veh;
            ModoModificar = true;
            InitializeComponent();
        }

        private void IngresarModificarVehiculo_Load(object sender, EventArgs e)
        {
            AppSettings.LoadMenuColor(this);
            if (CarroNuevo == null) return;
            if (CarroNuevo.Tipo == TipoDeVehiculo.Auto) autoRadioButton.Checked = true;
            if (CarroNuevo.Tipo == TipoDeVehiculo.Camioneta) camionetaRadioButton.Checked = true;

            ModeloTextBox.Text = CarroNuevo.Modelo;
            PlacaTextBox.Text = CarroNuevo.Placa;

        }

        private void AcceptRegisterButton_Click(object sender, EventArgs e)
        {
            if (UIHandler.FormInputIsFilled(this) && PlacaTextBox.Text.Length > 4)
            {
                if (ModoModificar)
                {
                    CarroNuevo.ModificarPlaca(PlacaTextBox.Text);
                    CarroNuevo.ModificarModelo(ModeloTextBox.Text);

                    if (autoRadioButton.Checked) CarroNuevo.ModificarTipoDeVehiculo(TipoDeVehiculo.Auto);
                    else if (camionetaRadioButton.Checked) CarroNuevo.ModificarTipoDeVehiculo(TipoDeVehiculo.Camioneta);
                }
                else
                {
                    TipoDeVehiculo car = TipoDeVehiculo.Auto; //Valor predeterminado

                    if (autoRadioButton.Checked) car = TipoDeVehiculo.Auto;
                    else if (camionetaRadioButton.Checked) car = TipoDeVehiculo.Camioneta;

                    CarroNuevo = new(car, ModeloTextBox.Text, PlacaTextBox.Text, null);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Rellene todos los campos", "Error", MessageBoxButtons.OK);
            }
        }

        private void PlacaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIHandler.OnlyMayus(sender, e);
        }

        private void FormularioVehiculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                CarroNuevo = null;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CarroNuevo = null;
            this.Close();
        }
    }
}
