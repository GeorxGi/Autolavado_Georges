using Proyecto_Autolavado_Georges.Clases.UserClasses;

namespace Proyecto_Autolavado_Georges.Clases.DataClasses
{
    public class ClientList : List<Cliente>
    {
        public Cliente? SearchByCondition(Func<Cliente, bool> condition)
        {
            foreach (Cliente client in this)
            {
                if (condition(client))
                {
                    return client;
                }
            }
            return null;
        }

        public bool CarPlaqueIsRegistered(string plaque)
        {
            return SearchByCondition(p => p.VehiculosRegistrados.SearchElementByCondition(v => v.Placa == plaque) != null) != null;
        }
    }
}
