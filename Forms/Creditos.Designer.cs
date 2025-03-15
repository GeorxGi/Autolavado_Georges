namespace Proyecto_Autolavado_Georges.Formularios
{
    partial class Creditos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Creditos));
            label1 = new Label();
            roundButton1 = new Proyecto_Autolavado_Georges.Clases.CustomFormControls.RoundButton();
            GitHubRoundButton = new Proyecto_Autolavado_Georges.Clases.CustomFormControls.RoundButton();
            RjCodeAdvanceRoundButton = new Proyecto_Autolavado_Georges.Clases.CustomFormControls.RoundButton();
            Icon8roundButton = new Proyecto_Autolavado_Georges.Clases.CustomFormControls.RoundButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(356, 31);
            label1.TabIndex = 1;
            label1.Tag = "mainLabel";
            label1.Text = "Enlaces de interés";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // roundButton1
            // 
            roundButton1.BackColor = Color.Blue;
            roundButton1.BorderColor = Color.Blue;
            roundButton1.BorderRadius = 8;
            roundButton1.BorderSize = 0;
            roundButton1.FlatAppearance.BorderSize = 0;
            roundButton1.FlatStyle = FlatStyle.Flat;
            roundButton1.ForeColor = SystemColors.Control;
            roundButton1.IsFilledButton = true;
            roundButton1.Location = new Point(382, 63);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(8, 8);
            roundButton1.TabIndex = 5;
            roundButton1.Text = "roundButton1";
            roundButton1.UseVisualStyleBackColor = false;
            // 
            // GitHubRoundButton
            // 
            GitHubRoundButton.BackColor = Color.Brown;
            GitHubRoundButton.BorderColor = SystemColors.ActiveCaption;
            GitHubRoundButton.BorderRadius = 10;
            GitHubRoundButton.BorderSize = 0;
            GitHubRoundButton.Cursor = Cursors.Hand;
            GitHubRoundButton.FlatStyle = FlatStyle.Flat;
            GitHubRoundButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GitHubRoundButton.ForeColor = Color.White;
            GitHubRoundButton.ImageAlign = ContentAlignment.MiddleLeft;
            GitHubRoundButton.IsFilledButton = true;
            GitHubRoundButton.Location = new Point(12, 59);
            GitHubRoundButton.Name = "GitHubRoundButton";
            GitHubRoundButton.Size = new Size(110, 40);
            GitHubRoundButton.TabIndex = 0;
            GitHubRoundButton.Tag = "";
            GitHubRoundButton.Text = "GitHub personal";
            GitHubRoundButton.UseVisualStyleBackColor = false;
            GitHubRoundButton.Click += GitHubRoundButton_Click;
            GitHubRoundButton.KeyDown += CloseWithEsc;
            // 
            // RjCodeAdvanceRoundButton
            // 
            RjCodeAdvanceRoundButton.BackColor = SystemColors.Control;
            RjCodeAdvanceRoundButton.BorderColor = Color.Brown;
            RjCodeAdvanceRoundButton.BorderRadius = 10;
            RjCodeAdvanceRoundButton.BorderSize = 2;
            RjCodeAdvanceRoundButton.Cursor = Cursors.Hand;
            RjCodeAdvanceRoundButton.FlatStyle = FlatStyle.Flat;
            RjCodeAdvanceRoundButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RjCodeAdvanceRoundButton.ForeColor = Color.Brown;
            RjCodeAdvanceRoundButton.IsFilledButton = false;
            RjCodeAdvanceRoundButton.Location = new Point(173, 59);
            RjCodeAdvanceRoundButton.Name = "RjCodeAdvanceRoundButton";
            RjCodeAdvanceRoundButton.Size = new Size(195, 40);
            RjCodeAdvanceRoundButton.TabIndex = 1;
            RjCodeAdvanceRoundButton.Tag = "";
            RjCodeAdvanceRoundButton.Text = "RjCodeAdvance (creador del estilo de los botones)";
            RjCodeAdvanceRoundButton.UseVisualStyleBackColor = false;
            RjCodeAdvanceRoundButton.Click += RjCodeAdvanceRoundButton_Click;
            RjCodeAdvanceRoundButton.KeyDown += CloseWithEsc;
            // 
            // Icon8roundButton
            // 
            Icon8roundButton.BackColor = SystemColors.Control;
            Icon8roundButton.BorderColor = Color.Brown;
            Icon8roundButton.BorderRadius = 10;
            Icon8roundButton.BorderSize = 2;
            Icon8roundButton.Cursor = Cursors.Hand;
            Icon8roundButton.FlatStyle = FlatStyle.Flat;
            Icon8roundButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon8roundButton.ForeColor = Color.Brown;
            Icon8roundButton.IsFilledButton = false;
            Icon8roundButton.Location = new Point(258, 105);
            Icon8roundButton.Name = "Icon8roundButton";
            Icon8roundButton.Size = new Size(110, 40);
            Icon8roundButton.TabIndex = 2;
            Icon8roundButton.Tag = "";
            Icon8roundButton.Text = "Icon8";
            Icon8roundButton.UseVisualStyleBackColor = false;
            Icon8roundButton.Click += Icon8roundButton_Click;
            Icon8roundButton.KeyDown += CloseWithEsc;
            // 
            // Creditos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 157);
            Controls.Add(Icon8roundButton);
            Controls.Add(RjCodeAdvanceRoundButton);
            Controls.Add(GitHubRoundButton);
            Controls.Add(roundButton1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Creditos";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Créditos";
            Load += Creditos_Load;
            KeyDown += CloseWithEsc;
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Clases.CustomFormControls.RoundButton roundButton1;
        private Clases.CustomFormControls.RoundButton GitHubRoundButton;
        private Clases.CustomFormControls.RoundButton RjCodeAdvanceRoundButton;
        private Clases.CustomFormControls.RoundButton Icon8roundButton;
    }
}