using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_1_IPC2.Modelos
{
    internal class GeneradorGraphviz
    {
        public void Generar(string ruta, ListaEstado lista)
        {
            StreamWriter writer = new StreamWriter(ruta);

            writer.WriteLine("digraph Estados {");

            NodoEstado actual = lista.Cabeza;

            // 🔹 Primero escribir todos los nodos
            while (actual != null)
            {
                writer.WriteLine($"   \"{actual.Estado}\";");
                actual = actual.Siguiente;
            }

            // 🔹 Luego escribir las transiciones
            actual = lista.Cabeza;

            while (actual != null && actual.Siguiente != null)
            {
                writer.WriteLine($"   \"{actual.Estado}\" -> \"{actual.Siguiente.Estado}\";");
                actual = actual.Siguiente;
            }

            writer.WriteLine("}");
            writer.Close();
        }
    }
}

