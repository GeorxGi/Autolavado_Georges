using System.IO;
using System.Net.Http;
using System.Windows;
using Newtonsoft.Json.Linq;

public static class TasaCambio
{
    private static double Bcv;
    /// <summary>
    /// Tasa cambiaria que debio ser previamente cargada
    /// </summary>
    /// <returns>Tasa del dolar cargada en memoria</returns>
    public static double TasaDolar()
    {
        if (File.Exists(DataDirectory))
        {
            return Bcv;
        }
        else
        {
            return 0;
        }
    }
    /// <summary>
    /// Establece la tasa cambiaria que manejara la aplicacion
    /// </summary>
    /// <param name="tasa">Tasa cambiaria a operar</param>
    private static void TasaDolar(double tasa)
    {
        Bcv = tasa;
    }
    private static readonly string DataDirectory = "tasas.json";

    /// <summary>
    /// Comprueba que no hayan más de 12 horas entre la fecha ingresada y la fecha del sistema
    /// </summary>
    /// <param name="lastUpdate">Fecha a comparar</param>
    /// <returns>Un booleano que indica si han pasado 12 horas</returns>
    public static bool Pasaron12Horas(DateTime lastUpdate)
    {
        TimeSpan Diff = DateTime.Now - lastUpdate;
        return Diff.TotalHours > 12;
    }

    /// <summary>
    /// Carga los datos de la tasa cambiaria a partir de una API y la almacena en memoria
    /// </summary>
    public static void LoadData()
    {
        //Comprueba que el archivo exista
        if (!File.Exists(DataDirectory))
        {
            CargarJSON();
        }
        else
        {
            JObject jsonData = JObject.Parse(File.ReadAllText(DataDirectory));
            //Intenta realizar el parseo de los datos del JSON
            if (!DateTime.TryParse(Convert.ToString(jsonData["last_update"]), out DateTime LastUpdate))
            {
                MessageBox.Show("Hubo un error en la lectura del archivo JSON", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Comprueba que no hayan pasado 12 horas desde la última actualización de tasas
                if (!Pasaron12Horas(LastUpdate))
                {
                    double dollar = Convert.ToDouble(jsonData["price"]);
                    TasaDolar(dollar);
                }
                else
                {
                    CargarJSON();
                }
            }
        }
    }

    private static void CargarJSON()
    {
        try
        {
            HttpClient client = new() { BaseAddress = new Uri("https://pydolarve.org//api/v1/dollar?monitor=bcv") };

            var value = client.GetAsync(client.BaseAddress).Result;
            //Comprueba si la solicitud GET fue exitosa
            if (value.IsSuccessStatusCode)
            {
                dynamic ApiResponse = value.Content.ReadAsStringAsync().Result;
                File.WriteAllTextAsync(DataDirectory, ApiResponse);
                MessageBox.Show("Tasas actualizadas correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                double dollar = JObject.Parse(ApiResponse)["price"];
                TasaDolar(dollar);
            }
            else
            {
                TasaDolar(44.75);
                MessageBox.Show("Hubo un error accediendo a la API, se cargará una tasa genérica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            TasaDolar(44.75);
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
