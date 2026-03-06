using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace proyecto_1_IPC2.Modelos
{
    internal class GeneradorXML
    {
        public void Generar(string ruta, ListaPacientes lista)
        {
            XmlDocument doc=new XmlDocument();
            XmlElement raiz= doc.CreateElement("pacientes");
            doc.AppendChild(raiz);

            NodoPaciente actual=lista.Cabeza;
            while (actual!= null)
            {
                Paciente paciente=actual.Dato;
                XmlElement pacienteXml= doc.CreateElement("paciente");
                XmlElement datos=doc.CreateElement("datospersonales");

                XmlElement nombre=doc.CreateElement("nombre");
                nombre.InnerText=paciente.Nombre;

                XmlElement edad=doc.CreateElement("edad");
                edad.InnerText=paciente.Edad.ToString();

                datos.AppendChild(nombre);
                datos.AppendChild(edad);
                pacienteXml.AppendChild(datos);

                XmlElement periodos=doc.CreateElement("periodos");
                periodos.InnerText= paciente.PeriodosMax.ToString();

                XmlElement m=doc.CreateElement("m");
                m.InnerText=paciente.M.ToString();

                XmlElement resultado =doc.CreateElement("resultado");
                resultado.InnerText =paciente.Resultado.ToLower();

                pacienteXml.AppendChild(periodos);
                pacienteXml.AppendChild(m);
                pacienteXml.AppendChild(resultado);
                if (paciente.Resultado !="leve")
                {
                    XmlElement n=doc.CreateElement("n");
                    n.InnerText =paciente.N.ToString();
                    pacienteXml.AppendChild(n);

                    XmlElement n1=doc.CreateElement("n1");
                    n1.InnerText=paciente.N1.ToString();
                    pacienteXml.AppendChild(n1);
                }
                raiz.AppendChild(pacienteXml);
                actual=actual.Siguiente;
            }
            doc.Save(ruta);
        }
    }
}
