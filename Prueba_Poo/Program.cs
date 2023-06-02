using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Poo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mat;
            int[] vect;
            int n = 10;
            int m = 8;
            Console.Write("Ingrese el numero de Filas: ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el numero de Columnas: ");
            m = int.Parse(Console.ReadLine());
            Console.Clear();
            mat = Mat(n, m);
            Console.WriteLine();
            Console.WriteLine("Matriz Genereda Tamaño {0}*{1}",n,m);
            Console.WriteLine();
            Mostar_Matriz(n, m, mat);
            vect = LLenar_Vector(n, m, mat);
            try
            {
                Console.WriteLine();
                Console.WriteLine();
               // Mostar_Vector(vect);
                Console.WriteLine();
                int[,] E = Espiral(n, m, vect);
                Console.WriteLine("Matriz Ordenada de la Forma Espiral o Caracol");
                Console.WriteLine();
                Mostar_Matriz(n, m, E);
            }
            catch(Exception ex)
            {
                
                Console.WriteLine("NO {0}",ex);
            }
            Console.ReadKey();
        }
        static int[,] Mat(int n,int m)
        {
            int[,] retorno = new int[n, m];
            Random ale = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    retorno[i, j] = ale.Next(0, 101);
                }
            }
            return retorno;
        }
        static void Mostar_Matriz(int n,int m,int [,] mat)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,5}", mat[i, j]);
                }
                Console.WriteLine();
            }
        }
        static int [] LLenar_Vector(int n,int m,int [,]matriz)
        {
            int[] retorno = new int [matriz.Length];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    retorno[k] = matriz[i, j];
                    k++;
                }
            }
            int pos = 0;
            int pos2 = 1;
            int aux = 0;
            for (pos = 0; pos < retorno.Length; pos++)
            {
                aux = retorno[pos];
                pos2 = pos - 1;
                while (pos2 >= 0 && retorno[pos2] > aux)
                {
                    retorno[pos2 + 1] = retorno[pos2];
                    pos2--;
                }
                retorno[pos2 + 1] = aux;
            }
            return retorno;
        }
        static void Mostar_Vector(int[] mat)
        {
            
                for (int j = 0; j < mat.Length; j++)
                {
                    Console.Write("{0,5}", mat[j]);
                }
        }
        static int [,] Espiral(int n,int m,int [] vect)
        {
            int[,] retorno = new int[n, m];
            int pos = 0;
            int f1 = 0;
            int f2 = 1;
            int c1 = n-f2;
            int c2 = m-f2;
            bool bandera = false;
            while (pos < retorno.Length&&bandera==false)
            {
                //Fila 0:n
                for (int i = f1; i < n-f1; i++)
                {
                    retorno[i, f1] = vect[pos];
                    pos++;
                    if (pos == (retorno.Length - 1))
                    {
                        bandera = true;
                        break;
                    }
                }
                //Columna 0:n
                pos--;
                for (int i = f1; i < m-f1; i++)
                {
                    retorno[c1, i] = vect[pos];
                    pos++;
                    if (pos == (retorno.Length - 1))
                    {
                        bandera = true;
                        break;
                    }
                }
                //Fila n:0
                pos--;
                for (int i = c1; i >= f1; i--)
                {
                    retorno[i, c2] = vect[pos];
                    pos++;
                    if (pos == (retorno.Length - 1))
                    {
                        bandera = true;
                        break;
                    }
                }
                //Columna m-1:1
                pos--;
                for (int i = c2; i >= f2; i--)
                {
                    retorno[f1, i] = vect[pos];
                    pos++;
                    if (pos == (retorno.Length - 1))
                    {
                        bandera = true;
                        break;
                    }
                }
                f1++;
                f2++;
                c1 = n - f2;
                c2 = m - f2;
            }
            return retorno;
        }
    }
}
