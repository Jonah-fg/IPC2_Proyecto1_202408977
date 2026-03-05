using System;
using System.Xml;

namespace proyecto_1_IPC2.Modelos
{
    public class CargadorXML
    {
        internal ListaPacientes Cargar(string ruta)
        {
            ListaPacientes lista = new ListaPacientes();

            XmlDocument doc = new XmlDocument();
            doc.Load(ruta);

            XmlNodeList pacientes = doc.GetElementsByTagName("paciente");

            foreach (XmlNode pacienteNode in pacientes)
            {
                // 📌 Datos personales
                string nombre = pacienteNode["datospersonales"]["nombre"].InnerText;
                int edad = int.Parse(pacienteNode["datospersonales"]["edad"].InnerText);
                int periodos = int.Parse(pacienteNode["periodos"].InnerText);
                int m = int.Parse(pacienteNode["m"].InnerText);

                // 📌 Crear paciente
                Paciente paciente = new Paciente(nombre, edad, m, periodos);

                // 📌 Llenar rejilla con celdas enfermas
                XmlNode rejillaNode = pacienteNode["rejilla"];

                if (rejillaNode != null)
                {
                    XmlNodeList celdas = rejillaNode.SelectNodes("celda");

                    foreach (XmlNode celda in celdas)
                    {
                        int f = int.Parse(celda.Attributes["f"].Value);
                        int c = int.Parse(celda.Attributes["c"].Value);

                        // ⚠️ Restamos 1 porque el XML empieza en 1 y la matriz en 0
                        paciente.RejillaInicial.Celdas[f - 1, c - 1] = 1;
                    }
                }

                // 📌 Insertar en lista enlazada
                lista.Insertar(paciente);
            }

            return lista;
        }
    }
}