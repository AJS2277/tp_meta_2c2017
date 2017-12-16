using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Entities
{
    public class LOInput
    {
        public string Name { get; set; }
        public LOCategory Category { get; set; }
        public int MaxOptimum { get; set; }
        public int MinOptimum { get; set; }

        public LOInput(string name, LOCategory cat, int minOpt, int maxOpt)
        {
            Name = name;
            Category = cat;
            MaxOptimum = maxOpt;
            MinOptimum = minOpt;
        }

        public Matriz GetMatriz()
        {
            string text = System.IO.File.ReadAllText(@Category.Path);
            string[] values = text.Split(' ');
            int matrizCount = int.Parse(values[0]);

            if(Math.Sqrt(values.Length - 1) != matrizCount)
            {
                throw new Exception("Tamaño de matriz inconsistente");
            }

            var matrix = new int[matrizCount][];

            for (int i = 0; i < matrizCount; i++)
            {
                matrix[i] = new int[matrizCount];

                for (int j = 0; j < matrizCount; j++)
                {

                }
            }

            var matriz = new Matriz(matrix);

            return matriz;
        }
    }
}
