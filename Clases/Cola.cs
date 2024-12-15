using Proyecto_Autolavado_Georges;

namespace Autolavado_GeorgesChakour.Clases
{
    public class Cola<T>(uint size) : Lista<T>
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
        public bool InsertarCola(T dato)
        {
            if (!ColaLlena())
            {
                Insertar(dato);
                Final++;
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
                T aux = PrimerElemento();
                if(Eliminar(aux))
                {
                Final--;
                }
                return aux;
            }
            return default;
        }

        public bool EliminarCola(T dato)
        {
            if (Eliminar(dato))
            {
                Final--;
                return true;
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
            //Para evitar tener que modificar código, al tener la misma funcionalidad, simplemente
            //llamo a esta funcion
            return ElementoEnLista(dato);
        }
        
        /// <summary>
        /// Indica si el elemento indicado se encuentra en el primer indice de la cola
        /// </summary>
        /// <param name="dato">Elemento a buscar</param>
        /// <returns>booleano que indica si el elemento ingresado es o no el primero</returns>
        public bool EsPrimerElemento(T dato)
        {
            return IComparable.Equals(dato, PrimerElemento());
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

        /// <summary>
        /// Crea una copia del objeto
        /// </summary>
        /// <returns>Copia de la cola</returns>
        public Cola<T> Copia()
        {
            return (Cola<T>)this.MemberwiseClone();
        }
    }
}
