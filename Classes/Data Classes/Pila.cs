using Proyecto_Autolavado_Georges;

namespace Autolavado_GeorgesChakour.Clases
{
    class Pila<T>(uint size) : Lista<T>
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
                Insertar(data);
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
            if (!PilaVacia())
            {
                T aux = UltimoElemento();
                Eliminar(aux);
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
