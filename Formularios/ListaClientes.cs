using Autolavado_GeorgesChakour.Clases;
namespace Proyecto_Autolavado_Georges.Formularios
{
    public partial class ListaClientes : Form
    {
        private List<Cliente> clientes;
        private Cola<int> colaElementos;

        private Cliente clienteInd;
        private bool esListaClientes;

        public bool Pagado { get; private set; } = false;

        /// <summary>
        /// Lista para mostrar clientes en una cola
        /// </summary>
        /// <param name="clients"></param>
        /// <param name="colaBusqueda"></param>
        public ListaClientes(List<Cliente> clients, Cola<int> colaBusqueda)
        {
            clientes = clients;
            colaElementos = colaBusqueda;
            esListaClientes = true;
            InitializeComponent();
        }

        /// <summary>
        /// Lista para facturar
        /// </summary>
        /// <param name="client"></param>
        public ListaClientes(Cliente client)
        {
            esListaClientes = false;
            clienteInd = client;
            InitializeComponent();
        }

        private void ListaClientes_Load(object sender, EventArgs e)
        {
            if (esListaClientes)
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
                    for(int d = 0; d < id.Length; d++)
                    {
                        colaElementos.Insertar(id[d]);
                    }
                }
                else
                {
                    this.Close();
                    MessageBox.Show("Aún no hay clientes en cola", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                pagarButton.Enabled = true; pagarButton.Visible = true;
                double price = 0;
                dataGridView1.Columns.Clear();
                mainLabel.Text = "Cliente: " + clienteInd.Name.Nombre + " " + clienteInd.Name.Apellido + "  |  Cédula: " + clienteInd.Cedula +
                    "\nPlaca: " + clienteInd.Carro.Placa + "  |  Vehículo: " + clienteInd.Carro.Modelo;
                dataGridView1.Columns.Add("item", "Item");
                dataGridView1.Columns.Add("service", "Servicio");
                dataGridView1.Columns.Add("pricedollar", "Monto($)");
                dataGridView1.Columns.Add("pricebs", "Monto(Bs)");
                //dataGridView1.Columns.Add("servicio", "Servicio consumido");
                //dataGridView1.Columns.Add("preciodollar", "Precio ($)");
                //dataGridView1.Columns.Add("preciobs", "Precio (Bs)");
                if (clienteInd.ServiciosConsumidos.Count > 0)
                {
                    int i = 0;
                    foreach (string servicio in clienteInd.ServiciosConsumidos)
                    {
                        string servAux = servicio;
                        //Balanceo
                        if (servicio == Servicios.ServiciosDisp[0])
                        {
                            if (clienteInd.Carro.Tipo == "Auto")
                            {
                                price = 25;
                            }
                            else
                            {
                                price = 35;
                            }
                        }
                        //Cambio de aceite
                        else if (servicio == Servicios.ServiciosDisp[1])
                        {
                            if (clienteInd.Carro.Tipo == "Auto")
                            {
                                price = 15;
                            }
                            else
                            {
                                price = 20;
                            }
                            servAux = "Cambio de " + servAux;
                        }
                        //Aspirado
                        else if (servicio == Servicios.ServiciosDisp[2])
                        {
                            if (clienteInd.Carro.Tipo == "Auto")
                            {
                                price = 4;
                            }
                            else
                            {
                                price = 6;
                            }
                        }
                        //Lavado
                        else if (servicio == Servicios.ServiciosDisp[3])
                        {
                            if (clienteInd.Carro.Tipo == "Auto")
                            {
                                price = 6;
                            }
                            else
                            {
                                price = 10;
                            }
                        }
                        //Secado
                        else if (servicio == Servicios.ServiciosDisp[4])
                        {
                            if (clienteInd.Carro.Tipo == "Auto")
                            {
                                price = 4;
                            }
                            else
                            {
                                price = 5;
                            }
                        }
                        dataGridView1.Rows.Add(i + 1, servAux, price, string.Format("{0:0.00}", price * TasaCambio.TasaDolar()));
                    }
                }
            }
        }

        private void pagarButton_Click(object sender, EventArgs e)
        {
            Pagado = true;
            this.Close();
        }
    }
}
