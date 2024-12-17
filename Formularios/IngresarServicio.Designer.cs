namespace Proyecto_Autolavado_Georges.Formularios
{
    partial class IngresarServicio
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
            secadoButton = new Button();
            label1 = new Label();
            lavadoButton = new Button();
            aspiradoButton = new Button();
            aceiteButton = new Button();
            balanceoButton = new Button();
            SuspendLayout();
            // 
            // secadoButton
            // 
            secadoButton.Cursor = Cursors.Hand;
            secadoButton.Dock = DockStyle.Bottom;
            secadoButton.Location = new Point(0, 265);
            secadoButton.Name = "secadoButton";
            secadoButton.Size = new Size(187, 50);
            secadoButton.TabIndex = 4;
            secadoButton.Text = "Secado";
            secadoButton.UseVisualStyleBackColor = true;
            secadoButton.Click += secadoButton_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(2, 9);
            label1.Name = "label1";
            label1.Size = new Size(185, 53);
            label1.TabIndex = 2;
            label1.Text = "Seleccione el servicio\r\ndeseado";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lavadoButton
            // 
            lavadoButton.Cursor = Cursors.Hand;
            lavadoButton.Dock = DockStyle.Bottom;
            lavadoButton.Location = new Point(0, 215);
            lavadoButton.Name = "lavadoButton";
            lavadoButton.Size = new Size(187, 50);
            lavadoButton.TabIndex = 3;
            lavadoButton.Text = "Lavado";
            lavadoButton.UseVisualStyleBackColor = true;
            lavadoButton.Click += lavadoButton_Click;
            // 
            // aspiradoButton
            // 
            aspiradoButton.Cursor = Cursors.Hand;
            aspiradoButton.Dock = DockStyle.Bottom;
            aspiradoButton.Location = new Point(0, 165);
            aspiradoButton.Name = "aspiradoButton";
            aspiradoButton.Size = new Size(187, 50);
            aspiradoButton.TabIndex = 2;
            aspiradoButton.Text = "Aspirado";
            aspiradoButton.UseVisualStyleBackColor = true;
            aspiradoButton.Click += aspiradoButton_Click;
            // 
            // aceiteButton
            // 
            aceiteButton.Cursor = Cursors.Hand;
            aceiteButton.Dock = DockStyle.Bottom;
            aceiteButton.Location = new Point(0, 115);
            aceiteButton.Name = "aceiteButton";
            aceiteButton.Size = new Size(187, 50);
            aceiteButton.TabIndex = 1;
            aceiteButton.Text = "Cambio de aceite";
            aceiteButton.UseVisualStyleBackColor = true;
            aceiteButton.Click += aceiteButton_Click;
            // 
            // balanceoButton
            // 
            balanceoButton.Cursor = Cursors.Hand;
            balanceoButton.Dock = DockStyle.Bottom;
            balanceoButton.Location = new Point(0, 65);
            balanceoButton.Name = "balanceoButton";
            balanceoButton.Size = new Size(187, 50);
            balanceoButton.TabIndex = 0;
            balanceoButton.Text = "Balanceo";
            balanceoButton.UseVisualStyleBackColor = true;
            balanceoButton.Click += balanceoButton_Click;
            // 
            // IngresarServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(187, 315);
            Controls.Add(balanceoButton);
            Controls.Add(aceiteButton);
            Controls.Add(aspiradoButton);
            Controls.Add(lavadoButton);
            Controls.Add(label1);
            Controls.Add(secadoButton);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "IngresarServicio";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ingresar servicio";
            Load += IngresarServicio_Load;
            KeyDown += IngresarServicio_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private Button secadoButton;
        private Label label1;
        private Button lavadoButton;
        private Button aspiradoButton;
        private Button aceiteButton;
        private Button balanceoButton;
    }
}