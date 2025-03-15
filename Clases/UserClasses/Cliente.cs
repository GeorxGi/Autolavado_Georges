using Newtonsoft.Json.Linq;
using Proyecto_Autolavado_Georges.Clases.DataClasses;
using Proyecto_Autolavado_Georges.Clases.DataHandlers;

public enum TipoDeVehiculo
{
    Auto,
    Camioneta
}

public struct Datos
{
    public string Nombre, Apellido;
}

namespace Proyecto_Autolavado_Georges.Clases.UserClasses
{
    public class Cliente
    {
        public Datos Name { get; private set; }
        public string Cedula { get; private set; }
        public CustomLinkedList<Vehiculo> VehiculosRegistrados { get; private set; }
        public uint Id { get; private set; }
        public bool Enabled { get; private set; }
        public decimal DeudaTotal { get; private set; }

        public decimal MontoPorCuota { get; private set; }
        public uint NumeroDeCuotas {  get; private set; }

        public CustomLinkedList<(Services, decimal)> ServiciosConsumidos { get; private set; }

        public Cliente()
        {
            Cedula = "";
            Id = 0;
            ServiciosConsumidos = null;
            VehiculosRegistrados = null;
        }
        /// <summary>
        /// Constructor de la clase cliente
        /// </summary>
        /// <param name="id">Identificador interno del cliente</param>
        /// <param name="cedula">Cedula de identidad del cliente</param>
        /// <param name="datos">Estructura que contiene el nombre y apellido del cliente</param>
        /// <param name="carros">Lista que contiene todos los carros que posee el cliente</param>
        public Cliente(uint id, string cedula, Datos datos, DataClasses.CustomLinkedList<Vehiculo> carros)
        {
            Id = id;
            Cedula = cedula;
            Name = datos;
            VehiculosRegistrados = carros;
            Enabled = true;
            ServiciosConsumidos = new();
        }

        /// <summary>
        /// Recibe datos del cliente e intenta modificar los ya cargados
        /// </summary>
        /// <param name="cedula">Cedula del cliente</param>
        /// <param name="datos">Estructura que contiene su nombre y apellido</param>
        /// <param name="carros">Lista que contiene los vehículos del cliente</param>
        /// <returns> que indica si la modificación se realizó o hubo algo que no lo permitiera</returns>
        public bool Modificar(string cedula, Datos datos)
        {
            foreach (Vehiculo veh in VehiculosRegistrados)
            {
                if (veh.ServicioUbicado.HasValue)
                {
                    return false;
                }
            }
            if(ServiciosConsumidos.Count == 0)
            {
                Cedula = cedula;
                Name = datos;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Comprueba si alguno de los vehiculos del cliente se encuentra en un servicio
        /// </summary>
        /// <returns>Booleano que indica si algún vehículo está en servicio</returns>
        public bool HayVehiculoEnServicio()
        {
            return VehiculosRegistrados.SearchElementByCondition(V => V.ServicioUbicado.HasValue) != null;
        }

        /// <summary>
        /// Procesa el servicio en el que se encuentre actualmente el vehiculo del cliente
        /// (Si el vehiculo ingresado no pertenece al cliente se genera una excepción)
        /// </summary>
        /// <param name="vehiculo">Vehiculo a procesar servicio</param>
        /// <exception cref="ArgumentException"></exception>
        public void ProcesarServicio(Vehiculo vehiculo)
        {
            //Valida que el vehiculo ingresado pertenezca al cliente
            Vehiculo VehiculoModificar = VehiculosRegistrados.SearchElementByCondition(V => V == vehiculo) ?? throw new ArgumentException("Vehiculo no pertenece al cliente");
            
            if(VehiculoModificar.ServicioUbicado.HasValue)
            {
                decimal precio = ServiceManager.GetServicePrice(VehiculoModificar.ServicioUbicado.Value, VehiculoModificar.Tipo);

                ServiciosConsumidos.AddLast((VehiculoModificar.ServicioUbicado.Value, precio));

                DeudaTotal += precio;

                NumeroDeCuotas = 1;

                VehiculoModificar.CancelarServicio();
            }
        }

        /// <summary>
        /// Limpia la lista que contiene las facturas del cliente
        /// </summary>
        public void LimpiarFactura()
        {
            DeudaTotal = 0;
            NumeroDeCuotas = 0;
            MontoPorCuota = 0;
            ServiciosConsumidos.CleanList();
        }

        public void DeshabilitarCliente()
        {
            Enabled = false;
        }

        public void HabilitarCliente()
        {
            Enabled = true;
        }

        /// <summary>
        /// Registra el numero de cuotas en las que deberá pagar el cliente, minimo 1 máximo 4
        /// </summary>
        /// <param name="cuota">numero de cuotas a pagar</param>
        /// <returns>booleano que indica si el numero de cuotas seleccionado es válido</returns>
        public bool RegistrarCuota(uint cuota)
        {
            if(cuota < 0 || cuota > 4)
            {
                return false;
            }
            else
            {
                NumeroDeCuotas = cuota;
                MontoPorCuota = DeudaTotal / NumeroDeCuotas;
                return true;
            }
        }

        public void PagarCuota()
        {
            if(NumeroDeCuotas > 0 && NumeroDeCuotas <= 4)
            {
                if(NumeroDeCuotas == 1 && MontoPorCuota == DeudaTotal)
                {
                    LimpiarFactura();
                    return;
                }
                NumeroDeCuotas--;
                DeudaTotal -= MontoPorCuota;
            }
        }

        /// <summary>
        /// Recibe la placa del vehículo y retorna el modelo del mismo
        /// </summary>
        /// <param name="placa">Placa del vehiculo a buscar en la lista del cliente</param>
        /// <returns>Enum que contiene el tipo de vehiculo de la placa ingresada, puede ser null</returns>
        public TipoDeVehiculo? TipoVehiculoPorPlaca(string placa)
        {
            Vehiculo? aux = VehiculosRegistrados.SearchElementByCondition(V => V.Placa == placa);
            if (aux != null)
            {
                return aux.Tipo;
            }
            return null;
        }

        /// <summary>
        /// Busca entre todos los vehiculos del cliente en busca de que alguna de las placas ingresadas exista
        /// </summary>
        /// <param name="placas">Arreglo de placas a buscar</param>
        /// <returns>Booleano que indica si alguna de las placas ingresadas ya se encontraba cargada</returns>
        public bool PlacaYaRegistrada(string[] placas)
        {
            return VehiculosRegistrados.SearchElementByCondition(V => placas.Contains(V.Placa)) != null;
        }

        /// <summary>
        /// Busca entre todos los vehiculos del cliente si la placa ingresada ya se encontraba registrada
        /// </summary>
        /// <param name="placa">Placa a buscar</param>
        /// <returns>Booleano que indica si la placa se encontraba registrada</returns>
        public bool PlacaYaRegistrada(string placa)
        {
            return VehiculosRegistrados.SearchElementByCondition(V => V.Placa == placa) != null;
        }

        /// <summary>
        /// Itera entre todos los vehiculos del cliente y retorna un arreglo con todas sus placas
        /// </summary>
        /// <returns>Arreglo de string que contiene todas las placas</returns>
        public string[] PlacasArray()
        {
            string[] plaq = new string[VehiculosRegistrados.Count];
            uint i = 0;
            foreach(Vehiculo carr in VehiculosRegistrados)
            {
                plaq[i++] = carr.Placa;
            }
            return plaq;
        }

        /// <summary>
        /// Serializa la estáncia del cliente en formato JSON
        /// </summary>
        /// <returns>Objeto JSON con datos selectos a almacenar</returns>
        public JObject SerializeToJson()
        {
            JArray carros = [];
            JArray Consumos = [];
            if(VehiculosRegistrados != null)
            {
                foreach (Vehiculo veh in VehiculosRegistrados)
                {
                    carros.Add(new JObject(new JProperty(nameof(veh.Modelo), veh.Modelo),
                                           new JProperty(nameof(veh.Tipo), veh.Tipo.ToString()),
                                           new JProperty(nameof(veh.Placa), veh.Placa)
                                           )
                               );
                }
            }
            foreach ((Services, TipoDeVehiculo) serv in ServiciosConsumidos)
            {
                Consumos.Add(serv.ToString());
            }
            JObject obj = [];
            obj.Add(nameof(Id), Id);
            obj.Add(nameof(Datos), JToken.FromObject(Name));
            obj.Add(nameof(Cedula), Cedula);
            obj.Add(new JProperty(nameof(VehiculosRegistrados), carros));
            obj.Add(nameof(Enabled), Enabled);
            obj.Add(new JProperty(nameof(ServiciosConsumidos), Consumos));
            obj.Add("Deuda", new JObject(new JProperty(nameof(DeudaTotal), DeudaTotal),
                                         new JProperty(nameof(MontoPorCuota), MontoPorCuota),
                                         new JProperty(nameof(NumeroDeCuotas), NumeroDeCuotas)
                                                    )
                    );
            return obj;
        }

        /// <summary>
        /// Recibe un Token JSON y deserializa los datos en la instancia del cliente
        /// </summary>
        /// <param name="data">Token JSON con los datos del cliente</param>
        /// <returns>Booleano que indica si la conversión se realizó correctamente</returns>
        public bool DeserializeFromJson(JToken data)
        {
            Id = (uint)data[nameof(Id)];
            Name = data[nameof(Datos)].ToObject<Datos>();

            VehiculosRegistrados = new();
            Vehiculo veh;
            JArray carr = (JArray)data[nameof(VehiculosRegistrados)];
            foreach (JToken c in carr)
            {
                TipoDeVehiculo tipovehiculo;
                if(Enum.TryParse(c[nameof(veh.Tipo)].ToString(), out tipovehiculo))
                {
                    veh = new(  tipovehiculo,
                                c[nameof(veh.Modelo)].ToString(),
                                c[nameof(veh.Placa)].ToString(),
                                null
                                );
                     VehiculosRegistrados.AddLast(veh);
                }
            }
            carr = null;
            Cedula = data[nameof(Cedula)]?.ToString() ?? string.Empty;

            Enabled = Convert.ToBoolean(data[nameof(Enabled)]);

            JToken? deudaToken = data["Deuda"];
            if (deudaToken != null)
            {
                NumeroDeCuotas = (uint)(deudaToken[nameof(NumeroDeCuotas)] ?? 0);
                MontoPorCuota = (decimal)(deudaToken[nameof(MontoPorCuota)] ?? 0);
                DeudaTotal = (decimal)(deudaToken[nameof(DeudaTotal)] ?? 0);
            }

            ServiciosConsumidos = new();
            carr = (JArray)data[nameof(ServiciosConsumidos)];
            (Services, decimal) ser;
            foreach(var c in carr)
            {
                string[] servicios = c.ToString().Trim('(', ')').Split(", ");

                Enum.TryParse(servicios[0], out ser.Item1);
                ser.Item2 = decimal.Parse(servicios[1]);

                ServiciosConsumidos.AddLast(ser);
            }
            return true;
        }
        /// <summary>
        /// Devuelve una copia del cliente
        /// </summary>
        /// <returns>Copia de la instancia del cliente</returns>
        public Cliente Copia()
        {
            return (Cliente)MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{Name.Nombre} {Name.Apellido}";
        }
    }
}
