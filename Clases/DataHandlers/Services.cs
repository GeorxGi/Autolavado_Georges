namespace Proyecto_Autolavado_Georges.Clases.DataHandlers
{
    public enum Services
    {
        Balanceo,
        Aceite,
        Aspirado,
        Lavado,
        Secado
    }

    public static class ServiceManager
    {
        private static Dictionary<Services, decimal> PreciosAuto = new()
        {
            { Services.Balanceo, 20},
            { Services.Aceite, 15},
            { Services.Aspirado, 4},
            { Services.Lavado, 6},
            { Services.Secado, 4}
        };

        private static Dictionary<Services, decimal> preciosCamioneta = new()
        {
            { Services.Balanceo, 35},
            { Services.Aceite, 20},
            { Services.Aspirado, 6},
            { Services.Lavado, 10},
            { Services.Secado, 5}
        };

        public static Dictionary<Services, decimal> GetAllPrices(TipoDeVehiculo veh)
        {
            switch (veh)
            {
                case TipoDeVehiculo.Auto:
                    return PreciosAuto;
                case TipoDeVehiculo.Camioneta:
                    return preciosCamioneta;
                default:
                    throw new InvalidDataException("Unknown vehicle type");
            }
        }

        public static void SetServicePrice(Services service, TipoDeVehiculo vehicleType, decimal newPrice)
        {
            switch (vehicleType)
            {
                case TipoDeVehiculo.Auto:
                    PreciosAuto[service] = newPrice;
                    break;

                case TipoDeVehiculo.Camioneta:
                    preciosCamioneta[service] = newPrice;
                    break;

                default:
                throw new InvalidDataException("Unknown vehicle type");
            }
        }

        public static decimal GetServicePrice(Services service, TipoDeVehiculo vehicleType)
        {
            switch(vehicleType)
            {
                case TipoDeVehiculo.Auto:
                    return PreciosAuto[service];

                case TipoDeVehiculo.Camioneta:
                    return preciosCamioneta[service];

                default:
                    throw new InvalidDataException("Unknown vehicle type");
            }

        }
        public static void SetDefaultPrices()
        {
            PreciosAuto = new()
            {
                { Services.Balanceo, 20},
                { Services.Aceite, 15},
                { Services.Aspirado, 4},
                { Services.Lavado, 6},
                { Services.Secado, 4}
            };

            preciosCamioneta = new()
            {
                { Services.Balanceo, 35},
                { Services.Aceite, 20},
                { Services.Aspirado, 6},
                { Services.Lavado, 10},
                { Services.Secado, 5}
            };
        }
    }
}