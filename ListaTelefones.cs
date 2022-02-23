namespace AgendaLista
{
    internal class ListaTelefones
    {
        public Telefone Head { get; set; }
        public Telefone Tail { get; set; }

        public ListaTelefones()
        {
            Head = Tail = null;
        }

        public void Push(Telefone aux)
        {
            if (Vazia())
            {
                Head = Tail = aux;
            }
            else
            {
                Tail.Proximo = aux;
                Tail = aux;
            }
        }

        public bool Vazia()
        {
            if ((Head == null) && (Tail == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
