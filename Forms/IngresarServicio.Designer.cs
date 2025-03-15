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
            label1 = new Label();
            SecadoRoundButton = new Proyecto_Autolavado_Georges.Clases.CustomFormControls.RoundButton();
            LavadoRoundButton = new Proyecto_Autolavado_Georges.Clases.CustomFormControls.RoundButton();
            AspiradoRoundButton = new Proyecto_Autolavado_Georges.Clases.CustomFormControls.RoundButton();
            CambioAceiteRoundButton = new Proyecto_Autolavado_Georges.Clases.CustomFormControls.RoundButton();
            BalanceoRoundButton = new Proyecto_Autolavado_Georges.Clases.CustomFormControls.RoundButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(2, 4);
            label1.Name = "label1";
            label1.Size = new Size(185, 53);
            label1.TabIndex = 2;
            label1.Text = "Seleccione un servicio";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SecadoRoundButton
            // 
            SecadoRoundButton.BackColor = SystemColors.Control;
            SecadoRoundButton.BorderColor = Color.Brown;
            SecadoRoundButton.BorderRadius = 10;
            SecadoRoundButton.BorderSize = 2;
            SecadoRoundButton.Cursor = Cursors.Hand;
            SecadoRoundButton.Dock = DockStyle.Bottom;
            SecadoRoundButton.FlatStyle = FlatStyle.Flat;
            SecadoRoundButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SecadoRoundButton.ForeColor = Color.Brown;
            SecadoRoundButton.IsFilledButton = false;
            SecadoRoundButton.Location = new Point(0, 264);
            SecadoRoundButton.Name = "SecadoRoundButton";
            SecadoRoundButton.Size = new Size(187, 51);
            SecadoRoundButton.TabIndex = 4;
            SecadoRoundButton.Tag = "";
            SecadoRoundButton.Text = "Secado";
            SecadoRoundButton.UseVisualStyleBackColor = false;
            SecadoRoundButton.Click += secadoButton_Click;
            SecadoRoundButton.KeyDown += IngresarServicio_KeyDown;
            // 
            // LavadoRoundButton
            // 
            LavadoRoundButton.BackColor = SystemColors.Control;
            LavadoRoundButton.BorderColor = Color.Brown;
            LavadoRoundButton.BorderRadius = 10;
            LavadoRoundButton.BorderSize = 2;
            LavadoRoundButton.Cursor = Cursors.Hand;
            LavadoRoundButton.Dock = DockStyle.Bottom;
            LavadoRoundButton.FlatStyle = FlatStyle.Flat;
            LavadoRoundButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LavadoRoundButton.ForeColor = Color.Brown;
            LavadoRoundButton.IsFilledButton = false;
            LavadoRoundButton.Location = new Point(0, 213);
            LavadoRoundButton.Name = "LavadoRoundButton";
            LavadoRoundButton.Size = new Size(187, 51);
            LavadoRoundButton.TabIndex = 3;
            LavadoRoundButton.Tag = "";
            LavadoRoundButton.Text = "Lavado";
            LavadoRoundButton.UseVisualStyleBackColor = false;
            LavadoRoundButton.Click += lavadoButton_Click;
            LavadoRoundButton.KeyDown += IngresarServicio_KeyDown;
            // 
            // AspiradoRoundButton
            // 
            AspiradoRoundButton.BackColor = SystemColors.Control;
            AspiradoRoundButton.BorderColor = Color.Brown;
            AspiradoRoundButton.BorderRadius = 10;
            AspiradoRoundButton.BorderSize = 2;
            AspiradoRoundButton.Cursor = Cursors.Hand;
            AspiradoRoundButton.Dock = DockStyle.Bottom;
            AspiradoRoundButton.FlatStyle = FlatStyle.Flat;
            AspiradoRoundButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AspiradoRoundButton.ForeColor = Color.Brown;
            AspiradoRoundButton.IsFilledButton = false;
            AspiradoRoundButton.Location = new Point(0, 162);
            AspiradoRoundButton.Name = "AspiradoRoundButton";
            AspiradoRoundButton.Size = new Size(187, 51);
            AspiradoRoundButton.TabIndex = 2;
            AspiradoRoundButton.Tag = "";
            AspiradoRoundButton.Text = "Aspirado";
            AspiradoRoundButton.UseVisualStyleBackColor = false;
            AspiradoRoundButton.Click += aspiradoButton_Click;
            AspiradoRoundButton.KeyDown += IngresarServicio_KeyDown;
            // 
            // CambioAceiteRoundButton
            // 
            CambioAceiteRoundButton.BackColor = SystemColors.Control;
            CambioAceiteRoundButton.BorderColor = Color.Brown;
            CambioAceiteRoundButton.BorderRadius = 10;
            CambioAceiteRoundButton.BorderSize = 2;
            CambioAceiteRoundButton.Cursor = Cursors.Hand;
            CambioAceiteRoundButton.Dock = DockStyle.Bottom;
            CambioAceiteRoundButton.FlatStyle = FlatStyle.Flat;
            CambioAceiteRoundButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CambioAceiteRoundButton.ForeColor = Color.Brown;
            CambioAceiteRoundButton.IsFilledButton = false;
            CambioAceiteRoundButton.Location = new Point(0, 111);
            CambioAceiteRoundButton.Name = "CambioAceiteRoundButton";
            CambioAceiteRoundButton.Size = new Size(187, 51);
            CambioAceiteRoundButton.TabIndex = 1;
            CambioAceiteRoundButton.Tag = "";
            CambioAceiteRoundButton.Text = "Cambio de aceite";
            CambioAceiteRoundButton.UseVisualStyleBackColor = false;
            CambioAceiteRoundButton.Click += aceiteButton_Click;
            CambioAceiteRoundButton.KeyDown += IngresarServicio_KeyDown;
            // 
            // BalanceoRoundButton
            // 
            BalanceoRoundButton.BackColor = SystemColors.Control;
            BalanceoRoundButton.BorderColor = Color.Brown;
            BalanceoRoundButton.BorderRadius = 10;
            BalanceoRoundButton.BorderSize = 2;
            BalanceoRoundButton.Cursor = Cursors.Hand;
            BalanceoRoundButton.Dock = DockStyle.Bottom;
            BalanceoRoundButton.FlatStyle = FlatStyle.Flat;
            BalanceoRoundButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BalanceoRoundButton.ForeColor = Color.Brown;
            BalanceoRoundButton.IsFilledButton = false;
            BalanceoRoundButton.Location = new Point(0, 60);
            BalanceoRoundButton.Name = "BalanceoRoundButton";
            BalanceoRoundButton.Size = new Size(187, 51);
            BalanceoRoundButton.TabIndex = 0;
            BalanceoRoundButton.Tag = "";
            BalanceoRoundButton.Text = "Balanceo";
            BalanceoRoundButton.UseVisualStyleBackColor = false;
            BalanceoRoundButton.Click += balanceoButton_Click;
            BalanceoRoundButton.KeyDown += IngresarServicio_KeyDown;
            // 
            // IngresarServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(187, 315);
            Controls.Add(BalanceoRoundButton);
            Controls.Add(CambioAceiteRoundButton);
            Controls.Add(AspiradoRoundButton);
            Controls.Add(LavadoRoundButton);
            Controls.Add(SecadoRoundButton);
            Controls.Add(label1);
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
        private Label label1;
        private Button lavadoButton;
        private Button aspiradoButton;
        private Button aceiteButton;
        private Clases.CustomFormControls.RoundButton SecadoRoundButton;
        private Clases.CustomFormControls.RoundButton LavadoRoundButton;
        private Clases.CustomFormControls.RoundButton CambioAceiteRoundButton;
        private Clases.CustomFormControls.RoundButton BalanceoRoundButton;
        private Clases.CustomFormControls.RoundButton AspiradoRoundButton;
    }
}