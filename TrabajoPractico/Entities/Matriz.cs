using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Interfaces;
using TrabajoPractico.Utils.Object;

namespace TrabajoPractico.Entities
{
    public class Matriz : Individual
    {
        public int Size { get; set; }
        private int[][] matrix { get; set; }
        public int[][] Original { get; set; }
        public List<Tuple<int, int>> Moves { get; set; } = new List<Tuple<int, int>>();

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

            Moves.Add(new Tuple<int, int>(i, j));

        }

        public Matriz(int[][] matriz)
        {
            matrix = FactoryObject.DeepCopy(matriz);
            Size = matrix.Length;

            Original = matriz;
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

        public void Mutate()
        {
            var random = new Random();
            var position = random.Next(0, Moves.Count);
            var randomI = new Random();
            var randomJ = new Random();
            var i = randomI.Next(0, Size);
            var j = randomJ.Next(0, Size);

            Moves.RemoveAt(position);
            Moves.Insert(position, new Tuple<int, int>(i, j));

            Rebuild();
        }

        private void Rebuild()
        {
            matrix = FactoryObject.DeepCopy(Original);

            foreach (var move in Moves)
            {
                Swap(move.Item1, move.Item2);
            }
        }
    }
}
