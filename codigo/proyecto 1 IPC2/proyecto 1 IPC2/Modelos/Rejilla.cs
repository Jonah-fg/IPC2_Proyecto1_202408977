using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_1_IPC2.Modelos
{
    internal class Rejilla
    {
        public int M;
        public ListaCeldas Celdas;

        public Rejilla(int m)
        {
            M = m;
            Celdas = new ListaCeldas();
        }

        public int ContarVecinos(int fila, int columna)
        {
            int contador=0;
            for (int i =fila - 1; i<=fila + 1; i++)
            {
                for (int j=columna-1; j<=columna+1; j++)
                {
                    if (i>=0 && i<M && j>=0 && j<M)
                    {
                        if (!(i == fila&&j==columna))
                        {
                            if (Celdas.ContieneCelda(i, j))
                            {
                                contador++;
                            }
                        }
                    }
                }
            }
            return contador;
        }

        public Rejilla GenerarSiguienteRejilla()
        {
            Rejilla nueva =new Rejilla(M);

            for (int i=0; i<M; i++)
            {
                for (int j=0; j<M; j++)
                {
                    bool viva=Celdas.ContieneCelda(i, j);
                    int vecinos=ContarVecinos(i, j);
                    if (viva)
                    {
                        if (vecinos==2 || vecinos== 3)
                        {
                            nueva.Celdas.Insertar(i, j);
                        }
                    }
                    else
                    {
                        if (vecinos==3)
                        {
                            nueva.Celdas.Insertar(i, j);
                        }
                    }
                }
            }
            return nueva;
        }

        public int ContarContagiadas()
        {
            return Celdas.Contar();
        }

        public int ContarSanas()
        {
            int total= M*M;
            return total-ContarContagiadas();
        }

        public string ObtenerEstado()
        {
            string estado="";
            for (int i=0; i < M; i++)
            {
                for (int j= 0; j<M; j++)
                {
                    if (Celdas.ContieneCelda(i, j))
                    {
                        estado+="1";
                    }
                    else
                    {
                        estado+="0";
                    }
                }
            }
            return estado;
        }








        public void DepurarRejilla(string titulo)
        {
            Console.WriteLine($"\n=== {titulo} ===");
            Console.WriteLine($"Tamaño M: {M}");
            Console.WriteLine("Estado visual (■ contagiada, □ sana):");

            for (int i = 0; i < M; i++)
            {
                string filaVisual = "";
                string filaBinaria = "";

                for (int j = 0; j < M; j++)
                {
                    bool contagiada = Celdas.ContieneCelda(i, j);
                    filaVisual += contagiada ? "■ " : "□ ";
                    filaBinaria += contagiada ? "1" : "0";
                }

                Console.WriteLine($"Fila {i:00}: {filaVisual} | {filaBinaria}");
            }

            Console.WriteLine($"Total contagiadas: {ContarContagiadas()}");
            Console.WriteLine($"Estado completo: {ObtenerEstado()}");
            Console.WriteLine($"Longitud estado: {ObtenerEstado().Length} (debe ser {M * M})");
        }
    }
}


           