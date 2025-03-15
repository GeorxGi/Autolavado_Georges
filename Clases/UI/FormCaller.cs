using Proyecto_Autolavado_Georges.Clases.DataClasses;
using Proyecto_Autolavado_Georges.Clases.DataHandlers;
using Proyecto_Autolavado_Georges.Clases.UserClasses;
using Proyecto_Autolavado_Georges.Forms;
using Proyecto_Autolavado_Georges.Formularios;

namespace Proyecto_Autolavado_Georges.Clases.UI
{
    public static class FormCaller
    {
        public static bool GetClientID(out uint ID, CustomLinkedList<Cliente> clientesRegistrados)
        {
            //HACER CLASE DE CLIENTES ESTATICAS ANTES DE CONTINUAR
            IngresarID ui = new();
            ui.ShowDialog();
            ui.Dispose();

            if (!ui.ReturnID.HasValue || clientesRegistrados.SearchElementByCondition(p => p.Id == ui.ReturnID.Value) == null)
            {
                ID = 0;
                return false;
            }

            ID = ui.ReturnID.Value;
            return true;
        }

        public static Cliente? GetClient(ClientList clientesRegistrados)
        {
            IngresarID ui = new();
            ui.ShowDialog();
            ui.Dispose();

            if (!ui.ReturnID.HasValue) return null;

            return clientesRegistrados.SearchByCondition(p => p.Id == ui.ReturnID.Value);
        }

        public static bool SelectService(out Services? servicio)
        {
            IngresarServicio ingresar = new();
            ingresar.ShowDialog();
            ingresar.Dispose();
            servicio = ingresar.Servicio;
            return servicio.HasValue;
        }

        public static Vehiculo GetClientVehicle(Cliente client, SeleccionarVehiculo.GetVehicleMode filter)
        {
            SeleccionarVehiculo ui = new(client, filter);
            ui.ShowDialog();
            ui.Dispose();
            return ui.PickedVehicle;
        }

        public static Vehiculo? CreateNewVehicle()
        {
            IngresarModificarVehiculo ui = new();
            ui.ShowDialog();
            ui.Dispose();
            return ui.CarroNuevo;
        }

        public static void ModifyVehicle(Vehiculo veh)
        {
            IngresarModificarVehiculo ui = new(veh);
            ui.ShowDialog();
            ui.Dispose();
        }

        public static decimal InsertNumber(string message, decimal min, decimal max, bool acceptDecimals)
        {
            IngresarNumero ui = new(message, min, max, acceptDecimals);
            ui.ShowDialog();
            ui.Dispose();
            return ui.ReturnNumber;
        }

        public static decimal InsertNumber(string mensaje, decimal min, bool acceptDecimals)
        {
            return InsertNumber(mensaje, min, decimal.MaxValue, acceptDecimals);
        }

        public static bool PayBill(Cliente client)
        {
            ListaClientes ui = new(client);
            ui.ShowDialog();
            ui.Dispose();
            return ui.Pagado;
        }

        public static void ServiceList(ClientList list, CustomQueue<(uint, Vehiculo)> serviceQueue)
        {
            ListaClientes ui = new(list, serviceQueue);
            ui.ShowDialog();
            ui.Dispose();
        }
        public static void ClientsList(ClientList list)
        {
            ListaClientes ui = new(list);
            ui.ShowDialog();
            ui.Dispose();
        }

        public static Color? CustomizeColor()
        {
            UIPersonalization ui = new();
            ui.ShowDialog();
            ui.Dispose();
            return ui.pickedColor;
        }

        public static void ShowCredits()
        {
            Creditos ui = new();
            ui.ShowDialog();
            ui.Dispose();
        }
    }
}
