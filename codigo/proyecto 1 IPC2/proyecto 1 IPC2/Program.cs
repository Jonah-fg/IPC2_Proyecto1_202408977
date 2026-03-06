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
            GeneradorGraphviz generadorGraphviz = new GeneradorGraphviz();
            bool salir = false;

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
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        lista = cargadorXML.Cargar("entrada.xml");
                        Console.WriteLine("Pacientes cargados correctamente.");
                        break;

                    case "2":
                        if (lista.Cabeza == null)
                        {
                            Console.WriteLine("Primero cargue un archivo XML.");
                            break;
                        }
                        Console.WriteLine("Pacientes disponibles:");
                        lista.MostrarNombres();

                        Console.Write("Ingrese el nombre del paciente: ");
                        string nombre = Console.ReadLine();

                        Paciente paciente =lista.Buscar(nombre);

                        if (paciente == null)
                        {
                            Console.WriteLine("Paciente no encontrado.");
                        }
                        else
                        {
                            Console.WriteLine("1. Simulación automática");
                            Console.WriteLine("2. Simulación paso a paso");
                            Console.Write("Seleccione opción: ");
                            string tipo = Console.ReadLine();

                            if (tipo == "1")
                            {
                                paciente.Simulacion();
                                paciente.Simulacion();
                                Console.WriteLine($"\n RESULTADO COMPLETO:");
                                Console.WriteLine($"   Resultado: {paciente.Resultado}");
                                Console.WriteLine($"   N (período donde apareció el patrón): {paciente.N}");
                                Console.WriteLine($"   N1 (cada cuánto se repite): {paciente.N1}");

                                if (paciente.N1 == 1)
                                    Console.WriteLine("   Enfermedad MORTAL (se repite cada período)");
                                else if (paciente.N1>1)
                                    Console.WriteLine("   Enfermedad GRAVE");
                                else
                                    Console.WriteLine("   Enfermedad LEVE");
                            }
                            else if (tipo == "2")
                            {
                                SimulacionPasoAPaso(paciente);
                            }
                        }
                        break;

                    case "3":
                        generadorXML.Generar("salida.xml", lista);
                        Console.WriteLine("Archivo salida.xml generado correctamente.");
                        break;

                    case "4":
                        if (lista.Cabeza==null)
                        {
                            Console.WriteLine("Primero cargue y simule pacientes.");
                            break;
                        }
                        Console.WriteLine("\nPacientes disponibles:");
                        lista.MostrarNombres();

                        Console.Write("\nIngrese el nombre del paciente: ");
                        string nombrePaciente=Console.ReadLine();

                        Paciente pacienteSeleccionado=lista.Buscar(nombrePaciente);
                        if (pacienteSeleccionado==null)
                        {
                            Console.WriteLine("Paciente no encontrado.");
                        }
                        else if (pacienteSeleccionado.ListaEstados==null)
                        {
                            Console.WriteLine("Primero debe simular este paciente (opción 2).");
                        }
                        else
                        {
                            generadorGraphviz.GenerarImagenesRejilla(pacienteSeleccionado);
                        }
                        break;


                    case "5":
                        lista.Limpiar();
                        Console.WriteLine("Memoria limpiada.");
                        break;

                    case "6":
                        salir=true;
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }


            static void SimulacionPasoAPaso(Paciente paciente)
            {
                Rejilla actual = paciente.RejillaInicial;

                for (int periodo = 0; periodo <= paciente.PeriodosMax; periodo++)
                {
                    Console.Clear();
                    Console.WriteLine($"Paciente: {paciente.Nombre}");
                    Console.WriteLine($"Período: {periodo}");

                    MostrarRejilla(actual);

                    int contagiadas =actual.ContarContagiadas();
                    int sanas =paciente.M * paciente.M - contagiadas;

                    Console.WriteLine($"Contagiadas: {contagiadas}");
                    Console.WriteLine($"Sanas: {sanas}");

                    Console.WriteLine("Presione ENTER para siguiente período...");
                    Console.ReadLine();

                    actual=actual.GenerarSiguienteRejilla();
                }
            }

            static void MostrarRejilla(Rejilla rejilla)
            {
                for (int i=0;i<rejilla.M; i++)
                {
                    for (int j=0; j<rejilla.M; j++)
                    {
                        if (rejilla.Celdas.ContieneCelda(i,j) )
                            Console.Write("0 ");
                        else
                            Console.Write("1 ");
                    }
                    Console.WriteLine();
                }
            }
    }

}
