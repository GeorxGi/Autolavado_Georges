using Proyecto_Autolavado_Georges.Clases.DataClasses;
using Proyecto_Autolavado_Georges.Clases.DataHandlers;
using Proyecto_Autolavado_Georges.Clases.UI;
using Proyecto_Autolavado_Georges.Clases.UserClasses;

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
        private readonly ClientList clientes;
        private readonly CustomQueue<(uint, Vehiculo?)> colaElementos;

        private readonly Cliente clienteInd;
        private readonly TipoLista tipo;

        private static string FormatMoney(string prefix, decimal money) => prefix + string.Format("{0:0.00}", money);

        public bool Pagado { get; private set; } = false;

        /// <summary>
        /// Lista para mostrar clientes en una cola
        /// </summary>
        /// <param name="clients"></param>
        /// <param name="colaBusqueda"></param>
        public ListaClientes(ClientList clients, CustomQueue<(uint, Vehiculo)> colaBusqueda)
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

        /// <summary>
        /// Lista de clientes
        /// </summary>
        /// <param name="client">Lista de la cual se tomará la información</param>
        public ListaClientes(ClientList client)
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

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (Cliente cliente in clientes)
            {
                if (cliente.Enabled)
                {
                    dataGridView1.Rows.Add(cliente.Id.ToString(), cliente.Name.Nombre, cliente.Name.Apellido,
                    cliente.Cedula, "", "", "", FormatMoney("$", cliente.DeudaTotal));
                    foreach (Vehiculo carr in cliente.VehiculosRegistrados)
                    {
                        dataGridView1.Rows.Add("", "||", "||", "||", carr.Placa, carr.Tipo, carr.Modelo, "", carr.ServicioUbicado.ToString());
                    }
                }
            }
        }

        private void ListaClientesEspera()
        {
            if (!colaElementos.IsEmpty())
            {
                uint id, cont = 1;
                Vehiculo carr;
                foreach ((uint, Vehiculo?) var in colaElementos)
                {
                    id = var.Item1;

                    carr = var.Item2 ?? new(); //Valida que el vehiculo de la lista no sea nulo

                    foreach (Cliente client in clientes)
                    {
                        if (client.Id != id) continue;

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
            else
            {
                this.Close();
                MessageBox.Show("Aún no hay clientes en cola", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ListaServiciosConsumidos()
        {
            PayRoundButton.Enabled = true; PayRoundButton.Visible = true;
            dataGridView1.Columns.Clear();
            mainLabel.Text = $"Cliente: {clienteInd.Name.Nombre} {clienteInd.Name.Apellido}  |  Cédula: {clienteInd.Cedula}";
            dataGridView1.Columns.Add("item", "Item");
            dataGridView1.Columns.Add("service", "Servicio");
            dataGridView1.Columns.Add("pricedollar", "Monto ($)");
            dataGridView1.Columns.Add("pricebs", "Monto (Bs)");
            
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (clienteInd.ServiciosConsumidos.Count > 0)
            {
                uint Indice = 1;
                decimal MontoTotal = 0;
                foreach ((Services, decimal) servicio in clienteInd.ServiciosConsumidos)
                {
                    MontoTotal += servicio.Item2;
                    dataGridView1.Rows.Add(Indice++, servicio.Item1.ToString(), FormatMoney("$", servicio.Item2),FormatMoney("Bs. ", servicio.Item2 * TasaCambio.TasaBcv));
                }
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add("Total", "", FormatMoney("$", MontoTotal), FormatMoney("Bs.", MontoTotal * TasaCambio.TasaBcv));
                decimal montoAbonado = MontoTotal - clienteInd.DeudaTotal;
                dataGridView1.Rows.Add("Monto abonado", "", FormatMoney("$", montoAbonado), FormatMoney("Bs.", montoAbonado * TasaCambio.TasaBcv)); 
                dataGridView1.Rows.Add("Monto a pagar", "", FormatMoney("$", clienteInd.DeudaTotal), FormatMoney("Bs.", clienteInd.DeudaTotal * TasaCambio.TasaBcv));
            }
        }

        private void ListaClientes_Load(object sender, EventArgs e)
        {
            AppSettings.LoadMenuColor(this);
            dataGridView1.GridColor = AppSettings.MainColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = AppSettings.MainColor;
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
                if (clienteInd.RegistrarCuota(clienteInd.NumeroDeCuotas - 1))
                {
                    MessageBox.Show($"Monto a pagar: {FormatMoney("$", clienteInd.MontoPorCuota)}");
                }
            }
        }

        private void CloseWithEscape(object sender, KeyEventArgs e)
        {
            UIHandler.CloseWithEscape(e, this);
        }
    }
}
