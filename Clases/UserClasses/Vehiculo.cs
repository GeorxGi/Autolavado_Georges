using Proyecto_Autolavado_Georges.Clases.DataHandlers;
using Proyecto_Autolavado_Georges.Properties;
namespace Proyecto_Autolavado_Georges.Clases.UserClasses
{
    public class Vehiculo
    {
        public TipoDeVehiculo Tipo { get; private set; }
        public string Modelo { get; private set; }
        public string Placa { get; private set; }
        public Services? ServicioUbicado { get; private set; }

        public Vehiculo()
        {
            Modelo = Placa = string.Empty;
        }
        public Vehiculo(TipoDeVehiculo tipo, string modelo, string placa, Services? servicioUbicado)
        {
            Tipo = tipo;
            Modelo = modelo;
            Placa = placa;
            ServicioUbicado = servicioUbicado;
        }

        public void ModificarModelo(string modelo)
        {
            this.Modelo = modelo;
        }
        public void ModificarPlaca(string placa)
        {
            this.Placa = placa;
        }
        public void ModificarTipoDeVehiculo(TipoDeVehiculo tipo)
        {
            Tipo = tipo;
        }

        /// <summary>
        /// Asigna un servicio al vehiculo
        /// </summary>
        /// <param name="servicio">Servicio a registrar</param>
        /// <returns> bool que indica si el vehiculo ya se encontraba en un servicio previamente (se cancela la operación)</returns>
        public void AsignarServicio(Services servicio)
        {
            ServicioUbicado = servicio;
        }

        /// <summary>
        /// Asigna un servicio al vehiculo indistintamente del servicio en el que se encuentre actualmente
        /// </summary>
        /// <param name="servicio">Servicio a registrar</param>
        public void ModificarServicioActivo(Services servicio)
        {
            ServicioUbicado = servicio;
        }


        public void CancelarServicio()
        {
            ServicioUbicado = null;
        }

        public override string ToString()
        {
            return $"{this.Tipo.ToString()} - {this.Modelo}\n{this.Placa}\n";
        }
        public (string, Bitmap) ToStringWithIcon()
        {
            Bitmap icon = Resources.carro_icon;
            switch (this.Tipo)
            {
                case TipoDeVehiculo.Auto:
                    icon = Resources.carro_icon;
                    break;
                case TipoDeVehiculo.Camioneta:
                    icon = Resources.camioneta_icon;
                    break;
                default:
                    break;
            }
            return ($"{this.Modelo} - {this.Placa}", icon);
        }
    }
}
