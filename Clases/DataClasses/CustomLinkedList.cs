using System.Collections;

namespace Proyecto_Autolavado_Georges.Clases.DataClasses
{
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Cantidad de elementos que se encuentran en la lista
        /// </summary>
        public uint Count { get; private set; }
        protected Node<T> Head;
        protected Node<T> Last;

        public CustomLinkedList()
        {
            Head = Last = null;
            Count = 0;
        }

        /// <summary>
        /// Indica si la lista se encuentra vacia
        /// </summary>
        /// <returns>Booleano que retorna verdadero si la lista no posee elementos</returns>
        public bool IsEmpty()
        {
            return Head == null;
        }

        public void AddLast(T value)
        {
             Node<T> newNode = new(value);
            if (Head == null)
            {
                Head = newNode;
                Last = newNode;
                Count++;
            }
            else
            {
                Last.SetNextNode(newNode);
                Last = newNode;
                Count++;
            }
        }

        /// <summary>
        /// Busca el elemento en la lista y lo retorna
        /// </summary>
        /// <param name="condition">Condición o valor con el que buscar el elemento</param>
        /// <returns>Dato almacenado en lista que cumpla la condición</returns>
        public T? SearchElementByCondition(Func<T, bool> condition)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (condition(current.Element))
                {
                    return current.Element;
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
        /// <param name="value">Elemento a eliminar</param>
        /// <returns>Booleano que indica si la operación se realizó correctamente</returns>
        public bool Delete(T value)
        {
            Node<T> current = Head;
            Node<T> previous = null;

            while (current != null)
            {
                if (Equals(value, current.Element))
                {
                    if (previous == null)
                    {
                        Head = current.NextNode;
                    }
                    else if(current == Last)
                    {
                        Last = previous;
                        Last.SetNextNode(null);
                    }
                    else
                    {
                        previous.SetNextNode(current.NextNode);
                    }
                    GC.Collect();
                    Count--;
                    return true;
                }

                previous = current;
                current = current.NextNode;
            }
            return false;
        }

        /// <summary>
        /// Retorna el primer elemento de la lista
        /// </summary>
        /// <returns>Primer elemento de la lista</returns>
        protected T GetFirstElement()
        {
            return Head.Element;
        }
        /// <summary>
        /// Retorna el ultimo elemento de la lista
        /// </summary>
        /// <returns>Ultimo elemento de la lista</returns>
        protected T GetLastElement()
        {
            return Last.Element;
        }

        /// <summary>
        /// Limpia todos los elementos que existan en la lista
        /// </summary>
        public void CleanList()
        {
            Node<T> current = Head;
            Node<T> next;
            do
            {
                next = current.NextNode;
                current = null;
                current = next;

            } while (current != null);
            Count = 0;
            Head = Last = null;
            GC.Collect();
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            Node<T> current = Head;
            uint ind = 0;

            while(current != null)
            {
                array[ind] = current.Element;
            }
            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Element;
                current = current.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
