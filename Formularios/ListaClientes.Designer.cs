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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            cedula = new DataGridViewTextBoxColumn();
            placaVehiculo = new DataGridViewTextBoxColumn();
            tipoVehiculo = new DataGridViewTextBoxColumn();
            modeloVehiculo = new DataGridViewTextBoxColumn();
            posicion = new DataGridViewTextBoxColumn();
            tableLayoutPanel1 = new TableLayoutPanel();
            mainLabel = new Label();
            pagarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.RosyBrown;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, Nombre, Apellido, cedula, placaVehiculo, tipoVehiculo, modeloVehiculo, posicion });
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.Brown;
            dataGridView1.Location = new Point(3, 54);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(794, 345);
            dataGridView1.TabIndex = 0;
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.Name = "id";
            id.ReadOnly = true;
            id.Resizable = DataGridViewTriState.False;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Resizable = DataGridViewTriState.False;
            // 
            // Apellido
            // 
            Apellido.HeaderText = "Apellido";
            Apellido.Name = "Apellido";
            Apellido.ReadOnly = true;
            Apellido.Resizable = DataGridViewTriState.False;
            // 
            // cedula
            // 
            cedula.HeaderText = "Cedula";
            cedula.Name = "cedula";
            cedula.ReadOnly = true;
            cedula.Resizable = DataGridViewTriState.False;
            // 
            // placaVehiculo
            // 
            placaVehiculo.HeaderText = "Placa vehiculo";
            placaVehiculo.Name = "placaVehiculo";
            placaVehiculo.ReadOnly = true;
            placaVehiculo.Resizable = DataGridViewTriState.False;
            // 
            // tipoVehiculo
            // 
            tipoVehiculo.HeaderText = "Tipo de vehiculo";
            tipoVehiculo.Name = "tipoVehiculo";
            tipoVehiculo.ReadOnly = true;
            tipoVehiculo.Resizable = DataGridViewTriState.False;
            // 
            // modeloVehiculo
            // 
            modeloVehiculo.HeaderText = "Modelo del vehículo";
            modeloVehiculo.Name = "modeloVehiculo";
            modeloVehiculo.ReadOnly = true;
            modeloVehiculo.Resizable = DataGridViewTriState.False;
            // 
            // posicion
            // 
            posicion.HeaderText = "Posición en la cola";
            posicion.Name = "posicion";
            posicion.ReadOnly = true;
            posicion.Resizable = DataGridViewTriState.False;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Controls.Add(mainLabel, 0, 0);
            tableLayoutPanel1.Location = new Point(1, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 351F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(800, 402);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // mainLabel
            // 
            mainLabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mainLabel.Location = new Point(3, 0);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(794, 51);
            mainLabel.TabIndex = 1;
            mainLabel.Text = ".";
            mainLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pagarButton
            // 
            pagarButton.Cursor = Cursors.Hand;
            pagarButton.Enabled = false;
            pagarButton.Location = new Point(678, 410);
            pagarButton.Name = "pagarButton";
            pagarButton.Size = new Size(110, 35);
            pagarButton.TabIndex = 9;
            pagarButton.Text = "Pagar";
            pagarButton.UseVisualStyleBackColor = true;
            pagarButton.Visible = false;
            pagarButton.Click += pagarButton_Click;
            // 
            // ListaClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pagarButton);
            Controls.Add(tableLayoutPanel1);
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
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label mainLabel;
        private Button pagarButton;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn cedula;
        private DataGridViewTextBoxColumn placaVehiculo;
        private DataGridViewTextBoxColumn tipoVehiculo;
        private DataGridViewTextBoxColumn modeloVehiculo;
        private DataGridViewTextBoxColumn posicion;
    }
}