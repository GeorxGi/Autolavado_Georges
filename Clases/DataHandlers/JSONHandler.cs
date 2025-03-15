using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Proyecto_Autolavado_Georges.Clases.DataClasses;
using Proyecto_Autolavado_Georges.Clases.UI;
using Proyecto_Autolavado_Georges.Clases.UserClasses;
using System.Diagnostics;

namespace Proyecto_Autolavado_Georges.Clases.DataHandlers
{
    internal class JSONHandler
    {
        private const string ClientDataDirectory = "Data\\ClientesRegistrados.json";
        private const string OldClientDataDirectory = "Clientes.json";

        private const string PriceDataDirectory = "Data\\PrecioServicios.json";
        private const string menuSettingsDirectory = "config\\UISettings.json";

        private static void WriteJson(string fileDirectory, JObject storeData)
        {
            using StreamWriter file = new(fileDirectory);
            using JsonTextWriter writer = new(file);
            writer.Formatting = Formatting.Indented;
            storeData.WriteTo(writer);
        }
        private static void WriteJson(string fileDirectory, JArray storeData)
        {
            using StreamWriter file = new(fileDirectory);
            using JsonTextWriter writer = new(file);
            writer.Formatting = Formatting.Indented;
            storeData.WriteTo(writer);
        }

        public static void AlmacenarPrecioServicios()
        {
            JObject VehiculosJarr = []; //Arreglo de tipos de vehiculos
            foreach (TipoDeVehiculo veh in Enum.GetValues(typeof(TipoDeVehiculo)))
            {
                JArray ServiciosJarr = []; //Arreglo de servicios disponibles
                foreach (Services servicio in Enum.GetValues(typeof(Services)))
                {
                    //Añade el nombre del servicio y su precio
                    ServiciosJarr.Add(new JObject(new JProperty(servicio.ToString(),
                                                                ServiceManager.GetServicePrice(servicio, veh)
                                                               )
                                                 )
                                     );
                }
                VehiculosJarr.Add(new JProperty(veh.ToString(), ServiciosJarr));
            }

            WriteJson(PriceDataDirectory, VehiculosJarr);
        }
        public static void CargarPrecioServicios()
        {
            if (!File.Exists(PriceDataDirectory))
            {
                ServiceManager.SetDefaultPrices();
            }
            else
            {
                string jsonData = File.ReadAllText(PriceDataDirectory);
                JToken dataArray = JToken.Parse(jsonData);
                foreach (JProperty VehiculosProperty in dataArray.Cast<JProperty>())
                {
                    if (VehiculosProperty.Value is JArray ServiciosArray)
                    {
                        foreach (JObject ServicioObject in ServiciosArray.Cast<JObject>())
                        {
                            foreach (JProperty servicioProperty in ServicioObject.Cast<JProperty>())
                            {
                                try
                                {
                                    if (!Enum.TryParse(servicioProperty.Name, out Services serv))
                                    {
                                        throw new ArgumentNullException("Error en la lectura del servicio");
                                    }

                                    if (!Enum.TryParse(VehiculosProperty.Name, out TipoDeVehiculo veh))
                                    {
                                        throw new ArgumentNullException("Error en la lectura del tipo de vehiculo");
                                    }
                                    ServiceManager.SetServicePrice(serv, veh, (decimal)servicioProperty.Value);
                                }
                                catch (ArgumentNullException e)
                                {
                                    Debug.WriteLine(e.Message);
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void ModificarDirectorioAntiguoClientes()
        {
            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }

            if (File.Exists(OldClientDataDirectory))
            {
                File.Move(OldClientDataDirectory, ClientDataDirectory);
            }
        }

        public static ClientList CargarListaClientes()
        {
            ModificarDirectorioAntiguoClientes();
            ClientList lista = new();

            Cliente client;

            if (File.Exists(ClientDataDirectory))
            {
                string jsonData = File.ReadAllText(ClientDataDirectory);
                JArray jData = new(JArray.Parse(jsonData));

                foreach (JToken item in jData)
                {
                    client = new();
                    client.DeserializeFromJson(item);
                    lista.Add(client);
                }

            }
            return lista;
        }

        public static void AlmacenarListaClientes(ClientList clientes)
        {
            JArray array = [];
            JObject aux = [];
            foreach (Cliente cliente in clientes)
            {
                aux = cliente.SerializeToJson();
                array.Add(aux);
            }

            WriteJson(ClientDataDirectory, array);
        }

        public static void StoreUISettings()
        {
            JObject storeSettings = AppSettings.SerializeToJson();

            if(!Directory.Exists("config"))
            {
                Directory.CreateDirectory("config");
            }
            WriteJson(menuSettingsDirectory, storeSettings);
        }

        public static void LoadUISettings()
        {
            if (!File.Exists(menuSettingsDirectory)) return;

            string jsonData = File.ReadAllText(menuSettingsDirectory);
            JToken settings = JToken.Parse(jsonData);
            AppSettings.DeserializeFromJson(settings);
        }
    }
}