﻿namespace Proyecto_Autolavado_Georges.Formularios
{
    public partial class FormularioVehiculo : Form
    {
        public string? ModeloCarro { get; private set; }
        public Vehiculo? carroNuevo { get; private set; }

        /// <summary>
        /// Formulario para registrar vehiculo
        /// </summary>
        public FormularioVehiculo()
        {
            ModeloCarro = null;
            InitializeComponent();
        }
        /// <summary>
        /// Formulario en forma de modificar vehiculo
        /// </summary>
        /// <param name="veh">Vehiculo a modificar</param>
        public FormularioVehiculo(Vehiculo veh)
        {
            ModeloCarro = veh.Tipo.ToString();
        }

        private void CleanRegisterButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormularioVehiculo_Load(object sender, EventArgs e)
        {
            foreach (TipoDeVehiculo mod in Enum.GetValues(typeof(TipoDeVehiculo)))
            {
                tipoCarrocomboBox.Items.Add(mod.ToString());
            }
            tipoCarrocomboBox.SelectedIndex = 0;
        }

        private void AcceptRegisterButton_Click(object sender, EventArgs e)
        {
            if (Interfaz.DatosColocados(this) && PlacaTextBox.Text.Length > 4)
            {
                ModeloCarro = $"\n{tipoCarrocomboBox.Text} - {ModeloTextBox.Text}\n{PlacaTextBox.Text}";
                TipoDeVehiculo car;
                Enum.TryParse<TipoDeVehiculo>(tipoCarrocomboBox.SelectedItem.ToString(), out car);
                carroNuevo = new()
                {
                    Tipo = car,
                    Placa = PlacaTextBox.Text,
                    Modelo = ModeloTextBox.Text
                };
                this.Close();
            }
            else
            {
                MessageBox.Show("Rellene todos los campos", "Error", MessageBoxButtons.OK);
            }
        }

        private void PlacaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Interfaz.OnlyMayus(sender, e);
        }

        private void FormularioVehiculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
