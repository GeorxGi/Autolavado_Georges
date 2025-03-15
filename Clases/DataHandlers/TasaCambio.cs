using Newtonsoft.Json.Linq;

namespace Proyecto_Autolavado_Georges.Clases.DataHandlers
{
    public static class TasaCambio
    {
        private const string DataDirectory = "Data\\tasaCambio.json";

        public static decimal TasaBcv { get; private set; }

        /// <summary>
        /// Comprueba que no hayan más de 12 horas entre la fecha ingresada y la fecha del sistema
        /// </summary>
        /// <param name="lastUpdate">Fecha a comparar</param>
        /// <returns>Un booleano que indica si han pasado 12 horas</returns>
        public static bool Pasaron12Horas(DateTime lastUpdate)
        {
            return (DateTime.Now - lastUpdate).TotalHours > 12;
        }

        /// <summary>
        /// Carga los datos de la tasa cambiaria a partir de una API y la almacena en memoria
        /// </summary>
        public static async Task LoadData()
        {
            //Si el archivo no existe
            if (!File.Exists(DataDirectory))
            {
                await CargarJSON();
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
                        decimal dollar = Convert.ToDecimal(jsonData["price"]);
                        TasaBcv = dollar;
                    }
                    else
                    {
                        await CargarJSON();
                    }
                }
            }
        }

        private static async Task CargarJSON()
        {
            try
            {
                HttpClient client = new() { BaseAddress = new Uri("https://pydolarve.org//api/v1/dollar?monitor=bcv") };

                HttpResponseMessage value = await client.GetAsync(client.BaseAddress);
                //Comprueba si la solicitud GET fue exitosa
                if (value.IsSuccessStatusCode)
                {
                    dynamic ApiResponse = value.Content.ReadAsStringAsync().Result;
                    File.WriteAllTextAsync(DataDirectory, ApiResponse);
                    MessageBox.Show("Tasas actualizadas correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    decimal dollar = JObject.Parse(ApiResponse)["price"];
                    TasaBcv = dollar;
                }
                else
                {
                    TasaBcv = 54.75M;
                    MessageBox.Show("Hubo un error accediendo a la API, se cargará una tasa genérica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                TasaBcv = 64.6M;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}