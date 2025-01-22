using Newtonsoft.Json.Linq;
using Proyecto_Autolavado_Georges;
using Proyecto_Autolavado_Georges.Classes;
using Proyecto_Autolavado_Georges.Formularios;

public enum TipoDeVehiculo
{
    Auto,
    Camioneta
}

public struct Datos
{
    public string Nombre, Apellido;
}

namespace Autolavado_GeorgesChakour.Clases
{   
    public class Cliente
    {
        public Datos Name { get; private set; }
        public string Cedula { get; private set; }
        public Lista<Vehiculo> VehiculosRegistrados { get; private set; }
        public uint Id { get; private set; }
        public bool Enabled { get; private set; }
        public float DeudaTotal { get; private set; }

        public float MontoPorCuota { get; private set; }
        public uint NumeroDeCuotas {  get; private set; }

        public Lista<(Servicios, TipoDeVehiculo)> ServiciosConsumidos { get; private set; }

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
        public Cliente(uint id, string cedula, Datos datos, Lista<Vehiculo> carros)
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
                if (veh.ServicioUbicado != null)
                {
                    return false;
                }
            }
            if(ServiciosConsumidos.Cant == 0)
            {
                Cedula = cedula;
                Name = datos;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Ingresa el servicio actual en los datos del cliente
        /// </summary>
        /// <param name="servicio">Servicio a ingresar, debe pertenecer a la lista de servicios disponibles</param>
        /// <returns>booleano que indica si el servicio se registró correctamente</returns>
        public bool RegistrarServicio(Servicios servicio, string placa)
        {
            Vehiculo? mod = VehiculosRegistrados.BuscarElemento(V => V.Placa == placa);
            if(mod != null)
            {
                mod.AsignarServicio(servicio);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Comprueba si el vehiculo ingresado está actualmente en un servicio, retorna nulo si no se encontro un vehiculo
        /// con la placa ingresada
        /// </summary>
        /// <param name="placa">Placa del vehiculo a buscar</param>
        /// <returns>Booleano que indica si el vehiculo se encuentra o no en un servicio</returns>
        public bool? EstaEnServicio(string placa)
        {
            Vehiculo? aux = VehiculosRegistrados.BuscarElemento(V => V.Placa == placa);
            if(aux != null)
            {
                return aux.ServicioUbicado != null;
            }
            return null;
        }

        /// <summary>
        /// Comprueba si alguno de los vehiculos del cliente se encuentra en un servicio
        /// </summary>
        /// <returns>Booleano que indica si algún vehículo está en servicio</returns>
        public bool HayVehiculoEnServicio()
        {
            return VehiculosRegistrados.BuscarElemento(V => V.ServicioUbicado != null) != null;
        }

        /// <summary>
        /// Busca entre los vehiculos registrados y devuelve el servicio en el que se encuentre el vehiculo indicado
        /// </summary>
        /// <param name="placa">Placa del vehiculo a buscar</param>
        /// <returns>Servicio en el que se encuentra el vehiculo indicado</returns>
        public Servicios? ServicioActual(string placa)
        {
            Vehiculo? aux = VehiculosRegistrados.BuscarElemento(V => V.Placa == placa);
            if(aux != null)
            {
                return aux.ServicioUbicado;
            }
            return null;
        }

        /// <summary>
        /// Procesa el servicio actualmente activo del cliente
        /// </summary>
        public void ProcesarServicio(string placa)
        {
            Vehiculo? mod = VehiculosRegistrados.BuscarElemento(V => V.Placa == placa && V.ServicioUbicado != null);
            if(mod != null)
            {
                if(mod.ServicioUbicado.HasValue)
                {
                    ServiciosConsumidos.Insertar((mod.ServicioUbicado.Value, mod.Tipo));
                    DeudaTotal += (float)Operadores.PrecioServicios(mod.ServicioUbicado.Value, mod.Tipo);
                    NumeroDeCuotas = 1;
                    mod.AsignarServicio(null);
                }
            }
        }

        /// <summary>
        /// Cancela el servicio en el que se encuentre el cliente
        /// </summary>
        public void CancelarServicio(string placa)
        {
            Vehiculo? mod = VehiculosRegistrados.BuscarElemento(V => V.Placa == placa);
            mod?.CancelarServicio();
        }

        /// <summary>
        /// Limpia la lista que contiene las facturas del cliente
        /// </summary>
        public void LimpiarFactura()
        {
            DeudaTotal = 0;
            NumeroDeCuotas = 0;
            MontoPorCuota = 0;
            ServiciosConsumidos.LimpiarLista();
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
                if(NumeroDeCuotas == 1)
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
            Vehiculo? aux = VehiculosRegistrados.BuscarElemento(V => V.Placa == placa);
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
            return VehiculosRegistrados.BuscarElemento(V => placas.Contains(V.Placa)) != null;
        }

        /// <summary>
        /// Busca entre todos los vehiculos del cliente si la placa ingresada ya se encontraba registrada
        /// </summary>
        /// <param name="placa">Placa a buscar</param>
        /// <returns>Booleano que indica si la placa se encontraba registrada</returns>
        public bool PlacaYaRegistrada(string placa)
        {
            return VehiculosRegistrados.BuscarElemento(V => V.Placa == placa) != null;
        }

        /// <summary>
        /// Itera entre todos los vehiculos del cliente y retorna un arreglo con todas sus placas
        /// </summary>
        /// <returns>Arreglo de string que contiene todas las placas</returns>
        public string[] PlacasArray()
        {
            string[] plaq = new string[VehiculosRegistrados.Cant];
            uint i = 0;
            foreach(Vehiculo carr in VehiculosRegistrados)
            {
                plaq[i++] = carr.Placa;
            }
            return plaq;
        }

        /// <summary>
        /// Abre un formulario y devuelve un vehiculo, retorna null si no se selecciono ninguno
        /// </summary>
        /// <returns>Vehiculo del cliente seleccionado</returns>
        public Vehiculo? ElegirVehiculo()
        {
            SeleccionarVehiculo selec = new(this);
            selec.ShowDialog();
            Vehiculo? retorno = selec.VehiculoSeleccionado;
            selec.Dispose();
            return retorno;
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
                JObject aux = [];
                foreach (Vehiculo veh in VehiculosRegistrados)
                {
                    carros.Add(new JObject(new JProperty(nameof(veh.Modelo), veh.Modelo),
                                           new JProperty(nameof(veh.Tipo), veh.Tipo.ToString()),
                                           new JProperty(nameof(veh.Placa), veh.Placa)
                                           )
                               );
                }
            }
            foreach((Servicios, TipoDeVehiculo) serv in ServiciosConsumidos)
            {
                Consumos.Add(serv.ToString());
            }
            JObject obj = [];
            obj.Add(nameof(Id), this.Id);
            obj.Add(nameof(Datos), JProperty.FromObject(Name));
            obj.Add(nameof(Cedula), this.Cedula);
            obj.Add(new JProperty(nameof(VehiculosRegistrados), carros));
            obj.Add(nameof(Enabled), this.Enabled);
            obj.Add(new JProperty(nameof(ServiciosConsumidos), Consumos));
            obj.Add("Deuda", new JObject(new JProperty(nameof(DeudaTotal), this.DeudaTotal),
                                         new JProperty(nameof(MontoPorCuota), this.MontoPorCuota),
                                         new JProperty(nameof(NumeroDeCuotas), this.NumeroDeCuotas)
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
            this.Id = (uint)data[nameof(Id)];
            this.Name = data[nameof(Datos)].ToObject<Datos>();

            this.VehiculosRegistrados = new();
            Vehiculo veh;
            JArray carr = (JArray)data[nameof(VehiculosRegistrados)];
            foreach (JToken c in carr)
            {
                TipoDeVehiculo tipovehiculo;
                if(Enum.TryParse<TipoDeVehiculo>(c[nameof(veh.Tipo)].ToString(), out tipovehiculo))
                {
                    veh = new(  tipovehiculo,
                                c[nameof(veh.Modelo)].ToString(),
                                c[nameof(veh.Placa)].ToString(),
                                null
                                );
                     VehiculosRegistrados.Insertar(veh);
                }
            }
            carr = null; 

            this.Cedula = data[nameof(Cedula)].ToString();
            this.Enabled = Convert.ToBoolean(data[nameof(Enabled)]);
            this.NumeroDeCuotas = (uint)data["Deuda"][nameof(NumeroDeCuotas)];
            this.MontoPorCuota = (float)data["Deuda"][nameof(MontoPorCuota)];

            this.DeudaTotal = (float)data["Deuda"][nameof(DeudaTotal)];

            this.ServiciosConsumidos = new();
            carr = (JArray)data[nameof(ServiciosConsumidos)];
            (Servicios, TipoDeVehiculo) ser;
            foreach(var c in carr)
            {
                var servicios = c.ToString().Trim('(', ')').Split(", ");

                Enum.TryParse(servicios[0], out ser.Item1);
                Enum.TryParse(servicios[1], out ser.Item2);

                ServiciosConsumidos.Insertar(ser);
            }
            return true;
        }
        /// <summary>
        /// Devuelve una copia del cliente
        /// </summary>
        /// <returns>Copia de la instancia del cliente</returns>
        public Cliente Copia()
        {
            return (Cliente)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{this.Name.Nombre} {this.Name.Apellido}";
        }
    }
}
