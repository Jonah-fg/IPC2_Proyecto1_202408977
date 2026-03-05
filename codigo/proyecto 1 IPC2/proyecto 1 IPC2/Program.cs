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
            ListaPacientes lista= new ListaPacientes();
            CargadorXML cargadorXML=new CargadorXML();
            GeneradorXML generadorXML=new GeneradorXML();
            GeneradorGraphviz generadorGraphviz=new GeneradorGraphviz();
            bool salir=false;

            while (!salir)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Cargar archivo XML");
                Console.WriteLine("2. Simular pacientes");
                Console.WriteLine("3. Generar XML de salida");
                Console.WriteLine("4. Generar Graphviz");
                Console.WriteLine("5. Limpiar memoria");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion=Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        lista = cargadorXML.Cargar("entrada.xml");
                        Console.WriteLine("Pacientes cargados correctamente.");
                        break;

                    case "2":
                        NodoPaciente actual = lista.Cabeza;

                        while (actual != null)
                        {
                            actual.Dato.Simulacion();
                            Console.WriteLine($"Paciente: {actual.Dato.Nombre}");
                            Console.WriteLine($"Resultado: {actual.Dato.Resultado}");
                            Console.WriteLine("---------------------------");

                            actual=actual.Siguiente;
                        }
                        break;

                    case "3":
                        generadorXML.Generar("salida.xml", lista);
                        Console.WriteLine("Archivo salida.xml generado correctamente.");
                        break;

                    case "4":
                        NodoPaciente nodo = lista.Cabeza;

                        while (nodo != null)
                        {
                            string nombreArchivo = "grafo_" + nodo.Dato.Nombre + ".dot";
                            generadorGraphviz.Generar(nombreArchivo, nodo.Dato.ListaEstados);
                            nodo = nodo.Siguiente;
                        }

                        Console.WriteLine("Archivos .dot generados correctamente.");
                        break;

                    case "5":
                        lista.Limpiar();
                        Console.WriteLine("Memoria limpiada.");
                        break;

                    case "6":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }

            Console.WriteLine("Programa finalizado.");
        }
    }
}
