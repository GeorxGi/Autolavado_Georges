namespace Proyecto_Autolavado_Georges.Formularios
{
    partial class ListaClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            cedula = new DataGridViewTextBoxColumn();
            placaVehiculo = new DataGridViewTextBoxColumn();
            tipoVehiculo = new DataGridViewTextBoxColumn();
            modeloVehiculo = new DataGridViewTextBoxColumn();
            posicion = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Nombre, Apellido, cedula, placaVehiculo, tipoVehiculo, modeloVehiculo, posicion });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(800, 450);
            dataGridView1.TabIndex = 0;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            Apellido.HeaderText = "Apellido";
            Apellido.Name = "Apellido";
            Apellido.ReadOnly = true;
            // 
            // cedula
            // 
            cedula.HeaderText = "Cedula";
            cedula.Name = "cedula";
            cedula.ReadOnly = true;
            // 
            // placaVehiculo
            // 
            placaVehiculo.HeaderText = "Placa vehiculo";
            placaVehiculo.Name = "placaVehiculo";
            placaVehiculo.ReadOnly = true;
            // 
            // tipoVehiculo
            // 
            tipoVehiculo.HeaderText = "Tipo de vehiculo";
            tipoVehiculo.Name = "tipoVehiculo";
            tipoVehiculo.ReadOnly = true;
            // 
            // modeloVehiculo
            // 
            modeloVehiculo.HeaderText = "Modelo del vehículo";
            modeloVehiculo.Name = "modeloVehiculo";
            modeloVehiculo.ReadOnly = true;
            // 
            // posicion
            // 
            posicion.HeaderText = "Posición en la cola";
            posicion.Name = "posicion";
            posicion.ReadOnly = true;
            // 
            // ListaClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ListaClientes";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Lista de clientes";
            Load += ListaClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn cedula;
        private DataGridViewTextBoxColumn placaVehiculo;
        private DataGridViewTextBoxColumn tipoVehiculo;
        private DataGridViewTextBoxColumn modeloVehiculo;
        private DataGridViewTextBoxColumn posicion;
    }
}