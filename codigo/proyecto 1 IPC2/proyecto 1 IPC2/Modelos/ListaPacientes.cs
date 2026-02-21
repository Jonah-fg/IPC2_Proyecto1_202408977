using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_1_IPC2.Modelos
{
    internal class ListaPacientes
    {
        private NodoPaciente Cabeza; 

        public ListaPacientes()
        {
            Cabeza =null;
        }

        public void Insertar(Paciente paciente)
        {
            NodoPaciente nuevo=new NodoPaciente(paciente);

            if (Cabeza== null)
            {
                Cabeza=nuevo;
            }
            else
            {
                NodoPaciente actual=Cabeza;

                while (actual.Siguiente != null)
                {
                    actual =actual.Siguiente;
                }
                actual.Siguiente=nuevo;
            }
        }

        public Paciente Buscar(string nombre)
        {
            NodoPaciente actual=Cabeza;

            while (actual!=null)
            {
                if (actual.Dato.Nombre==nombre)
                {
                    return actual.Dato;
                }

                actual=actual.Siguiente;
            }

            return null;
        }

        public void Mostrar()
        {
            NodoPaciente actual = Cabeza;

            while (actual != null)
            {
                Console.WriteLine("Paciente: "+ actual.Dato.Nombre);
                actual = actual.Siguiente;
            }
        }

        public void Limpiar()
        {
            Cabeza = null;
        }
    }
}
