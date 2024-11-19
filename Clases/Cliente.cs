namespace Autolavado_GeorgesChakour.Clases
{
    [Serializable]
    /// <summary>
    /// Constructor de la clase cliente
    /// </summary>
    /// <param name="id">Identificador interno del cliente</param>
    /// <param name="cedula">Cedula de identidad del cliente</param>
    /// <param name="datos">Estructura que contiene el nombre y apellido del cliente</param>
    /// <param name="carro">Estructura que contiene el tipo, modelo y placa del vehiculo del cliente</param>
    public class Cliente(uint id, string cedula, Datos datos, Vehiculo carro)
    {
        public Datos Name { get; private set; } = datos;
        public string Cedula { get; private set; } = cedula;
        public Vehiculo Carro { get; private set; } = carro;
        public uint Id { get; private set; } = id;

        public string? ServicioActivo { get; private set; } = null;
        public List<string> ServiciosConsumidos { get; private set; } = new List<string> { };

        /// <summary>
        /// Recibe datos del cliente e intenta modificar los ya cargados
        /// </summary>
        /// <param name="cedula">Cedula del cliente</param>
        /// <param name="datos">Estructura que contiene su nombre y apellido</param>
        /// <param name="carro">Estructura que contiene la información del vehiculo del cliente</param>
        /// <returns>booleano que indica si la modificación se realizó o hubo algo que no lo permitiera</returns>
        public bool Modificar(string cedula, Datos datos, Vehiculo carro)
        {
            if(ServicioActivo == null && ServiciosConsumidos.Count == 0)
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
        public bool RegistrarServicio(string servicio)
        {
            if(ServicioActivo == null)
            {
                if (Servicios.ServiciosDisp.Contains<string>(servicio))
                {
                    ServicioActivo = servicio;
                    return true;
                }
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
                ServiciosConsumidos.Add(ServicioActivo);
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
            ServiciosConsumidos.Clear();
        }
    }
}
