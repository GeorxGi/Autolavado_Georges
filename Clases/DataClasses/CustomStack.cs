namespace Proyecto_Autolavado_Georges.Clases.DataClasses
{
    class CustomStack<T>(uint size) : CustomLinkedList<T>
    {
        #region Atributos
        public uint Size { get; private set; } = size;
        public int top { get; private set; } = -1;
        #endregion

        #region Manejadores

        /// <summary>
        /// Verifica que el objeto de la pila se encuentre lleno
        /// </summary>
        /// <returns>booleano que indica si la pila se encuentra llena</returns>
        public bool IsFull()
        {
            return top == Size - 1;
        }

        /// <summary>
        /// Reinicia los indices, deshaciendo cualquier dato almacenado en la pila
        /// </summary>
        public void CleanStack()
        {
            CleanList();
            top = -1;
        }

        #endregion

        /// <summary>
        /// Ingresa un elemento en la pila
        /// </summary>
        /// <param name="data">Dato a ingresar en la pila</param>
        /// <returns>booleano que indica si la operacion pudo realizarse</returns>
        public bool Push(T data)
        {
            if (!IsFull())
            {
                AddLast(data);
                top++;
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Retira el último elemento ingresado de la pila
        /// </summary>
        /// <returns></returns>
        public T? Pop()
        {
            if (!IsEmpty())
            {
                T aux = GetLastElement();
                Delete(aux);
                top--;
                return aux;
            }
            else
            {
                return default;
            }
        }
    }
}
