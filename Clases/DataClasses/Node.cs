namespace Proyecto_Autolavado_Georges.Clases.DataClasses
{
    public class Node<T>
    {
        public T Element { get; private set; }
        public Node<T> NextNode { get; private set; }

        public Node(T value)
        {
            Element = value;
            NextNode = null;
        }
        public void SetNextNode(Node<T> next)
        {
            NextNode = next;
        }
        public void SetDato(T dato)
        {
            Element = dato;
        }
        public void ModificarDato(T dato)
        {
            Element = dato;
        }
    }
}
