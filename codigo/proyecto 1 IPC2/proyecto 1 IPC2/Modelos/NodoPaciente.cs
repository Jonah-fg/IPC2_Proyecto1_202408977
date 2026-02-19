using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_1_IPC2.Modelos
{
    public class NodoPaciente
    {
        public Paciente Dato { get; set; }
        public NodoPaciente Siguiente { get; set; }

        public NodoPaciente(Paciente dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

}
