namespace Proyecto_Autolavado_Georges.Clases.DataClasses
{
    public class CustomQueue<T>(uint size) : CustomLinkedList<T>
    {
        #region Atributos
        public uint Size { get; private set; } = size;
        private int Final = -1;
        #endregion

        /// <summary>
        /// Inserta un elemento en la cola
        /// </summary>
        /// <param name="dato">Elemento a ingresar en la cola</param>
        /// <returns>booleano que indica si se pudo ingresar (false si la cola está llena)</returns>
        public bool Insert(T dato)
        {
            if (!IsFull())
            {
                AddLast(dato);
                Final++;
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Retira un elemento de la lista, si se encuentra vacia, no retorna nada
        /// </summary>
        /// <returns>retorna el elemento en la primera posición de la cola</returns>
        public T? Retire()
        {
            if (!IsEmpty())
            {
                T aux = GetFirstElement();
                if(Delete(aux))
                {
                Final--;
                }
                return aux;
            }
            return default;
        }

        public bool DeleteQueue(T dato)
        {
            if (Delete(dato))
            {
                Final--;
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// Indica si el elemento indicado se encuentra en el primer indice de la cola
        /// </summary>
        /// <param name="dato">Elemento a buscar</param>
        /// <returns>booleano que indica si el elemento ingresado es o no el primero</returns>
        public bool IsFirstElement(T dato)
        {
            return Equals(dato, GetFirstElement());
        }

        /// <summary>
        /// Indica si la cola se encuentra llena
        /// </summary>
        /// <returns>booleano que indica si la cola no puede contener más elementos</returns>
        public bool IsFull()
        {
            return Final == Size - 1;
        }
        /// <summary>
        /// Indica la cantidad de elementos que hay en la cola
        /// </summary>
        /// <returns>cantidad de elementos que hay en la cola</returns>
        public int GetCount()
        {
            return Final + 1;
        }

        /// <summary>
        /// Elimina todos los elementos de la cola
        /// </summary>
        public void CleanQueue()
        {
            CleanList();
            Final = -1;
        }

        /// <summary>
        /// Crea una copia del objeto
        /// </summary>
        /// <returns>Copia de la cola</returns>
        public CustomQueue<T> Copy()
        {
            return (CustomQueue<T>)MemberwiseClone();
        }
    }
}
