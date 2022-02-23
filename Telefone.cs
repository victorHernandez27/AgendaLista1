using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaLista
{
    internal class Telefone
    {
        public string Tipo { get; set; }
        public int DDD { get; set; }
        public string Numero { get; set; }
        public Telefone Proximo { get; set; }

        public Telefone(string tipo, int dDD, string numero)
        {
            Tipo = tipo;
            DDD = dDD;
            Numero = numero;
            Proximo = null;
        }

        public override string ToString()
        {
            return Tipo +"("+DDD+")" + Numero;
        }
    }    
}
