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
            AcceptRoundButton = new Proyecto_Autolavado_Georges.Clases.CustomFormControls.RoundButton();
            CancelRoundButton = new Proyecto_Autolavado_Georges.Clases.CustomFormControls.RoundButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            // AcceptRoundButton
            // 
            AcceptRoundButton.BackColor = Color.Brown;
            AcceptRoundButton.BorderColor = SystemColors.ActiveCaption;
            AcceptRoundButton.BorderRadius = 10;
            AcceptRoundButton.BorderSize = 0;
            AcceptRoundButton.Cursor = Cursors.Hand;
            AcceptRoundButton.FlatStyle = FlatStyle.Flat;
            AcceptRoundButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AcceptRoundButton.ForeColor = Color.White;
            AcceptRoundButton.IsFilledButton = true;
            AcceptRoundButton.Location = new Point(12, 132);
            AcceptRoundButton.Name = "AcceptRoundButton";
            AcceptRoundButton.Size = new Size(110, 40);
            AcceptRoundButton.TabIndex = 1;
            AcceptRoundButton.Tag = "";
            AcceptRoundButton.Text = "Aceptar";
            AcceptRoundButton.UseVisualStyleBackColor = false;
            AcceptRoundButton.Click += AcceptButton_Click;
            // 
            // CancelRoundButton
            // 
            CancelRoundButton.BackColor = SystemColors.Control;
            CancelRoundButton.BorderColor = Color.Brown;
            CancelRoundButton.BorderRadius = 10;
            CancelRoundButton.BorderSize = 2;
            CancelRoundButton.Cursor = Cursors.Hand;
            CancelRoundButton.FlatStyle = FlatStyle.Flat;
            CancelRoundButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelRoundButton.ForeColor = Color.Brown;
            CancelRoundButton.IsFilledButton = false;
            CancelRoundButton.Location = new Point(208, 132);
            CancelRoundButton.Name = "CancelRoundButton";
            CancelRoundButton.Size = new Size(110, 40);
            CancelRoundButton.TabIndex = 2;
            CancelRoundButton.Tag = "";
            CancelRoundButton.Text = "Cancelar";
            CancelRoundButton.UseVisualStyleBackColor = false;
            CancelRoundButton.Click += CancelRoundButton_Click;
            // 
            // SeleccionarVehiculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 177);
            Controls.Add(CancelRoundButton);
            Controls.Add(AcceptRoundButton);
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
        private Button AcceptRegisterButton;
        private Clases.CustomFormControls.RoundButton AcceptRoundButton;
        private Clases.CustomFormControls.RoundButton CancelRoundButton;
    }
}