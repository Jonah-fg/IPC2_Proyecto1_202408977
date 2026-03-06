using System;
using System.Xml;

namespace proyecto_1_IPC2.Modelos
{
    public class CargadorXML
    {
        internal ListaPacientes Cargar(string ruta)
        {
            ListaPacientes lista=new ListaPacientes();

            XmlDocument doc = new XmlDocument();
            doc.Load(ruta);

            XmlNodeList pacientes=doc.GetElementsByTagName("paciente");

            foreach (XmlNode pacienteNode in pacientes)
            {
                string nombre =pacienteNode["datospersonales"]["nombre"].InnerText;
                int edad=int.Parse(pacienteNode["datospersonales"]["edad"].InnerText);
                int periodos=int.Parse(pacienteNode["periodos"].InnerText);
                int m=int.Parse(pacienteNode["m"].InnerText);

                Paciente paciente=new Paciente(nombre, edad, m, periodos);

                XmlNode rejillaNode=pacienteNode["rejilla"];
                if (rejillaNode!=null)
                {
                    XmlNodeList celdas=rejillaNode.SelectNodes("celda");
                    foreach (XmlNode celda in celdas)
                    {
                        int f=int.Parse(celda.Attributes["f"].Value)-1;
                        int c=int.Parse(celda.Attributes["c"].Value)-1;

                        paciente.RejillaInicial.Celdas.Insertar(f, c);
                    }
                }
                lista.Insertar(paciente);
            }
            return lista;
        }
    }
}