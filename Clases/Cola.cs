namespace Autolavado_GeorgesChakour.Clases
{
    public class Cola<T>(uint size)
    {
        #region Atributos
        private uint Size = size;
        private int Final = -1;
        private T[] Datos = new T[size];
        #endregion

        /// <summary>
        /// Inserta un elemento en la cola
        /// </summary>
        /// <param name="dato">Elemento a ingresar en la cola</param>
        /// <returns>booleano que indica si se pudo ingresar (false si la cola está llena)</returns>
        public bool Insertar(T dato)
        {
            if (!ColaLlena())
            {
                Datos[++Final] = dato;
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Retira un elemento de la lista, si se encuentra vacia, no retorna nada
        /// </summary>
        /// <returns>retorna el elemento en la primera posición de la cola</returns>
        public T? Retirar()
        {
            if (!ColaVacia())
            {
                T aux = Datos[0];
                for(uint i = 0; i < Final; i++)
                {
                    Datos[i] = Datos[i+1];
                }
                Final--;
                return aux;
            }
            return default;
        }

        /// <summary>
        /// Recibe un elemento y si este se encuentra en la cola, es eliminado
        /// </summary>
        /// <param name="dato">Elemento a eliminar</param>
        /// <returns>Booleano que indica si se encontró y eliminó el elemento</returns>
        public bool Eliminar(T dato)
        {
            if (!ColaVacia())
            {
                int indice = -1;
                for(int i = 0; i < Final + 1; i++)
                {
                    if (EqualityComparer<T>.Default.Equals(Datos[i], dato))
                    {
                        indice = i;
                        break;
                    }
                }
                if(indice != -1)
                {
                    if (indice == 0)
                    {
                        Retirar();
                        return true;
                    }
                    else
                    {
                        for (int i = indice; i < Final - 1; i++)
                        {
                            Datos[i] = Datos[i + 1];
                        }
                        Final--;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Recibe un elemento e indica si este se encuentra o no en la cola
        /// </summary>
        /// <param name="dato">Elemento a buscar en la cola</param>
        /// <returns>booleano que indica si el elemento se encuentra o no en la cola</returns>
        public bool Find(T dato)
        {
            for (uint i = 0; i <= Final; i++)
            {
                if (EqualityComparer<T>.Default.Equals(Datos[i], dato)) return true;
            }
            return false;
        }
        /// <summary>
        /// Recibe el objeto a buscar en la cola
        /// </summary>
        /// <param name="dato">elemento a buscar en la cola</param>
        /// <returns>indice en el que se encuentra el objeto indicado, si no se encuentra, retorna -1</returns>
        public int FindIndex(T dato)
        {
            for (int i = 0; i <= Final; i++)
            {
                if (EqualityComparer<T>.Default.Equals(Datos[i], dato)) return i;
            }
            return -1;
        }
        /// <summary>
        /// Indica si la cola se encuentra vacia
        /// </summary>
        /// <returns>booleano que indica si la cola no contiene elementos</returns>
        public bool ColaVacia()
        {
            return Final == -1;
        }
        /// <summary>
        /// Indica si la cola se encuentra llena
        /// </summary>
        /// <returns>booleano que indica si la cola no puede contener más elementos</returns>
        public bool ColaLlena()
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
    }
}
