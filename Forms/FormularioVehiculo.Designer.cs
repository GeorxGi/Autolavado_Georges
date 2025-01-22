namespace Proyecto_Autolavado_Georges.Formularios
{
    partial class FormularioVehiculo
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
            label4 = new Label();
            label5 = new Label();
            ModeloTextBox = new TextBox();
            label6 = new Label();
            PlacaTextBox = new TextBox();
            CleanRegisterButton = new Button();
            AcceptRegisterButton = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            autoRadioButton = new RadioButton();
            camionetaRadioButton = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(306, 43);
            label1.TabIndex = 2;
            label1.Text = "Ingrese los datos del vehiculo";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Location = new Point(35, 52);
            label4.Name = "label4";
            label4.Size = new Size(262, 15);
            label4.TabIndex = 1;
            label4.Text = "Tipo";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Location = new Point(35, 148);
            label5.Name = "label5";
            label5.Size = new Size(262, 15);
            label5.TabIndex = 1;
            label5.Text = "Modelo";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ModeloTextBox
            // 
            ModeloTextBox.Location = new Point(35, 166);
            ModeloTextBox.MaxLength = 20;
            ModeloTextBox.Name = "ModeloTextBox";
            ModeloTextBox.PlaceholderText = "Modelo";
            ModeloTextBox.Size = new Size(262, 23);
            ModeloTextBox.TabIndex = 2;
            // 
            // label6
            // 
            label6.Location = new Point(35, 199);
            label6.Name = "label6";
            label6.Size = new Size(262, 15);
            label6.TabIndex = 1;
            label6.Text = "Placa";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PlacaTextBox
            // 
            PlacaTextBox.Location = new Point(35, 217);
            PlacaTextBox.MaxLength = 7;
            PlacaTextBox.Name = "PlacaTextBox";
            PlacaTextBox.PlaceholderText = "Placa";
            PlacaTextBox.Size = new Size(262, 23);
            PlacaTextBox.TabIndex = 3;
            PlacaTextBox.KeyPress += PlacaTextBox_KeyPress;
            // 
            // CleanRegisterButton
            // 
            CleanRegisterButton.BackColor = Color.Crimson;
            CleanRegisterButton.Cursor = Cursors.Hand;
            CleanRegisterButton.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CleanRegisterButton.ForeColor = SystemColors.Control;
            CleanRegisterButton.Location = new Point(208, 260);
            CleanRegisterButton.Name = "CleanRegisterButton";
            CleanRegisterButton.Size = new Size(110, 35);
            CleanRegisterButton.TabIndex = 5;
            CleanRegisterButton.Text = "Cancelar";
            CleanRegisterButton.UseVisualStyleBackColor = false;
            CleanRegisterButton.Click += CleanRegisterButton_Click;
            // 
            // AcceptRegisterButton
            // 
            AcceptRegisterButton.BackColor = Color.PaleGreen;
            AcceptRegisterButton.Cursor = Cursors.Hand;
            AcceptRegisterButton.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AcceptRegisterButton.Location = new Point(12, 260);
            AcceptRegisterButton.Name = "AcceptRegisterButton";
            AcceptRegisterButton.Size = new Size(110, 35);
            AcceptRegisterButton.TabIndex = 4;
            AcceptRegisterButton.Text = "Aceptar";
            AcceptRegisterButton.UseCompatibleTextRendering = true;
            AcceptRegisterButton.UseVisualStyleBackColor = false;
            AcceptRegisterButton.Click += AcceptRegisterButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.camioneta_icon;
            pictureBox1.Location = new Point(227, 95);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(70, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.carro_icon;
            pictureBox2.Location = new Point(35, 95);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(58, 48);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // autoRadioButton
            // 
            autoRadioButton.AutoSize = true;
            autoRadioButton.Checked = true;
            autoRadioButton.Cursor = Cursors.Hand;
            autoRadioButton.Location = new Point(35, 70);
            autoRadioButton.Name = "autoRadioButton";
            autoRadioButton.Size = new Size(51, 19);
            autoRadioButton.TabIndex = 0;
            autoRadioButton.TabStop = true;
            autoRadioButton.Text = "Auto";
            autoRadioButton.UseVisualStyleBackColor = true;
            // 
            // camionetaRadioButton
            // 
            camionetaRadioButton.AutoSize = true;
            camionetaRadioButton.Cursor = Cursors.Hand;
            camionetaRadioButton.Location = new Point(214, 70);
            camionetaRadioButton.Name = "camionetaRadioButton";
            camionetaRadioButton.Size = new Size(83, 19);
            camionetaRadioButton.TabIndex = 1;
            camionetaRadioButton.Text = "Camioneta";
            camionetaRadioButton.UseVisualStyleBackColor = true;
            // 
            // FormularioVehiculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 307);
            Controls.Add(camionetaRadioButton);
            Controls.Add(autoRadioButton);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(CleanRegisterButton);
            Controls.Add(AcceptRegisterButton);
            Controls.Add(PlacaTextBox);
            Controls.Add(label6);
            Controls.Add(ModeloTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormularioVehiculo";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Vehiculo";
            KeyDown += FormularioVehiculo_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label4;
        private Label label5;
        private TextBox ModeloTextBox;
        private Label label6;
        private TextBox PlacaTextBox;
        private Button CleanRegisterButton;
        private Button AcceptRegisterButton;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private RadioButton autoRadioButton;
        private RadioButton camionetaRadioButton;
    }
}