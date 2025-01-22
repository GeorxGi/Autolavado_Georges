using System.Collections;
using System.Text.Json.Nodes;

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
             Node<T> nuevoNodo = new(dato);
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
        /// Busca el elemento en la lista y lo retorna
        /// </summary>
        /// <param name="condicion">Condición o valor con el que buscar el elemento</param>
        /// <returns>Dato almacenado en lista que cumpla la condición</returns>
        public T? BuscarElemento(Func<T, bool> condicion)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (condicion(current.Dato))
                {
                    return current.Dato;
                }
                else
                {
                    current = current.NextNode;
                }
            }
            return default;
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
                    else if(current == Last)
                    {
                        Last = Previous;
                        Last.SetNextNode(null);
                    }
                    else
                    {
                        Previous.SetNextNode(current.NextNode);
                    }
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
