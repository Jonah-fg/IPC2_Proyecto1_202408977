using proyecto_1_IPC2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_1_IPC2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaPacientes lista = new ListaPacientes();
            LectorXML lector = new LectorXML();

            lector.Cargar("entrada.xml", lista);

            lista.RecorrerYSimular();

            lista.Mostrar();
        }
    }
}
