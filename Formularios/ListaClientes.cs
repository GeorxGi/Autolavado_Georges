using Autolavado_GeorgesChakour.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Autolavado_Georges.Formularios
{
    public partial class ListaClientes : Form
    {
        List<Cliente> clientes;
        Cola<int> colaElementos;
        public ListaClientes(List<Cliente> clients, Cola<int> colaBusqueda)
        {
            InitializeComponent();
            clientes = clients;
            colaElementos = colaBusqueda;
        }

        private void ListaClientes_Load(object sender, EventArgs e)
        {
            List<Cliente> aux = new() ;
            foreach (Cliente cliente in clientes)
            {
                if (colaElementos.Find(Convert.ToInt32(cliente.Id) -1))
                {
                    MessageBox.Show("Yes encontrado");
                    aux.Add(cliente);
                }
            }
            clientes = aux;
            Cliente clt;
            int id, i = 1;
            while (!colaElementos.ColaVacia())
            {
                id = colaElementos.Retirar();
                clt = clientes[id];
                dataGridView1.Rows.Add(clt.Name.Nombre, clt.Name.Apellido, clt.Cedula,
                    clt.Carro.Placa, clt.Carro.Tipo, clt.Carro.Modelo, i++);
            }
        }
            /*foreach (Cliente cliente in clientes)
            {
                dataGridView1.Rows.Add(cliente.Name.Nombre, cliente.Name.Apellido, cliente.Cedula,
                    cliente.Carro.Placa, cliente.Carro.Tipo, cliente.Carro.Modelo, colaElementos.FindIndex(Convert.ToInt32(cliente.Id-1)) + 1);
            }
            */
    }
}
