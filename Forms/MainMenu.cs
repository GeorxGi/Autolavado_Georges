using Proyecto_Autolavado_Georges.Clases.DataClasses;
using Proyecto_Autolavado_Georges.Clases.DataHandlers;
using Proyecto_Autolavado_Georges.Clases.UI;
using Proyecto_Autolavado_Georges.Clases.UserClasses;
using Proyecto_Autolavado_Georges.Formularios;
using Proyecto_Autolavado_Georges.Properties;

namespace Proyecto_Autolavado_Georges
{
    public partial class MainMenu : Form
    {

        private readonly CustomQueue<(uint, Vehiculo)> colaAceite = new(5);
        private readonly CustomQueue<(uint, Vehiculo)> colaBalanceo = new(5);

        private readonly CustomQueue<(uint, Vehiculo)> colaAspirado = new(10);
        private readonly CustomQueue<(uint, Vehiculo)> colaLavado = new(10);
        private readonly CustomQueue<(uint, Vehiculo)> colaSecado = new(10);

        private readonly CustomStack<bool> pilaCauchos = new(4);

        private CustomLinkedList<Vehiculo> ListaCarroCliente;

        private ClientList ClientesRegistrados = [];

        private uint LastID = 1;

        #region ManejoClientes
        public async Task UpdateClientsCountAsync()
        {
            int cant = await Task.Run(() =>
            {
                int count = 0;
                foreach (Cliente client in ClientesRegistrados)
                {
                    if (client.Enabled)
                    {
                        count++;
                    }
                }
                return count;
            });
            clientsAmountLabel.Text = cant.ToString();
        }

        Cliente? clienteModificar;
        public void ModificarCliente()
        {
            UIHandler.ShowPanel(this, panelModificar, "MODIFICAR CLIENTE");

            Cliente? client = FormCaller.GetClient(ClientesRegistrados);

            if (client == null)
            {
                GoToMainMenu();
                MessageBox.Show("Cliente no encontrado/registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (client.Enabled)
            {
                datosAnterioresLabel.Text = $"  DATOS CLIENTE  " +
                                            $"\n\nNombre: {client.Name.Nombre}" +
                                            $"\nApellido: {client.Name.Apellido}" +
                                            $"\nCedula: {client.Cedula}";

                listaVehiculosModificarlabel.Text = "Vehiculos:";

                foreach (Vehiculo vehiculo in client.VehiculosRegistrados)
                {

                    listaVehiculosModificarlabel.Text += $"\n{vehiculo.Tipo} - {vehiculo.Modelo}\n{vehiculo.Placa}";
                }
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show($"El cliente {client} se encuentra deshabilitado, desea habilitarlo nuevamente?",
                    "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    client.HabilitarCliente();
                    UpdateClientsCountAsync();
                }
            }
        }

        public bool RegistrarCliente(Datos dat, CustomLinkedList<Vehiculo> carr, string cedula)
        {
            Cliente? cliente = ClientesRegistrados.SearchByCondition(c => c.Cedula == cedula);

            if (cliente != null)
            {
                if (!cliente.Enabled)
                {
                    if (DialogResult.Yes == MessageBox.Show($"La cedula ingresada pertenece a {cliente}," +
                            $"el cual se encuentra deshabilitado desea habilitarlo nuevamente?",
                            "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    {
                        return true;
                    }
                    else
                    {
                        GoToMainMenu();
                    }
                }
            }

            if (!UIHandler.CheckAllTextBoxHaveData(panelRegistrar))
            {
                MessageBox.Show("Rellene todos los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                //ESTABA AQUI
                Cliente client = new(LastID, cedula, dat, carr);
                if (IngresarClienteLista(client))
                {
                    MessageBox.Show("Cliente registrado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateClientsCountAsync();
                    return true;
                }
                else
                {
                    MessageBox.Show("Cliente ya registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        #endregion

        /// <summary>
        /// Recibe una cola y realiza el proceso de atendido de la misma
        /// </summary>
        /// <param name="cola">Cola a atender</param>
        /// <returns>Booleano que indica si todo el proceso se realizó correctamente</returns>
        public bool AtenderCola(Clases.DataClasses.CustomQueue<(uint, Vehiculo)> cola)
        {
            (uint, Vehiculo) item = cola.Retire();
            if (item.Item2 == null) return false;

            Cliente? client = ClientesRegistrados.SearchByCondition(p => p.Id == item.Item1);

            if (client == null) return false;

            client.ProcesarServicio(item.Item2);
            MessageBox.Show("Atendido correctamente el cliente: " + client.Name.Nombre, "Atendido", MessageBoxButtons.OK);
            return true;
        }
        /// <summary>
        /// Recibe una cola y realiza el proceso de atendido de la misma
        /// </summary>
        /// <param name="colaInicial">Cola a atender</param>
        /// <param name="colaDestino">Nueva cola a asignar</param>
        /// <returns>Booleano que indica si todo el proceso se realizó correctamente</returns>
        public bool AtenderCola(Clases.DataClasses.CustomQueue<(uint, Vehiculo)> colaInicial, Clases.DataClasses.CustomQueue<(uint, Vehiculo)> colaDestino, Services servicio)
        {
            (uint, Vehiculo) item = colaInicial.Retire();
            if (item.Item2 == null) return false;

            Cliente? client = ClientesRegistrados.SearchByCondition(p => p.Id == item.Item1);
            if (client == null) return false;

            client.ProcesarServicio(item.Item2);
            item.Item2.AsignarServicio(servicio);

            colaDestino.Insert(item);
            MessageBox.Show("Atendido correctamente el cliente: " + client.Name.Nombre, "Atendido", MessageBoxButtons.OK);
            return true;
        }

        public bool IngresarClienteLista(Cliente nuevoCliente)
        {
            bool finded = false;

            foreach (Cliente cl in ClientesRegistrados)
            {
                if (cl.Cedula == nuevoCliente.Cedula || cl.PlacaYaRegistrada(nuevoCliente.PlacasArray()))
                {
                    finded = true;
                    break;
                }
            }
            if (!finded)
            {
                ClientesRegistrados.Add(nuevoCliente);
                LastID++;
                return true;
            }
            else return false;
        }

        private bool ColaServicioLlena(Services servicio)
        {
            return servicio switch
            {
                Services.Balanceo => colaBalanceo.IsFull(),
                Services.Aceite => colaAceite.IsFull(),
                Services.Aspirado => colaAspirado.IsFull(),
                Services.Lavado => colaLavado.IsFull(),
                Services.Secado => colaSecado.IsFull(),
                _ => throw new ArgumentNullException("Servicio no valido/registrado")
            };
        }

        public bool? IngresarColaServicios(Cliente client, Vehiculo? veh, Services servicio)
        {
            if (veh == null)
            {
                return false;
            }
            else
            {
                return servicio switch
                {
                    Services.Balanceo => colaBalanceo.Insert((client.Id, veh)),
                    Services.Aceite => colaAceite.Insert((client.Id, veh)),
                    Services.Aspirado => colaAspirado.Insert((client.Id, veh)),
                    Services.Lavado => colaLavado.Insert((client.Id, veh)),
                    Services.Secado => colaSecado.Insert((client.Id, veh)),
                    _ => null,
                };
            }
        }

        public void EliminarClienteLista(Cliente client)
        {
            if (!client.Enabled)
            {
                MessageBox.Show("El cliente ya se encuentra deshabilitado");
                return;
            }

            if (client.HayVehiculoEnServicio())
            {
                MessageBox.Show("El cliente se encuentra actualmente en un servicio, termine dicho servicio antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (client.DeudaTotal != 0)
            {
                MessageBox.Show("El cliente posee deuda, pague primero antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DialogResult.Yes ==
                MessageBox.Show($"Esta seguro de que desea inhabilitar al cliente: {client}",
                "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                client.DeshabilitarCliente();
                MessageBox.Show("Cliente inhabilitado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateClientsCountAsync();
            }
            else
            {
                MessageBox.Show("Operación cancelada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            GoToMainMenu();
        }

        public static void EliminarColaServicio(Cliente cliente, CustomQueue<(uint, Vehiculo)> cola, Vehiculo car)
        {
            if (DialogResult.Yes == MessageBox.Show("Está seguro que desea cancelar su servicio?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (car != null)
                {
                    if (cola.DeleteQueue((cliente.Id, car)))
                    {
                        car.CancelarServicio();
                        MessageBox.Show("Servicio cancelado exitosamente", "Cancelación exitosa", MessageBoxButtons.OK);
                        return;
                    }
                }
                MessageBox.Show("Operacion fallada");
            }
        }

        public void CancelarServicio(Cliente cliente)
        {
            GoToMainMenu();
            if (!cliente.HayVehiculoEnServicio())
            {
                MessageBox.Show("El cliente indicado no se encuentra en un servicio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Vehiculo car = FormCaller.GetClientVehicle(cliente, SeleccionarVehiculo.GetVehicleMode.OnlyInService);
                if (car == null) return;

                switch (car.ServicioUbicado)
                {
                    case Services.Balanceo:
                        if (!colaBalanceo.IsFirstElement((cliente.Id, car)))
                        {
                            MessageBox.Show("No fue primer elemento");
                            EliminarColaServicio(cliente, colaBalanceo, car);
                        }
                        else
                        {
                            if (!pilaCauchos.IsEmpty())
                            {
                                MessageBox.Show("Proceso de balanceo iniciado, no se puede cancelar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                EliminarColaServicio(cliente, colaBalanceo, car);
                            }
                        }
                        break;

                    case Services.Aceite:
                        EliminarColaServicio(cliente, colaAceite, car);
                        break;
                    case Services.Aspirado:
                        EliminarColaServicio(cliente, colaAspirado, car);
                        break;
                    case Services.Lavado:
                        EliminarColaServicio(cliente, colaLavado, car);
                        break;
                    case Services.Secado:
                        EliminarColaServicio(cliente, colaSecado, car);
                        break;
                    default:
                        break;
                }
            }
        }

        public void PagarFactura()
        {
            Cliente? client = FormCaller.GetClient(ClientesRegistrados);
            if (client == null) return;

            if (client.ServiciosConsumidos.Count == 0)
            {
                MessageBox.Show("Cliente no posee deuda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (FormCaller.PayBill(client))
            {
                client.LimpiarFactura();
                MessageBox.Show("Factura pagada exitosamente", "Pago realizado", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Pago de factura cancelado", "Pago cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void AsignarCuota()
        {
            Cliente? client = FormCaller.GetClient(ClientesRegistrados);

            if (client == null) return;

            if (client.DeudaTotal == 0)
            {
                MessageBox.Show("Cliente no posee deuda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (client.MontoPorCuota != 0 && client.NumeroDeCuotas != 0)
            {
                MessageBox.Show("Cliente ya posee cuotas registradas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal aux = FormCaller.InsertNumber($"Deuda pendiente = ${client.DeudaTotal}\n¿A cuantas cuotas? (1 - 4)", 1, 4, false);
            if (aux < 0)
            {
                MessageBox.Show("Operación cancelada", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            uint numeroDeCuotas = (uint)aux;
            if (client.RegistrarCuota(numeroDeCuotas))
            {
                MessageBox.Show($"Cuotas registradas correctamente, deberá pagar un monto de ${string.Format("{0:0.00}", client.MontoPorCuota)} por cuota", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void GoToMainMenu()
        {
            UIHandler.ShowPanel(this, Optionpanel, "AUTOLAVADO");
        }

        public MainMenu()
        {
            InitializeComponent();
            CedulaComboBox.SelectedIndex = 0;
            this.Size = new Size(800, 500);
            panelModificar.Location = new Point(134, 55);
            panelServicios.Location = new Point(132, 55);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(static async () => await TasaCambio.LoadData());

            ClientesRegistrados = JSONHandler.CargarListaClientes();
            JSONHandler.CargarPrecioServicios();
            JSONHandler.LoadUISettings();

            AppSettings.InitializeSettings(this);

            UpdateClientsCountAsync();

            modoOscuroToolStripMenuItem.Checked = AppSettings.IsDarkMode;
            LastID = (uint)ClientesRegistrados.Count + 1;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                JSONHandler.AlmacenarListaClientes(ClientesRegistrados);
                JSONHandler.AlmacenarPrecioServicios();
                JSONHandler.StoreUISettings();
            }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            GoToMainMenu();
        }

        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIHandler.OnlyLetters(sender, e);
        }

        private void ApellidoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIHandler.OnlyLetters(sender, e);
        }

        private void CedulaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIHandler.OnlyNumbers(sender, e);
        }

        private void TipoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIHandler.OnlyLetters(sender, e);
        }

        private void ModeloTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIHandler.OnlyLetters(sender, e);
        }

        private void modificarClienteButton_Click(object sender, EventArgs e)
        {
        }


        private void cancelarModificarButton_Click(object sender, EventArgs e)
        {
            GoToMainMenu();
        }

        private void PlacaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIHandler.OnlyMayus(sender, e);
        }

        private void modificarPlacaVehiculoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            UIHandler.OnlyMayus(sender, e);
        }

        private void eliminarClienteButton_Click(object sender, EventArgs e)
        {

        }

        private void asignarServicioButton_Click(object sender, EventArgs e)
        {
            GoToMainMenu();
            Cliente? client = FormCaller.GetClient(ClientesRegistrados);

            if (client == null)
            {
                MessageBox.Show("El ID ingresado no se encuentra registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!client.Enabled)
            {
                MessageBox.Show("El cliente se encuentra actualmente inhabilitado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (FormCaller.SelectService(out Services? serv))
            {
                if (!serv.HasValue) return;

                if (!client.Enabled)
                {
                    MessageBox.Show("El cliente indicado no se encuentra habilitado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Vehiculo car = FormCaller.GetClientVehicle(client, SeleccionarVehiculo.GetVehicleMode.OnlyAvailable);
                if (car == null)
                {
                    return;
                }

                if (car.ServicioUbicado.HasValue)
                {
                    MessageBox.Show("el vehiculo seleccionado ya se encuentra en un servicio activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (ColaServicioLlena(serv.Value))
                {
                    MessageBox.Show("Cola de atención llena, atienda antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                car.AsignarServicio(serv.Value);
                IngresarColaServicios(client, car, serv.Value);
            }
        }

        private void sistemaAtencionButton_Click(object sender, EventArgs e)
        {
            UIHandler.ShowPanel(this, panelServicios, "SERVICIO ATENCIÓN");
            colaBalanceolabel.Text = "Clientes en espera:\n" + colaBalanceo.GetCount();
            colaAceitelabel.Text = "Clientes en espera:\n" + colaAceite.GetCount();
            colaLavadolabel.Text = "Clientes en espera:\n" + colaLavado.GetCount();
            colaAspiradolabel.Text = "Clientes en espera:\n" + colaAspirado.GetCount();
            colaSecadolabel.Text = "Clientes en espera:\n" + colaSecado.GetCount();

        }

        private void cancelarServiciobutton_Click(object sender, EventArgs e)
        {
            Cliente? client = FormCaller.GetClient(ClientesRegistrados);

            if (client == null)
            {
                MessageBox.Show("Cliente no encontrado/registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!client.Enabled)
            {
                MessageBox.Show("El cliente se encuentra actualmente inhabilitado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CancelarServicio(client);
        }

        private void listarClientesbutton_Click(object sender, EventArgs e)
        {
            ListaClientescontextMenuStrip.Show(Cursor.Position);
        }

        private void pagarFacturaButton_Click(object sender, EventArgs e)
        {
            pagoContextMenuStrip.Show(Cursor.Position);
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIHandler.ShowPanel(this, panelRegistrar, "REGISTRAR CLIENTE");
            ListaCarroCliente = new();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarCliente();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToMainMenu();
            Cliente? client = FormCaller.GetClient(ClientesRegistrados);
            if (client == null)
            {
                MessageBox.Show("Cliente no encontrado/Cargado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            EliminarClienteLista(client);
        }

        private void porServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCaller.SelectService(out Services? servicio);

            switch (servicio)
            {
                case Services.Balanceo:
                    FormCaller.ServiceList(ClientesRegistrados, colaBalanceo.Copy());
                    break;
                case Services.Aceite:
                    FormCaller.ServiceList(ClientesRegistrados, colaAceite.Copy());
                    break;
                case Services.Aspirado:
                    FormCaller.ServiceList(ClientesRegistrados, colaAspirado.Copy());
                    break;
                case Services.Lavado:
                    FormCaller.ServiceList(ClientesRegistrados, colaLavado.Copy());
                    break;
                case Services.Secado:
                    FormCaller.ServiceList(ClientesRegistrados, colaSecado.Copy());
                    break;
                default:
                    break;
            }
        }

        private void clientesRegistradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCaller.ClientsList(ClientesRegistrados);
        }

        private void pagarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PagarFactura();
        }

        private void pagarCuotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente? client = FormCaller.GetClient(ClientesRegistrados);

            if (client == null) return;

            if (client.DeudaTotal == 0)
            {
                MessageBox.Show("Cliente no posee deuda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (client.MontoPorCuota == 0 || client.NumeroDeCuotas == 0)
            {
                MessageBox.Show("Cliente no posee cuotas asignadas");
                return;
            }

            if (DialogResult.Yes == MessageBox.Show($"Desea pagar una de las {client.NumeroDeCuotas} cuotas pendientes?\n\nEl monto a pagar" +
                $" será de $" + string.Format("{0:0.00}", client.MontoPorCuota), "Pagar cuota", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                client.PagarCuota();
                MessageBox.Show("Pago realizado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Operación cancelada", "Cancelado", MessageBoxButtons.OK);
            }

        }

        private void asignarCuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignarCuota();
        }

        #region VehiculoCliente
        private void registrarVehículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente? clientForNewCar = FormCaller.GetClient(ClientesRegistrados);

            if (clientForNewCar == null) return;

            Vehiculo? newCar = FormCaller.CreateNewVehicle();

            if (newCar != null)
            {
                if (ClientesRegistrados.CarPlaqueIsRegistered(newCar.Placa))
                {
                    MessageBox.Show("La placa ingresada ya se encuentra registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                clientForNewCar.VehiculosRegistrados.AddLast(newCar);
                MessageBox.Show("Vehiculo registrado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void eliminarVehículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente? client = FormCaller.GetClient(ClientesRegistrados);

            if (client == null) return;

            Vehiculo car = FormCaller.GetClientVehicle(client, SeleccionarVehiculo.GetVehicleMode.OnlyAvailable);

            if (car == null) return;

            if (car.ServicioUbicado.HasValue)
            {
                MessageBox.Show("El vehiculo se encuentra actualmente en un servicio, termine dicho servicio antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DialogResult.Yes == MessageBox.Show("Está seguro de que desea eliminar" +
                $" el/la {car.Modelo} de placa {car.Placa} de {client}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                if (client.VehiculosRegistrados.Delete(car))
                {
                    MessageBox.Show("Vehiculo eliminado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            GoToMainMenu();
        }

        private void modificarVehículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente? client = FormCaller.GetClient(ClientesRegistrados);
            if (client == null) return;

            Vehiculo car = FormCaller.GetClientVehicle(client, SeleccionarVehiculo.GetVehicleMode.OnlyAvailable);
            if (car == null) return;

            if (car.ServicioUbicado.HasValue)
            {
                MessageBox.Show("El vehiculo se encuentra actualmente en un servicio, termine dicho servicio antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            GoToMainMenu();
            FormCaller.ModifyVehicle(car);
        }
        #endregion

        #region ButtonPress
        //BOTON DE ADMIN
        private void adminButton_MouseDown(object sender, MouseEventArgs e)
        {
            adminContextMenuStrip.Show(Cursor.Position);
        }
        private void adminButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                adminContextMenuStrip.Show(AdminRoundButton.PointToScreen(Point.Empty));
        }

        //BOTON DE CLIENTES
        private void registrarClienteButton_MouseDown(object sender, MouseEventArgs e)
        {
            clienteContextMenuStrip.Show(Cursor.Position);
        }
        private void registrarClienteButton_KeyDown(object sender, KeyEventArgs e)
        {
            clienteContextMenuStrip.Show(ClientsRoundButton.PointToScreen(Point.Empty));
        }

        //BOTON DE LISTAR
        private void listadobutton_MouseDown(object sender, MouseEventArgs e)
        {
            ListaClientescontextMenuStrip.Show(Cursor.Position);
        }
        private void listadobutton_KeyDown(object sender, KeyEventArgs e)
        {
            ListaClientescontextMenuStrip.Show(ListingRoundButton.PointToScreen(Point.Empty));
        }

        //BOTON DE PAGO
        private void pagarFacturaButton_MouseDown(object sender, MouseEventArgs e)
        {
            pagoContextMenuStrip.Show(Cursor.Position);
        }
        private void pagarFacturaButton_KeyDown(object sender, KeyEventArgs e)
        {
            pagoContextMenuStrip.Show(PayBillRoundButton.PointToScreen(Point.Empty));
        }
        #endregion

        #region adminToolStrip
        private void mostrarPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string listado;

            listado = "AUTOS\n";
            foreach (var precios in ServiceManager.GetAllPrices(TipoDeVehiculo.Auto))
            {
                listado += "\n" + precios.Key + " = " + precios.Value.ToString();
            }
            MessageBox.Show(listado);

            listado = "CAMIONETAS\n";
            foreach (var precios in ServiceManager.GetAllPrices(TipoDeVehiculo.Camioneta))
            {
                listado += "\n" + precios.Key + " = " + precios.Value.ToString();
            }
            MessageBox.Show(listado);
        }
        #endregion

        private void cambiarColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color? customColor = FormCaller.CustomizeColor();
            if (customColor.HasValue)
            {
                AppSettings.SetMainColor(customColor.Value);
                AppSettings.LoadMenuColor(this);
            }
        }

        private void modoOscuroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppSettings.SetDarkMode(modoOscuroToolStripMenuItem.Checked);
            AppSettings.SetDarkOrLightMode(this);
        }

        #region RegisterClientPanel
        private void acceptRegisterRoundButton_Click(object sender, EventArgs e)
        {
            Datos dat;
            dat.Nombre = NameTextBox.Text; dat.Apellido = ApellidoTextBox.Text;
            string cedula = CedulaComboBox.Text + CedulaTextBox.Text;

            if (RegistrarCliente(dat, ListaCarroCliente, cedula))
            {
                GoToMainMenu();
                ListaCarroCliente = new();
            }
        }

        private void CleanRegisterRoundButton_Click(object sender, EventArgs e)
        {
            UIHandler.CleanAllTextBox(panelRegistrar);
        }

        private void AddVehicleRoundButton_Click(object sender, EventArgs e)
        {
            Vehiculo? newCar = FormCaller.CreateNewVehicle();

            if (newCar != null)
            {
                listaVehiculoslabel.Text += newCar.ToString();
                ListaCarroCliente.AddLast(newCar);
            }
        }
        #endregion

        #region ModifyClientPanel
        private void AcceptModifyRoundButton_Click(object sender, EventArgs e)
        {
            if (clienteModificar == null) return;

            Cliente? client = clienteModificar;
            clienteModificar = null;
            Datos dat;
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

            if (DialogResult.Yes == MessageBox.Show("Está seguro de que desea modificar al cliente\n" +
                client.Name.Nombre + " " + client.Name.Apellido + "?", "¿Seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (client.Modificar(cedula, dat))
                {
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
            GoToMainMenu();
        }
        private void CancelModifyRoundButton_Click(object sender, EventArgs e)
        {
            GoToMainMenu();
        }
        #endregion

        #region AttendServicesPanel
        private void AtenderBalanceoRoundButton_Click(object sender, EventArgs e)
        {
            if (pilaCauchos.IsEmpty())
            {
                if (!colaBalanceo.IsEmpty())
                {
                    caucho1pictureBox.Visible = false;
                    caucho2pictureBox.Visible = false;
                    caucho3pictureBox.Visible = false;
                    caucho4pictureBox.Visible = false;
                    decimal cantidadCauchos = FormCaller.InsertNumber("Cuantos cauchos desea balancear?", 1, 4, false);

                    if (cantidadCauchos >= 1 && cantidadCauchos <= 4)
                    {
                        for (ushort i = 0; i < cantidadCauchos; i++)
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

        private void OilChangeRoundButton_Click(object sender, EventArgs e)
        {
            if (colaAceite.IsEmpty())
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

        private void WashingCycleRoundButton_Click(object sender, EventArgs e)
        {
            if (colaSecado.IsEmpty() && colaLavado.IsEmpty() && colaAspirado.IsEmpty())
            {
                MessageBox.Show("No hay clientes asignados al ciclo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!colaSecado.IsEmpty())
                {
                    if (!AtenderCola(colaSecado))
                    {
                        MessageBox.Show("Ocurrió un error inesperado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (!colaLavado.IsEmpty())
                {
                    if (!AtenderCola(colaLavado, colaSecado, Services.Secado))
                    {
                        MessageBox.Show("Ocurrió un error inesperado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (!colaAspirado.IsEmpty())
                {
                    if (!AtenderCola(colaAspirado, colaLavado, Services.Lavado))
                    {
                        MessageBox.Show("Ocurrió un error inesperado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                colaSecadolabel.Text = "Clientes en espera:\n" + colaSecado.GetCount();
                colaLavadolabel.Text = "Clientes en espera:\n" + colaLavado.GetCount();
                colaAspiradolabel.Text = "Clientes en espera:\n" + colaAspirado.GetCount();

            }
        }

        private void BalanceWheelRoundButton_Click(object sender, EventArgs e)
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
            if (pilaCauchos.IsEmpty() && !colaBalanceo.IsEmpty())
            {
                if (!AtenderCola(colaBalanceo))
                {
                    MessageBox.Show("Ocurrió un error inesperado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Balanceopanel.Visible = false; Balanceopanel.Enabled = false;
                colaBalanceolabel.Text = "Clientes en espera:\n" + colaBalanceo.GetCount();
            }
        }
        #endregion

        #region ModifyPrices
        private void autosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCaller.SelectService(out Services? servicio);
            if (servicio.HasValue)
            {
                Services mod = servicio.Value;
                decimal newPrice = FormCaller.InsertNumber($"Precio actual = ${ServiceManager.GetServicePrice(mod, TipoDeVehiculo.Auto)}", 0, true);
                if (newPrice != -1)
                {
                    ServiceManager.SetServicePrice(mod, TipoDeVehiculo.Auto, newPrice);
                }
            }
        }
        #endregion

        private void camionetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCaller.SelectService(out Services? servicio);
            if (servicio.HasValue)
            {
                Services mod = servicio.Value;
                decimal newPrice = FormCaller.InsertNumber($"Precio actual = ${ServiceManager.GetServicePrice(mod, TipoDeVehiculo.Camioneta)}", 0, true);
                if (newPrice != -1)
                {
                    ServiceManager.SetServicePrice(mod, TipoDeVehiculo.Camioneta, newPrice);
                }
            }
        }

        private void informaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCaller.ShowCredits();
        }
    }
}
