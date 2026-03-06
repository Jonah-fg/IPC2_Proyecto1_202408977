using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_1_IPC2.Modelos
{
    internal class NodoCelda
    {
        public int Fila;
        public int Columna;
        public NodoCelda Siguiente;
        public NodoCelda(int fila, int columna)
        {
            Fila =fila;
            Columna=columna;
            Siguiente =null;
        }
    }
}
