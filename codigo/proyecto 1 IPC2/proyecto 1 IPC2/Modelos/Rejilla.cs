using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_1_IPC2.Modelos
{
    public class Rejilla
    {
        public int[,] Celdas{ get; set; }
        public int M { get; set; }

        public Rejilla(int m)
        {
            M = m;
            Celdas = new int[m, m];
        }

        public int ContarVecinos(int fila, int columna) 
        {
            int contador =0;

            for (int i=fila-1;i<=fila +1; i++)
            {
                for (int j=columna-1; j<=columna+1; j++)
                {
                    if (i >= 0 && i < M && j>=0 && j< M)
                    {
                        // No contar la celda misma
                        if (!(i==fila && j==columna))
                        {
                            if (Celdas[i, j]==1)
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
            Rejilla nueva = new Rejilla(M);
            for (int i=0; i<M; i++)
            {
                for (int j=0; j<M; j++)
                {
                    int vecinosVivos = ContarVecinos(i, j);
                    if (Celdas[i,j] ==1) // Celda viva
                    {
                        if (vecinosVivos ==2 ||vecinosVivos ==3)
                        {
                            nueva.Celdas[i, j]=0; // Muere
                        }
                        else
                        {
                            nueva.Celdas[i, j]=1; // Permanece viva
                        }
                    }

                    else // Celda muerta
                    {
                        if (vecinosVivos == 3)
                        {
                            nueva.Celdas[i, j] =1; // Nace
                        }
                        else
                        {
                            nueva.Celdas[i, j]=0; // Permanece muerta
                        }
                    }
                }
            }
            return nueva;
        }

        public int ContarContagiadas()
        {
            int contador=0;
            for (int i = 0; i<M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (Celdas[i, j]==1)
                    {
                        contador++;
                    }
                }
            }

            return contador;
        }

        public string ObtenerEstado()
        {
            string estado = "";
            for (int i=0; i <M;i++)
            {
                for (int j =0; j<M;j++)
                {
                    estado += Celdas[i,j];
                }
            }

            return estado;
        }

    }
}
