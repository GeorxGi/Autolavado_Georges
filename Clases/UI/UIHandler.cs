namespace Proyecto_Autolavado_Georges.Clases.UI
{
    public static class UIHandler
    {
        /// <summary>
        /// Recibe un panel y limpia todos los textbox que este contenga de forma recursiva
        /// </summary>
        /// <param name="pan">Panel a limpiar</param>
        public static void CleanAllTextBox(Panel pan)
        {
            foreach (Panel control in pan.Controls.OfType<Panel>())
            {
                CleanAllTextBox(control);
            }
            foreach (TextBox text in pan.Controls.OfType<TextBox>())
            {
                text.Text = "";
            }
        }
        /// <summary>
        /// Recibe un formulario y limpia todos los textbox que este contenga de forma recursiva
        /// </summary>
        /// <param name="form">Formulario a limpiar</param>
        public static void CleanAllTextBox(Form form)
        {
            foreach (Panel control in form.Controls.OfType<Panel>())
            {
                CleanAllTextBox(control);
            }
            foreach (TextBox text in form.Controls.OfType<TextBox>())
            {
                text.Text = "";
            }
        }

        /// <summary>
        /// Recibe un panel y verifica que todos los textbox y combobox de este no se encuentren vacios
        /// </summary>
        /// <param name="pan">Panel en el que se buscarán los textbox</param>
        /// <returns>booleano que indica si todos los textbox estan o no vacios</returns>
        public static bool CheckAllTextBoxHaveData(Panel pan)
        {
            foreach (Panel control in pan.Controls.OfType<Panel>())
            {
                CheckAllTextBoxHaveData(control);
            }

            foreach (TextBox text in pan.Controls.OfType<TextBox>())
            {
                if (string.IsNullOrWhiteSpace(text.Text))
                {
                    return false;
                }
            }
            foreach (ComboBox combo in pan.Controls.OfType<ComboBox>())
            {
                if (string.IsNullOrWhiteSpace(combo.Text))
                {
                    return false;
                }
            }
            return true;
        }


        public static bool FormInputIsFilled(Form form)
        {
            foreach (Panel pan in form.Controls.OfType<Panel>())
            {
                if (!CheckAllTextBoxHaveData(pan)) return false;
            }
            foreach (TextBox control in form.Controls.OfType<TextBox>())
            {
                if (string.IsNullOrWhiteSpace(control.Text)) return false;
            }
            foreach (ComboBox combo in form.Controls.OfType<ComboBox>())
            {
                if (string.IsNullOrWhiteSpace(combo.Text)) return false;
            }
            return true;
        }


        /// <summary>
        /// Oculta todos los paneles del form (exceptuando el lateral) y muestra el panel indicado junto al titulo
        /// </summary>
        /// <param name="form">Formulario principal</param>
        /// <param name="panel">Panel que se mostrará</param>
        /// <param name="title">Titulo a colocar en el label principal</param>
        public static void ShowPanel(MainMenu form, Panel panel, string title)
        {
            foreach (Panel pan in form.Controls.OfType<Panel>())
            {
                if (pan != panel && pan != form.Optionpanel)
                {
                    CleanAllTextBox(pan);
                    pan.Enabled = false;
                    pan.Visible = false;
                }
            }
            panel.Visible = true;
            panel.Enabled = true;
            form.mainLabel.Text = title;
        }

        /// <summary>
        /// Excepción de keyPress en textbox que solo permite ingresar texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnlyLetters(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Excepción de keyPress en textbox que solo permite ingresar numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Excepción de keyPress en textbox que solo permite ingresar numeros y comas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnlyNumbersWithDecimal(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '.') e.KeyChar = ',';
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Excepción de KeyPress en textbox que convierte las teclas en mayusculas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnlyMayus(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        public static void CloseWithEscape(KeyEventArgs e, Form form)
        {
            if (e.KeyCode == Keys.Escape)
            {
                form.Close();
            }
        }
    }
}