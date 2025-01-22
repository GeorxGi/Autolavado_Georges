public enum Servicios
{
    Balanceo,
    Aceite,
    Aspirado,
    Lavado,
    Secado
}

public struct ClienteVehiculo
{
    public TipoDeVehiculo modelo;
    public uint Id;
}

public static class Operadores
{
    public static decimal PrecioServicios(Servicios serv, TipoDeVehiculo vehiculo)
    {
        if (vehiculo == TipoDeVehiculo.Auto)
        {
            return serv switch
            {
                Servicios.Balanceo => 25,
                Servicios.Aceite => 15,
                Servicios.Aspirado => 4,
                Servicios.Lavado => 6,
                Servicios.Secado => 4,
                _ => (decimal)0,
            };
        }
        else if (vehiculo == TipoDeVehiculo.Camioneta)
        {
            return serv switch
            {
                Servicios.Balanceo => 35,
                Servicios.Aceite => 20,
                Servicios.Aspirado => 6,
                Servicios.Lavado => 10,
                Servicios.Secado =>5,
                _ => (decimal)0,
            };
        }
        else
        {
            return 0;
        }
    }
}