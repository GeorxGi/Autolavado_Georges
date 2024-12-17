using Autolavado_GeorgesChakour.Clases;
using Proyecto_Autolavado_Georges.Formularios;
using Proyecto_Autolavado_Georges.Properties;
using System.CodeDom;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Printing;


namespace Proyecto_Autolavado_Georges
{
    public partial class Form1 : Form
    {
        private Cola<(uint, Vehiculo?)> colaAceite = new(5);
        private Cola<(uint, Vehiculo?)> colaBalanceo = new(5);

        private Cola<(uint, Vehiculo?)> colaAspirado = new(10);
        private Cola<(uint, Vehiculo?)> colaLavado = new(10);
        private Cola<(uint, Vehiculo?)> colaSecado = new(10);
        private Pila<bool> pilaCauchos = new(4);

        private Lista<Vehiculo> ListaCarroCliente;

        Lista<Cliente> Clientes = new Lista<Cliente>();

        public int Id { get; private set; } = 1;
        private Servicios? Servicio = null;
        private int IdBusqueda;

        public Cliente BuscarCliente(int ID)
        {
            foreach (Cliente cliente in Clientes)
            {
                if (ID == cliente.Id)
                {
                    return cliente;
                }
            }
            return null;
        }

        public void ActualizarCantClientes()
        {
            int i = 0;
            foreach (Cliente client in Clientes)
            {
                if (client.Enabled)
                {
                    i++;
                }
            }
            clientsAmountLabel.Text = i.ToString();
        }

        public void ModificarCliente()
        {
            Interfaz.MostrarPanel(this, panelModificar, "MODIFICAR CLIENTE");
            if (BuscarID())
            {
                Cliente clien = BuscarCliente(IdBusqueda);
                if (clien.Enabled)
                {
                    datosAnterioresLabel.Text = $"  DATOS CLIENTE  " +
                                                $"\n\nNombre: {clien.Name.Nombre}" +
                                                $"\nApellido: {clien.Name.Apellido}" +
                                                $"\nCedula: {clien.Cedula}";
                    listaVehiculosModificarlabel.Text = "Vehiculos:";

                    foreach (Vehiculo vehiculo in clien.VehiculosRegistrados)
                    {

                        listaVehiculosModificarlabel.Text += $"\n{vehiculo.Tipo} - {vehiculo.Modelo}\n{vehiculo.Placa}";
                    }
                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show($"El cliente {clien.Name.Nombre} se encuentra deshabilitado, desea habilitarlo nuevamente?",
                        "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    {
                        Cliente mod = clien.Copia();
                        clien.HabilitarCliente();
                        Clientes.ModificarElemento(mod, clien);
                        ActualizarCantClientes();
                        MainMenu();
                    }
                    else
                    {
                        MainMenu();
                    }
                }
            }
            else
            {
                MainMenu();
                MessageBox.Show("Cliente no encontrado/registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool Registrar(Datos dat, Lista<Vehiculo> carr, string cedula)
        {
            foreach (Cliente cliente in Clientes)
            {
                if (cedula == cliente.Cedula)
                {
                    if (!cliente.Enabled)
                    {
                        if (DialogResult.Yes == MessageBox.Show($"La cedula ingresada pertenece a {cliente.ToString()}," +
                            $"el cual se encuentra deshabilitado desea habilitarlo nuevamente?",
                            "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                        {
                            Cliente mod = cliente.Copia();
                            cliente.HabilitarCliente();
                            Clientes.ModificarElemento(mod, cliente);
                            return true;
                        }
                        else
                        {
                            MainMenu();
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (!Interfaz.DatosColocados(panelRegistrar))
            {
                MessageBox.Show("Rellene todos los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {

                Cliente client = new(Convert.ToUInt32(Id), cedula, dat, carr);
                if (IngresarClienteLista(client))
                {
                    MessageBox.Show("Cliente registrado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarCantClientes();
                    return true;
                }
                else
                {
                    MessageBox.Show("Cliente ya registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        /// <summary>
        /// Recibe una cola y realiza el proceso de atendido de la misma
        /// </summary>
        /// <param name="cola">Cola a atender</param>
        /// <returns>Booleano que indica si todo el proceso se realizó correctamente</returns>
        public bool AtenderCola(Cola<(uint, Vehiculo?)> cola)
        {
            Cliente client;
            (uint, Vehiculo?) item = cola.Retirar();
            IdBusqueda = (int)item.Item1;
            Vehiculo carr;
            if (item.Item2 != null)
            {
                carr = (Vehiculo)item.Item2;
            }
            else
            {
                return false;
            }
            client = BuscarCliente(IdBusqueda);

            Cliente mod = client.Copia();

            client.ProcesarServicio(carr.Placa);

            Clientes.ModificarElemento(mod, client);
            MessageBox.Show("Atendido correctamente el cliente: " + client.Name.Nombre, "Atendido", MessageBoxButtons.OK);
            return true;
        }
        /// <summary>
        /// Recibe una cola y realiza el proceso de atendido de la misma
        /// </summary>
        /// <param name="colaInicial">Cola a atender</param>
        /// <param name="colaDestino">Nueva cola a asignar</param>
        /// <returns>Booleano que indica si todo el proceso se realizó correctamente</returns>
        public bool AtenderCola(Cola<(uint, Vehiculo?)> colaInicial, Cola<(uint, Vehiculo?)> colaDestino, Servicios servicio)
        {
            Cliente client;
            (uint, Vehiculo?) item = colaInicial.Retirar();
            IdBusqueda = (int)item.Item1;
            Vehiculo carr = (Vehiculo)item.Item2;
            if (item.Item2 != null)
            {
                carr = (Vehiculo)item.Item2;
            }
            else
            {
                return false;
            }
            client = BuscarCliente(IdBusqueda);
            Cliente mod = client.Copia();
            client.ProcesarServicio(carr.Placa);
            client.RegistrarServicio(servicio, carr.Placa);
            colaDestino.InsertarCola(item);
            Clientes.ModificarElemento(mod, client);

            MessageBox.Show("Atendido correctamente el cliente: " + client.Name.Nombre, "Atendido", MessageBoxButtons.OK);
            return true;
        }

        public bool IngresarClienteLista(Cliente clients)
        {
            bool find = false;
            foreach (Cliente cl in Clientes)
            {
                if (cl.Cedula == clients.Cedula || cl.PlacaYaRegistrada(clients.PlacasArray()))
                {
                    find = true;
                    break;
                }
            }
            if (find)
            {
                return false;
            }
            else
            {
                Clientes.Insertar(clients);
                Id++;
                return true;
            }
        }

        /// <summary>
        /// Abre un form para ingresar el ID del cliente, retorna el ID - 1
        /// </summary>
        /// <returns>booleano que indica si se encontró o no el cliente</returns>
        public bool BuscarID()
        {
            IngresarID ingresar = new();
            ingresar.ShowDialog();
            IdBusqueda = ingresar.ReturnID;
            ingresar.Dispose();
            ingresar = null;
            foreach (Cliente client in Clientes)
            {
                if (client.Id == IdBusqueda)
                {
                    IdBusqueda = (int)client.Id;
                    return true;
                }
            }
            return false;
        }

        public bool SeleccionarServicio()
        {
            IngresarServicio ingresar = new();
            ingresar.ShowDialog();
            Servicio = ingresar.Servicio;
            ingresar.Dispose();
            return Servicio != null;
        }

        private bool? ColaNoEstaLlena()
        {
            switch(Servicio)
            {
                case Servicios.Balanceo:
                    return !colaBalanceo.ColaLlena();

                case Servicios.Aceite:
                    return !colaAceite.ColaLlena();

                case Servicios.Aspirado:
                    return !colaAspirado.ColaLlena();

                case Servicios.Lavado:
                    return !colaLavado.ColaLlena();

                case Servicios.Secado:
                    return !colaSecado.ColaLlena();
                default:
                    return null;
            }
        }

        public bool? IngresarColaServicios(Cliente client, Vehiculo? veh)
        {
            if (veh == null)
            {
                return false;
            }
            else
            {
                switch (Servicio)
                {
                    case Servicios.Balanceo:
                        return colaBalanceo.InsertarCola((client.Id, (Vehiculo)veh));

                    case Servicios.Aceite:
                        return colaAceite.InsertarCola((client.Id, (Vehiculo)veh));

                    case Servicios.Aspirado:
                        return colaAspirado.InsertarCola((client.Id, (Vehiculo)veh));

                    case Servicios.Lavado:
                        return colaLavado.InsertarCola((client.Id, (Vehiculo)veh));

                    case Servicios.Secado:
                        return colaSecado.InsertarCola((client.Id, (Vehiculo)veh));
                    default:
                        return null;
                }
            }
        }

        public void EliminarClienteLista(Cliente client)
        {
            if (!client.Enabled)
            {
                MessageBox.Show("El cliente ya se encuentra deshabilitado");
            }
            else
            {
                if (!client.EstaEnServicio())
                {
                    if (client.DeudaTotal == 0)
                    {
                        if (DialogResult.Yes ==
                            MessageBox.Show($"Esta seguro de que desea inhabilitar al cliente: {client.ToString()}",
                            "CUIDADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            Cliente mod = client.Copia();
                            client.DeshabilitarCliente();

                            Clientes.ModificarElemento(mod, client);
                            MessageBox.Show("Cliente eliminado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ActualizarCantClientes();
                        }
                        else
                        {
                            MessageBox.Show("Operación cancelada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El cliente posee deuda, pague primero antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("El cliente se encuentra actualmente en un servicio, termine dicho servicio antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            MainMenu();
        }

        public void EliminarColaServicio(Cliente cliente, Cola<(uint, Vehiculo?)> cola, Vehiculo? car)
        {
            if (DialogResult.Yes == MessageBox.Show("Está seguro que desea cancelar su servicio?", "Cancelar servicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                ///AQUI EL ERROR
                if (cola.EliminarCola((cliente.Id, car)))
                {
                    if (car != null)
                    {
                        Vehiculo carr = (Vehiculo)car;

                        Cliente mod = cliente.Copia();
                        cliente.CancelarServicio(carr.Placa);
                        Clientes.ModificarElemento(mod, cliente);
                        MessageBox.Show("Servicio cancelado exitosamente", "Cancelación exitosa", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Operacion fallada");
                }
            }
            else
            {
                MessageBox.Show("Operacion cancelada");
            }
        }

        public void CancelarServicio(Cliente cliente)
        {
            MainMenu();
            if (!cliente.EstaEnServicio())
            {
                MessageBox.Show("El cliente indicado no se encuentra en un servicio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Vehiculo? car = cliente.ElegirVehiculo();
                Vehiculo carr;
                if (car != null)
                {
                    carr = (Vehiculo)car;
                    carr.ServicioUbicado = null;
                    switch (cliente.ServicioActual(carr.Placa))
                    {
                        case Servicios.Balanceo:
                            if (!colaBalanceo.EsPrimerElemento((cliente.Id, cliente.ElegirVehiculo())))
                            {
                                EliminarColaServicio(cliente, colaBalanceo, carr);
                            }
                            else
                            {
                                if (!pilaCauchos.PilaVacia())
                                {
                                    MessageBox.Show("Proceso de balanceo iniciado, no se puede cancelar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    EliminarColaServicio(cliente, colaBalanceo, carr);
                                }
                            }
                            break;
                        case Servicios.Aceite:
                            EliminarColaServicio(cliente, colaAceite, car);
                            break;
                        case Servicios.Aspirado:
                            EliminarColaServicio(cliente, colaAspirado, carr);
                            break;
                        case Servicios.Lavado:
                            EliminarColaServicio(cliente, colaLavado, carr);
                            break;
                        case Servicios.Secado:
                            EliminarColaServicio(cliente, colaSecado, carr);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void PagarFactura()
        {
            bool pagado = false;
            if (BuscarID())
            {
                Cliente client = BuscarCliente(IdBusqueda);
                Cliente mod = client.Copia();
                if (client.ServiciosConsumidos.Cant == 0)
                {
                    MessageBox.Show("Cliente no posee deuda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ListaClientes lista = new(client);
                    lista.ShowDialog();
                    pagado = lista.Pagado;
                    if (pagado)
                    {
                        client.LimpiarFactura();
                        Clientes.ModificarElemento(mod, client);
                        MessageBox.Show("Factura pagada exitosamente", "Pago realizado", MessageBoxButtons.OK);
                    }
                    else
                    {
                        {
                            MessageBox.Show("Pago de factura cancelado", "Pago cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    lista.Close();
                }
            }
        }

        public void AsignarCuota()
        {
            if (BuscarID())
            {
                Cliente client = BuscarCliente(IdBusqueda);
                Cliente mod = client.Copia();
                if (client.DeudaTotal != 0 && client.MontoPorCuota == 0)
                {
                    IngresarNumero ing = new($"Deuda pendiente = ${client.DeudaTotal}\n¿A cuantas cuotas? (1 - 4)", 1, 4);
                    ing.ShowDialog();
                    if (client.RegistrarCuota((uint)ing.ReturnNumber))
                    {
                        MessageBox.Show($"Cuotas registradas correctamente, deberá pagar un monto de ${string.Format("{0:0.00}", client.MontoPorCuota)} por cuota", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error inesperado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    Clientes.ModificarElemento(mod, client);
                    ing.Dispose();
                    ing = null;
                }
                else
                {
                    MessageBox.Show("Cliente no presenta deudas o ya posee cuotas asignadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void MainMenu()
        {
            Interfaz.MostrarPanel(this, Optionpanel, "AUTOLAVADO");
        }

        public Form1()
        {
            InitializeComponent();
            CedulaComboBox.SelectedIndex = 0;
            this.Size = new Size(800, 500);
            panelModificar.Location = new Point(134, 55);
            panelServicios.Location = new Point(132, 55);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TasaCambio.LoadData();
            TasaCambio.TasaDolar();

            Clientes = Interfaz.LeerDatos();

            int i = 0;
            ActualizarCantClientes();
            Id = Clientes.Cant + 1;
        }

        private void AcceptRegisterButton_Click(object sender, EventArgs e)
        {
            Datos dat;
            dat.Nombre = NameTextBox.Text; dat.Apellido = ApellidoTextBox.Text;
            string cedula = CedulaComboBox.Text + CedulaTextBox.Text;

            if (Registrar(dat, ListaCarroCliente, cedula))
            {
                MainMenu();
                ListaCarroCliente = null;
            }
        }

        private void CleanRegisterButton_Click(object sender, EventArgs e)
        {
            Interfaz.LimpiarTextBox(panelRegistrar);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            clienteContextMenuStrip.Show(Cursor.Position);
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            MainMenu();
        }

        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Interfaz.OnlyLetters(sender, e);
        }

        private void ApellidoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Interfaz.OnlyLetters(sender, e);
        }

        private void CedulaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Interfaz.OnlyNumbers(sender, e);
        }

        private void TipoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Interfaz.OnlyLetters(sender, e);
        }

        private void ModeloTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Interfaz.OnlyLetters(sender, e);
        }

        private void modificarClienteButton_Click(object sender, EventArgs e)
        {
        }

        private void aceptarModificarButton_Click(object sender, EventArgs e)
        {

            Cliente client = BuscarCliente(IdBusqueda);
            Datos dat;
            Vehiculo carr;
            string cedula;

            dat.Nombre =
                string.IsNullOrWhiteSpace(modificarNombreTextBox.Text) ?
                client.Name.Nombre : modificarNombreTextBox.Text;

            dat.Apellido =
                string.IsNullOrWhiteSpace(modificarApellidoTextBox.Text) ?
                client.Name.Apellido : modificarApellidoTextBox.Text;

            cedula =
                string.IsNullOrWhiteSpace(modificarCedulaComboBox.Text + modificarCedulaTextBox.Text) ?
                client.Cedula : modificarCedulaComboBox.Text + modificarCedulaTextBox.Text;


            MainMenu();

            if (DialogResult.Yes == MessageBox.Show("Está seguro de que desea modificar al cliente\n" +
                client.Name.Nombre + " " + client.Name.Apellido + "?", "¿Seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Cliente mod = client.Copia();
                if (client.Modificar(cedula, dat))
                {
                    Clientes.ModificarElemento(mod, client);
                    MessageBox.Show("Cliente modificado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El cliente se encuentra en un servicio o posee deuda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Operacion cancelada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MainMenu();

        }

        private void cancelarModificarButton_Click(object sender, EventArgs e)
        {
            MainMenu();
        }

        private void PlacaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Interfaz.OnlyMayus(sender, e);
        }

        private void modificarPlacaVehiculoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Interfaz.OnlyMayus(sender, e);
        }

        private void eliminarClienteButton_Click(object sender, EventArgs e)
        {

        }

        private void asignarServicioButton_Click(object sender, EventArgs e)
        {
            MainMenu();
            if (BuscarID())
            {
                Cliente client = BuscarCliente(IdBusqueda);
                if (SeleccionarServicio())
                {
                    if (!client.Enabled)
                    {
                        MessageBox.Show("El cliente indicado no se encuentra habilitado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Cliente mod = client.Copia();
                        Vehiculo? car = client.ElegirVehiculo();
                        Vehiculo carr;
                        if (car != null)
                        {
                            carr = (Vehiculo)car;

                            if (!client.EstaEnServicio(carr.Placa))
                            {
                                bool? opt = ColaNoEstaLlena();
                                if (opt == true)
                                {
                                    client.RegistrarServicio((Servicios)Servicio, carr.Placa);
                                    Clientes.ModificarElemento(mod, client);
                                    carr.ServicioUbicado = (Servicios)Servicio;
                                    IngresarColaServicios(client, carr);
                                }
                                else if (opt == false)
                                {
                                    MessageBox.Show("Cola de atención llena, atienda antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("el cliente ya cuenta con un servicio activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("El ID ingresado no se encuentra registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void atenderBalanceoButton_Click(object sender, EventArgs e)
        {
            if (pilaCauchos.PilaVacia())
            {
                if (!colaBalanceo.ColaVacia())
                {
                    caucho1pictureBox.Visible = false;
                    caucho2pictureBox.Visible = false;
                    caucho3pictureBox.Visible = false;
                    caucho4pictureBox.Visible = false;
                    IngresarNumero form = new("Cuantos cauchos desea balancear?", 1, 4);
                    form.ShowDialog();
                    if (form.ReturnNumber > 0 && form.ReturnNumber < 4)
                    {
                        for (ushort i = 0; i < form.ReturnNumber; i++)
                        {
                            pilaCauchos.Push(true);
                            switch (i)
                            {
                                case 0:
                                    caucho1pictureBox.Image = Resources.caucho_faltante;
                                    caucho1pictureBox.Visible = true;
                                    break;
                                case 1:
                                    caucho2pictureBox.Image = Resources.caucho_faltante;
                                    caucho2pictureBox.Visible = true;
                                    break;
                                case 2:
                                    caucho3pictureBox.Image = Resources.caucho_faltante;
                                    caucho3pictureBox.Visible = true;
                                    break;
                                case 3:
                                    caucho4pictureBox.Image = Resources.caucho_faltante;
                                    caucho4pictureBox.Visible = true;
                                    break;
                            }
                        }
                        Balanceopanel.Visible = true; Balanceopanel.Enabled = true;
                        form.Dispose();
                        form = null;
                    }
                    else
                    {
                        MessageBox.Show("Valor fuera de límites");
                    }
                }
                else
                {
                    MessageBox.Show("No hay clientes asignados a balanceo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                Balanceopanel.Visible = true; Balanceopanel.Enabled = true;
            }
        }

        private void realizarBalanceobutton_Click(object sender, EventArgs e)
        {
            switch (pilaCauchos.top)
            {
                case 3:
                    caucho4pictureBox.Image = Resources.caucho_listo;
                    pilaCauchos.Pop();
                    break;
                case 2:
                    caucho3pictureBox.Image = Resources.caucho_listo;
                    pilaCauchos.Pop();
                    break;
                case 1:
                    caucho2pictureBox.Image = Resources.caucho_listo;
                    pilaCauchos.Pop();
                    break;

                case 0:
                    caucho1pictureBox.Image = Resources.caucho_listo;
                    pilaCauchos.Pop();
                    break;
            }
            if (pilaCauchos.PilaVacia() && !colaBalanceo.ColaVacia())
            {
                if (!AtenderCola(colaBalanceo))
                {
                    MessageBox.Show("Ocurrió un error inesperado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Balanceopanel.Visible = false; Balanceopanel.Enabled = false;
                colaBalanceolabel.Text = "Clientes en espera:\n" + colaBalanceo.GetCount();
            }
        }

        private void sistemaAtencionButton_Click(object sender, EventArgs e)
        {
            Interfaz.MostrarPanel(this, panelServicios, "SERVICIO ATENCIÓN");
            colaBalanceolabel.Text = "Clientes en espera:\n" + colaBalanceo.GetCount();
            colaAceitelabel.Text = "Clientes en espera:\n" + colaAceite.GetCount();
            colaLavadolabel.Text = "Clientes en espera:\n" + colaLavado.GetCount();
            colaAspiradolabel.Text = "Clientes en espera:\n" + colaAspirado.GetCount();
            colaSecadolabel.Text = "Clientes en espera:\n" + colaSecado.GetCount();

        }

        private void atenderAceitebutton_Click(object sender, EventArgs e)
        {
            if (colaAceite.ColaVacia())
            {
                MessageBox.Show("No hay clientes asignados a cambio de aceite", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!AtenderCola(colaAceite))
                {
                    MessageBox.Show("Ocurrió un error inesperado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                colaAceitelabel.Text = "Clientes en espera:\n" + colaAceite.GetCount();
            }
        }

        private void atenderCicloLavadobutton_Click(object sender, EventArgs e)
        {
            if (colaSecado.ColaVacia() && colaLavado.ColaVacia() && colaAspirado.ColaVacia())
            {
                MessageBox.Show("No hay clientes asignados al ciclo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Cliente client, mod;
                if (!colaSecado.ColaVacia())
                {
                    if (!AtenderCola(colaSecado))
                    {
                        MessageBox.Show("Ocurrió un error inesperado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (!colaLavado.ColaVacia())
                {
                    if (!AtenderCola(colaLavado, colaSecado, Servicios.Secado))
                    {
                        MessageBox.Show("Ocurrió un error inesperado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (!colaAspirado.ColaVacia())
                {
                    if (!AtenderCola(colaAspirado, colaLavado, Servicios.Lavado))
                    {
                        MessageBox.Show("Ocurrió un error inesperado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                colaSecadolabel.Text = "Clientes en espera:\n" + colaSecado.GetCount();
                colaLavadolabel.Text = "Clientes en espera:\n" + colaLavado.GetCount();
                colaAspiradolabel.Text = "Clientes en espera:\n" + colaAspirado.GetCount();

            }
        }

        private void cancelarServiciobutton_Click(object sender, EventArgs e)
        {
            if (BuscarID())
            {
                Cliente client = BuscarCliente(IdBusqueda);
                CancelarServicio(client);
            }
            else
            {
                MessageBox.Show("Cliente no encontrado/registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listarClientesbutton_Click(object sender, EventArgs e)
        {
            ListaClientescontextMenuStrip.Show(Cursor.Position);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Interfaz.GuardarDatos(Clientes);
            }
        }

        private void pagarFacturaButton_Click(object sender, EventArgs e)
        {
            pagoContextMenuStrip.Show(Cursor.Position);
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Interfaz.MostrarPanel(this, panelRegistrar, "REGISTRAR CLIENTE");
            ListaCarroCliente = new();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarCliente();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu();
            if (BuscarID())
            {
                Cliente client = BuscarCliente(IdBusqueda);
                EliminarClienteLista(client);
            }
            else
            {
                MessageBox.Show("Cliente no encontrado/Cargado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void porServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresarServicio Serv = new();
            Serv.ShowDialog();
            Servicio = Serv.Servicio;
            Serv.Dispose();
            Serv = null;

            ListaClientes lista;

            switch (Servicio)
            {
                case Servicios.Balanceo:
                    lista = new(Clientes, colaBalanceo.Copia());
                    break;

                case Servicios.Aceite:
                    lista = new(Clientes, colaAceite.Copia());
                    break;

                case Servicios.Aspirado:
                    lista = new(Clientes, colaAspirado.Copia());
                    break;

                case Servicios.Lavado:
                    lista = new(Clientes, colaLavado.Copia());
                    break;

                case Servicios.Secado:
                    lista = new(Clientes, colaSecado.Copia());
                    break;
                default:
                    lista = null;
                    break;
            }
            if (lista != null)
            {
                lista.ShowDialog();
                lista.Dispose();
                lista = null;
            }
        }

        private void clientesRegistradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaClientes lista = new(Clientes);
            lista.ShowDialog();
            lista.Dispose();
            lista = null;
        }

        private void pagarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PagarFactura();
        }

        private void pagarCuotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BuscarID())
            {
                Cliente client = BuscarCliente(IdBusqueda);
                if (client.NumeroDeCuotas > 0 && client.MontoPorCuota != 0)
                {
                    if (DialogResult.Yes == MessageBox.Show($"Desea pagar una de las {client.NumeroDeCuotas} cuotas pendientes?\n\nEl monto a pagar" +
                        $" será de ${client.MontoPorCuota}", "Pagar cuota", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        Cliente mod = client.Copia();
                        client.PagarCuota();
                        Clientes.ModificarElemento(mod, client);
                        MessageBox.Show("Pago realizado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Operación cancelada", "Cancelado", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Cliente no posee cuotas/deudas pendientes");
                }
            }
        }

        private void asignarCuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignarCuota();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormularioVehiculo veh = new();
            veh.ShowDialog();
            //INGRESAR CARROS
            listaVehiculoslabel.Text += veh.ModeloCarro;
            if (veh.carroNuevo != null)
            {
                ListaCarroCliente.Insertar((Vehiculo)veh.carroNuevo);
            }
            veh.Dispose();
            veh = null;
        }

        private void registrarVehículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BuscarID())
            {
                Cliente mod = BuscarCliente(IdBusqueda);
                Cliente aux = mod.Copia();
                FormularioVehiculo form = new();
                form.ShowDialog();
                bool find = false;
                if (form.carroNuevo != null)
                {
                    Vehiculo carro = (Vehiculo)form.carroNuevo;
                    foreach (Cliente cl in Clientes)
                    {
                        if (cl.PlacaYaRegistrada(carro.Placa))
                        {
                            MessageBox.Show("La placa ingresada ya se encuentra registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            find = true;
                            break;
                        }
                    }
                    if (!find)
                    {
                        mod.VehiculosRegistrados.Insertar(carro);
                        Clientes.ModificarElemento(aux, mod);
                    }
                }
                form.Dispose();
                form = null;
            }
        }

        private void eliminarVehículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BuscarID())
            {
                Cliente client = BuscarCliente(IdBusqueda);
                SeleccionarVehiculo form = new(client);
                form.ShowDialog();
                if(form.VehiculoSeleccionado != null)
                {
                    Vehiculo car = (Vehiculo)form.VehiculoSeleccionado;
                    if (DialogResult.Yes == MessageBox.Show("Está seguro de que desea eliminar" +
                        $" la {car.Modelo} de placa {car.Placa} de {client.ToString()}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    {
                        Cliente mod = client.Copia();
                        client.VehiculosRegistrados.Eliminar(car);

                        Clientes.ModificarElemento(mod, client);
                        MessageBox.Show("Vehiculo eliminado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            MainMenu();
        }
    }
}
