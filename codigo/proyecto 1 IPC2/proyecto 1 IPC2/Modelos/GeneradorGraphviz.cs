using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_1_IPC2.Modelos
{
    internal class GeneradorGraphviz
    {
        public void GenerarImagenesRejilla(Paciente paciente)
        {
            if (paciente.ListaEstados==null ||paciente.ListaEstados.Cabeza == null)
                return;

            string carpetaDestino=AppDomain.CurrentDomain.BaseDirectory;

            NodoEstado actual= paciente.ListaEstados.Cabeza;
            int contador=0;

            Console.WriteLine($"\n Generando archivos en: {carpetaDestino}");

            while (actual!=null)
            {
                Rejilla rejilla=ReconstruirRejilla(actual.Estado,paciente.M);

                string nombreArchivo= $"{paciente.Nombre}_Periodo_{actual.Periodo}.dot";
                string rutaCompleta= Path.Combine(carpetaDestino, nombreArchivo);

                GenerarArchivoDot(rejilla, actual.Periodo, paciente.Nombre, rutaCompleta);

                actual = actual.Siguiente;
                contador++;
            }
            Console.WriteLine($" Se generaron {contador} archivs .dot para {paciente.Nombre}");
            Console.WriteLine($" Los archivos están e: {carpetaDestino}");

            Console.WriteLine("\n Generando PNG...");
            GenerarImagenesPNG(carpetaDestino, paciente.Nombre);
        }

        private Rejilla ReconstruirRejilla(string estado, int m)
        {
            Rejilla rejilla=new Rejilla(m);

            for (int i = 0; i<m; i++)
            {
                for (int j=0; j<m; j++)
                {
                    int posicion=i * m + j;
                    if (posicion<estado.Length && estado[posicion] == '1')
                    {
                        rejilla.Celdas.Insertar(i, j);
                    }
                }
            }

            return rejilla;
        }

        private void GenerarArchivoDot(Rejilla rejilla,int periodo, string nombrePaciente, string rutaArchivo)
        {
            using (StreamWriter writer=new StreamWriter(rutaArchivo))
            {
                writer.WriteLine("digraph G {");
                writer.WriteLine("node [shape=plaintext];");
                writer.WriteLine("rankdir=TB;");

                writer.WriteLine($"labelloc=\"t\";");
                writer.WriteLine($"label=\"Paciente: {nombrePaciente}-Período {periodo}\";");
                writer.WriteLine("fontsize=16;");
                writer.WriteLine("tabla [label=<");
                writer.WriteLine("<TABLE BORDER=\"0\" CELLBORDER=\"1\" CELLSPACING=\"0\" CELLPADDING=\"8\">");

                for (int i = 0; i < rejilla.M; i++)
                {
                    writer.WriteLine("<TR>");
                    for (int j=0; j<rejilla.M; j++)
                    {
                        string color =rejilla.Celdas.ContieneCelda(i, j)? "red":"white";
                        string texto=rejilla.Celdas.ContieneCelda(i, j)? "1":"0";

                        writer.WriteLine($"<TD BGCOLOR=\"{color}\" BORDER=\"1\">{texto}</TD>");
                    }
                    writer.WriteLine("</TR>");
                }
                writer.WriteLine("</TABLE>>];");
                writer.WriteLine("}");
            }
        }


        public void GenerarImagenesPNG(string carpetaOrigen, string nombrePaciente)
        {
            string[] archivosDot=Directory.GetFiles(carpetaOrigen, $"{nombrePaciente}_Periodo_*.dot");

            if (archivosDot.Length==0)
            {
                Console.WriteLine("No hay archivos .dot para convertir.");
                return;
            }
            Console.WriteLine($"\nConvirtiendo {archivosDot.Length} archivos a PNG...");
            Console.WriteLine("(Esto puede tomar unos segundos)");

            string archivoBatch=Path.Combine(carpetaOrigen, "convertir.bat");

            using (StreamWriter writer=new StreamWriter(archivoBatch))
            {
                foreach (string archivoDot in archivosDot)
                {
                    string nombreArchivo =Path.GetFileNameWithoutExtension(archivoDot);
                    string archivoPNG=Path.Combine(carpetaOrigen, nombreArchivo + ".png");

                    writer.WriteLine($"dot -Tpng \"{archivoDot}\" -o \"{archivoPNG}\"");
                }
            }

            System.Diagnostics.Process.Start("cmd.exe", $"/c \"{archivoBatch}\"");

            Console.WriteLine($"\nProceso inicado. Los PNG se guardarn en:");
            Console.WriteLine($"   {carpetaOrigen}");
        }
    }
}
        
