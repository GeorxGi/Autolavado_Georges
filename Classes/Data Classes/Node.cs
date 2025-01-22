namespace Proyecto_Autolavado_Georges
{
    public class Node<T>
    {
        public T Dato { get; private set; }
        public Node<T> NextNode { get; private set; }

        public Node(T dato)
        {
            Dato = dato;
            NextNode = null;
        }
        public void SetNextNode(Node<T> next)
        {
            this.NextNode = next;
        }
        public void SetDato(T dato)
        {
            this.Dato = dato;
        }
        public void ModificarDato(T dato)
        {
            this.Dato = dato;
        }
    }
}
