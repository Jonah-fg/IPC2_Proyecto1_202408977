using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_1_IPC2.Modelos
{
    public class ListaEstado
    {
        public NodoEstado Cabeza { get; set; }
        public ListaEstado() 
        { 
            Cabeza = null;
        }

        public void agragar(String estado, int periodo)
        {
            NodoEstado nuevo=new NodoEstado(estado, periodo);

            if (Cabeza==null)
            {
                Cabeza=nuevo;
            }
            else
            {
                NodoEstado actual=Cabeza; 
                while (actual.Siguiente !=null)
                {
                    actual=actual.Siguiente;
                }

                actual.Siguiente=nuevo;
            }
        }

        public NodoEstado Buscar(string estado)
        {
            NodoEstado actual=Cabeza;

            while (actual!=null)
            {
                if (actual.Estado==estado)
                {
                    return actual;
                }
                actual=actual.Siguiente;
            }
            return null;
        }
    }
}
