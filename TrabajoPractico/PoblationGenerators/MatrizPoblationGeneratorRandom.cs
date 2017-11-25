using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using TrabajoPractico.Interfaces;
using TrabajoPractico.Utils.Object;

namespace TrabajoPractico.PoblationGenerators
{
    public class MatrizPoblationGeneratorRandom : PoblationGenerator
    {
        
        public MatrizPoblationGeneratorRandom(Matriz matriz, int size) : base(matriz, size)
        {
        }

        public override void Generate()
        {
            Matriz originalAsMatriz = (Matriz)Original;
            var poblation = new List<Individual>();

            for (int i = 0; i < Size; i++)
            {
                Matriz individual = FactoryObject.DeepCopy(originalAsMatriz);
                Tuple<int, int> move = originalAsMatriz.GetRandomCoordinate();
                individual.Swap(move);
                poblation.Add(individual);
            }
            
            Poblation = poblation;
        }
    }
}
