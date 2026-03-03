using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace proyecto_1_IPC2.Modelos
{
    internal class LectorXML
    {
        public void Cargar(string ruta, ListaPacientes lista)
        {
            XmlDocument doc=new XmlDocument();
            doc.Load(ruta);

            XmlNodeList pacientes=doc.GetElementsByTagName("paciente");

            foreach(XmlNode pacienteNode in pacientes)
            {
                string nombre=pacienteNode["datospersonales"]["nombre"].InnerText;
                int edad=int.Parse(pacienteNode["datospersonales"]["edad"].InnerText);
                int periodos= int.Parse(pacienteNode["periodos"].InnerText);
                int m=int.Parse(pacienteNode["m"].InnerText);

                Paciente paciente=new Paciente(nombre, edad, m, periodos);

                XmlNodeList celdas=pacienteNode["rejilla"].GetElementsByTagName("celda");

                foreach (XmlNode celda in celdas)
                {
                    int fila=int.Parse(celda.Attributes["f"].Value)-1;
                    int columna=int.Parse(celda.Attributes["c"].Value)-1;

                    paciente.RejillaInicial.Celdas[fila, columna] = 1;
                }

                lista.Insertar(paciente);
            }
        }
    
      }
}
