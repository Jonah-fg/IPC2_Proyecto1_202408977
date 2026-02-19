using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_1_IPC2.Modelos
{
    public class Paciente
    {
        public String Nombre { get; set; }
        public int Edad {get; set;}
        public int M { get; set; }
        public int PeriodosMax { get; set; }
        public string Resultado { get; set; }
        public int[,] RejillaInicial { get; set; }
        public int N { get; set; }
        public int N1 { get; set; }

        public Paciente(string nombre, int edad, int m, int periodos)
        {
            Nombre = nombre;
            Edad = edad;
            M = m;
            RejillaInicial = new int[m, m];
            PeriodosMax = periodos;
            
        }
    }
}
