using Autolavado_GeorgesChakour.Clases;
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
        private Cola<int> colaElementos;

        private Cliente clienteInd;
        private TipoLista tipo;

        public bool Pagado { get; private set; } = false;

        /// <summary>
        /// Lista para mostrar clientes en una cola
        /// </summary>
        /// <param name="clients"></param>
        /// <param name="colaBusqueda"></param>
        public ListaClientes(Lista<Cliente> clients, Cola<int> colaBusqueda)
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
            foreach (Cliente cliente in clientes)
            {
                if (cliente.Enabled)
                {
                dataGridView1.Rows.Add(cliente.Id, cliente.Name.Nombre, cliente.Name.Apellido,
                    cliente.Cedula, cliente.Carro.Placa, cliente.Carro.Tipo, cliente.Carro.Modelo, $"${cliente.Deuda}");
                }
            }
        }

        private void ListaClientesEspera()
        {
            if (!colaElementos.ColaVacia())
            {
                int[] id = new int[colaElementos.GetCount()];
                int contador = 1, i = 0;
                while (!colaElementos.ColaVacia())
                {
                    id[i] = colaElementos.Retirar();
                    foreach (Cliente client in clientes)
                    {
                        if (client.Id == (uint)id[i] && i < id.Length)
                        {
                            dataGridView1.Rows.Add(client.Id, client.Name.Nombre, client.Name.Apellido, client.Cedula,
                                                   client.Carro.Placa, client.Carro.Tipo, client.Carro.Modelo, contador++);
                        }
                    }
                }
                for (int d = 0; d < id.Length; d++)
                {
                    colaElementos.InsertarCola(id[d]);
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
            double price = 0;
            dataGridView1.Columns.Clear();
            mainLabel.Text = $"Cliente: {clienteInd.Name.Nombre} {clienteInd.Name.Apellido}  |  Cédula: {clienteInd.Cedula}" +
                $"\nPlaca: {clienteInd.Carro.Placa}  |  Vehículo: {clienteInd.Carro.Modelo}";
            dataGridView1.Columns.Add("item", "Item");
            dataGridView1.Columns.Add("service", "Servicio");
            dataGridView1.Columns.Add("pricedollar", "Monto ($)");
            dataGridView1.Columns.Add("pricebs", "Monto (Bs)");
            if (clienteInd.ServiciosConsumidos.Cant > 0)
            {
                uint i = 1;
                double total = 0;
                foreach (Servicios servicio in clienteInd.ServiciosConsumidos)
                {
                    string servAux = servicio.ToString();
                    price = Operadores.PrecioServicios(servicio, clienteInd.Carro.Tipo);
                    total += price;
                    dataGridView1.Rows.Add(i++, servAux, $"${price}", string.Format("Bs. {0:0.00}", price * TasaCambio.TasaDolar()));
                }
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add("Total", "", $"${total}", string.Format("Bs. {0:0.00}", total * TasaCambio.TasaDolar()));
                dataGridView1.Rows.Add("Monto a pagar", "", $"${clienteInd.Deuda}", string.Format("Bs. {0:0.00}", clienteInd.Deuda * TasaCambio.TasaDolar()));
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
            if(clienteInd.NumeroDeCuotas > 1)
            {
                Cliente mod = clienteInd.Copia();
                if(clienteInd.RegistrarCuota(clienteInd.NumeroDeCuotas - 1))
                {
                    MessageBox.Show($"Monto a pagar: {clienteInd.MontoPorCuota}");
                }
            }
        }
    }
}
