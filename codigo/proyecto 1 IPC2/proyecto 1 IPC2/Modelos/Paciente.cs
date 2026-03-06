using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_1_IPC2.Modelos
{
    internal class Paciente
    {
        public String Nombre { get; set; }
        public int Edad {get; set;}
        public int M { get; set; }
        public int PeriodosMax { get; set; }
        public string Resultado { get; set; }
        public Rejilla RejillaInicial { get; set; }
        public ListaEstado ListaEstados { get; set; }
        public int N { get; set; }
        public int N1 { get; set; }

        public Paciente(string nombre, int edad, int m, int periodos)
        {
            Nombre =nombre;
            Edad =edad;
            M =m;
            RejillaInicial=new Rejilla(m);
            PeriodosMax = periodos;
            Resultado="";
            N=0;
            N1=0;
        }

        public void Simulacion() 
        {
            ListaEstados=new ListaEstado();
            Rejilla actual=RejillaInicial;
            bool patronEncontrado = false;

            String estadoInicial=actual.ObtenerEstado();
            ListaEstados.agragar(estadoInicial, 0); 

            for (int periodo=1;periodo<=PeriodosMax; periodo++)
            {
                Rejilla siguiente =actual.GenerarSiguienteRejilla();
                String estadoActual=siguiente.ObtenerEstado();
                NodoEstado encontrado=ListaEstados.Buscar(estadoActual);

                if (encontrado!=null &&!patronEncontrado)
                {                    N =encontrado.Periodo;
                    N1 =periodo-N;

                    if (N1==1)
                        Resultado ="Mortal";
                    else
                        Resultado ="Grave";
                    patronEncontrado=true;
                }
                ListaEstados.agragar(estadoActual, periodo);
                actual=siguiente;
            }
            if (!patronEncontrado)
                Resultado ="Leve";
        }

    }
}
