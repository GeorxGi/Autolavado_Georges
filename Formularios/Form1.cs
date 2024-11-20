using Autolavado_GeorgesChakour.Clases;
using Proyecto_Autolavado_Georges.Formularios;
using Proyecto_Autolavado_Georges.Properties;
using System.Net.NetworkInformation;

namespace Proyecto_Autolavado_Georges
{
    public partial class Form1 : Form
    {
        private Cola<int> colaAceite = new(5);
        private Cola<int> colaBalanceo = new(5);

        private Cola<int> colaAspirado = new(10);
        private Cola<int> colaLavado = new(10);
        private Cola<int> colaSecado = new(10);
        private Pila<bool> pilaCauchos = new(4);

        List<Cliente> Clientes = new();

        public int Id { get; private set; } = 1;
        private string? Servicio = null;
        private int IdBusqueda;

        public void Registrar(Datos dat, Vehiculo carr, string cedula)
        {
            if (!Interfaz.DatosColocados(panelRegistrar))
            {
                MessageBox.Show("Rellene todos los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Cliente client = new(Convert.ToUInt32(Id), cedula, dat, carr);
                if (IngresarClienteLista(client))
                {
                    MessageBox.Show("Cliente registrado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clientsAmountLabel.Text = Convert.ToString(Clientes.Count);
                }
                else
                {
                    MessageBox.Show("Cliente ya registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public bool IngresarClienteLista(Cliente clients)
        {
            bool find = false;
            foreach (Cliente cl in Clientes)
            {
                if (cl.Cedula == clients.Cedula || cl.Carro.Placa == clients.Carro.Placa)
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
                Clientes.Add(clients);
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
            foreach (Cliente client in Clientes)
            {
                if (client.Id == IdBusqueda)
                {
                    IdBusqueda--;
                    return true;
                }
            }
            return false;
        }

        public void SeleccionarServicio()
        {
            IngresarServicio ingresar = new();
            ingresar.ShowDialog();
            Servicio = ingresar.Servicio;
            ingresar.Dispose();
        }

        public bool IngresarColaServicios(Cliente client)
        {
            if (Servicio == Servicios.ServiciosDisp[0])
            {
                if (colaBalanceo.Insertar((int)client.Id)) return true;
            }
            else if (Servicio == Servicios.ServiciosDisp[1])
            {
                if (colaAceite.Insertar((int)client.Id)) return true;
            }
            else if (Servicio == Servicios.ServiciosDisp[2])
            {
                if (colaAspirado.Insertar((int)client.Id)) return true;
            }
            else if (Servicio == Servicios.ServiciosDisp[3])
            {
                if (colaLavado.Insertar((int)client.Id)) return true;
            }
            else if (Servicio == Servicios.ServiciosDisp[4])
            {
                if (colaSecado.Insertar((int)client.Id)) return true;
            }
            return false;
        }

        public void EliminarClienteLista(Cliente client)
        {
            if (client.ServicioActivo == null)
            {
                if (client.ServiciosConsumidos.Count == 0)
                {
                    DialogResult resp = MessageBox.Show("Esta seguro de que desea eliminar al cliente:\n" + client.Name.Nombre + " " +
                            client.Name.Apellido + "?\nESTA ACCIÓN NO SE PUEDE REVERTIR"
                            , "CUIDADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resp == DialogResult.Yes)
                    {
                        Clientes.Remove(client);
                        MessageBox.Show("Cliente eliminado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clientsAmountLabel.Text = Convert.ToString(Clientes.Count);
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
            MainMenu();
        }

        public void EliminarColaServicio(Cliente cliente, Cola<int> cola)
        {
            if (DialogResult.Yes == MessageBox.Show("Está seguro que desea cancelar su servicio?", "Cancelar servicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                MessageBox.Show("Toco eliminar a: " + cliente.Id);
                if (cola.Eliminar(Convert.ToInt32(cliente.Id)))
                {
                    cliente.CancelarServicio();
                    Clientes[IdBusqueda] = cliente;
                    MessageBox.Show("Servicio cancelado exitosamente", "Cancelación exitosa", MessageBoxButtons.OK);
                }
            }
        }

        public void CanceLarServicio(Cliente cliente)
        {
            MainMenu();
            if (cliente.ServicioActivo == null)
            {
                MessageBox.Show("El cliente indicado no se encuentra en un servicio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cliente.ServicioActivo == Servicios.ServiciosDisp[0])
                {
                    if (colaBalanceo.FindIndex((int)cliente.Id) != 0)
                    {
                        EliminarColaServicio(cliente, colaBalanceo);
                    }
                    else
                    {
                        if (!pilaCauchos.PilaVacia())
                        {
                            MessageBox.Show("Proceso de balanceo iniciado, no se puede cancelar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            EliminarColaServicio(cliente, colaBalanceo);
                        }
                    }
                }
                else if (cliente.ServicioActivo == Servicios.ServiciosDisp[1])
                {
                    EliminarColaServicio(cliente, colaAceite);
                }
                else
                {
                    if (cliente.ServicioActivo == Servicios.ServiciosDisp[2])
                    {
                        EliminarColaServicio(cliente, colaAspirado);
                    }
                    else if (cliente.ServicioActivo == Servicios.ServiciosDisp[3])
                    {
                        EliminarColaServicio(cliente, colaLavado);
                    }
                    else if (cliente.ServicioActivo == Servicios.ServiciosDisp[4])
                    {
                        EliminarColaServicio(cliente, colaSecado);
                    }
                    cliente.CancelarServicio();
                    Clientes[IdBusqueda] = cliente;
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
            Id = Clientes.Count + 1;
            clientsAmountLabel.Text = Convert.ToString(Clientes.Count);
            tipoCarrocomboBox.SelectedIndex = 0;
            modificarTipoCarrocomboBox.SelectedIndex = 0;
            int num = 1;
            foreach(Cliente client in Clientes)
            {
                if (client.Id > num)
                {
                    num = Convert.ToInt32(client.Id);
                }
            }
            Id = num;
        }

        private void AcceptRegisterButton_Click(object sender, EventArgs e)
        {
            Datos dat;
            dat.Nombre = NameTextBox.Text; dat.Apellido = ApellidoTextBox.Text;
            Vehiculo carr;
            carr.Modelo = ModeloTextBox.Text; carr.Placa = PlacaTextBox.Text; carr.Tipo = tipoCarrocomboBox.Text;
            string cedula = CedulaComboBox.Text + CedulaTextBox.Text;

            Registrar(dat, carr, cedula);
            MainMenu();
        }

        private void CleanRegisterButton_Click(object sender, EventArgs e)
        {
            Interfaz.LimpiarTextBox(panelRegistrar);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Interfaz.MostrarPanel(this, panelRegistrar, "REGISTRAR CLIENTE");
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
            Interfaz.MostrarPanel(this, panelModificar, "MODIFICAR CLIENTE");
            if (BuscarID())
            {
                Cliente clien = Clientes.ElementAt(IdBusqueda);
                datosAnterioresLabel.Text = "Datos cliente: " +
                                            "\nNombre: " + clien.Name.Nombre + "\nApellidos: " + clien.Name.Apellido +
                                            "\nCedula: " + clien.Cedula + "\nVEHICULO\nTipo : " + clien.Carro.Tipo +
                                            "\nModelo " + clien.Carro.Modelo + "\nPlaca: " + clien.Carro.Placa;
            }
            else
            {
                MainMenu();
                MessageBox.Show("Cliente no encontrado/registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void aceptarModificarButton_Click(object sender, EventArgs e)
        {
            Cliente client = Clientes.ElementAt(IdBusqueda);
            Datos dat;
            Vehiculo carr;
            string cedula;
            if (string.IsNullOrWhiteSpace(modificarNombreTextBox.Text)) dat.Nombre = client.Name.Nombre;
            else dat.Nombre = modificarNombreTextBox.Text;

            if (string.IsNullOrWhiteSpace(modificarApellidoTextBox.Text)) dat.Apellido = client.Name.Apellido;
            else dat.Apellido = modificarApellidoTextBox.Text;

            if (string.IsNullOrWhiteSpace(CedulaTextBox.Text)) cedula = client.Cedula;
            else cedula = CedulaComboBox.Text + CedulaTextBox.Text;

            if (string.IsNullOrWhiteSpace(modificarModeloVehiculoTextBox.Text)) carr.Modelo = client.Carro.Modelo;
            else carr.Modelo = modificarModeloVehiculoTextBox.Text;

            if (string.IsNullOrWhiteSpace(modificarPlacaVehiculoTextBox.Text)) carr.Placa = client.Carro.Placa;
            else carr.Placa = modificarPlacaVehiculoTextBox.Text;

            if (string.IsNullOrWhiteSpace(modificarTipoCarrocomboBox.Text)) carr.Tipo = client.Carro.Tipo;
            else carr.Tipo = modificarTipoCarrocomboBox.Text;

            DialogResult resp = MessageBox.Show("Está seguro de que desea modificar al cliente\n" +
                client.Name.Nombre + " " + client.Name.Apellido + "?", "¿Seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                if (client.Modificar(cedula, dat, carr))
                {
                    Clientes[IdBusqueda] = client;
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
            MainMenu();
            if (BuscarID())
            {
                Cliente client = Clientes.ElementAt(IdBusqueda);
                EliminarClienteLista(client);
            }
            else
            {
                MessageBox.Show("Cliente no encontrado/Cargado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void asignarServicioButton_Click(object sender, EventArgs e)
        {
            MainMenu();
            if (BuscarID())
            {
                Cliente client = Clientes.ElementAt(IdBusqueda);
                SeleccionarServicio();
                if (client.ServicioActivo == null)
                {
                    if (IngresarColaServicios(client))
                    {
                        client.RegistrarServicio(Servicio);
                        Clientes[IdBusqueda] = client;
                    }
                    else
                    {
                        MessageBox.Show("Cola de atención llena, atienda antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("el cliente ya cuenta con un servicio activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Balanceopanel.Visible = true; Balanceopanel.Enabled = true;
                    pilaCauchos.Push(true); pilaCauchos.Push(false);
                    pilaCauchos.Push(false); pilaCauchos.Push(false);
                    caucho4pictureBox.Image = Resources.caucho_faltante;
                    caucho3pictureBox.Image = Resources.caucho_faltante;
                    caucho2pictureBox.Image = Resources.caucho_faltante;
                    caucho1pictureBox.Image = Resources.caucho_faltante;
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
                IdBusqueda = colaBalanceo.Retirar() - 1;
                Cliente client = Clientes[IdBusqueda];
                MessageBox.Show("Atendido correctamente el cliente: " + client.Name.Nombre, "Cauchos balanceados", MessageBoxButtons.OK);
                client.ProcesarServicio();
                Clientes[IdBusqueda] = client;
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
                IdBusqueda = colaAceite.Retirar() - 1;
                Cliente client = Clientes[IdBusqueda];
                client.ProcesarServicio();
                Clientes[IdBusqueda] = client;
                MessageBox.Show("Atendido correctamente el cliente: " + client.Name.Nombre, "Aceite cambiado", MessageBoxButtons.OK);
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
                Cliente client;
                if (!colaSecado.ColaVacia())
                {
                    IdBusqueda = colaSecado.Retirar() - 1;
                    client = Clientes[IdBusqueda];
                    MessageBox.Show("Atendido correctamente el cliente: " + client.Name.Nombre, "Secado realizado", MessageBoxButtons.OK);
                    client.ProcesarServicio();
                    Clientes[IdBusqueda] = client;
                }

                if (!colaLavado.ColaVacia())
                {
                    IdBusqueda = colaLavado.Retirar() - 1;
                    client = Clientes[IdBusqueda];
                    MessageBox.Show("Atendido correctamente el cliente: " + client.Name.Nombre, "Lavado realizado", MessageBoxButtons.OK);
                    client.ProcesarServicio();
                    client.RegistrarServicio(Servicios.ServiciosDisp[4]);
                    colaSecado.Insertar(Convert.ToInt32(client.Id));
                    Clientes[IdBusqueda] = client;
                }

                if (!colaAspirado.ColaVacia())
                {
                    IdBusqueda = colaAspirado.Retirar() - 1;
                    client = Clientes[IdBusqueda];
                    MessageBox.Show("Atendido correctamente el cliente: " + client.Name.Nombre, "Aspirado realizado", MessageBoxButtons.OK);
                    client.ProcesarServicio();
                    client.RegistrarServicio(Servicios.ServiciosDisp[3]);
                    colaLavado.Insertar(Convert.ToInt32(client.Id));
                    Clientes[IdBusqueda] = client;
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
                Cliente client = Clientes[IdBusqueda];
                CanceLarServicio(client);
            }
            else
            {
                MessageBox.Show("Cliente no encontrado/registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Cola<int> CargarAux(Cola<int> cola)
        {
            Cola<int> colaAux = new(cola.Size);
            int[] dat = cola.ObtenerDatos();
            for(int i = 0; i < cola.GetCount(); i++)
            {
                colaAux.Insertar(dat[i]);
            }
            return colaAux;
        }

        private void listarClientesbutton_Click(object sender, EventArgs e)
        {
            IngresarServicio Serv = new();
            Serv.ShowDialog();
            Servicio = Serv.Servicio;
            Serv.Dispose();


            if (Servicio == Servicios.ServiciosDisp[0])
            {
                Cola<int> aux = CargarAux(colaBalanceo);
                ListaClientes lista = new(Clientes, aux);
                lista.ShowDialog();
                lista.Dispose();
            }
            else if (Servicio == Servicios.ServiciosDisp[1])
            {
                Cola<int> aux = CargarAux(colaAceite);
                ListaClientes lista = new(Clientes, aux);
                lista.ShowDialog();
                lista.Dispose();
            }
            else if (Servicio == Servicios.ServiciosDisp[2])
            {
                Cola<int> aux = CargarAux(colaAspirado);
                ListaClientes lista = new(Clientes, aux);
                lista.ShowDialog();
                lista.Dispose();
            }
            else if (Servicio == Servicios.ServiciosDisp[3])
            {
                Cola<int> aux = CargarAux(colaLavado);
                ListaClientes lista = new(Clientes, aux);
                lista.ShowDialog();
                lista.Dispose();
            }
            else if (Servicio == Servicios.ServiciosDisp[4])
            {
                Cola<int> aux = CargarAux(colaSecado);
                ListaClientes lista = new(Clientes, aux);
                lista.ShowDialog();
                lista.Dispose();
            }

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
            bool pagado = false;
            if (BuscarID())
            {
                Cliente client = Clientes[IdBusqueda];
                if (client.ServiciosConsumidos.Count == 0)
                {
                    MessageBox.Show("Cliente no posee deuda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ListaClientes lista = new(client);
                    lista.ShowDialog();
                    lista.Dispose();
                    pagado = lista.Pagado;
                    if (pagado)
                    {
                        client.LimpiarFactura();
                        Clientes[IdBusqueda] = client;
                        MessageBox.Show("Factura pagada exitosamente", "Pago realizado", MessageBoxButtons.OK);
                    }
                    else
                    {
                        {
                            MessageBox.Show("Pago de factura cancelado", "Pago cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
    }
}
