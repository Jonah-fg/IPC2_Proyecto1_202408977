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
        public Rejilla RejillaInicial { get; set; }
        public int N { get; set; }
        public int N1 { get; set; }

        public Paciente(string nombre, int edad, int m, int periodos)
        {
            Nombre = nombre;
            Edad = edad;
            M = m;
            RejillaInicial = new Rejilla(m);
            PeriodosMax = periodos;
            
        }

        public void Simulacion() 
        {
            Rejilla actual = RejillaInicial;

            for (int periodo = 1; periodo<= PeriodosMax; periodo++)
            {
                Rejilla siguiente = actual.GenerarSiguienteRejilla();

                // Si todas murieron
                if (siguiente.ContarContagiadas() == 0)
                {
                    Resultado = "Mortal";
                    return;
                }
                actual = siguiente;
            }
            Resultado = "Grave";
        }
    }
}
