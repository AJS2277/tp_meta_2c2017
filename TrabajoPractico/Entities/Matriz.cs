using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Interfaces;
using TrabajoPractico.Utils.Object;

namespace TrabajoPractico.Entities
{
    [Serializable]
    public class Matriz : Individual
    {
        public int Size { get; set; }
        private int[][] matrix { get; set; }
        public int[][] Original { get; set; }
        public List<Tuple<int, int>> Moves { get; set; } = new List<Tuple<int, int>>();
        public int Fitness { get; set; }

        public void Swap(Tuple<int, int> move)
        {
            var i = move.Item1;
            var j = move.Item2;

            if (i >= Size || j >= Size)
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

            Moves.Add(move);
            Evaluate();

        }

        public Matriz(int[][] matriz)
        {
            matrix = FactoryObject.DeepCopy(matriz);
            Size = matrix.Length;
            Evaluate();
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

        public virtual void Evaluate()
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

            Fitness = score;
        }

        public void Rebuild()
        {
            var movesToDo = FactoryObject.DeepCopy(Moves);

            foreach (var move in movesToDo)
            {
                Swap(move);
            }

            Evaluate();
        }

        private Random randomSelecter = new Random();
        public List<Tuple<int, int>> GetRandomCoordinates(int size)
        {
            List<Tuple<int, int>> coordinates = GenerateRandomCoordinates().Take(size).ToList();

            return coordinates;
        }

        private List<Tuple<int, int>> GenerateRandomCoordinates()
        {
            var coordinates = new List<Tuple<int, int>>();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    coordinates.Add(new Tuple<int, int>(i, j));
                }
            }

            return coordinates.OrderBy(x => randomSelecter.Next()).ToList();
        }

        public int GetRandomPosition()
        {
            var random = new Random();
            var position = random.Next(0, Moves.Count);

            return position;
        }
    }
}
