namespace Proyecto_Autolavado_Georges.Classes
{
    public class Vehiculo
    {
        public TipoDeVehiculo Tipo { get; private set; }
        public string Modelo { get; private set; }
        public string Placa { get; private set; }
        public Servicios? ServicioUbicado { get; private set; }

        public Vehiculo()
        {
        }
        public Vehiculo(TipoDeVehiculo tipo, string modelo, string placa, Servicios? servicioUbicado)
        {
            Tipo = tipo;
            Modelo = modelo;
            Placa = placa;
            ServicioUbicado = servicioUbicado;
        }

        public void AsignarServicio(Servicios? servicio)
        {
            ServicioUbicado = servicio;
        }
        public bool CancelarServicio()
        {
            if (ServicioUbicado.HasValue)
            {
                ServicioUbicado = null;
                return true;
            }
            return false;
        }
    }
}
