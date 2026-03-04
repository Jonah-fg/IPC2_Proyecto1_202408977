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
            Nombre =nombre;
            Edad =edad;
            M =m;
            RejillaInicial=new Rejilla(m);
            PeriodosMax = periodos;
            
        }

        public void Simulacion() 
        {
            ListaEstado listaE =new ListaEstado();
            Rejilla actual=RejillaInicial;

            String estadoInicial=actual.ObtenerEstado();
            listaE.agragar(estadoInicial, 0); 

            for (int periodo=1;periodo<=PeriodosMax; periodo++)
            {
                Rejilla siguiente =actual.GenerarSiguienteRejilla();
                String estadoActual=siguiente.ObtenerEstado();
                NodoEstado encontrado=listaE.Buscar(estadoActual);

                if (encontrado!=null)
                {
                    int N=encontrado.Periodo;
                    int N1 =periodo-N;

                    if (N1==1)
                        Resultado ="Mortal";
                    else
                        Resultado ="Grave";
                    return;
                }
                listaE.agragar(estadoActual, periodo);
                actual=siguiente;
            }
            Resultado="Leve";
        }

    }
}
