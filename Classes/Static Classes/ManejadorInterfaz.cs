using Autolavado_GeorgesChakour.Clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Proyecto_Autolavado_Georges;
using System.Security.Cryptography.X509Certificates;

public static class Interfaz
{
    private static string DataDirectory = "Clientes.json";
    public static void LimpiarTextBox(Panel pan)
    {
        foreach (Panel control in pan.Controls.OfType<Panel>())
        {
            foreach (TextBox text in control.Controls.OfType<TextBox>())
            {
                text.Text = "";
            }
        }
        foreach (TextBox text in pan.Controls.OfType<TextBox>())
        {
            text.Text = "";
        }
    }
    public static void LimpiarTextBox(Form form)
    {
        foreach(Panel control in form.Controls.OfType<Panel>())
        {
            LimpiarTextBox(control);
        }
        foreach(TextBox text in form.Controls.OfType<TextBox>())
        {
            text.Text = "";
        }
    }

    /// <summary>
    /// Recibe un panel y verifica que todos los textbox de este no se encuentren vacios
    /// </summary>
    /// <param name="pan">Panel en el que se buscarán los textbox</param>
    /// <returns>booleano que indica si todos los textbox estan o no vacios</returns>
    public static bool DatosColocados(Panel pan)
    {
        foreach(Panel control in pan.Controls.OfType<Panel>())
        {
            foreach(TextBox text in control.Controls.OfType<TextBox>())
            {
                if(string.IsNullOrWhiteSpace(text.Text))
                {
                    return false;
                }
            }
            foreach(ComboBox combo in pan.Controls.OfType<ComboBox>())
            {
                if(string.IsNullOrWhiteSpace(combo.Text))
                {
                    return false;
                }
            }
        }
        foreach(TextBox text in pan.Controls.OfType<TextBox>())
        {
            if(string.IsNullOrWhiteSpace(text.Text))
            {
                return false;
            }
        }
        return true;
    }

    public static bool DatosColocados(Form form)
    {
        foreach(TextBox control in form.Controls.OfType<TextBox>())
        {
            if (string.IsNullOrWhiteSpace(control.Text)) return false;
        }
        foreach(ComboBox combo in form.Controls.OfType<ComboBox>())
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
    public static void MostrarPanel(Form1 form, Panel panel, string title)
    {
        foreach (Panel pan in form.Controls.OfType<Panel>())
        {
            if (pan != panel && pan != form.Optionpanel)
            {
                Interfaz.LimpiarTextBox(pan);
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
        if (Char.IsDigit(e.KeyChar))
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
        if (!Char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
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
        e.KeyChar = Char.ToUpper(e.KeyChar);
    }

    public static void GuardarDatos(Lista<Cliente> clientes)
    {
        JArray array = [];
        JObject aux = [];
        foreach (Cliente cliente in clientes)
        {
            aux = cliente.SerializeToJson();
            array.Add(aux);
        }
        
        using (StreamWriter file = new StreamWriter(DataDirectory))
        using (JsonTextWriter writer = new JsonTextWriter(file))
        {
            array.WriteTo(writer);
        }
    }

    public static Lista<Cliente> LeerDatos()
    {
        Lista<Cliente> lista = new();

        Cliente client;

        if (File.Exists(DataDirectory))
        {
            string jsonData = File.ReadAllText(DataDirectory);
            JArray jData = new (JArray.Parse(jsonData));

            foreach (JToken item in jData)
            {
                client = new();
                client.DeserializeFromJson(item);
                lista.Insertar(client);
            }            
            
        }
        return lista;
    }
}