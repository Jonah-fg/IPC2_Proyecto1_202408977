using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_1_IPC2.Modelos
{
    internal class ListaCeldas
    {
        public NodoCelda Cabeza;
        public ListaCeldas()
        {
            Cabeza=null;
        }

        public void Insertar(int fila, int columna)
        {
            NodoCelda nuevo=new NodoCelda(fila, columna);

            nuevo.Siguiente=Cabeza;
            Cabeza=nuevo;
        }

        public bool ContieneCelda(int fila,int columna)
        {
            NodoCelda actual=Cabeza;

            while (actual !=null)
            {
                if (actual.Fila ==fila &&actual.Columna==columna)
                {
                    return true;
                }
                actual=actual.Siguiente;
            }
            return false;
        }

        public int Contar()
        {
            int contador=0;

            NodoCelda actual =Cabeza;

            while (actual !=null)
            {
                contador++;
                actual=actual.Siguiente;
            }
            return contador;
        }
    }
}
