using Autolavado_GeorgesChakour.Clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Proyecto_Autolavado_Georges;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

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
        foreach(TextBox text in pan.Controls.OfType<TextBox>())
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

    public static void GuardarDatos(List<Cliente> clientes)
    {
        JArray array = new JArray();
        JObject aux = new();
        foreach (Cliente cliente in clientes)
        {
            aux = new JObject(new JProperty("Nombre", cliente.Name.Nombre),
                              new JProperty("Apellido", cliente.Name.Apellido),
                              new JProperty("Cedula", cliente.Cedula),
                              new JProperty("Modelo", cliente.Carro.Modelo),
                              new JProperty("Placa", cliente.Carro.Placa),
                              new JProperty("Tipo", cliente.Carro.Tipo),
                              new JProperty("ID", cliente.Id));
            array.Add(aux);
        }

        using (StreamWriter file = new StreamWriter(DataDirectory))
        using (JsonTextWriter writer = new JsonTextWriter(file))
        {
            array.WriteTo(writer);
        }
    }

    public static List<Cliente> LeerDatos()
    {
        List<Cliente> lista = new();
        
        Datos dat;
        Vehiculo carr;
        string cedula;
        uint id;
        Cliente client;

        if (File.Exists(DataDirectory))
        {
            string jsonData = File.ReadAllText(DataDirectory);
            JArray jData = new JArray(JArray.Parse(jsonData));
            int i = 0;

            foreach (JToken item in jData)
            {
                dat = new Datos()
                {
                    Nombre = item["Nombre"].ToString(),
                    Apellido = item["Apellido"].ToString()
                };
                carr = new Vehiculo()
                {
                    Modelo = item["Modelo"].ToString(),
                    Placa = item["Placa"].ToString(),
                    Tipo = item["Tipo"].ToString()
                };
                cedula = item["Cedula"].ToString() ;
                id = (uint)item["ID"];

                client = new(id, cedula, dat, carr);
                lista.Add(client);
            }            
            
        }
        return lista;
    }
}