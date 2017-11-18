using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Interfaces;

namespace TrabajoPractico.Entities
{
    public class Matriz : Individual
    {
        public int Size { get; set; }
        private int[][] matrix { get; set; }

        public void Swap(int i, int j)
        {
            if(i >= Size || j >= Size)
            {
                throw new Exception("La fila o columna no debe ser menor a " + Size);
            }

            for (int k = 0; k < Size; k++)
            {
                var temp = matrix[k][i];
                matrix[k][i] = matrix[k][j];
                matrix[k][j] = temp;
            }

            var temp2 = matrix[i];
            matrix[i] = matrix[j];
            matrix[j] = temp2;

        }

        public Matriz(int[][] matriz)
        {
            matrix = matriz;
            Size = matrix.Length;
        }

        public override string ToString()
        {
            var str = "";
            var stringArray = new string[Size];

            for (int i = 0; i < Size; i++)
            {
                stringArray[i] = ToSubString(matrix[i]);
            }

            str = string.Join("\n", stringArray);

            return str;
        }

        private string ToSubString(int[] row)
        {
            var str = "";
            str = string.Join(", ", row);

            return str;
        }

        public int Evaluate()
        {
            int score = 0;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if(j >= i)
                    {
                        score += matrix[i][j];
                    }
                }
            }

            return score;
        }
    }
}
