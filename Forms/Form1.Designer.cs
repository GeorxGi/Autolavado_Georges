namespace Proyecto_Autolavado_Georges
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label2 = new Label();
            registrarClienteButton = new Button();
            clienteContextMenuStrip = new ContextMenuStrip(components);
            registrarToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            modificarToolStripMenuItem = new ToolStripMenuItem();
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            registrarVehículoToolStripMenuItem = new ToolStripMenuItem();
            eliminarVehículoToolStripMenuItem = new ToolStripMenuItem();
            mainLabel = new Label();
            Optionpanel = new Panel();
            pagarFacturaButton = new Button();
            listadobutton = new Button();
            cancelarServiciobutton = new Button();
            sistemaAtencionButton = new Button();
            asignarServicioButton = new Button();
            clientsAmountLabel = new Label();
            pictureBox1 = new PictureBox();
            homeButton = new Button();
            panelRegistrar = new Panel();
            listaVehiculoslabel = new Label();
            CedulaTextBox = new TextBox();
            label1 = new Label();
            CedulaComboBox = new ComboBox();
            ApellidoTextBox = new TextBox();
            CedulaLabel = new Label();
            label8 = new Label();
            NameTextBox = new TextBox();
            button1 = new Button();
            CleanRegisterButton = new Button();
            AcceptRegisterButton = new Button();
            label7 = new Label();
            panelModificar = new Panel();
            listaVehiculosModificarlabel = new Label();
            modificarCedulaTextBox = new TextBox();
            modificarApellidoLabel = new Label();
            modificarCedulaComboBox = new ComboBox();
            modificarApellidoTextBox = new TextBox();
            modificarCédulaLabel = new Label();
            modificarNombreLabel = new Label();
            modificarNombreTextBox = new TextBox();
            datosAnterioresLabel = new Label();
            cancelarModificarButton = new Button();
            aceptarModificarButton = new Button();
            VehiculoLabel = new Label();
            panelServicios = new Panel();
            servicioslabel = new Label();
            Balanceopanel = new Panel();
            caucho4pictureBox = new PictureBox();
            caucho3pictureBox = new PictureBox();
            caucho2pictureBox = new PictureBox();
            caucho1pictureBox = new PictureBox();
            realizarBalanceobutton = new Button();
            panel16 = new Panel();
            colaBalanceolabel = new Label();
            colaSecadolabel = new Label();
            colaAceitelabel = new Label();
            panel19 = new Panel();
            colaLavadolabel = new Label();
            atenderAceitebutton = new Button();
            colaAspiradolabel = new Label();
            atenderBalanceoButton = new Button();
            atenderCicloLavadobutton = new Button();
            ListaClientescontextMenuStrip = new ContextMenuStrip(components);
            clientesRegistradosToolStripMenuItem = new ToolStripMenuItem();
            porServiciosToolStripMenuItem = new ToolStripMenuItem();
            pagoContextMenuStrip = new ContextMenuStrip(components);
            pagarFacturaToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            pagarCuotaToolStripMenuItem = new ToolStripMenuItem();
            asignarCuotasToolStripMenuItem = new ToolStripMenuItem();
            clienteContextMenuStrip.SuspendLayout();
            Optionpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelRegistrar.SuspendLayout();
            panelModificar.SuspendLayout();
            panelServicios.SuspendLayout();
            Balanceopanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)caucho4pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)caucho3pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)caucho2pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)caucho1pictureBox).BeginInit();
            ListaClientescontextMenuStrip.SuspendLayout();
            pagoContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(8, 398);
            label2.Name = "label2";
            label2.Size = new Size(110, 21);
            label2.TabIndex = 2;
            label2.Text = "Clientes";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // registrarClienteButton
            // 
            registrarClienteButton.ContextMenuStrip = clienteContextMenuStrip;
            registrarClienteButton.Cursor = Cursors.Hand;
            registrarClienteButton.ImageAlign = ContentAlignment.MiddleLeft;
            registrarClienteButton.Location = new Point(8, 13);
            registrarClienteButton.Name = "registrarClienteButton";
            registrarClienteButton.Size = new Size(110, 35);
            registrarClienteButton.TabIndex = 0;
            registrarClienteButton.Text = "Clientes";
            registrarClienteButton.UseVisualStyleBackColor = true;
            registrarClienteButton.Click += RegisterButton_Click;
            // 
            // clienteContextMenuStrip
            // 
            clienteContextMenuStrip.Items.AddRange(new ToolStripItem[] { registrarToolStripMenuItem, toolStripMenuItem2, modificarToolStripMenuItem, eliminarToolStripMenuItem, toolStripMenuItem3, registrarVehículoToolStripMenuItem, eliminarVehículoToolStripMenuItem });
            clienteContextMenuStrip.Name = "clienteContextMenuStrip";
            clienteContextMenuStrip.Size = new Size(169, 126);
            // 
            // registrarToolStripMenuItem
            // 
            registrarToolStripMenuItem.Image = Properties.Resources.add_user_icon;
            registrarToolStripMenuItem.Name = "registrarToolStripMenuItem";
            registrarToolStripMenuItem.Size = new Size(168, 22);
            registrarToolStripMenuItem.Text = "Registrar";
            registrarToolStripMenuItem.Click += registrarToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(165, 6);
            // 
            // modificarToolStripMenuItem
            // 
            modificarToolStripMenuItem.Image = Properties.Resources.edit_icon;
            modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            modificarToolStripMenuItem.Size = new Size(168, 22);
            modificarToolStripMenuItem.Text = "Modificar";
            modificarToolStripMenuItem.Click += modificarToolStripMenuItem_Click;
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Image = Properties.Resources.delete_icon;
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(168, 22);
            eliminarToolStripMenuItem.Text = "Eliminar";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(165, 6);
            // 
            // registrarVehículoToolStripMenuItem
            // 
            registrarVehículoToolStripMenuItem.Image = Properties.Resources.add_car;
            registrarVehículoToolStripMenuItem.Name = "registrarVehículoToolStripMenuItem";
            registrarVehículoToolStripMenuItem.Size = new Size(168, 22);
            registrarVehículoToolStripMenuItem.Text = "Registrar vehículo";
            registrarVehículoToolStripMenuItem.Click += registrarVehículoToolStripMenuItem_Click;
            // 
            // eliminarVehículoToolStripMenuItem
            // 
            eliminarVehículoToolStripMenuItem.Image = Properties.Resources.delete_icon;
            eliminarVehículoToolStripMenuItem.Name = "eliminarVehículoToolStripMenuItem";
            eliminarVehículoToolStripMenuItem.Size = new Size(168, 22);
            eliminarVehículoToolStripMenuItem.Text = "Eliminar vehículo";
            eliminarVehículoToolStripMenuItem.Click += eliminarVehículoToolStripMenuItem_Click;
            // 
            // mainLabel
            // 
            mainLabel.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mainLabel.Location = new Point(134, 0);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(638, 43);
            mainLabel.TabIndex = 5;
            mainLabel.Text = "AUTOLAVADO";
            mainLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Optionpanel
            // 
            Optionpanel.BackColor = Color.Brown;
            Optionpanel.Controls.Add(pagarFacturaButton);
            Optionpanel.Controls.Add(listadobutton);
            Optionpanel.Controls.Add(cancelarServiciobutton);
            Optionpanel.Controls.Add(sistemaAtencionButton);
            Optionpanel.Controls.Add(asignarServicioButton);
            Optionpanel.Controls.Add(clientsAmountLabel);
            Optionpanel.Controls.Add(pictureBox1);
            Optionpanel.Controls.Add(homeButton);
            Optionpanel.Controls.Add(label2);
            Optionpanel.Controls.Add(registrarClienteButton);
            Optionpanel.Dock = DockStyle.Left;
            Optionpanel.Location = new Point(0, 0);
            Optionpanel.Name = "Optionpanel";
            Optionpanel.Size = new Size(128, 800);
            Optionpanel.TabIndex = 0;
            // 
            // pagarFacturaButton
            // 
            pagarFacturaButton.Cursor = Cursors.Hand;
            pagarFacturaButton.Location = new Point(8, 221);
            pagarFacturaButton.Name = "pagarFacturaButton";
            pagarFacturaButton.Size = new Size(110, 35);
            pagarFacturaButton.TabIndex = 5;
            pagarFacturaButton.Text = "Pago";
            pagarFacturaButton.UseVisualStyleBackColor = true;
            pagarFacturaButton.Click += pagarFacturaButton_Click;
            // 
            // listadobutton
            // 
            listadobutton.Cursor = Cursors.Hand;
            listadobutton.Location = new Point(8, 180);
            listadobutton.Name = "listadobutton";
            listadobutton.Size = new Size(110, 35);
            listadobutton.TabIndex = 4;
            listadobutton.Text = "Listado";
            listadobutton.UseVisualStyleBackColor = true;
            listadobutton.Click += listarClientesbutton_Click;
            // 
            // cancelarServiciobutton
            // 
            cancelarServiciobutton.Cursor = Cursors.Hand;
            cancelarServiciobutton.Location = new Point(8, 98);
            cancelarServiciobutton.Name = "cancelarServiciobutton";
            cancelarServiciobutton.Size = new Size(110, 35);
            cancelarServiciobutton.TabIndex = 2;
            cancelarServiciobutton.Text = "Cancelar cita";
            cancelarServiciobutton.UseVisualStyleBackColor = true;
            cancelarServiciobutton.Click += cancelarServiciobutton_Click;
            // 
            // sistemaAtencionButton
            // 
            sistemaAtencionButton.Cursor = Cursors.Hand;
            sistemaAtencionButton.Location = new Point(8, 139);
            sistemaAtencionButton.Name = "sistemaAtencionButton";
            sistemaAtencionButton.Size = new Size(110, 35);
            sistemaAtencionButton.TabIndex = 3;
            sistemaAtencionButton.Text = "Sistema atención";
            sistemaAtencionButton.UseVisualStyleBackColor = true;
            sistemaAtencionButton.Click += sistemaAtencionButton_Click;
            // 
            // asignarServicioButton
            // 
            asignarServicioButton.Cursor = Cursors.Hand;
            asignarServicioButton.Location = new Point(8, 57);
            asignarServicioButton.Name = "asignarServicioButton";
            asignarServicioButton.Size = new Size(110, 35);
            asignarServicioButton.TabIndex = 1;
            asignarServicioButton.Text = "Asignar cita";
            asignarServicioButton.UseVisualStyleBackColor = true;
            asignarServicioButton.Click += asignarServicioButton_Click;
            // 
            // clientsAmountLabel
            // 
            clientsAmountLabel.AutoSize = true;
            clientsAmountLabel.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clientsAmountLabel.ForeColor = SystemColors.Control;
            clientsAmountLabel.Location = new Point(48, 429);
            clientsAmountLabel.Name = "clientsAmountLabel";
            clientsAmountLabel.Size = new Size(18, 19);
            clientsAmountLabel.TabIndex = 19;
            clientsAmountLabel.Text = "0";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Users;
            pictureBox1.Location = new Point(12, 422);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // homeButton
            // 
            homeButton.Cursor = Cursors.Hand;
            homeButton.Location = new Point(8, 360);
            homeButton.Name = "homeButton";
            homeButton.Size = new Size(110, 35);
            homeButton.TabIndex = 8;
            homeButton.Text = "Inicio";
            homeButton.UseVisualStyleBackColor = true;
            homeButton.Click += homeButton_Click;
            // 
            // panelRegistrar
            // 
            panelRegistrar.Controls.Add(listaVehiculoslabel);
            panelRegistrar.Controls.Add(CedulaTextBox);
            panelRegistrar.Controls.Add(label1);
            panelRegistrar.Controls.Add(CedulaComboBox);
            panelRegistrar.Controls.Add(ApellidoTextBox);
            panelRegistrar.Controls.Add(CedulaLabel);
            panelRegistrar.Controls.Add(label8);
            panelRegistrar.Controls.Add(NameTextBox);
            panelRegistrar.Controls.Add(button1);
            panelRegistrar.Controls.Add(CleanRegisterButton);
            panelRegistrar.Controls.Add(AcceptRegisterButton);
            panelRegistrar.Controls.Add(label7);
            panelRegistrar.Enabled = false;
            panelRegistrar.Location = new Point(134, 55);
            panelRegistrar.Name = "panelRegistrar";
            panelRegistrar.Size = new Size(638, 373);
            panelRegistrar.TabIndex = 7;
            panelRegistrar.Visible = false;
            // 
            // listaVehiculoslabel
            // 
            listaVehiculoslabel.Location = new Point(20, 205);
            listaVehiculoslabel.Name = "listaVehiculoslabel";
            listaVehiculoslabel.Size = new Size(321, 135);
            listaVehiculoslabel.TabIndex = 18;
            listaVehiculoslabel.Text = "Vehículos:\r\n";
            // 
            // CedulaTextBox
            // 
            CedulaTextBox.Location = new Point(63, 112);
            CedulaTextBox.MaxLength = 10;
            CedulaTextBox.Name = "CedulaTextBox";
            CedulaTextBox.PlaceholderText = "Cédula";
            CedulaTextBox.Size = new Size(215, 23);
            CedulaTextBox.TabIndex = 3;
            CedulaTextBox.KeyPress += CedulaTextBox_KeyPress;
            // 
            // label1
            // 
            label1.Location = new Point(314, 22);
            label1.Name = "label1";
            label1.Size = new Size(262, 15);
            label1.TabIndex = 2;
            label1.Text = "Apellidos";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CedulaComboBox
            // 
            CedulaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CedulaComboBox.FormattingEnabled = true;
            CedulaComboBox.Items.AddRange(new object[] { "V", "E" });
            CedulaComboBox.Location = new Point(16, 112);
            CedulaComboBox.Name = "CedulaComboBox";
            CedulaComboBox.Size = new Size(41, 23);
            CedulaComboBox.TabIndex = 2;
            // 
            // ApellidoTextBox
            // 
            ApellidoTextBox.Location = new Point(314, 40);
            ApellidoTextBox.MaxLength = 20;
            ApellidoTextBox.Name = "ApellidoTextBox";
            ApellidoTextBox.PlaceholderText = "Apellidos";
            ApellidoTextBox.Size = new Size(262, 23);
            ApellidoTextBox.TabIndex = 1;
            ApellidoTextBox.KeyPress += ApellidoTextBox_KeyPress;
            // 
            // CedulaLabel
            // 
            CedulaLabel.Location = new Point(16, 94);
            CedulaLabel.Name = "CedulaLabel";
            CedulaLabel.Size = new Size(262, 15);
            CedulaLabel.TabIndex = 1;
            CedulaLabel.Text = "Cédula de Identidad";
            CedulaLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Location = new Point(16, 22);
            label8.Name = "label8";
            label8.Size = new Size(262, 15);
            label8.TabIndex = 1;
            label8.Text = "Nombre";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(16, 40);
            NameTextBox.MaxLength = 20;
            NameTextBox.Name = "NameTextBox";
            NameTextBox.PlaceholderText = "Nombre";
            NameTextBox.Size = new Size(262, 23);
            NameTextBox.TabIndex = 0;
            NameTextBox.KeyPress += NameTextBox_KeyPress;
            // 
            // button1
            // 
            button1.ContextMenuStrip = clienteContextMenuStrip;
            button1.Cursor = Cursors.Hand;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(383, 94);
            button1.Name = "button1";
            button1.Size = new Size(110, 35);
            button1.TabIndex = 4;
            button1.Text = "Añadir vehículo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CleanRegisterButton
            // 
            CleanRegisterButton.BackColor = Color.Crimson;
            CleanRegisterButton.Cursor = Cursors.Hand;
            CleanRegisterButton.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CleanRegisterButton.ForeColor = SystemColors.Control;
            CleanRegisterButton.Location = new Point(483, 312);
            CleanRegisterButton.Name = "CleanRegisterButton";
            CleanRegisterButton.Size = new Size(110, 35);
            CleanRegisterButton.TabIndex = 7;
            CleanRegisterButton.Text = "Limpiar";
            CleanRegisterButton.UseVisualStyleBackColor = false;
            CleanRegisterButton.Click += CleanRegisterButton_Click;
            // 
            // AcceptRegisterButton
            // 
            AcceptRegisterButton.BackColor = Color.PaleGreen;
            AcceptRegisterButton.Cursor = Cursors.Hand;
            AcceptRegisterButton.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AcceptRegisterButton.Location = new Point(352, 312);
            AcceptRegisterButton.Name = "AcceptRegisterButton";
            AcceptRegisterButton.Size = new Size(110, 35);
            AcceptRegisterButton.TabIndex = 6;
            AcceptRegisterButton.Text = "Registrar";
            AcceptRegisterButton.UseCompatibleTextRendering = true;
            AcceptRegisterButton.UseVisualStyleBackColor = false;
            AcceptRegisterButton.Click += AcceptRegisterButton_Click;
            // 
            // label7
            // 
            label7.AccessibleRole = AccessibleRole.ToolTip;
            label7.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(16, 157);
            label7.Name = "label7";
            label7.Size = new Size(590, 45);
            label7.TabIndex = 17;
            label7.Text = "Vehículos";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelModificar
            // 
            panelModificar.Controls.Add(listaVehiculosModificarlabel);
            panelModificar.Controls.Add(modificarCedulaTextBox);
            panelModificar.Controls.Add(modificarApellidoLabel);
            panelModificar.Controls.Add(modificarCedulaComboBox);
            panelModificar.Controls.Add(modificarApellidoTextBox);
            panelModificar.Controls.Add(modificarCédulaLabel);
            panelModificar.Controls.Add(modificarNombreLabel);
            panelModificar.Controls.Add(modificarNombreTextBox);
            panelModificar.Controls.Add(datosAnterioresLabel);
            panelModificar.Controls.Add(cancelarModificarButton);
            panelModificar.Controls.Add(aceptarModificarButton);
            panelModificar.Controls.Add(VehiculoLabel);
            panelModificar.Enabled = false;
            panelModificar.Location = new Point(792, 55);
            panelModificar.Name = "panelModificar";
            panelModificar.Size = new Size(638, 373);
            panelModificar.TabIndex = 18;
            panelModificar.Visible = false;
            // 
            // listaVehiculosModificarlabel
            // 
            listaVehiculosModificarlabel.Location = new Point(16, 205);
            listaVehiculosModificarlabel.Name = "listaVehiculosModificarlabel";
            listaVehiculosModificarlabel.Size = new Size(279, 135);
            listaVehiculosModificarlabel.TabIndex = 19;
            listaVehiculosModificarlabel.Text = "Vehículos:\r\n";
            // 
            // modificarCedulaTextBox
            // 
            modificarCedulaTextBox.Location = new Point(63, 100);
            modificarCedulaTextBox.MaxLength = 10;
            modificarCedulaTextBox.Name = "modificarCedulaTextBox";
            modificarCedulaTextBox.PlaceholderText = "Cédula";
            modificarCedulaTextBox.Size = new Size(215, 23);
            modificarCedulaTextBox.TabIndex = 1;
            // 
            // modificarApellidoLabel
            // 
            modificarApellidoLabel.Location = new Point(314, 22);
            modificarApellidoLabel.Name = "modificarApellidoLabel";
            modificarApellidoLabel.Size = new Size(262, 15);
            modificarApellidoLabel.TabIndex = 2;
            modificarApellidoLabel.Text = "Apellidos";
            modificarApellidoLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // modificarCedulaComboBox
            // 
            modificarCedulaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            modificarCedulaComboBox.FormattingEnabled = true;
            modificarCedulaComboBox.Items.AddRange(new object[] { "V", "E" });
            modificarCedulaComboBox.Location = new Point(16, 100);
            modificarCedulaComboBox.Name = "modificarCedulaComboBox";
            modificarCedulaComboBox.Size = new Size(41, 23);
            modificarCedulaComboBox.TabIndex = 0;
            // 
            // modificarApellidoTextBox
            // 
            modificarApellidoTextBox.Location = new Point(314, 40);
            modificarApellidoTextBox.MaxLength = 20;
            modificarApellidoTextBox.Name = "modificarApellidoTextBox";
            modificarApellidoTextBox.PlaceholderText = "Apellidos";
            modificarApellidoTextBox.Size = new Size(262, 23);
            modificarApellidoTextBox.TabIndex = 0;
            // 
            // modificarCédulaLabel
            // 
            modificarCédulaLabel.Location = new Point(16, 82);
            modificarCédulaLabel.Name = "modificarCédulaLabel";
            modificarCédulaLabel.Size = new Size(262, 15);
            modificarCédulaLabel.TabIndex = 1;
            modificarCédulaLabel.Text = "Cédula de Identidad";
            modificarCédulaLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // modificarNombreLabel
            // 
            modificarNombreLabel.Location = new Point(16, 22);
            modificarNombreLabel.Name = "modificarNombreLabel";
            modificarNombreLabel.Size = new Size(262, 15);
            modificarNombreLabel.TabIndex = 1;
            modificarNombreLabel.Text = "Nombre";
            modificarNombreLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // modificarNombreTextBox
            // 
            modificarNombreTextBox.Location = new Point(16, 40);
            modificarNombreTextBox.MaxLength = 20;
            modificarNombreTextBox.Name = "modificarNombreTextBox";
            modificarNombreTextBox.PlaceholderText = "Nombre";
            modificarNombreTextBox.Size = new Size(262, 23);
            modificarNombreTextBox.TabIndex = 0;
            // 
            // datosAnterioresLabel
            // 
            datosAnterioresLabel.AutoSize = true;
            datosAnterioresLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            datosAnterioresLabel.Location = new Point(314, 84);
            datosAnterioresLabel.Name = "datosAnterioresLabel";
            datosAnterioresLabel.Size = new Size(102, 21);
            datosAnterioresLabel.TabIndex = 18;
            datosAnterioresLabel.Text = "Datos cliente:\r\n";
            // 
            // cancelarModificarButton
            // 
            cancelarModificarButton.BackColor = Color.Crimson;
            cancelarModificarButton.Cursor = Cursors.Hand;
            cancelarModificarButton.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelarModificarButton.ForeColor = SystemColors.Control;
            cancelarModificarButton.Location = new Point(502, 322);
            cancelarModificarButton.Name = "cancelarModificarButton";
            cancelarModificarButton.Size = new Size(110, 35);
            cancelarModificarButton.TabIndex = 7;
            cancelarModificarButton.Text = "Cancelar";
            cancelarModificarButton.UseVisualStyleBackColor = false;
            cancelarModificarButton.Click += cancelarModificarButton_Click;
            // 
            // aceptarModificarButton
            // 
            aceptarModificarButton.BackColor = Color.PaleGreen;
            aceptarModificarButton.Cursor = Cursors.Hand;
            aceptarModificarButton.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            aceptarModificarButton.Location = new Point(367, 322);
            aceptarModificarButton.Name = "aceptarModificarButton";
            aceptarModificarButton.Size = new Size(110, 35);
            aceptarModificarButton.TabIndex = 6;
            aceptarModificarButton.Text = "Modificar";
            aceptarModificarButton.UseCompatibleTextRendering = true;
            aceptarModificarButton.UseVisualStyleBackColor = false;
            aceptarModificarButton.Click += aceptarModificarButton_Click;
            // 
            // VehiculoLabel
            // 
            VehiculoLabel.AccessibleRole = AccessibleRole.ToolTip;
            VehiculoLabel.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            VehiculoLabel.Location = new Point(16, 156);
            VehiculoLabel.Name = "VehiculoLabel";
            VehiculoLabel.Size = new Size(276, 45);
            VehiculoLabel.TabIndex = 17;
            VehiculoLabel.Text = "Vehículos";
            VehiculoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelServicios
            // 
            panelServicios.Controls.Add(servicioslabel);
            panelServicios.Controls.Add(Balanceopanel);
            panelServicios.Controls.Add(panel16);
            panelServicios.Controls.Add(colaBalanceolabel);
            panelServicios.Controls.Add(colaSecadolabel);
            panelServicios.Controls.Add(colaAceitelabel);
            panelServicios.Controls.Add(panel19);
            panelServicios.Controls.Add(colaLavadolabel);
            panelServicios.Controls.Add(atenderAceitebutton);
            panelServicios.Controls.Add(colaAspiradolabel);
            panelServicios.Controls.Add(atenderBalanceoButton);
            panelServicios.Controls.Add(atenderCicloLavadobutton);
            panelServicios.Enabled = false;
            panelServicios.Location = new Point(134, 434);
            panelServicios.Name = "panelServicios";
            panelServicios.Size = new Size(638, 337);
            panelServicios.TabIndex = 19;
            panelServicios.Visible = false;
            // 
            // servicioslabel
            // 
            servicioslabel.BackColor = Color.Transparent;
            servicioslabel.Dock = DockStyle.Bottom;
            servicioslabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            servicioslabel.ForeColor = SystemColors.Desktop;
            servicioslabel.Location = new Point(0, 311);
            servicioslabel.Name = "servicioslabel";
            servicioslabel.Size = new Size(638, 26);
            servicioslabel.TabIndex = 34;
            servicioslabel.Text = "Aspirado                                       Lavado                                       Secado";
            servicioslabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Balanceopanel
            // 
            Balanceopanel.Controls.Add(caucho4pictureBox);
            Balanceopanel.Controls.Add(caucho3pictureBox);
            Balanceopanel.Controls.Add(caucho2pictureBox);
            Balanceopanel.Controls.Add(caucho1pictureBox);
            Balanceopanel.Controls.Add(realizarBalanceobutton);
            Balanceopanel.Enabled = false;
            Balanceopanel.Location = new Point(225, 17);
            Balanceopanel.Name = "Balanceopanel";
            Balanceopanel.Size = new Size(237, 100);
            Balanceopanel.TabIndex = 1;
            Balanceopanel.Visible = false;
            // 
            // caucho4pictureBox
            // 
            caucho4pictureBox.Image = Properties.Resources.caucho_faltante;
            caucho4pictureBox.Location = new Point(179, 47);
            caucho4pictureBox.Name = "caucho4pictureBox";
            caucho4pictureBox.Size = new Size(51, 50);
            caucho4pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            caucho4pictureBox.TabIndex = 26;
            caucho4pictureBox.TabStop = false;
            // 
            // caucho3pictureBox
            // 
            caucho3pictureBox.Image = Properties.Resources.caucho_faltante;
            caucho3pictureBox.Location = new Point(122, 47);
            caucho3pictureBox.Name = "caucho3pictureBox";
            caucho3pictureBox.Size = new Size(51, 50);
            caucho3pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            caucho3pictureBox.TabIndex = 25;
            caucho3pictureBox.TabStop = false;
            // 
            // caucho2pictureBox
            // 
            caucho2pictureBox.Image = Properties.Resources.caucho_faltante;
            caucho2pictureBox.Location = new Point(65, 47);
            caucho2pictureBox.Name = "caucho2pictureBox";
            caucho2pictureBox.Size = new Size(51, 50);
            caucho2pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            caucho2pictureBox.TabIndex = 24;
            caucho2pictureBox.TabStop = false;
            // 
            // caucho1pictureBox
            // 
            caucho1pictureBox.Image = Properties.Resources.caucho_faltante;
            caucho1pictureBox.Location = new Point(6, 47);
            caucho1pictureBox.Name = "caucho1pictureBox";
            caucho1pictureBox.Size = new Size(51, 50);
            caucho1pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            caucho1pictureBox.TabIndex = 0;
            caucho1pictureBox.TabStop = false;
            // 
            // realizarBalanceobutton
            // 
            realizarBalanceobutton.Cursor = Cursors.Hand;
            realizarBalanceobutton.Location = new Point(65, 6);
            realizarBalanceobutton.Name = "realizarBalanceobutton";
            realizarBalanceobutton.Size = new Size(110, 35);
            realizarBalanceobutton.TabIndex = 1;
            realizarBalanceobutton.Text = "Balancear caucho";
            realizarBalanceobutton.UseVisualStyleBackColor = true;
            realizarBalanceobutton.Click += realizarBalanceobutton_Click;
            // 
            // panel16
            // 
            panel16.BackColor = Color.Brown;
            panel16.Location = new Point(430, 247);
            panel16.Name = "panel16";
            panel16.Size = new Size(14, 90);
            panel16.TabIndex = 32;
            // 
            // colaBalanceolabel
            // 
            colaBalanceolabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            colaBalanceolabel.ForeColor = SystemColors.Desktop;
            colaBalanceolabel.Location = new Point(3, 17);
            colaBalanceolabel.Name = "colaBalanceolabel";
            colaBalanceolabel.Size = new Size(200, 50);
            colaBalanceolabel.TabIndex = 27;
            colaBalanceolabel.Text = "Clientes en espera:";
            colaBalanceolabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // colaSecadolabel
            // 
            colaSecadolabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            colaSecadolabel.ForeColor = SystemColors.Desktop;
            colaSecadolabel.Location = new Point(450, 258);
            colaSecadolabel.Name = "colaSecadolabel";
            colaSecadolabel.Size = new Size(182, 40);
            colaSecadolabel.TabIndex = 31;
            colaSecadolabel.Text = "Clientes en espera:";
            colaSecadolabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // colaAceitelabel
            // 
            colaAceitelabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            colaAceitelabel.ForeColor = SystemColors.Desktop;
            colaAceitelabel.Location = new Point(6, 130);
            colaAceitelabel.Name = "colaAceitelabel";
            colaAceitelabel.Size = new Size(197, 40);
            colaAceitelabel.TabIndex = 28;
            colaAceitelabel.Text = "Clientes en espera:";
            colaAceitelabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel19
            // 
            panel19.BackColor = Color.Brown;
            panel19.Location = new Point(205, 0);
            panel19.Name = "panel19";
            panel19.Size = new Size(14, 308);
            panel19.TabIndex = 33;
            // 
            // colaLavadolabel
            // 
            colaLavadolabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            colaLavadolabel.ForeColor = SystemColors.Desktop;
            colaLavadolabel.Location = new Point(225, 258);
            colaLavadolabel.Name = "colaLavadolabel";
            colaLavadolabel.Size = new Size(199, 40);
            colaLavadolabel.TabIndex = 30;
            colaLavadolabel.Text = "Clientes en espera:";
            colaLavadolabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // atenderAceitebutton
            // 
            atenderAceitebutton.Cursor = Cursors.Hand;
            atenderAceitebutton.Location = new Point(6, 173);
            atenderAceitebutton.Name = "atenderAceitebutton";
            atenderAceitebutton.Size = new Size(197, 35);
            atenderAceitebutton.TabIndex = 1;
            atenderAceitebutton.Text = "Cambo de aceite";
            atenderAceitebutton.UseVisualStyleBackColor = true;
            atenderAceitebutton.Click += atenderAceitebutton_Click;
            // 
            // colaAspiradolabel
            // 
            colaAspiradolabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            colaAspiradolabel.ForeColor = SystemColors.Desktop;
            colaAspiradolabel.Location = new Point(6, 220);
            colaAspiradolabel.Name = "colaAspiradolabel";
            colaAspiradolabel.Size = new Size(197, 40);
            colaAspiradolabel.TabIndex = 29;
            colaAspiradolabel.Text = "Clientes en espera:";
            colaAspiradolabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // atenderBalanceoButton
            // 
            atenderBalanceoButton.Cursor = Cursors.Hand;
            atenderBalanceoButton.Location = new Point(3, 70);
            atenderBalanceoButton.Name = "atenderBalanceoButton";
            atenderBalanceoButton.Size = new Size(200, 35);
            atenderBalanceoButton.TabIndex = 0;
            atenderBalanceoButton.Text = "Balanceo";
            atenderBalanceoButton.UseVisualStyleBackColor = true;
            atenderBalanceoButton.Click += atenderBalanceoButton_Click;
            // 
            // atenderCicloLavadobutton
            // 
            atenderCicloLavadobutton.Cursor = Cursors.Hand;
            atenderCicloLavadobutton.Location = new Point(6, 263);
            atenderCicloLavadobutton.Name = "atenderCicloLavadobutton";
            atenderCicloLavadobutton.Size = new Size(197, 35);
            atenderCicloLavadobutton.TabIndex = 2;
            atenderCicloLavadobutton.Text = "Ciclo autolavado";
            atenderCicloLavadobutton.UseVisualStyleBackColor = true;
            atenderCicloLavadobutton.Click += atenderCicloLavadobutton_Click;
            // 
            // ListaClientescontextMenuStrip
            // 
            ListaClientescontextMenuStrip.Items.AddRange(new ToolStripItem[] { clientesRegistradosToolStripMenuItem, porServiciosToolStripMenuItem });
            ListaClientescontextMenuStrip.Name = "ListaClientescontextMenuStrip";
            ListaClientescontextMenuStrip.Size = new Size(178, 48);
            // 
            // clientesRegistradosToolStripMenuItem
            // 
            clientesRegistradosToolStripMenuItem.Image = Properties.Resources.user_icon;
            clientesRegistradosToolStripMenuItem.Name = "clientesRegistradosToolStripMenuItem";
            clientesRegistradosToolStripMenuItem.Size = new Size(177, 22);
            clientesRegistradosToolStripMenuItem.Text = "Clientes registrados";
            clientesRegistradosToolStripMenuItem.Click += clientesRegistradosToolStripMenuItem_Click;
            // 
            // porServiciosToolStripMenuItem
            // 
            porServiciosToolStripMenuItem.Image = Properties.Resources.services_icon;
            porServiciosToolStripMenuItem.Name = "porServiciosToolStripMenuItem";
            porServiciosToolStripMenuItem.Size = new Size(177, 22);
            porServiciosToolStripMenuItem.Text = "Por servicios";
            porServiciosToolStripMenuItem.Click += porServiciosToolStripMenuItem_Click;
            // 
            // pagoContextMenuStrip
            // 
            pagoContextMenuStrip.Items.AddRange(new ToolStripItem[] { pagarFacturaToolStripMenuItem, toolStripMenuItem1, pagarCuotaToolStripMenuItem, asignarCuotasToolStripMenuItem });
            pagoContextMenuStrip.Name = "pagoContextMenuStrip";
            pagoContextMenuStrip.Size = new Size(153, 76);
            // 
            // pagarFacturaToolStripMenuItem
            // 
            pagarFacturaToolStripMenuItem.Image = Properties.Resources.money_icon;
            pagarFacturaToolStripMenuItem.Name = "pagarFacturaToolStripMenuItem";
            pagarFacturaToolStripMenuItem.Size = new Size(152, 22);
            pagarFacturaToolStripMenuItem.Text = "Pagar factura";
            pagarFacturaToolStripMenuItem.Click += pagarFacturaToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(149, 6);
            // 
            // pagarCuotaToolStripMenuItem
            // 
            pagarCuotaToolStripMenuItem.Image = Properties.Resources.money_icon;
            pagarCuotaToolStripMenuItem.Name = "pagarCuotaToolStripMenuItem";
            pagarCuotaToolStripMenuItem.Size = new Size(152, 22);
            pagarCuotaToolStripMenuItem.Text = "Pagar cuota";
            pagarCuotaToolStripMenuItem.Click += pagarCuotaToolStripMenuItem_Click;
            // 
            // asignarCuotasToolStripMenuItem
            // 
            asignarCuotasToolStripMenuItem.Image = Properties.Resources.cashea;
            asignarCuotasToolStripMenuItem.Name = "asignarCuotasToolStripMenuItem";
            asignarCuotasToolStripMenuItem.Size = new Size(152, 22);
            asignarCuotasToolStripMenuItem.Text = "Asignar cuotas";
            asignarCuotasToolStripMenuItem.Click += asignarCuotasToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1473, 800);
            Controls.Add(panelServicios);
            Controls.Add(panelModificar);
            Controls.Add(panelRegistrar);
            Controls.Add(Optionpanel);
            Controls.Add(mainLabel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Autolavado";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            clienteContextMenuStrip.ResumeLayout(false);
            Optionpanel.ResumeLayout(false);
            Optionpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelRegistrar.ResumeLayout(false);
            panelRegistrar.PerformLayout();
            panelModificar.ResumeLayout(false);
            panelModificar.PerformLayout();
            panelServicios.ResumeLayout(false);
            Balanceopanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)caucho4pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)caucho3pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)caucho2pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)caucho1pictureBox).EndInit();
            ListaClientescontextMenuStrip.ResumeLayout(false);
            pagoContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private Button registrarClienteButton;
        private Panel panelRegistrar;
        private Button CleanRegisterButton;
        private Button AcceptRegisterButton;
        private Label label7;
        private Label label8;
        private TextBox NameTextBox;
        private Label label1;
        private TextBox ApellidoTextBox;
        private TextBox CedulaTextBox;
        private ComboBox CedulaComboBox;
        private Label CedulaLabel;
        private Button homeButton;
        public Label mainLabel;
        public Panel Optionpanel;
        private PictureBox pictureBox1;
        private Label clientsAmountLabel;
        private Panel panelModificar;
        private Button cancelarModificarButton;
        private Button aceptarModificarButton;
        private Label VehiculoLabel;
        private Label modificarNombreLabel;
        private TextBox modificarNombreTextBox;
        private Label modificarApellidoLabel;
        private TextBox modificarApellidoTextBox;
        private TextBox modificarCedulaTextBox;
        private ComboBox modificarCedulaComboBox;
        private Label modificarCédulaLabel;
        private Label datosAnterioresLabel;
        private Panel panelServicios;
        private Button sistemaAtencionButton;
        private Button asignarServicioButton;
        private Button atenderBalanceoButton;
        private Button atenderCicloLavadobutton;
        private Button atenderAceitebutton;
        private Button realizarBalanceobutton;
        private Label colaAspiradolabel;
        private Label colaAceitelabel;
        private Label colaBalanceolabel;
        private Panel Balanceopanel;
        private PictureBox caucho4pictureBox;
        private PictureBox caucho3pictureBox;
        private PictureBox caucho2pictureBox;
        private PictureBox caucho1pictureBox;
        private Label colaSecadolabel;
        private Label colaLavadolabel;
        private Panel panel16;
        private Panel panel19;
        private Button cancelarServiciobutton;
        private Button pagarFacturaButton;
        private Button listadobutton;
        private ContextMenuStrip clienteContextMenuStrip;
        private ToolStripMenuItem registrarToolStripMenuItem;
        private ToolStripMenuItem modificarToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private ContextMenuStrip ListaClientescontextMenuStrip;
        private ToolStripMenuItem clientesRegistradosToolStripMenuItem;
        private ToolStripMenuItem porServiciosToolStripMenuItem;
        private ContextMenuStrip pagoContextMenuStrip;
        private ToolStripMenuItem pagarFacturaToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem pagarCuotaToolStripMenuItem;
        private ToolStripMenuItem asignarCuotasToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem registrarVehículoToolStripMenuItem;
        private ToolStripMenuItem eliminarVehículoToolStripMenuItem;
        private Label servicioslabel;
        private Button button1;
        private Label listaVehiculoslabel;
        private Label listaVehiculosModificarlabel;
    }
}
