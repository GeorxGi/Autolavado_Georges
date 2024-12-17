namespace Proyecto_Autolavado_Georges.Formularios
{
    partial class SeleccionarVehiculo
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
            label1 = new Label();
            tipoCarrocomboBox = new ComboBox();
            label4 = new Label();
            CleanRegisterButton = new Button();
            AcceptRegisterButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(306, 43);
            label1.TabIndex = 2;
            label1.Text = "Seleccione un vehiculo";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tipoCarrocomboBox
            // 
            tipoCarrocomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            tipoCarrocomboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tipoCarrocomboBox.FormattingEnabled = true;
            tipoCarrocomboBox.Location = new Point(35, 82);
            tipoCarrocomboBox.Name = "tipoCarrocomboBox";
            tipoCarrocomboBox.Size = new Size(262, 29);
            tipoCarrocomboBox.TabIndex = 0;
            tipoCarrocomboBox.KeyDown += tipoCarrocomboBox_KeyDown;
            // 
            // label4
            // 
            label4.Location = new Point(35, 64);
            label4.Name = "label4";
            label4.Size = new Size(262, 15);
            label4.TabIndex = 1;
            label4.Text = "Vehículo:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CleanRegisterButton
            // 
            CleanRegisterButton.BackColor = Color.Crimson;
            CleanRegisterButton.Cursor = Cursors.Hand;
            CleanRegisterButton.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CleanRegisterButton.ForeColor = SystemColors.Control;
            CleanRegisterButton.Location = new Point(208, 135);
            CleanRegisterButton.Name = "CleanRegisterButton";
            CleanRegisterButton.Size = new Size(110, 35);
            CleanRegisterButton.TabIndex = 4;
            CleanRegisterButton.Text = "Cancelar";
            CleanRegisterButton.UseVisualStyleBackColor = false;
            CleanRegisterButton.Click += CleanRegisterButton_Click;
            // 
            // AcceptRegisterButton
            // 
            AcceptRegisterButton.BackColor = Color.PaleGreen;
            AcceptRegisterButton.Cursor = Cursors.Hand;
            AcceptRegisterButton.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AcceptRegisterButton.Location = new Point(12, 135);
            AcceptRegisterButton.Name = "AcceptRegisterButton";
            AcceptRegisterButton.Size = new Size(110, 35);
            AcceptRegisterButton.TabIndex = 3;
            AcceptRegisterButton.Text = "Aceptar";
            AcceptRegisterButton.UseCompatibleTextRendering = true;
            AcceptRegisterButton.UseVisualStyleBackColor = false;
            AcceptRegisterButton.Click += AcceptRegisterButton_Click;
            // 
            // SeleccionarVehiculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 177);
            Controls.Add(CleanRegisterButton);
            Controls.Add(AcceptRegisterButton);
            Controls.Add(tipoCarrocomboBox);
            Controls.Add(label4);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SeleccionarVehiculo";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Vehiculo";
            Load += FormularioVehiculo_Load;
            KeyDown += SeleccionarVehiculo_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox tipoCarrocomboBox;
        private Label label4;
        private Button CleanRegisterButton;
        private Button AcceptRegisterButton;
    }
}