using Autolavado_GeorgesChakour.Clases;
using Proyecto_Autolavado_Georges.Classes;
namespace Proyecto_Autolavado_Georges.Formularios
{
    public partial class ListaClientes : Form
    {
        private enum TipoLista
        {
            Clientes,
            Servicios,
            Factura
        }
        private Lista<Cliente> clientes;
        private Cola<(uint, Vehiculo?)> colaElementos;

        private Cliente clienteInd;
        private TipoLista tipo;

        public bool Pagado { get; private set; } = false;

        /// <summary>
        /// Lista para mostrar clientes en una cola
        /// </summary>
        /// <param name="clients"></param>
        /// <param name="colaBusqueda"></param>
        public ListaClientes(Lista<Cliente> clients, Cola<(uint, Vehiculo?)> colaBusqueda)
        {
            clientes = clients;
            colaElementos = colaBusqueda;
            tipo = TipoLista.Servicios;
            InitializeComponent();
        }

        /// <summary>
        /// Lista para facturar
        /// </summary>
        /// <param name="client"></param>
        public ListaClientes(Cliente client)
        {
            tipo = TipoLista.Factura;
            clienteInd = client;
            InitializeComponent();
        }

        public ListaClientes(Lista<Cliente> client)
        {
            clientes = client;
            tipo = TipoLista.Clientes;
            InitializeComponent();
        }

        private void ListadoClientes()
        {
            dataGridView1.Columns.Remove("posicion");
            dataGridView1.Columns.Add("deuda", "Deuda ($)");
            dataGridView1.Columns.Add("inService", "Servicio actual");
            foreach (Cliente cliente in clientes)
            {
                if (cliente.Enabled)
                {
                    dataGridView1.Rows.Add(cliente.Id.ToString(), cliente.Name.Nombre, cliente.Name.Apellido,
                    cliente.Cedula, "", "", "", $"${cliente.DeudaTotal}");
                    foreach (Vehiculo carr in cliente.VehiculosRegistrados)
                    {
                        dataGridView1.Rows.Add("", "||", "||", "||", carr.Placa, carr.Tipo, carr.Modelo, "", carr.ServicioUbicado.ToString());
                    }
                }
            }
        }

        private void ListaClientesEspera()
        {
            if (!colaElementos.ColaVacia())
            {
                uint id, cont = 1;
                Vehiculo carr;
                foreach ((uint, Vehiculo?) var in colaElementos)
                {
                    id = var.Item1;
                    carr = var.Item2 != null ? (Vehiculo)var.Item2 : new Vehiculo();

                    foreach (Cliente client in clientes)
                    {
                        if (client.Id == id)
                        {
                            foreach (Vehiculo veh in client.VehiculosRegistrados)
                            {
                                if (veh.Placa == carr.Placa)
                                {
                                    dataGridView1.Rows.Add(client.Id, client.Name.Nombre, client.Name.Apellido, client.Cedula,
                                                   carr.Placa, carr.Modelo, carr.Tipo.ToString(), cont++);

                                }
                            }
                        }
                    }
                }
            }
            else
            {
                this.Close();
                MessageBox.Show("Aún no hay clientes en cola", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ListaServiciosConsumidos()
        {
            pagarButton.Enabled = true; pagarButton.Visible = true;
            decimal price = 0;
            dataGridView1.Columns.Clear();
            mainLabel.Text = $"Cliente: {clienteInd.Name.Nombre} {clienteInd.Name.Apellido}  |  Cédula: {clienteInd.Cedula}";
            dataGridView1.Columns.Add("item", "Item");
            dataGridView1.Columns.Add("service", "Servicio");
            dataGridView1.Columns.Add("model_serviced", "Modelo atendido");
            dataGridView1.Columns.Add("pricedollar", "Monto ($)");
            dataGridView1.Columns.Add("pricebs", "Monto (Bs)");
            if (clienteInd.ServiciosConsumidos.Cant > 0)
            {
                uint i = 1;
                decimal total = 0;
                foreach ((Servicios, TipoDeVehiculo) servicio in clienteInd.ServiciosConsumidos)
                {
                    price = Operadores.PrecioServicios(servicio.Item1, servicio.Item2);
                    total += price;
                    dataGridView1.Rows.Add(i++, servicio.Item1.ToString(), servicio.Item2.ToString(), $"${price}", string.Format("Bs. {0:0.00}", price * TasaCambio.TasaBcv));
                }
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add("Total", "", "", $"${total}", string.Format("Bs. {0:0.00}", total * TasaCambio.TasaBcv));
                dataGridView1.Rows.Add("Monto a pagar", "", "", $"${clienteInd.DeudaTotal}", string.Format("Bs. {0:0.00}", (decimal)clienteInd.DeudaTotal * TasaCambio.TasaBcv));
            }
        }

        private void ListaClientes_Load(object sender, EventArgs e)
        {
            switch (tipo)
            {
                case TipoLista.Servicios:
                    ListaClientesEspera();
                    this.Text = "Clientes en espera";
                    break;

                case TipoLista.Factura:
                    this.Text = "Factura";
                    ListaServiciosConsumidos();
                    break;

                case TipoLista.Clientes:
                    ListadoClientes();
                    this.Text = "Lista de clientes";
                    break;
            }
        }

        private void pagarButton_Click(object sender, EventArgs e)
        {
            Pagado = true;
            this.Close();
        }

        private void pagarCuotaButton_Click(object sender, EventArgs e)
        {
            if (clienteInd.NumeroDeCuotas > 1)
            {
                Cliente mod = clienteInd.Copia();
                if (clienteInd.RegistrarCuota(clienteInd.NumeroDeCuotas - 1))
                {
                    MessageBox.Show($"Monto a pagar: {clienteInd.MontoPorCuota}");
                }
            }
        }

        private void ListaClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
