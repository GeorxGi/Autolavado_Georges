using System.Collections;

namespace Proyecto_Autolavado_Georges
{
    public class Lista<T> : IEnumerable<T>
    {
        /// <summary>
        /// Cantidad de elementos que se encuentran en la lista
        /// </summary>
        public int Cant { get; private set; }
        protected Node<T> Head;
        protected Node<T> Last;

        public Lista()
        {
            Head = Last = null;
            Cant = 0;
        }

        /// <summary>
        /// Indica si la lista se encuentra vacia
        /// </summary>
        /// <returns>Booleano que retorna verdadero si la lista no posee elementos</returns>
        public bool ListaVacia()
        {
            return Head == null;
        }

        public void Insertar(T dato)
        {
            Node<T> nuevoNodo = new Node<T>(dato);
            if (Head == null)
            {
                Head = nuevoNodo;
                Last = nuevoNodo;
                Cant++;
            }
            else
            {
                Last.SetNextNode(nuevoNodo);
                Last = nuevoNodo;
                Cant++;
            }
        }

        /// <summary>
        /// Busca el nodo en el que se encuentra el dato ingresado
        /// </summary>
        /// <param name="dato">Dato a buscar en la lista</param>
        /// <returns>Nodo en el que se encuentra el elemento</returns>
        private Node<T> BuscarNodo(T dato)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (IComparable.Equals(dato, current.Dato))
                {
                    return current;
                }
                else
                {
                    current = current.NextNode;
                }
            }
            return null;
        }

        /// <summary>
        /// Modifica la primera instancia del elemento ingresado y cambia sus datos en base al segundo elemento ingresado
        /// </summary>
        /// <param name="dato">Elemento a modificar</param>
        /// <param name="NuevoDato">Nuevos datos a ingresar</param>
        /// <returns>Booleano que indica si la operación se realizó correctamente</returns>
        public bool ModificarElemento(T dato, T NuevoDato)
        {
            Node<T> NodeToModify = BuscarNodo(dato);
            if (NodeToModify != null)
            {
                NodeToModify.SetDato(NuevoDato);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina el elemento ingresado de la lista
        /// </summary>
        /// <param name="dato">Elemento a eliminar</param>
        /// <returns>Booleano que indica si la operación se realizó correctamente</returns>
        public bool Eliminar(T dato)
        {
            Node<T> current = Head;
            Node<T> Previous = null;

            while (current != null)
            {
                if (IComparable.Equals(dato, current.Dato))
                {
                    if (Previous == null)
                    {
                        Head = current.NextNode;
                    }
                    else
                    {
                        Previous.SetNextNode(current.NextNode);
                    }
                    current = null;
                    GC.Collect();
                    Cant--;
                    return true;
                }

                Previous = current;
                current = current.NextNode;
            }
            return false;
        }

        /// <summary>
        /// Busca el elemento ingresado en la lista
        /// </summary>
        /// <param name="dato">Elemento a buscar</param>
        /// <returns>Booleano que indica si el elemento se encuentra o no cargado</returns>
        public bool ElementoEnLista(T dato)
        {
            return BuscarNodo(dato) != null;
        }

        /// <summary>
        /// Retorna el primer elemento de la lista
        /// </summary>
        /// <returns>Primer elemento de la lista</returns>
        protected T PrimerElemento()
        {
            return this.Head.Dato;
        }
        /// <summary>
        /// Retorna el ultimo elemento de la lista
        /// </summary>
        /// <returns>Ultimo elemento de la lista</returns>
        protected T UltimoElemento()
        {
            return this.Last.Dato;
        }

        /// <summary>
        /// Limpia todos los elementos que existan en la lista
        /// </summary>
        public void LimpiarLista()
        {
            Node<T> current = Head;
            Node<T> next;
            do
            {
                next = current.NextNode;
                current = null;
                current = next;

            } while (current != null);
            Cant = 0;
            Head = Last = null;
            GC.Collect();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Dato;
                current = current.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
    }
}
