namespace Autolavado_GeorgesChakour.Clases
{
    public class Pila<T>(uint size)
    {
        #region Atributos
        public uint Size { get; private set; } = size;
        public int top { get; private set; } = -1;
        private T[] Data = new T[size];
        #endregion

        #region Manejadores

        /// <summary>
        /// Verifica que el objeto de la pila se encuentre lleno
        /// </summary>
        /// <returns>booleano que indica si la pila se encuentra llena</returns>
        public bool PilaLlena()
        {
            return top == Size - 1;
        }
        /// <summary>
        /// Verifica que el objeto de la pila se encuentre vacio
        /// </summary>
        /// <returns>booleano que indica si la pila se encuentra vacia</returns>
        public bool PilaVacia()
        {
            return top == -1;
        }
        /// <summary>
        /// Reinicia los indices, deshaciendo cualquier dato almacenado en la pila
        /// </summary>
        public void LimpiarPila()
        {
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
            if (!PilaLlena())
            {
                Data[++top] = data;
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Retira un elemento de la pila
        /// </summary>
        /// <returns>el último elemento ingresado en la pila</returns>
        public T? Pop()
        {
            if (!PilaVacia())
            {
                return Data[top--];
            }
            else
            {
                return default;
            }
        }
    }
}
