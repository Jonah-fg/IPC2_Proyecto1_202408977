using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_1_IPC2.Modelos
{
    internal class NodoEstado
    {
        public String Estado { get; set; }
        public int Periodo { get; set; }
        public NodoEstado Siguiente { get; set; }
        public NodoEstado(String estado, int periodo) 
        { 
            Estado = estado;
            Periodo = periodo;
            Siguiente = null;

        }
    }
}
