using Newtonsoft.Json.Linq;

public enum Servicios
{
    Balanceo,
    Aceite,
    Aspirado,
    Lavado,
    Secado
}
public enum TipoDeVehiculo
{
    Auto,
    Camioneta
}

public struct Vehiculo
{
    public TipoDeVehiculo Tipo;
    public string Modelo, Placa;
    public Servicios? ServicioUbicado;
}
public struct ClienteVehiculo
{
    public TipoDeVehiculo modelo;
    public uint Id;
}

public struct Datos
{
    public string Nombre, Apellido;
}

public static class Operadores
{
    public static float PrecioServicios(Servicios serv, TipoDeVehiculo vehiculo)
    {
        if (vehiculo == TipoDeVehiculo.Auto)
        {
            switch (serv)
            {
                case Servicios.Balanceo:
                    return 25;
                case Servicios.Aceite:
                    return 15;
                case Servicios.Aspirado:
                    return 4;
                case Servicios.Lavado:
                    return 6;
                case Servicios.Secado:
                    return 4;
                default:
                    return 0;
            }
        }
        else if (vehiculo == TipoDeVehiculo.Camioneta)
        {
            switch (serv)
            {
                case Servicios.Balanceo:
                    return 35;
                case Servicios.Aceite:
                    return 20;
                case Servicios.Aspirado:
                    return 6;
                case Servicios.Lavado:
                    return 10;
                case Servicios.Secado:
                    return 5;
                default:
                    return 0;
            }
        }
        else
        {
            return 0;
        }
    }
}