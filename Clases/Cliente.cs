using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Proyecto_Autolavado_Georges;

namespace Autolavado_GeorgesChakour.Clases
{   
    public class Cliente
    {
        public Datos Name { get; private set; }
        public string Cedula { get; private set; }
        public Vehiculo Carro { get; private set; }
        public uint Id { get; private set; }
        public bool Enabled { get; private set; }
        public float Deuda { get; private set; }

        public float MontoPorCuota { get; private set; }
        public uint NumeroDeCuotas {  get; private set; }

        public Servicios? ServicioActivo { get; private set; } = null;

        public Lista<Servicios> ServiciosConsumidos { get; private set; }

        public Cliente()
        {
            Cedula = "0";
            Id = 0;
            ServiciosConsumidos = new();
        }
        /// <summary>
        /// Constructor de la clase cliente
        /// </summary>
        /// <param name="id">Identificador interno del cliente</param>
        /// <param name="cedula">Cedula de identidad del cliente</param>
        /// <param name="datos">Estructura que contiene el nombre y apellido del cliente</param>
        /// <param name="carro">Estructura que contiene el tipo, modelo y placa del vehiculo del cliente</param>
        public Cliente(uint id, string cedula, Datos datos, Vehiculo carro)
        {
            Id = id;
            Cedula = cedula;
            Name = datos;
            Carro = carro;
            Enabled = true;
            ServiciosConsumidos = new();
        }

        /// <summary>
        /// Recibe datos del cliente e intenta modificar los ya cargados
        /// </summary>
        /// <param name="cedula">Cedula del cliente</param>
        /// <param name="datos">Estructura que contiene su nombre y apellido</param>
        /// <param name="carro">Estructura que contiene la información del vehiculo del cliente</param>
        /// <returns>booleano que indica si la modificación se realizó o hubo algo que no lo permitiera</returns>
        public bool Modificar(string cedula, Datos datos, Vehiculo carro)
        {
            if(ServicioActivo == null && ServiciosConsumidos.Cant == 0)
            {
                Cedula = cedula;
                Name = datos;
                Carro = carro;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Ingresa el servicio actual en los datos del cliente
        /// </summary>
        /// <param name="servicio">Servicio a ingresar, debe pertenecer a la lista de servicios disponibles</param>
        /// <returns>booleano que indica si el servicio se registró correctamente</returns>
        public bool RegistrarServicio(Servicios servicio)
        {
            if(ServicioActivo == null)
            {
                    ServicioActivo = servicio;
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Procesa el servicio actualmente activo del cliente
        /// </summary>
        public void ProcesarServicio()
        {
            if (ServicioActivo != null)
            {
                ServiciosConsumidos.Insertar((Servicios)ServicioActivo);
                Deuda += Operadores.PrecioServicios((Servicios)ServicioActivo, this.Carro.Tipo);
                
                NumeroDeCuotas = 1;

                ServicioActivo = null;
            }
        }

        /// <summary>
        /// Cancela el servicio en el que se encuentre el cliente
        /// </summary>
        public void CancelarServicio()
        {
            if (ServicioActivo != null)
            {
                ServicioActivo = null;
            }
        }

        /// <summary>
        /// Limpia la lista que contiene las facturas del cliente
        /// </summary>
        public void LimpiarFactura()
        {
            Deuda = 0;
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
                MontoPorCuota = Deuda / NumeroDeCuotas;
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
                Deuda -= MontoPorCuota;
            }
        }

        /// <summary>
        /// Serializa la estáncia del cliente en formato JSON
        /// </summary>
        /// <returns>Objeto JSON con datos selectos a almacenar</returns>
        public JObject SerializeToJson()
        {
            string[] servArr = new string[ServiciosConsumidos.Cant];
            int i = 0;
            foreach (Servicios serv in ServiciosConsumidos)
            {
                servArr[i] = serv.ToString();
                i++;
            }
            return new JObject(new JProperty("ID", this.Id),

                              new JProperty(new JProperty("Datos", JProperty.FromObject(Name))),

                              new JProperty("Cedula", this.Cedula),

                              new JProperty(new JProperty("Vehiculo", JProperty.FromObject(Carro))),

                              new JProperty("Enabled", this.Enabled),

                              new JProperty("Consumos", servArr),

                              new JProperty("Deuda", new JObject(new JProperty("Monto", MontoPorCuota), new JProperty("Cuotas", NumeroDeCuotas))));
        }

        /// <summary>
        /// Recibe un Token JSON y deserializa los datos en la instancia del cliente
        /// </summary>
        /// <param name="data">Token JSON con los datos del cliente</param>
        /// <returns>Booleano que indica si la conversión se realizó correctamente</returns>
        public bool DeserializeFromJson(JToken data)
        {
            try
            {
                this.Id = (uint)data["ID"];
                this.Name = data["Datos"].ToObject<Datos>();

                this.Carro = data["Vehiculo"].ToObject<Vehiculo>();

                this.Cedula = data["Cedula"].ToString();
                this.Enabled = Convert.ToBoolean(data["Enabled"]);
                this.NumeroDeCuotas = (uint)data["Deuda"]["Cuotas"];
                this.MontoPorCuota = (float)data["Deuda"]["Monto"];

                this.Deuda = MontoPorCuota * NumeroDeCuotas;

                
                string[] servArr;
                servArr = data["Consumos"].ToObject<string[]>();
                this.ServiciosConsumidos = new();
                Servicios ser;
                foreach (string serv in servArr)
                {
                    Enum.TryParse(serv, out ser);
                    ServiciosConsumidos.Insertar(ser);   
                }
                
                return true;
            }
            catch
            {
                return false;
            }
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
